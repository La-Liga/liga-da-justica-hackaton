**HACKATHON GRAAC**
========================================================================

Descrição do Projeto
========================================================================

Criamos a ferramenta usando o Visual Studio, MongoDB e Nodejs. Um robô monitora os sites dos tribunais e varas penais, registrando no mongodb todas as publicações referentes a editais e sentenças, uma vez registrado no mongodb, são listados na aplicação web. Um usuário autenticado no sistema, classifica tais publicações como Edital ou Sentença (que passsrão a serem monitorados em outra lista), acrescenta uma etiqueta para acompanhamento, de acordo com o trâmite interno e uma data para ser notificado. Na nova lista, o Edital ou Sentença poderá ser favoritado, facilitando a localização e o monitoramento.


Tecnologias
========================================================================
* .Net Core
* NodeJS
* MongoDB
* Mysql


Instalação
========================================================================
Rodar app node
```shell
cd RoboGraacc
npm start
```



Arquitetura Atual
========================================================================
![Arquitetura_Atual](/uploads/7a482d92efbec09faf64b3301ac41d35/Arquitetura_Atual.png)

Temos um robô escrito em NodeJS que vai realizar a extração das informações na internet e envia para o banco de dados NoSQL MongoDB. Uma
aplicação web desenvolvida em .Net obtem as informações do MongoDB e confirma a ações do usuário, está informação e inserida numa base de dados relacional Mysql

Arquitetura Futura
========================================================================
![Arquitetura_Futura](/uploads/6a12aabf7bd05b0c7bee646f2786d41f/Arquitetura_Futura.png)

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