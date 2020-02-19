**HACKATHON GRAAC**
========================================================================

# Inspiration
Potencializar as doações para o GRAACC, e para isso, uma das fontes possíveis, é através das Penas Pecuniárias, uma medida alternativa à prisão, que pune crimes de menor potencial ofensivo com o pagamento em dinheiro. Onde apenas as entidades públicas ou privadas com fim social e conveniadas ou de caráter essencial à segurança pública, educação e saúde recebem a verba.

# What it does
A ferramenta monitorará e gerenciará a publicação de editais e sentenças, listando-os por período de publicação e notificando o GRAACC. Através de uma lista, a instituição conseguirá ter acesso a alguns editais, onde poderá favoritar e acompanhar internamente até o dia do julgamento ou decisão do juiz, com isso, tendo acesso hábil ao recurso.

# How we built it
Criamos a ferramenta usando o Visual Studio, MongoDB e Nodejs. Um robô monitora os sites dos tribunais e varas penais, registrando no mongodb todas as publicações referentes a editais e sentenças, uma vez registrado no mongodb, são listados na aplicação web. Um usuário autenticado no sistema web, classifica tais publicações como Edital ou Sentença (que passarão a serem monitorados em outra lista), acrescenta uma etiqueta para acompanhamento, de acordo com o trâmite interno e uma data para ser notificado. Na nova lista, o Edital ou Sentença poderá ser favoritado, facilitando a localização e o monitoramento.

# Challenges we ran into
Nosso maior desafio foi extrair as informações que precisávamos do html. Por não existir um padrão na estrutura dos sites dos tribunais, abordamos um, no qual os processos estão impressos no html, mas isso não se torna uma limitação. Sofremos um pouquinho nos testes e na instalação das dependências, por causa da instabilidade da internet e limitações do tráfego na rede. Também tivemos alguns problemas nas integrações das plataformas, por não termos tantas experiências nas que escolhemos, em função da limitação dos gastos.

# Accomplishments that we're proud of
Estamos realmente orgulhosos de todas as pesquisas e informações que colhemos, e no quanto essa ferramenta poderá ajudar ao GRAACC que precisa tanto de doações. Não imaginávamos que a partir desse hackathon, conseguiríamos desenvolver uma ideia que pudesse trazer mais doações, de uma fonte desconhecida por nós e talvez, por boa parte da sociedade. Estamos muito orgulhosos da nossa ferramenta e do seu potencial!

# What we learned
Aprendemos que quando queremos ajudar, conseguimos transpor diversos obstáculos. Conseguimos integrar diferentes plataformas, que passarão a trabalhar coordenadamente para um bem comum. A partir dessa abordagem na arrecadação de doações, com as penas pecuniárias, acabamos conhecendo mais um pouco da legislação brasileira, que torna isso possível.

# What's next for Liga da Justiça Social
Liga da Justiça tem muito potencial para crescimento futuro. Temos a intenção de continuar o desenvolvimento da ferramenta, colocando mais inteligência nos robôs e tornando algumas ações automáticas. Além disso, acrescentar mais alvos de buscas em diferente formatos, e sugerir um padrão que facilite a busca e comunicação, entre as instituições e os tribunais, com isso, ajudando mais instituições que poderão se beneficiar.

# Built With
* .Net Core
* NodeJS
* MongoDB
* Mysql


# Instalation
Rodar app node
```shell
cd RoboGraacc
npm start
```


Arquitetura Atual
========================================================================
![Arquitetura_Atual](https://github.com/liga-da-justica-social/hackaton/blob/master/Docs/Arquitetura%20Atual.png)

Temos um robô escrito em NodeJS que vai realizar a extração das informações na internet e envia para o banco de dados NoSQL MongoDB. Uma
aplicação web desenvolvida em .Net obtem as informações do MongoDB e confirma a ações do usuário, está informação e inserida numa base de dados relacional Mysql

Arquitetura Futura
========================================================================
![Arquitetura_Futura](https://github.com/liga-da-justica-social/hackaton/blob/master/Docs/Arquitetura%20Futura.png)

A intenção para o futuro é criar um mecanismo de escalabilidade para os robôs e que eles possam se utilizar se serviços cognitivos de inteligência atificial para se tornarem mais inteligentes, trazendo mais efetividade nas informações colhidas. O RabbitMQ será usado para controlar o fluxo de informações a facilitar o processamento das mesmas que seram inseridas no Elasticsearch, onde seram melhor indexadas

Funcionalidades Futuras
========================================================================
* Notificações (Email, Celular)
* Análise cognitiva textual
* Automatização de processos através de integração com ferramentas externas (Sistema SEI e TJs)
* Acrescentar mais alvos de buscas em diferente formatos (PDFs)
* Sugerir um padrão aberto que facilite a busca e comunicação, entre as instituições e os tribunais

Licenças
========================================================================
GNU General Public License v3.0
