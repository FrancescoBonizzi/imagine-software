---
layout: projects-apps-layout

permalink: open-source-projects/smart-scale-3000

metaTitle: 'Smart Scale 3000: la bilancia intelligente'
metaDescription: "SmartScale3000 è la bilancia intelligente che manca nei supermercati di tutto il mondo! Vincitore dell'Hackaton Hackfork 2020 organizzato da iSolutions!"
shortDescription: "La bilancia intelligente, powered by AI e **vincitrice** dell'**iSolutions Hackaton 2020**"
subtitle: 'La bilancia intelligente powered by AI'

ogImage: 'logos/logo-smart-scale.png?v=qlQrZW_fjB6oB2UwUPeHmJMvv91EhxgBameW-7Yu-V0'

previousPageRoute: open-source-projects
previousPageTitle: Progetti open source

logoName: logo-smart-scale.png?v=qlQrZW_fjB6oB2UwUPeHmJMvv91EhxgBameW-7Yu-V0
logoAlt: Il logo del progetto open source Smart Scale 3000

buttons:
    - text: GitHub
      url: https://github.com/FrancescoBonizzi/SmartScale3000
      icon: icon-github
      title-text: Apri il repository GitHub di Smart Scale 3000

jsonLd: '{"@context":"https://schema.org","@type":"SoftwareApplication","name":"SmartScale3000","description":"SmartScale3000 &#xE8; la bilancia intelligente che manca nei supermercati di tutto il mondo! Vincitore dell&#x27;Hackaton Hackfork 2020 organizzato da iSolutions!","operatingSystem":"Windows","applicationCategory":"Software","url":"https://github.com/FrancescoBonizzi/SmartScale3000","image":"https://www.imaginesoftware.it/images/logos/logo-smart-scale.png?v=qlQrZW_fjB6oB2UwUPeHmJMvv91EhxgBameW-7Yu-V0","contentRating":"Everyone","author":{"@type":"Organization","name":"Imagine Software","legalName":"Imagine Software di Bonizzi Francesco","url":"https://www.imaginesoftware.it","logo":"https://www.imaginesoftware.it/images/logos/logo-imagine-software.jpg?v=IZ-cRR2fLms0GurmGkxsLFjfoPJsUcwwoevs-TsCoF8","vatID":"02982280345","location":"Italy","sameAs":["https://www.imaginesoftware.it"],"foundingDate":"2021","founders":[{"@type":"Person","name":"Francesco Bonizzi"}],"contactPoint":{"@type":"ContactPoint","contactType":"customer support","email":"f.bonizzi@imaginesoftware.it"}},"offers":[{"@type":"Offer","price":"0","priceCurrency":"XXX","availability":"https://schema.org/InStock"}]}'
---

Nel 2020 abbiamo presentato **SmartScale3000**, la bilancia intelligente *powered by AI*, all'hackaton *Hackfork* organizzato da [iSolutions](https://www.isolutions.it/news-hackathon012020_2.html 'Visita la pagina che parla di Hackfork sul sito di iSolutions').

<p><img class="section-centered-image" src="{{ site.url }}/assets/images/screenshots/smartscale-hackaton-office.jpg?v=Cu5QYNDrFGuVTx8Eh0aIxzfosiROoakiWr0IMy8qbAY" alt="smartscale-hackaton-office" /></p>

Tutti conoscono le bilance dell'ortofrutta, con le quali ogni settimana pesiamo e prezziamo i prodotti: noi **ne abbiamo implementata una intelligente** che riconosce automaticamente cosa stai pesando, senza bisogno di ricordarsi il numero o premere il pulsante corretto: **fa tutto da sola!**

Abbiamo realizzato la bilancia in 24 ore, con un cella di carico e [Arduino](https://www.arduino.cc/ 'Il sito ufficiale di Arduino'). Arduino invia le pesate in centesimi di grammo ad un *broker* `MQTT` appoggiato su un mini router che sta nel palmo della mano.

Un dispositivo - in questo caso un PC, ma poteva essere anche molto meno - riceve i dati e quando la pesata è *stabile* scatta una foto. La foto viene processata da un rete neurale trainata con [TensorFlow](https://www.tensorflow.org/ 'Visita il sito ufficiale di TensorFlow') ed eseguita da [ML .NET](https://dotnet.microsoft.com/apps/machinelearning-ai/ml-dotnet 'Visita il sito ufficiale di ML. NET'), fino ad ottenere il nome del prodotto.

<p><img class="section-centered-image" src="{{ site.url }}/assets/images/screenshots/smartscale-hackaton-app-screenshot-1.jpg?v=ZwAvy-J5LH5DuohSJCh0oIjWlckdCEOEH45Ta41gQ0A" alt="smartscale-hackaton-app-screenshot-1" /></p>

Da lì il frontend realizzato in `WPF` calcola il prezzo, genera il codice a barre, mostra il risultato ed invia ad un broker il risultato in modo da salvarlo in uno storage per future analisi.

<div class="section-separator-inside-section"></div>

### Il nostro kit hardware e software

-   Un computer portatile per eseguire il frontend
-   **Arduino**
-   Una cella di carico per Arduino
-   Un modulo Wifi per Arduino
-   Un mini router Wifi per creare una rete privata e mettere in comunicazione Arduino con il frontend
-   Una WebCam 1080p
-   Framework di frontend: `WPF`, su Windows
-   Framework di machine learning: `TensorFlow` ed `ML.NET`

<div class="section-separator-inside-section"></div>

### Il progetto vincitore dell'Hackaton Hackfork organizzato da iSolutions a tema food

Questa è stata la prima hackaton italiana **dedicata al cibo**, alla nutrizione e all'automazione agroalimentare. Lo scopo della competizione era di creare un prodotto sul tema della filiera alimentare dalla produzione alla logistica, dalla vendita fino arrivare alla ristorazione.

<p><img class="section-centered-image" src="{{ site.url }}/assets/images/screenshots/smartscale-hackaton-office-selfie-of-victory.jpg?v=aAk97kT1qad0npB75DESB5ffHn4_3hQ-GNw05kuM2nA" alt="smartscale-hackaton-office-selfie-of-victory" /></p>

<div class="section-separator-inside-section"></div>

### Contribuire

Il mondo dell'open source è meraviglioso proprio perché ognuno può dare il proprio contributo ed aiutare chissà chi nel mondo!

Il codice di **SmartScale3000** è interamente [open source su GitHub](https://github.com/FrancescoBonizzi/SmartScale3000 'Vai alla pagina GitHub di SmartScale3000') ed è aperta alla collaborazione da parte di tutti. Troverete il frontend al path `source/SmartWeightDevice`, e la parte di Arduino in `source/sensore`.
