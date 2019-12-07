const rp = require('request-promise');
const cheerio = require('cheerio');

const options = {
    uri: 'http://globoesporte.globo.com/futebol/brasileirao-serie-a/',
    transform: function (body) {
        return cheerio.load(body)
    }
}

rp(options)
.then(($) => {
  $('.classificacao__tabela--linha').each((i, item) => {
      console.log(item);
    console.log($(item).find('.classificacao__equipes--nome').text())
  })
})
.catch((err) => {
  console.log(err);
})