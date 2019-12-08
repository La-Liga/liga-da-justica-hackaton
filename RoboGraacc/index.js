const cron = require('node-cron');

const robots = {
    tjes: require('./robots/tjes.js'),
}

function start() {
    robots.tjes();
}

cron.schedule('* * * * *', () => {
    start();
});



