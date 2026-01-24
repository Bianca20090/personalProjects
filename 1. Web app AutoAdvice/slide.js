const firebase = require("firebase");
require("firebase/database");
const fs = require('fs');
const { resolve } = require('path');


const { initializeApp } = require("firebase/app");


const firebaseConfig = {
  apiKey: "***",
  authDomain: "***.firebaseapp.com",
  databaseURL: "https://***.firebaseio.com",
  projectId: "autoadvicedb",
  storageBucket: "autoadvicedb.appspot.com",
  messagingSenderId: "***",
  appId: "***"
};


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


async function main() {

  const populator = new PopulateJsonDatabase();
  const jsonData = await populator.loadDataFromJson('dataEnterprise.json');
  if (jsonData) {
    await populator.saveDataToFirebase(jsonData);
  }

  console.timeEnd("Time taken");
}

main();

