---
layout: projects-apps-layout

permalink: open-source-projects/restart-on-crash

metaTitle: 'RestartOnCrash'
metaDescription: 'RestartOnCrash è una semplice applicazione .NET Core scritta in C#, open source, che riavvia in automatico le applicazioni che crashano.'
shortDescription: 'La tua applicazione crasha ed hai bisogno di una _remediation_ alla velocità della luce. **Riavviala in automatico!**'
subtitle: 'Riavvia le applicazioni che crashano!'

ogImage: 'logos/logo-restart-on-crash.png?v=MrywDch5J6DojRJnulkT-U01P1TCLlDrdSnIsj1qV2Q'

previousPageRoute: open-source-projects
previousPageTitle: Progetti open source

logoName: logo-restart-on-crash.png?v=MrywDch5J6DojRJnulkT-U01P1TCLlDrdSnIsj1qV2Q
logoAlt: 'Il logo del software RestartOnCrash'

buttons:
    - text: Guarda su GitHub
      url: https://github.com/FrancescoBonizzi/RestartOnCrash
      icon: icon-github
      title-text: Apri il repository di RestartOnCrash su GitHub

jsonLd: '{"@context":"https://schema.org","@type":"SoftwareApplication","name":"RestartOnCrash","description":"RestartOnCrash &#xE8; una semplice applicazione .NET Core scritta in C#, open source, che riavvia in automatico le applicazioni che crashano.","operatingSystem":"Windows","applicationCategory":"Software","url":"https://github.com/FrancescoBonizzi/RestartOnCrash","image":"https://www.imaginesoftware.it/images/logos/logo-restart-on-crash.png?v=MrywDch5J6DojRJnulkT-U01P1TCLlDrdSnIsj1qV2Q","contentRating":"Everyone","author":{"@type":"Organization","name":"Imagine Software","legalName":"Imagine Software di Bonizzi Francesco","url":"https://www.imaginesoftware.it","logo":"https://www.imaginesoftware.it/images/logos/logo-imagine-software.jpg?v=IZ-cRR2fLms0GurmGkxsLFjfoPJsUcwwoevs-TsCoF8","vatID":"02982280345","location":"Italy","sameAs":["https://www.imaginesoftware.it"],"foundingDate":"2021","founders":[{"@type":"Person","name":"Francesco Bonizzi"}],"contactPoint":{"@type":"ContactPoint","contactType":"customer support","email":"f.bonizzi@imaginesoftware.it"}},"offers":[{"@type":"Offer","price":"0","priceCurrency":"XXX","availability":"https://schema.org/InStock"}]}'
---

**RestartOnCrash** è una semplice applicazione `.NET Core`, [open source](https://github.com/FrancescoBonizzi/RestartOnCrash 'Vai alla pagina GitHub di RestartOnCrash') e scritta in `C#` che mira a risolvere il problema di un'*applicazione per Windows* che cessa di funzionare per problemi che non puoi gestire dall'interno. Semplicemente **riavvia l'applicazione crashata**.

In passato mi è capitato di aver dovuto utilizzare un software di terze parti con un bug relativo alla gestione della memoria, un [memory leak](https://it.wikipedia.org/wiki/Memory_leak 'Vai alla pagina di Wikipedia per la definizione di memory leak'): dopo due giorni di esecuzione la memoria riservata dall'applicazione arrivava al 100% e Windows uccideva il processo per preservare le risorse. Nel mio contesto **avevo la necessità di mantenere l'applicazione sempre attiva**, *nonostante tutto*.

Non avendo accesso al codice sorgente in questione, ho dovuto arrangiarmi con una soluzione esterna, ed ho sviluppato **RestartOnCrash**.

<div class="section-separator-inside-section"></div>

**RestartOnCrash** sorveglia un particolare processo e lo riavvia se questo non è più in esecuzione.

Ogni volta che esegue un'operazione, scrive un evento nell'[EventViewer](https://en.wikipedia.org/wiki/Event_Viewer "Vai alla pagina di Wikipedia inglese per maggior informazioni sull'EventViewer") di Windows con i log del monitoraggio, per *tracciare* con precisione ogni crash e riavvio.

<p>
    <a title="Guarda più in grande" href="{{ site.url }}/assets/images/screenshots/restart-on-crash-event-viewer.png?v=_uyh4PXs8vI_5zVFO_eFbbumH_hLxtNsFNg3ibAA0hw" target="_blank" rel="noopener">
        <img class="section-centered-image" src="{{ site.url }}/assets/images/screenshots/restart-on-crash-event-viewer.png?v=_uyh4PXs8vI_5zVFO_eFbbumH_hLxtNsFNg3ibAA0hw" alt="restart-on-crash-event-viewer" />
    </a>
</p>

Nel mio caso - per gestire eventuali riavvii della macchina stessa dovuti ad aggiornamenti automatici, blackout, intervento umano - ho posto sia **RestartOnCrash** che l'applicazione da monitorare allo *startup* di Windows, così da non pensarci più.

<div class="section-separator-inside-section"></div>

### Configurare RestartOnCrash

Tutto quello che serve è configurare il file `configuration.json`

```
{
    "PathToApplicationToMonitor": "C:\Program Files (x86)\AnApplicationThatMayCrash.exe",
    "CheckInterval": "00:00:10",
    "StartApplicationOnlyAfterFirstExecution": true
}
```

-   `PathToApplicationToMonitor`: indica il percorso dell'applicazione da monitorare. Al momento gestisce una sola applicazione
-   `CheckInterval`: è un TimeSpan serializzato. Rappresenta la frequenza con cui RestartOnCrash controlla lo stato dell'applicazione
-   `StartApplicationOnlyAfterFirstExecution`: se `false`, quando RestartOnCrash si avvia per la prima volta, avvia anche l'applicazione monitorata; se true attende che l'applicazione monitorata sia in esecuzione per agganciarsi al suo processo

<p>
    <a title="RestartOnCrash video" href="{{ site.url }}/assets/images/screenshots/restart-on-crash-video.gif?v=xCgeAESi4O-PQI5QvJGGrDBUYxB8JB-4KK-jnA3_8N0" target="_blank" rel="noopener">
        <img class="section-centered-image" src="{{ site.url }}/assets/images/screenshots/restart-on-crash-video.gif?v=xCgeAESi4O-PQI5QvJGGrDBUYxB8JB-4KK-jnA3_8N0" alt="restart-on-crash-video" />
    </a>
</p>

<div class="section-separator-inside-section"></div>

### Contribuire

Il mondo dell'open source è meraviglioso proprio perché ognuno può dare il proprio contributo ed aiutare chissà chi nel mondo!

Il codice di **RestartOnCrash** è interamente [open source su GitHub](https://github.com/FrancescoBonizzi/RestartOnCrash 'Vai alla pagina GitHub di RestartOnCrash') ed è aperta alla collaborazione da parte di tutti. Poco tempo fa ho ricevuto una pull request molto gradita dove veniva impostata una notifica di sistema in seguito al riavvio delle applicazioni gestite.
