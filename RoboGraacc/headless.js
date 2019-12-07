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

    const html = await page.evaluate(element => {
        const elements =  Array.from(document.querySelectorAll('#e-search-right > div.item'));
        return elements.map(item => item.innerHTML.replace(/<a [^>]+>[^<]*<\/a>/g, '').trim());
    });

    console.log(html);
    //await page.screenshot({ path: 'pesquisa.png' });
    await browser.close();
})();