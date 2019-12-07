const puppeteer = require('puppeteer');

(async () => {
    const browser  = await puppeteer.launch();
    //console.log(await browser.version());
    const page = await browser.newPage();
    await page.goto('https://sistemas.tjes.jus.br/ediario/index.php/pesquisa');

    await page.focus('[name="jform[palavra_chave]"]');
    await page.keyboard.type('edital');
    await page.keyboard.press('Enter');
    await page.waitFor(7000);

    console.log(await page.title());

    // const result = await page.evaluate(body => {
    //     return document.querySelector('body');
        
    //     //console.log(element);
    // });

    const htmlElement = await page.$('#e-search-right > div.item');
    //console.log(htmlElement);
    const html = await page.evaluate(element => {
        //element.forEach(item => console.log(item));
        let itens = [];
        [].forEach.call(element, item => itens.push(item));
        return itens;
    }, htmlElement);

    console.log(html);
    //await page.screenshot({ path: 'pesquisa.png' });
    await browser.close();
})();