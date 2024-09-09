const cron = require('node-cron');
const { exec } = require('child_process');

cron.schedule('31 11 * * 1', () => {
    console.log('Rularea scripturilor a început...');

    exec('node s_telcar.js', (error, stdout, stderr) => {
        if (error) {
            console.error(`Eroare în timpul rulării scriptului in.js: ${error}`);
            return;
        }
        console.log(`Output in.js: ${stdout}`);
        console.error(`Eroare in.js: ${stderr}`);
    });

    exec('node scrap.js', (error, stdout, stderr) => {
        if (error) {
            console.error(`Eroare în timpul rulării scriptului scrap.js: ${error}`);
            return;
        }
        console.log(`Output scrap.js: ${stdout}`);
        console.error(`Eroare scrap.js: ${stderr}`);
    });
}, {
    scheduled: true,
    timezone: "Europe/Bucharest" // Setează fusul orar corespunzător
});