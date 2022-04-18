---
layout: projects-apps-layout

permalink: open-source-projects/boolli

metaTitle: 'Boolli'
metaDescription: 'Boolli è un interprete di espressioni booleane disponibile come libreria su NuGet, creato per implementare sistemi di regole avanzati.'
shortDescription: "L'interprete di espressioni booleane in `C#` che ti permette di implementare **sistemi di regole avanzati**"
subtitle: "L'interprete di espressioni booleane"

previousPageRoute: open-source-projects
previousPageTitle: Progetti open source

logoName: logo-boolli.png
logoAlt: "Il logo dell'interprete di espressioni booleane boolli"

buttons:
    - text: GitHub
      url: https://github.com/FrancescoBonizzi/boolli
      icon: icon-github
      title-text: Apri il repository GitHub di Boolli

jsonLd: '{"@context":"https://schema.org","@type":"SoftwareApplication","name":"Boolli","description":"Boolli &#xE8; un interprete di espressioni booleane disponibile come libreria su Nuget, creato per implementare sistemi di regole avanzati.","operatingSystem":"Windows","applicationCategory":"Software","image":"https://www.imaginesoftware.it/images/logos/logo-boolli.png","url":"https://github.com/FrancescoBonizzi/Boolli","contentRating":"Everyone","author":{"@type":"Organization","name":"Imagine Software","legalName":"Imagine Software di Bonizzi Francesco","url":"https://www.imaginesoftware.it","logo":"https://www.imaginesoftware.it/images/logos/logo-imagine-software.jpg","vatID":"02982280345","location":"Italy","sameAs":["https://www.imaginesoftware.it"],"foundingDate":"2021","founders":[{"@type":"Person","name":"Francesco Bonizzi"}],"contactPoint":{"@type":"ContactPoint","contactType":"customer support","email":"f.bonizzi@imaginesoftware.it"}},"offers":[{"@type":"Offer","price":"0","priceCurrency":"XXX","availability":"https://schema.org/InStock"}]}'
---

**Boolli** è un **interprete di espressioni booleane** [open-source](https://github.com/FrancescoBonizzi/Boolli 'Vai alla pagina GitHub di Boolli') scritto in `C#` e disponibile come [libreria su NuGet](https://www.nuget.org/packages/Boolli/ 'Vai alla pagina specifica su NuGet').

Cosa può fare **Boolli**? Rispondere `true` o `false` data un'espressione booleana!

<div class="section-separator-inside-section"></div>

Per **Boolli**, un'espressione booleana è una stringa generata secondo questa grammatica EBNF:

```
expr: factor((and | or) factor)*
factor: (not)* factor | boolean | LPAR expr RPAR
boolean: true | false | 0 | 1
```

Come software **Boolli** è composto da tre moduli:

-   Un lexer
-   Un parser
-   Un interprete

...e la struttura dati alla base del suo funzionamento è l'[Abstract Syntax Tree](https://en.wikipedia.org/wiki/Abstract_syntax_tree 'Più informazioni su Wikipedia inglese').

<div class="section-separator-inside-section"></div>

### Perché Boolli può esserti utile?

-   A scopo **didattico**: per capire come funziona un semplice interprete. Noi informatici li diamo per scontati, ma sono molto interessanti!
-   Se sostituisci, via codice, i token booleani con delle `Func<bool>` (o anche delle `Func<Task<bool>>`). Uno use case è quello di definire un semplice **sistema di regole**.

<div class="section-separator-inside-section"></div>

### Valutare un'espressione booleana

```
var boolli = new Evaluator();
string booleanExpression = "not true and false or (true and false)";
bool result = boolli.EvaluateBooleanExpression(booleanExpression);
```

...puoi anche usare `0` al posto di `false` e `1` al posto di `true`

```
var boolli = new Evaluator();
string booleanExpression = "not 1 and 0 or (true and false)";
bool result = boolli.EvaluateBooleanExpression(booleanExpression);
```

<div class="section-separator-inside-section"></div>

### Valutare un'espressione di `Func<bool>`

```
var boolli = new Evaluator();
bool result = boolli.EvaluateFuncOfBoolExpression(
    "f1 and f2",
    new NamedBooleanFunction[]
    {
        new NamedBooleanFunction("f1", () => true),
        new NamedBooleanFunction("f2", () => false),
    });
```

...anche in versione `Async`, con un'espressione di `Func<Task<bool>`

```
var boolli = new Evaluator();
bool result = await boolli.EvaluateFuncOfBoolExpressionAsync(
    "f3 and f4",
    new NamedAsyncBooleanFunction[]
    {
        new NamedAsyncBooleanFunction(
            "f3", 
            async () => { await Task.Delay(100); return true; }),
        new NamedAsyncBooleanFunction(
            "f4", 
            async () => { await Task.Delay(100); return true; })
    });
```

<div class="section-separator-inside-section"></div>

### Scenario reale

Ho sviluppato un **semplicissimo** scenario a scopo dimostrativo (se vuoi lo puoi migliorare tramite GitHub, fa sempre piacere!): un sistema di creazione di alert basato su regole configurabili interpretate da **Boolli.**

[Qui su GitHub](https://github.com/FrancescoBonizzi/Boolli/tree/master/SampleScenario 'Vai al codice open source del sistema di creazione di alert basato su regole') puoi trovare il codice sorgente dell'esempio specifico che sto per approfondire.

<p><a title="Apri l'immagine più in grande" href="{{ site.url }}/assets/images/screenshots/boolli-sample-scenario-output.png" target="_blank" rel="noopener"><img class="section-centered-image" src="{{ site.url }}/assets/images/screenshots/boolli-sample-scenario-output.png" alt="boolli-sample-scenario-output" /></a></p>

L'idea è quella di generare degli **alert testuali basati su dati di monitoraggio hardware**, come ad esempio la percentuali di CPU utilizzata in un dato momento. Ogni alert è generato da una regola che può essere scritta come una stringa - e quindi configurabile anche da una GUI - come ad esempio: `CPUPercentage and UsedRAMGigaBytes`.

In questo caso `CPUPercentage` è una funzione booleana che valuta la percentuale di CPU di un dato record secondo una soglia. Ad esempio può ritornare `true` se il valore supera il 90%.

Per completare l'esempio, ho cercato di immaginare uno scenario il più possibile reale. Abbiamo bisogno di questi elementi per far funzionare tutto:

-   Una lista di **regole** (`Rules`)
-   Dei **dati** di monitoraggio (`MonitoringData`) che in questo caso ho generato casualmente con `FakeMonitoringDataRepository`
-   Un generatore di **alert** che utilizzi un interprete di espressioni booleane (**Boolli**)

<div class="section-separator-inside-section"></div>

### L'anatomia di una regola

```
  new Rule()
  {
      RuleName = "RAM full and CPU busy last minute",
      BooleanExpression = $"{Metrics.CPUPercentage} and {Metrics.UsedRAMGigaBytes}",
      ResultingAlertGravity = AlertGravity.Critical,
      MessageFormat = "Attention! Last minute CPU ({0}%) and RAM ({1} GB) are very critical! (Last value collection time: {2})",
      TimeFrameMinutes = 1,
      DataEvaluationFunctionDescription  = new DataEvaluationFunctionDescription[]
      {
          new DataEvaluationFunctionDescription()
          {
              Metric = Metrics.CPUPercentage,
              Threshold = 90
          },
          new DataEvaluationFunctionDescription()
          {
              Metric = Metrics.UsedRAMGigaBytes,
              Threshold = 7
          }
      }
  }
```

Le property salienti sono:

-   `BooleanExpression`: con questa property specifichi un'espressione booleana che deve essere parsata ed eseguita da **Boolli** utilizzando i nomi di funzione specificati in `DataEvaluationFunctionDescription`
-   `MessageFormat`: per comporre il messaggio testuale di alert utilizzando come parametri l'output delle funzioni di valutazione dei record

In questo esempio specifico ho definito la classe `DataEvaluationFunctionDescription` con lo scopo di parametrizzare ogni tipo di metrica da valutare e la sua soglia specifica.

<div class="section-separator-inside-section"></div>

### Il generatore di alert

Questa è la parte più complessa di questo esempio, perché qui si mette tutto insieme: le regole, **Boolli** e i dati di monitoraggio.

```
public List<Alert> GenerateAlerts(MonitoringData[] monitoringData)
{
  var alerts = new List<Alert>();
  var boolli = new Evaluator();

  foreach (var rule in _alertGenerationRules)
  {
    // I need object for String.Format
    var lastValues = new Dictionary<Metrics, MonitoringData>();

    var namedBooleanFunctions = rule.DataEvaluationFunctionDescription.Select(d => new NamedBooleanFunction(
      d.Metric.ToString(),
      () =>
      {
        (bool IsCritical, MonitoringData data) = ValueCritical(
          monitoringData,
          DateTime.Now.AddMinutes(-rule.TimeFrameMinutes),
          d.Metric,
          d.Threshold);

        if (IsCritical && data != null)
        {
          lastValues[d.Metric] = data;
        }

        return IsCritical;
      })).ToArray();

    bool alertShouldBeGenerated = boolli.EvaluateFuncOfBoolExpression(
      rule.BooleanExpression,
      namedBooleanFunctions);

    if (alertShouldBeGenerated)
    {
      var stringFormatParameters = new List<object>();
      foreach (var lastValue in lastValues)
      {
        stringFormatParameters.Add((int)lastValue.Value.MetricValue);
      }

      if (stringFormatParameters.Count < Enum.GetNames(typeof(Metrics)).Length)
      {
        for (int i = 0; i < Enum.GetNames(typeof(Metrics)).Length; ++i)
          stringFormatParameters.Add("-");
      }

      stringFormatParameters.Add(lastValues.Values.OrderByDescending(v => v.CollectionTime).FirstOrDefault().CollectionTime);

      alerts.Add(new Alert()
      {
        GeneratingRuleName = rule.RuleName,
        AlertGravity = rule.ResultingAlertGravity,
        GenerationDate = DateTime.Now,
        Message = string.Format(rule.MessageFormat, stringFormatParameters.ToArray())
      });
    }
  }

  return alerts;
}
```

In questo frangente c'è un ciclo che valuta ogni regola ed il punto di giunzione con **Boolli** è proprio qui: le `DataEvaluationFunctionDescription` diventano `NamedBooleanFunction` per poter essere utilizzate dalla libreria.

```
bool alertShouldBeGenerated = boolli.EvaluateFuncOfBoolExpression(
    rule.BooleanExpression,
    namedBooleanFunctions);
```

<div class="section-separator-inside-section"></div>

### La funzione concreta dietro le quinte

Dopo aver letto tutto questo potrete pensare: ok, ma chi è che materialmente valuta quando i dati di monitoraggio devono generare un alert oppure no?

```
private (bool IsCritical, MonitoringData Data) ValueCritical(
    MonitoringData[] monitoringData,
    DateTime startingDate,
    Metrics metric,
    double threshold)
{
  foreach (var data in monitoringData
    .Where(d => d.CollectionTime > startingDate)
    .OrderByDescending(d => d.CollectionTime))
  {
    if (data.Metric == metric && data.MetricValue > threshold)
    {
      return (true, data);
    }
  }

  return (false, null);
}
```

Il codice sopra è l'`If` sostanziale che sta alla base di tutto.

<div class="section-separator-inside-section"></div>

### Contribuire

Il mondo dell'open source è meraviglioso proprio perché ognuno può dare il proprio contributo ed aiutare chissà chi nel mondo!

Il codice di **Boolli** è interamente [open source su GitHub](https://github.com/FrancescoBonizzi/Boolli 'Vai alla pagina GitHub di Boolli') ed è aperta alla collaborazione da parte di tutti!
