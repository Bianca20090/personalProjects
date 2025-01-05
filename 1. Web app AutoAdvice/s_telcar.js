const fs = require('fs');
const axios = require('axios');
const cheerio = require('cheerio');
const { v4: uuidv4 } = require('uuid');
const admin = require('firebase-admin');

// Calea către fișierul JSON cu cheile de autentificare descărcat din Consola Firebase
const serviceAccount = require("./autoadvicedb-firebase-adminsdk-i2p0c-fa0929f43b.json");

// Inițializare Firebase Admin SDK
admin.initializeApp({
  credential: admin.credential.cert(serviceAccount),
  databaseURL: "https://autoadvicedb-default-rtdb.firebaseio.com" // URL-ul bazei de date
});

const db = admin.database();

const urls = [
    'https://telcar.ro/masini/',
    'https://telcar.ro/masini/page/2/',
    'https://telcar.ro/masini/page/3/',
    'https://telcar.ro/masini/page/4/',
    'https://telcar.ro/masini/page/5/'
];

const dataLinks = {};

async function getHTML(url) {
  const { data: html } = await axios.get(url);
  return html;
}

async function scrapeHertzData(url) {
  try {
      const html = await getHTML(url);
      const $ = cheerio.load(html);

      $('.page.type-page.status-publish.hentry').each((i, vehicle) => {
          const denumire = $(vehicle).find('.om-container .om-container__inner h4.inline a').text().trim();
          const linkDetalii = $(vehicle).find('.om-container .om-container__inner h4.inline a').attr('href');
          console.log("Denumire:", denumire);
          console.log("Link Detalii:", linkDetalii);

          const imagineLink = $(vehicle).find('.spcarimages .carimage1 img').attr('src');
          const transmisie = $(vehicle).find('.sinfocol.carinfo .key:contains("Transmisie")').next('.value').text().trim();
          const nrLocuri = $(vehicle).find('.sinfocol.carinfo .key:contains("Nr. locuri")').next('.value').text().trim();
          const nrBagaje = $(vehicle).find('.sinfocol.carinfo .key:contains("Bagaje")').next('.value').text().trim();

          const id = uuidv4();

          if (!dataLinks[id]) {
              dataLinks[id] = {
                  denumire: denumire,
                  linkDetalii: linkDetalii,
                  specs: {
                      transmisie: transmisie,
                      nrLocuri: nrLocuri,
                      nrBagaje: nrBagaje
                  },
                  imagine: imagineLink
              };

              // Adăugare date în baza de date Firebase
              db.ref('anunturi/' + id).set({
                denumire: denumire,
                linkDetalii: linkDetalii,
                imagine: imagineLink,
                specs: {
                  cutieDeViteze: transmisie,
                  numarPersoane: nrLocuri,
                  nrBagaje: nrBagaje
                }
              })
              .then(() => {
                console.log('Datele au fost adăugate cu succes în baza de date Firebase!');
              })
              .catch((error) => {
                console.error('Eroare la adăugarea datelor în baza de date Firebase:', error);
              });
          }
      });

      console.log("Datele de la Telcar au fost preluate cu succes!");
  } catch (error) {
      console.error("Eroare în timpul preluării datelor :", error);
  }
}

async function scrapeAllData() {
    for (const url of urls) {
        await scrapeHertzData(url);
    }

    // Scriem datele în fișierul JSON după ce s-au terminat toate operațiile de scrap
    fs.writeFile('data.json', JSON.stringify({ anunturi: dataLinks }, null, 2), (err) => {
        if (err) throw err;
        console.log('Datele au fost preluate și adăugate în fișierul JSON cu succes!');
    });
}

scrapeAllData();