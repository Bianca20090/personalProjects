const admin = require('firebase-admin');

// Calea către fișierul JSON cu cheile de autentificare descărcat din Consola Firebase
const serviceAccount = require("./autoadvicedb-firebase-adminsdk-i2p0c-fa0929f43b.json");

// Inițializare Firebase Admin SDK
admin.initializeApp({
  credential: admin.credential.cert(serviceAccount),
  databaseURL: "https://autoadvicedb-default-rtdb.firebaseio.com" // URL-ul bazei de date
});

const db = admin.database();
const anunturiRef = db.ref('anunturi');
const anunturiDetaliiRef = db.ref('anunturiDetalii');
const anunturiCombinatRef = db.ref('anunturiCombinat');

// Funcția pentru combinarea datelor
async function combinaDate() {
  try {
    // Citire anunturi
    const anunturiSnapshot = await anunturiRef.once('value');
    const anunturi = anunturiSnapshot.val();

    // Citire anunturiDetalii
    const anunturiDetaliiSnapshot = await anunturiDetaliiRef.once('value');
    const anunturiDetalii = anunturiDetaliiSnapshot.val();

    // Iterare prin fiecare anunț și combinarea datelor
    for (const anuntId in anunturi) {
      const anunt = anunturi[anuntId];

      for (const detaliiId in anunturiDetalii) {
        const detalii = anunturiDetalii[detaliiId];

        if (anunt.denumire === detalii.denumire) {
          const anuntCombinat = { ...anunt, ...detalii };

          // Salvare în noua colecție
          await anunturiCombinatRef.child(anuntId).set(anuntCombinat);
          break;
        }
      }
    }

    console.log('Datele au fost combinate și salvate cu succes.');
  } catch (error) {
    console.error('Eroare la combinarea datelor:', error);
  }
}

// Apelăm funcția pentru a combina datele
combinaDate();
