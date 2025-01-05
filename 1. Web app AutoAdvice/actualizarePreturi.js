const cron = require('node-cron');
const { spawn } = require('child_process');

// Definim cron job-ul care sa ruleze in fiecare miercuri la ora 0:20
cron.schedule('0 20 * * 3', () => {
    console.log('Running fuel prices scraping job...');

    const scrapeProcess = spawn('node', ['preturi.js']);

    scrapeProcess.on('close', (code) => {
        console.log('Fuel prices scraping job finished with code:', code);
    });
}, {
    timezone: 'Europe/Bucharest' // Specificam fusul orar
});
