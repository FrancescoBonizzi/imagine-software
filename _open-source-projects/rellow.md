---
layout: projects-apps-layout

permalink: open-source-projects/rellow

metaTitle: 'Rellow'
metaDescription: 'Rellow è un gioco di concentrazione: premi il pulsante giusto!! Attenzione, i colori danno assuefazione, tipo il rosso, il giallo, il rallo, il glu.'
shortDescription: "Concentrati o ti perderai in un bicchier d'acqua **colorata**!"
subtitle: 'Rosso, giallo, rallo, glu'

ogImage: 'logos/logo-rellow.png?v=59vRNVlWSAhxDX3WNFDIP-rpBcCm2aduUGzyr628hSg'

previousPageRoute: open-source-projects
previousPageTitle: Progetti open source

logoName: logo-rellow.png?v=59vRNVlWSAhxDX3WNFDIP-rpBcCm2aduUGzyr628hSg
logoAlt: 'Il logo del videogioco RELLOW'

buttons:
    - text: Scarica per Windows
      url: https://www.microsoft.com/store/apps/9N5JJ68QFBPB
      icon: icon-windows
      title-text: Scarica Rellow per Windows
    - text: 'Guarda su GitHub'
      url: 'https://github.com/FrancescoBonizzi/Rellow'
      icon: icon-github
      title-text: 'Guarda il codice sorgente di Rellow!'

jsonLd: '{"@context":"https://schema.org","@type":"GameApplication","name":"Rellow","url":"https://github.com/FrancescoBonizzi/Rellow","description":"Rellow &#xE8; un gioco di concentrazione: premi il pulsante giusto!! Attenzione, i colori danno assuefazione, tipo il rosso, il giallo, il rallo, il glu.","operatingSystem":"ANDROID","applicationCategory":"GAME_PUZZLE","image":"https://www.imaginesoftware.it/images/logos/logo-rellow.png?v=59vRNVlWSAhxDX3WNFDIP-rpBcCm2aduUGzyr628hSg","contentRating":"Everyone","author":{"@type":"Organization","name":"Imagine Software","legalName":"Imagine Software di Bonizzi Francesco","url":"https://www.imaginesoftware.it","logo":"https://www.imaginesoftware.it/images/logos/logo-imagine-software.jpg?v=IZ-cRR2fLms0GurmGkxsLFjfoPJsUcwwoevs-TsCoF8","vatID":"02982280345","location":"Italy","sameAs":["https://www.imaginesoftware.it"],"foundingDate":"2021","founders":[{"@type":"Person","name":"Francesco Bonizzi"}],"contactPoint":{"@type":"ContactPoint","contactType":"customer support","email":"f.bonizzi@imaginesoftware.it"}},"offers":[{"@type":"Offer","price":"0","priceCurrency":"XXX","availability":"https://schema.org/InStock"}]}'
---

**Rellow** è un gioco di **concentrazione**: ti troverai di fronte ad una serie di pulsanti colorati dove lo scopo è premere quello giusto! In alto vedrai una scritta che indicherà un colore, e tu dovrai proprio premere il pulsante del colore che la scritta descrive. La difficoltà sta nel fatto che la scritta è colorata di un colore diverso da quello che denota!

All'inizio il gioco è molto semplice, ci sono solo tre pulsanti, ma continuando a vincere la **difficoltà** aumenta, fino a nove pulsanti diversi contemporaneamente; inoltre il tempo a disposizione per pensare si riduce sempre più!

<p><img class="section-centered-image" src="{{ site.url }}/assets/images/screenshots/rellow-game-screenshot-1.png?v=PU8Tjn-9ZHSqhTo9c6podGRlZibvuXVjM7D_Mou5C9A" alt="rellow-game-screenshot-1" /></p>

<div class="section-separator-inside-section"></div>

### Rellow e la sua piccola parentesi sociale

Ne è stata sviluppata una versione espressamente *NOT game*, in seguito all'interesse mostrato da un amico psicoterapeuta professionista, il quale ne vide le potenzialità didattiche e formative in quanto **allenatore visio-manuale** per alcuni soggetti con scarsà motilità delle falangi.

In tale versione di **Rellow** vennero apportate significative modifiche alla grafica ed alla velocità di autoapprendimento, affinché anche un impiego temporalmente importante del coach stesso consentisse di aumentare la coordinazione tra il visus e le falangi motili.

<p><img class="section-centered-image" src="{{ site.url }}/assets/images/screenshots/rellow-game-screenshot-2.png?v=6L37uY06QhSi_ffD8jy50dydItNmhcFS7gcIYCtgUF8" alt="rellow-game-screenshot-2" /></p>

<div class="section-separator-inside-section"></div>

### Il gioco è gratis ed open source

Questo gioco è **interamente gratis** ed **open source**: non utilizza alcuna libreria tracciante, nessun log per monitorare l'utilizzo da parte degli utenti, **nessuna pubblicità**. Ed è **multipiattaforma**: potete provarlo sia su Android che su Windows, ma su Mac non ho mai provato! 😁

Ho sviluppato il gioco in `C#`, utilizzando due librerie anch'esse open source:

-   [MonoGame](https://github.com/MonoGame 'Visita la pagina Github di MonoGame'), il nuovo *XNA framework*
-   [FbonizziMonoGame](https://github.com/FrancescoBonizzi/FbonizziMonoGame 'Visita la pagina Github di FbonizziMonoGame'), una libreria che ho sviluppato io per semplificarmi gli sviluppi

Il codice di **Rellow** è interamente [accessibile su GitHub](https://github.com/FrancescoBonizzi/Rellow 'Vai alla pagina GitHub di Rellow') ed è aperto alla collaborazione da parte di tutti!
