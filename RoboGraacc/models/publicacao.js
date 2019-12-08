const mongoose = require('mongoose');

const publicacaoSchema = new mongoose.Schema({
    titulo: String,
    link: String,
    textoHtml: String,
    texto: String,
    dataPublicacao: String,
    numeroProcesso: String
});

const Publicacao = mongoose.model('Publicacao', publicacaoSchema);

module.exports = Publicacao;
