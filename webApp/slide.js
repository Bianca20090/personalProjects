const firebase = require("firebase");
require("firebase/database");
const fs = require('fs');
const { resolve } = require('path');

// Import the functions you need from the SDKs you need
const { initializeApp } = require("firebase/app");

// Your web app's Firebase configuration
const firebaseConfig = {
  apiKey: "AIzaSyAsUUmj-UxOTh6phvTQQo9btmD48UdvJaI",
  authDomain: "autoadvicedb.firebaseapp.com",
  databaseURL: "https://autoadvicedb-default-rtdb.firebaseio.com",
  projectId: "autoadvicedb",
  storageBucket: "autoadvicedb.appspot.com",
  messagingSenderId: "293295777219",
  appId: "1:293295777219:web:4a9eee9af17bca84f24976"
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);

class PopulateJsonDatabase {
  constructor() {
    console.time("Time taken");
    this.db = firebase.database();
  }

  async loadDataFromJson(filePath) {
    try {
      const rawData = fs.readFileSync(filePath);
      const jsonData = JSON.parse(rawData);
      return jsonData;
    } catch (error) {
      console.error("Error reading JSON file:", error);
      return null;
    }
  }

  formatData(data) {
    const formattedData = {};
    for (const [carName, carDetails] of Object.entries(data)) {
      const [specs] = carDetails;
      const [cutieDeViteze, nrPersoane, nrBagaje] = specs.specs;
      formattedData[carName] = {
        Denumire: carName,
        Imagine: specs.imagine,
        CutieDeViteze: cutieDeViteze,
        NrPersoane: nrPersoane,
        NrBagaje: nrBagaje
      };
    }
    return formattedData;
  }

  async saveDataToFirebase(data) {
    try {
      const formattedData = this.formatData(data);
      await this.db.ref('anunturi').set(formattedData);
      console.log("Data successfully saved to Firebase!");
    } catch (error) {
      console.error("Error saving data to Firebase:", error);
    }
  }
}

// Funcție principală pentru a încapsula codul asincron
async function main() {
  // Instantiation and data processing
  const populator = new PopulateJsonDatabase();
  const jsonData = await populator.loadDataFromJson('dataEnterprise.json');
  if (jsonData) {
    await populator.saveDataToFirebase(jsonData);
  }

  console.timeEnd("Time taken");
}

main();
