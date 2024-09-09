const axios = require('axios');
const cheerio = require('cheerio');
const fs = require('fs');
const admin = require('firebase-admin');

// Calea către fișierul JSON cu cheile de autentificare descărcat din Consola Firebase
const serviceAccount = require("./autoadvicedb-firebase-adminsdk-i2p0c-fa0929f43b.json");

// Inițializare Firebase Admin SDK
admin.initializeApp({
  credential: admin.credential.cert(serviceAccount),
  databaseURL: "https://autoadvicedb-default-rtdb.firebaseio.com" // URL-ul bazei de date
});

const db = admin.database();
const { v4: uuidv4 } = require('uuid');

// URL-urile paginilor de unde facem scraping-ul
const urls = [
  'https://masininisam.com/consumul/volkswagen/jetta.html',
  'https://masininisam.com/consumul/volkswagen/atlas.html',
  'https://masininisam.com/consumul/volkswagen/passat.html',
  'https://masininisam.com/consumul/volkswagen/polo.html',
  'https://masininisam.com/consumul/ford/mustang.html',
  'https://masininisam.com/consumul/skoda/octavia.html',
  'https://masininisam.com/consumul/fiat/tipo.html',
  'https://masininisam.com/consumul/fiat/panda.html',
  'https://masininisam.com/consumul/jeep/wrangler.html',
  'https://masininisam.com/consumul/jeep/commander.html',
  'https://masininisam.com/consumul/chevrolet/tahoe.html',
  'https://masininisam.com/consumul/chevrolet/colorado.html',
  'https://masininisam.com/consumul/toyota/corolla.html',
  'https://masininisam.com/consumul/toyota/prius.html',
  'https://masininisam.com/consumul/toyota/sienna.html',
  'https://masininisam.com/consumul/hyundai/i20.html',
  'https://masininisam.com/consumul/ford/f-150.html',
  'https://masininisam.com/consumul/ford/edge.html',
  'https://masininisam.com/consumul/ford/fusion.html',
  'https://masininisam.com/consumul/ford/mondeo.html',
  'https://masininisam.com/consumul/ford/focus.html',
  'https://masininisam.com/consumul/dacia/duster.html',
  'https://masininisam.com/consumul/dacia/lodgy.html',
  'https://masininisam.com/consumul/dacia/logan.html',
  'https://masininisam.com/consumul/dacia/sandero.html',
  'https://masininisam.com/consumul/audi/q5.html',
  'https://masininisam.com/consumul/audi/a3.html',
  'https://masininisam.com/consumul/audi/a4.html',
  'https://masininisam.com/consumul/audi/a8.html',
  'https://masininisam.com/consumul/audi/a5.html',
  'https://masininisam.com/consumul/bmw/5-series.html',
  'https://masininisam.com/consumul/bmw/2-series.html',
  'https://masininisam.com/consumul/bmw/x3.html',
  'https://masininisam.com/consumul/skoda/vision.html',
  'https://masininisam.com/consumul/hyundai/celesta.html'
];

const sanitizeKey = (key) => {
  return key.replace(/[.#$/[\]]/g, '_');
};

const isValidKey = (key) => {
  return key && !/[.#$/[\]]/.test(key);
};

const scrapeData = async (url) => {
  try {
    const response = await axios.get(url);
    const html = response.data;
    const $ = cheerio.load(html);

    // Extragem marca și modelul din URL
    const marca = sanitizeKey(url.split('/').slice(-2, -1)[0].charAt(0).toUpperCase() + url.split('/').slice(-2, -1)[0].slice(1));
    const model = sanitizeKey(url.split('/').pop().split('.')[0].charAt(0).toUpperCase() + url.split('/').pop().split('.')[0].slice(1));

    // Obiect pentru a stoca datele extrase
    const data = {};

    // Parcurgem fiecare rand cu clasa "row fff some_name title title2"
    $('tr.row.fff.some_name.title.title2').each((index, element) => {
      // Gasim randurile urmatoare care conțin datele
      $(element).nextUntil('tr.row.fff.some_name.title.title2').each((i, el) => {
        if ($(el).hasClass('row') && $(el).hasClass('fff')) {
          const mod = sanitizeKey($(el).find('td.cell.mod').text().trim());
          if (!isValidKey(mod)) return; 

          const fuelType = $(el).find('td.cell').eq(1).text().trim();
          const urbanConsumption = $(el).find('td.cell').eq(2).text().trim();
          const highwayConsumption = $(el).find('td.cell').eq(3).text().trim();
          const mixedConsumption = $(el).find('td.cell').eq(4).text().trim();

          // Construim obiectul cu datele extrase
          data[mod] = {
            fuelType,
            urbanConsumption,
            highwayConsumption,
            mixedConsumption
          };
        }
      });
    });

    return { marca, model, data };
  } catch (error) {
    console.error(`Error scraping ${url}:`, error);
    return null;
  }
};

const scrapeAllData = async () => {
  let allData = {};

  for (const url of urls) {
    const result = await scrapeData(url);
    if (result) {
      const { marca, model, data } = result;

      if (!allData[marca]) {
        allData[marca] = {};
      }

      allData[marca][model] = data;
    }
  }

  
  for (const marca in allData) {
    db.ref(`consumCarburant/${marca}`).set(allData[marca]);
  }

  console.log('Data has been saved to Firebase and consumul_de_carburant.json');
};

// Apelam funcția de scraping pentru toate URL-urile
scrapeAllData();