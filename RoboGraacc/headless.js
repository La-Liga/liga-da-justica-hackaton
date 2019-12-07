const readlineSync = require('readline-sync');
const puppeteer = require('puppeteer');
const servico = require('./servicos/publicacao.service');

const palavraChave = readlineSync.question('Qual a palavra chave? ');

(async () => {
    const browser  = await puppeteer.launch();
    const page = await browser.newPage();
    await page.goto('https://sistemas.tjes.jus.br/ediario/index.php/pesquisa');

    //Seta a palavra chave
    await page.focus('[name="jform[palavra_chave]"]');
    await page.keyboard.type(palavraChave);

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

    //Obter foto da tela
    //await page.screenshot({ path: 'pesquisa.png' });

    //console.log(await page.title());

    // const html = await page.evaluate(() => {
    //     const elements =  Array.from(document.querySelectorAll('#e-search-right > div.item'));
    //     return elements.map(item => item.innerHTML);
    // });

    const html = await page.evaluate(() => {
        let result = [];
        const pat = /\d{2}\-\d{2}\-\d{4}/g;

        const elements =  document.querySelectorAll('#e-search-right > div.item');
        elements.forEach(item => {
            let element = item.querySelector('div.item-desc');
            let date = pat.exec(element.innerHTML);
            result.push({
                titulo: element.querySelector('a.e-search-title > b').innerText,
                link: element.querySelector('a.e-search-title').getAttribute('href'),
                texto: element.innerHTML,
                dataPublicacao: (date) ? date[0] : ''
            })
        });

        return result;
    });


    // const html = await page.evaluate(() => {
    //     let result = [];
    //     //const elements =
    //     document.querySelectorAll('#e-search-right > div.item').forEach(item => {
    //         result.push(item.querySelector('div.item-numero').innerHTML);
    //     });

    //     return result;
    //     //return elements.map(item => item);
    // });

    // const bodyHandle = await page.$('#e-search-right');
    // const html = await page.evaluate(body => {
    //     let i = [];
    //     async () => {
    //         await body.$$eval('div.item', (desc) => {
    //            i.push(desc.innerHTML);
    //         });
    //     }

    //     return i;
    // }, bodyHandle);

    // // const html = await page.evaluate(() => {
    // //     const element =  document.querySelector('#e-search-right');
    // //     return elements.map(item => item);
    // //     let result = [];
    // //     const feedHandle = await page.$('#e-search-right');
    // //     let result = elements.$$eval('div.item', (nodes) => nodes.map((n) => {
    // //         //n.innerText
    // //         //let tweetHandle = await n.$eval('.item-numero');
    // //          result.push(n.innerHTML)
    // //          return n.innerHTML;
    // //     }));

    // //     return result;
    // // });

    await browser.close();

    console.log(html);

    // await servico.criarPublicacao({
    //     titulo: 'titulo',
    //     link: 'link',
    //     resumo: 'resumo',
    //     texto: html[0],
    //     dataDisponibilizacao: new Date
    // });

    html.forEach( async(item) => {
        await servico.criarPublicacao(item)
        //console.log(item.innerHTML)
    });

})();
