---
layout: projects-apps-layout

permalink: open-source-projects/infart

metaTitle: 'INFART'
metaDescription: 'Ambientato in una città astratta, in continuo cambiamento, INFART è un gioco CORRI E SCOREGGIA in cui dovrete mangiare il più possibile verdure!'
shortDescription: "Una lotta contro il tempo per salvare la vivibilità della Terra tramite l'alimentazione. **Ognuno di noi può farlo!**"
subtitle: 'Esploderai dalle risate!'

ogImage: 'logos/logo-infart.png?v=m-WpIoF5rG6FDiXVxlkkPaKV4gbsoY_p9KGzIpQaZWk'

previousPageRoute: open-source-projects
previousPageTitle: Progetti open source

logoName: logo-infart.png?v=m-WpIoF5rG6FDiXVxlkkPaKV4gbsoY_p9KGzIpQaZWk
logoAlt: 'Il logo del videogioco INFART'

buttons:
    - text: Scarica per Android
      url: https://play.google.com/store/apps/details?id=com.francescobonizzi.infart
      icon: icon-android
      title-text: Scarica INFART per Android
    - text: Scarica per Windows
      url: https://www.microsoft.com/store/apps/9WZDNCRDHRJH
      icon: icon-windows
      title-text: Scarica INFART per Windows

jsonLd: '{"@context":"https://schema.org","@type":"GameApplication","name":"INFART","url":"https://play.google.com/store/apps/details?id=com.francescobonizzi.infart","description":"Ambientato in una città; astratta, in continuo cambiamento, INFART è un gioco CORRI E SCOREGGIA in cui dovrete mangiare il più possibile verdure!","operatingSystem":"ANDROID","applicationCategory":"GAME_ACTION","image":"https://www.imaginesoftware.it/images/logos/logo-infart.png?v=m-WpIoF5rG6FDiXVxlkkPaKV4gbsoY_p9KGzIpQaZWk","contentRating":"Everyone","author":{"@type":"Organization","name":"Imagine Software","legalName":"Imagine Software di Bonizzi Francesco","url":"https://www.imaginesoftware.it","logo":"https://www.imaginesoftware.it/images/logos/logo-imagine-software.jpg?v=IZ-cRR2fLms0GurmGkxsLFjfoPJsUcwwoevs-TsCoF8","vatID":"02982280345","location":"Italy","sameAs":["https://www.imaginesoftware.it"],"foundingDate":"2021","founders":[{"@type":"Person","name":"Francesco Bonizzi"}],"contactPoint":{"@type":"ContactPoint","contactType":"customer support","email":"f.bonizzi@imaginesoftware.it"}},"offers":[{"@type":"Offer","price":"0","priceCurrency":"XXX","availability":"https://schema.org/InStock"}]}'
---

L'uomo non ha trattato bene la Terra e **l'atmosfera è al collasso!**

Ambientato in una città astratta, in continuo cambiamento, **INFART** è un gioco *CORRI E SCOREGGIA* in cui dovrete mangiare il più possibile verdure, evitare gli hamburger ed i buchi nella strada che si sono creati in seguito ai cataclismi.

<p><img class="section-centered-image" src="{{ site.url }}/assets/images/screenshots/infart-game-screenshot-1.png?v=LC5MGYg3jM5Vf2xAZ-qX67r61-X1fS1BNJ0IdQSOx_o" alt="infart-game-screenshot-1" /></p>

**INFART** è un videogioco a scorrimento orizzontale - un'*infinite scroll* - **il cui mondo evolve nel tempo**: salta i buchi, evita gli hamburger più che puoi, altrimenti **ESPLODI**!

<div class="section-separator-inside-section"></div>

### Il pianeta terra al Game Over

Il gioco ironizza volutamente sulla **correlazione tra cibo, cambiamenti climatici e diritti dell'uomo**. Si vuole sensibilizzare in merito ad un mondo (il 2020) in cui una parte degli esseri umani soffre di patologie legate al sovrappeso mentre *l'altra parte* è malnutrita.

<p><img class="section-centered-image" src="{{ site.url }}/assets/images/screenshots/infart-game-screenshot-2.png?v=acf7SbK8hR52SEkHV1BGtGtRF1uJArXeN-nETN6ZxsU" alt="infart-game-screenshot-2" /></p>

Non solo: la *supply chain* del cibo, in particolare della carne - qui rappresentata dagli *hamburger* \- è correlata direttamente con [la perdita della biodiversità](https://www.theguardian.com/environment/2018/may/31/avoiding-meat-and-dairy-is-single-biggest-way-to-reduce-your-impact-on-earth "Un articolo del Guardian che parla della perdità di biodiversità in relazione all'alimentazione dell'uomo"), [l'inquinamento dell'aria](https://www.nature.com/articles/s41893-020-00603-4 'Nature: The carbon opportunity cost of animal-sourced food production on land'), la scarsità di acqua in alcuni paesi e lo sviluppo di batteri resistenti agli antibiotici.

Molte associazioni internazionali di rilievo, tra cui OMS, FAO, Academy of Nutrition and Dietetics, suggeriscono di preferire diete **green**.

<div class="section-separator-inside-section"></div>

### Le caratteristiche di INFART

-   Un livello completo a difficoltà incrementale
-   Potenziamenti divertenti
-   Un sacco di scoregge
-   Colonna sonora originale, composta dallo sviluppatore
-   Il personaggio principale è disegnato a mano su acquerello
-   Un mondo in continuo sviluppo che viene generato casualmente
-   Ottimizzato per l'utilizzo della batteria dello smartphone
-   Esploderai dalle risate!

<div class="section-separator-inside-section"></div>

### Un videogioco interamente gratis, open source, e senza pubblicità

Questo gioco è interamente **gratis** ed **open source**: non utilizza alcuna libreria tracciante, nessun log per monitorare l'utilizzo da parte degli utenti, **nessuna pubblicità**. Ed è **multipiattaforma**: potete provarlo sia su Android che su Windows, ma per Mac non l'ho ancora compilato! 😁

Ho sviluppato il gioco in `C#`, utilizzando due librerie anch'esse open source:

-   [MonoGame](https://github.com/MonoGame 'Visita la pagina Github di MonoGame'), il nuovo *XNA framework*
-   [FbonizziMonoGame](https://github.com/FrancescoBonizzi/FbonizziMonoGame 'Visita la pagina Github di FbonizziMonoGame'), una libreria che ho sviluppato io per semplificarmi gli sviluppi

Il codice di **INFART** è [accessibile su GitHub](https://github.com/FrancescoBonizzi/InfartGame 'Vai alla pagina GitHub di INFART') ed è aperto alla collaborazione da parte di tutti!
