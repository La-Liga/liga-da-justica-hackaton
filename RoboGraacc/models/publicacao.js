const mongoose = require('mongoose');

const publicacaoSchema = new mongoose.Schema({
    titulo: String,
    link: String,
    resumo: String,
    texto: String,
    dataDisponibilizacao: Date
});

const Publicacao = mongoose.model('Publicacao', publicacaoSchema);

module.exports = Publicacao;
