const fs = require('fs');
const axios = require('axios');
const cheerio = require('cheerio');
const { v4: uuidv4 } = require('uuid'); // Importăm funcția uuidv4 pentru generarea de ID-uri unice
const url = require('url');

const urls = [
  'https://www.enterprise.com/en/car-rental/vehicles/us/cars.html',
  'https://www.enterprise.com/en/car-rental/vehicles/us/suvs.html',
  'https://www.enterprise.com/en/car-rental/vehicles/us/trucks.html',
  'https://www.enterprise.com/en/car-rental/vehicles/us/vans.html',
  'https://www.enterprise.com/en/car-rental/vehicles/us/luxury-cars.html',
  'https://www.enterprise.com/en/car-rental/vehicles/us/awd-4x4.html'
];

const dataLinks = {};

async function getHTML(url) {
  const { data: html } = await axios.get(url);
  return html;
}

async function scrapeEnterpriseData(url) {
  const html = await getHTML(url);
  const $ = cheerio.load(html);

  $('.vehicle-class-card').each((i, vehicle) => {
    let denumire = $(vehicle).find('.vehicle-class-card__description').text().trim();
    // Eliminăm "or similar" din denumire folosind replace
    denumire = denumire.replace(/or similar/g, '').trim();
    const linkDetaliiPath = $(vehicle).find('.vehicle-class-card__title-link').attr('href'); // Obține doar calea către linkul detalii
    const linkDetalii = 'https://www.enterprise.com/' + linkDetaliiPath; // Concatenează URL-ul de bază cu calea către linkul detalii manual
    const imagineLink = $(vehicle).find('.vehicle-class-card__image').attr('src');
    const specs = $(vehicle).find('.vehicle-class-card__specs-list .vehicle-class-card__specs-item').map((i, spec) => $(spec).text().trim()).get();

    const id = uuidv4(); 

    if (!dataLinks[id]) {
      dataLinks[id] = {
        denumire: denumire,
        linkDetalii: linkDetalii,
        specs: specs,
        imagine: imagineLink
      };
    }
  });
}

async function scrapeAllData() {
  for (const url of urls) {
    await scrapeEnterpriseData(url);
  }

  // Scriem datele în fișierul JSON după ce s-au terminat toate operațiile de scrap
  fs.writeFile('dataEnterprise.json', JSON.stringify({ anunturi: dataLinks }, null, 2), (err) => {
    if (err) throw err;
    console.log('Datele au fost preluate și adăugate în fișierul JSON cu succes!');

    const admin = require('firebase-admin');

    // Calea către fișierul JSON cu cheile de autentificare descărcat din Consola Firebase
    const serviceAccount = require("./autoadvicedb-firebase-adminsdk-i2p0c-fa0929f43b.json");

    // Inițializare Firebase Admin SDK
    admin.initializeApp({
      credential: admin.credential.cert(serviceAccount),
      databaseURL: "https://autoadvicedb-default-rtdb.firebaseio.com" // URL-ul bazei de date
    });

    const db = admin.database();

    const dataLinkss = require('./dataEnterprise.json');
    // Parcurgem obiectul dataLinks pentru a extrage și a adăuga datele în baza de date Firebase
    for (const id in dataLinks) {
      const vehicle = dataLinks[id];
      
      const denumire = vehicle.denumire;
      const linkDetalii = vehicle.linkDetalii;
      const imagine = vehicle.imagine;
      const specs = vehicle.specs;
    
      // Extragem specificațiile individuale
      const cutieDeViteze = specs[0];
      const numarPersoane = specs[1];
      const nrBagaje = specs[2];
    
      // Verificăm dacă linkDetalii există
      if (linkDetalii) {
        // Setăm datele în Realtime Database
        db.ref('anunturi/' + id).set({
          denumire: denumire,
          linkDetalii: linkDetalii,
          imagine: imagine,
          specs: {
            cutieDeViteze: cutieDeViteze,
            numarPersoane: numarPersoane,
            nrBagaje: nrBagaje
          }
        })
        .then(() => {
          console.log('Datele au fost adăugate cu succes în Realtime Database!');
        })
        .catch((error) => {
          console.error('Eroare la adăugarea datelor în Realtime Database:', error);
        });
      } else {
        console.log(`Anunțul cu ID-ul ${id} nu are un link de detalii definit.`);
      }
    }
  });
}

scrapeAllData();
