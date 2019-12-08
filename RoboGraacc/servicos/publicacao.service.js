const mongoose = require('mongoose');
const credentials = require('../config/credentials.json').MongoBD;
const Publicacao = require('../models/publicacao');

const connectionString = credentials.url;

mongoose.connect(connectionString, {
    useNewUrlParser: true,
    useUnifiedTopology: true
});

const db = mongoose.connection;

db.on('error', console.error.bind(console, 'connection error:'));
db.once('open', function() {
    console.log('Connected');
});

const criarPublicacao = async (item) => {
    try {
        let publicacao = new Publicacao(item);
        await publicacao.save(item);
    } catch (error) {
        console.log(error);
    }
};

module.exports = {
    criarPublicacao
}
