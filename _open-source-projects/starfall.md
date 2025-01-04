---
layout: projects-apps-layout

permalink: open-source-projects/starfall

metaTitle: 'Starfall'
metaDescription: 'Sei una stella caduta sulla Terra. Ti ritrovi in una selva oscura in cerca della via per risalire verso casa...'
shortDescription: 'Sei una stella caduta sulla Terra. Ti ritrovi in una selva oscura, in cerca della luce per tornare a casa...'
subtitle: 'Mi ritrovai per una selva oscura...'

ogImage: 'logos/logo-starfall.png?v=yb-_nmV6rZQVhGnkWX8qKaJMFUCJIeJEvgOdEbbjsE4'

previousPageRoute: open-source-projects
previousPageTitle: Progetti open source

logoName: logo-starfall.png?v=yb-_nmV6rZQVhGnkWX8qKaJMFUCJIeJEvgOdEbbjsE4
logoAlt: Il logo del videogioco open source Starfall

buttons:
    - text: Scarica per Windows
      url: https://www.microsoft.com/it-it/p/starfall-free/9mw4t75wzr28
      icon: icon-windows
      title-text: Scarica Starfall per Windows
    - text: 'Guarda su GitHub'
      url: 'https://github.com/FrancescoBonizzi/StarfallGame'
      icon: icon-github
      title-text: 'Guarda il codice sorgente di Starfall!'

jsonLd: '{"@context":"https://schema.org","@type":"GameApplication","name":"Starfall","url":"https://play.google.com/store/apps/details?id=com.francescobonizzi.starfall","description":"Sei una stella caduta sulla Terra. Ti ritrovi in una selva oscura in cerca della via per risalire verso casa...","operatingSystem":"ANDROID","applicationCategory":"GAME_ACTION","image":"https://www.imaginesoftware.it/images/logos/logo-starfall.png?v=yb-_nmV6rZQVhGnkWX8qKaJMFUCJIeJEvgOdEbbjsE4","contentRating":"Everyone","author":{"@type":"Organization","name":"Imagine Software","legalName":"Imagine Software di Bonizzi Francesco","url":"https://www.imaginesoftware.it","logo":"https://www.imaginesoftware.it/images/logos/logo-imagine-software.jpg?v=IZ-cRR2fLms0GurmGkxsLFjfoPJsUcwwoevs-TsCoF8","vatID":"02982280345","location":"Italy","sameAs":["https://www.imaginesoftware.it"],"foundingDate":"2021","founders":[{"@type":"Person","name":"Francesco Bonizzi"}],"contactPoint":{"@type":"ContactPoint","contactType":"customer support","email":"f.bonizzi@imaginesoftware.it"}},"offers":[{"@type":"Offer","price":"0","priceCurrency":"XXX","availability":"https://schema.org/InStock"}]}'
---

**Sei una stella caduta sulla Terra**. Ti ritrovi in una selva oscura in cerca della via per risalire verso casa. Sei priva di energie e ti servono le luci per recuperare le forze e riuscire a volare.

Attenzione, però, durante il cammino i buchi neri cercheranno di assorbirti!

**Starfall** è un videogioco a scorrimento orizzontale - un'*infinite scroll* - **il cui mondo evolve nel tempo**. La tua capacità di volare dipende dalla luce che interiorizzi e si può ridurre se inglobi troppo **buio**...

<p><img class="section-centered-image" src="{{ site.url }}/assets/images/screenshots/starfall-game-screenshot-1.png?v=-jFnKdApBfjyP8Mz6A0vGWlLqz-pNSMBueaKgsmU-TI" alt="starfall-game-screenshot-1" /></p>

<div class="section-separator-inside-section"></div>

### Sviluppato con un amico

Ho sviluppato **Starfall** insieme ad un amico artista e fotografo: [Marco Oppici](https://www.linkedin.com/in/marco-oppici-b43471187 'Il profilo LinkedIn di Marco').

Un giorno Marco è venuto a trovarmi, abbiamo fatto una passeggiata, mi ha mostrato alcune foto di alberi che aveva scattato in montagna e ci è venuta l'idea: *perché non resti qui tutto il weekend e proviamo a sviluppare un videogioco in tre giorni con le tue foto?*

**E così è stato.**

Marco è un mago di strumenti di fotoritocco, ha un occhio clinico che io ancora non ho, ed intanto che scrivevo tutto il codice, lui mi preparava gli sfondi in parallasse, disegnava la stella protagonista del gioco e la animava con [Spriter](https://brashmonkey.com/spriter-pro/ "L'applicazione di animazione Spriter").

<p><img class="section-centered-image" src="{{ site.url }}/assets/images/screenshots/starfall-game-screenshot-menu.png?v=xpRbPlXMD53gwZl3HcrQC4xXOqIdrf5-ihNX3T3X34E" alt="starfall-game-screenshot-menu" /></p>

<div class="section-separator-inside-section"></div>

### Le funzionalità di Starfall

-   Un livello completo a difficoltà incrementale
-   Tre elementi di sfida: luci catturate, tempo di volo, tempo di gioco
-   Colonna sonora originale, composta dallo sviluppatore
-   Disegni d'autore e composizione grafica con fotografie
-   Una breve, ma significativa storia
-   Ottimizzato per l'utilizzo della batteria dello smartphone

<div class="section-separator-inside-section"></div>

### Un videogioco gratis ed open source

Questo gioco è interamente gratis ed open source: non utilizza alcuna libreria tracciante, nessun log per monitorare l'utilizzo da parte degli utenti, nessuna pubblicità. Ed è **multipiattaforma**: potete provarlo sia su Android che su Windows, ma su Mac non l'ho mai compilato! 😁

Ho sviluppato il gioco in `C#`, utilizzando due librerie anch'esse open source:

-   [MonoGame](https://github.com/MonoGame 'Visita la pagina Github di MonoGame'), il nuovo *XNA framework*
-   [FbonizziMonoGame](https://github.com/FrancescoBonizzi/FbonizziMonoGame 'Visita la pagina Github di FbonizziMonoGame'), una libreria che ho sviluppato io per semplificarmi gli sviluppi

Il codice di **Starfall** è interamente [accessibile su GitHub](https://github.com/FrancescoBonizzi/StarfallGame 'Vai alla pagina GitHub di Starfall') ed è aperto alla collaborazione da parte di tutti!
