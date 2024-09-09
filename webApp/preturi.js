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

const fetchData = async () => {
  const result = await axios.get('https://www.cargopedia.net/europe-fuel-prices');
  return cheerio.load(result.data);
};

const updateFirebase = async (data, date) => {
  const ref = db.ref('preturiCombustibil');

  // Verifică dacă data există deja
  const snapshot = await ref.once('value');
  const dataExists = snapshot.hasChild(date);

  if (!dataExists) {
    const updates = {};
    updates[date] = data;
    await ref.update(updates);
    console.log(`Data added for ${date}`);
  } else {
    console.log(`Data for ${date} already exists`);
  }
};

const scrapeAndSave = async () => {
  const $ = await fetchData();

  // Extrage data din elementul <h6>
  const rawDate = $('h6').text().trim();

  const data = {};
  $('table.table tbody tr').each((index, element) => {
    const country = $(element).find('td.tara').text().trim();
    const gasolinePrice = $(element).find('td').eq(1).text().trim();
    const dieselPrice = $(element).find('td').eq(2).text().trim();
    const lpgPrice = $(element).find('td').eq(3).text().trim() || 'N/A';

    if (country) {
      data[country] = {
        gasolinePrice: gasolinePrice || 'N/A',
        dieselPrice: dieselPrice || 'N/A',
        atPrice: lpgPrice
      };
    }
  });

  await updateFirebase(data, rawDate);
};

scrapeAndSave()
  .then(() => console.log('Scraping and saving completed'))
  .catch((error) => console.error('Error:', error));
