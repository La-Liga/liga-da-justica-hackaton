const puppeteer = require('puppeteer');
const htmlToText = require('html-to-text');
const servico = require('../servicos/publicacao.service');

const urlBase = 'https://sistemas.tjes.jus.br/ediario';
const linkPublicacaoBase = urlBase + '/index.php';

const removeQuebraLinhaTab = texto => {
    return texto.replace(/(\r\n|\n|\r|\t)/gm, '');
}

const enviarPublicacoes = async (publicacoes) => {
    publicacoes.forEach(async (item) => {
        await servico.criarPublicacao({
            ...item,
            link: linkPublicacaoBase + '/' + item.linkParcial,
            texto: removeQuebraLinhaTab(htmlToText.fromString(item.textoHtml, { wordwrap: 130 })),
        })
    });
}

const robot = async () => {
    const browser  = await puppeteer.launch();
    const page = await browser.newPage();
    await page.goto(urlBase + '/index.php/pesquisa');

    //Seta a palavra chave
    await page.focus('[name="jform[palavra_chave]"]');
    await page.keyboard.type('pena pecuniaria');

    //Seta a categoria edital
    await page.focus('[name="jform[categorias]"]');
    await page.select('[name="jform[categorias]"]', '36');

    //Seleciona a opção de Período: Outro período
    await page.focus('[name="jform[searchDay]"]');
    await page.$eval('#jform_searchDay > #jform_searchDay3', elem => elem.click());

    //Seta a data início
    await page.focus('[name="jform[date1]"]');
    await page.$eval('[name="jform[date1]"]', elem => elem.value = '01-01-2019');

    //Seta a data fim
    await page.focus('[name="jform[date2]"]');
    await page.$eval('[name="jform[date2]"]', elem => elem.value = '31-12-2019');

    await page.keyboard.press('Enter');
    await page.waitFor(10000);

    const publicacoes = await page.evaluate(() => {
        let result = [];
        const pat = /\d{2}\-\d{2}\-\d{4}/g;
        const processoRegex = /\d{7}\-\d{2}\.\d{4}\.\d{1,}\.\d{2}\.\d{4}/igm;//0001728-03.2016.8.08.0007

        const elements =  document.querySelectorAll('#e-search-right > div.item');
        elements.forEach(item => {
            let element = item.querySelector('div.item-desc');
            let date = pat.exec(element.innerHTML);
            let numeroProcesso = processoRegex.exec(element.innerHTML);

            result.push({
                titulo: element.querySelector('a.e-search-title > b').innerText,
                linkParcial: element.querySelector('a.e-search-title').getAttribute('href'),
                textoHtml: element.innerHTML,
                dataPublicacao: (date) ? date[0] : '',
                numeroProcesso: (numeroProcesso) ? numeroProcesso[0] : ''
            })
        });

        return result;
    });

    await browser.close();

    await enviarPublicacoes(publicacoes);
};

module.exports = robot;
