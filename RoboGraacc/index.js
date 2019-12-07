// const mongoose = require('mongoose');
// const credentials = require('./config/credentials.json').MongoBD;
// //const Publicacao = require('./models/publicacao');

// const pass = credentials.pass;
// const user = credentials.user;
// const connectionString = `mongodb://${user}:${pass}@ds253348.mlab.com:53348/hackaton_graacc`;

// mongoose.connect(connectionString, {
//     useNewUrlParser: true,
//     useUnifiedTopology: true
// });

// const db = mongoose.connection;

// db.on('error', console.error.bind(console, 'connection error:'));
// db.once('open', function() {
//     console.log('Connected');
//});

// const publicacao = new Publicacao({
//     titulo: 'titulo',
//     link: 'link',
//     resumo: 'resumo',
//     texto: 'texto',
//     dataDisponibilizacao: new Date
// });

// console.log(publicacao);

// publicacao.save(function (err, publicacao) {
//     if (err) return console.error(err);
// });



