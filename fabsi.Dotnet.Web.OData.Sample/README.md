
# OData unter ASP.NET Core

## Einleitung

OData (Open Data) ist ein standarisiertes Protokoll (http://docs.oasis-open.org/odata/odata/v4.0/odata-v4.0-part1-protocol.html) auf Basis einer RESTful WebAPI.
Diese Definition einer Schnittstellt ermöglicht es komplexe Datenstrukturen abzurufen und zu filtern.

Vorteile sind:
- Datenbank-Optimierte Filteroperationen (auch bei komplexen Filtern)
- effiziente Anbindung: Implementierungen sind in den meisten APIs bereits vorhanden

Nachteile sind:
- Eine Lösung zum verschleiern der originalen Datenbankschemata ist notwendig
  - ggf. über Views/ Dto-Entity Struktur

In Kombination mit einem geeigneten User Interface können komplexe Datenmodelle UI/UX veranschaulicht werden.
Im folgenden Beispiel wird das Angular-Framework und eine Tabelle von DevExtreme - das sogenannte `DxDataGrid` - genutzt.
Es kann aber auch z.b. React verwendet werden. Durch die Bibliothek `MUI` lassen sich ebenfalls Tabellen darstellen und an eine OData Schnittstelle anbinden.

---

## Konfiguration WebAPI

Da OData nur die Parameter der Schnittstelle definiert kann direkt auf die jeweiligen Funktionen in den Bibliotheken zugegriffen werden.

```csharp
var edmModelBuilder = new ODataConventionModelBuilder();
edmModelBuilder.EntitySet<TModel>(nameof(TModel));
var oDataQueryContext = new ODataQueryContext(edmModelBuilder.GetEdmModel(), typeof(TModel), request.ODataFeature().Path);
var oDataOptions = new ODataQueryOptions(oDataQueryContext, request);
Data = (IQueryable<TModel>?)oDataOptions.ApplyTo(dataSet);
```

OData operiert anhand von Query-Werten:
- $filter
- $orderby
- $count
- $top
- $skip

Diese werden dann anhand der Spezifikation gelesen, validiert und gegen das Ziel-Model ausgeführt.
Als Validierung & Prüfung gilt das "EdmModel" welches das Schemata/den Typen des Ziel-Models definiert.

```csharp
var edmModelBuilder = new ODataConventionModelBuilder();

edmModelBuilder.EntitySet<TEntity>(nameof(TEntity));

var oDataQueryContext = new ODataQueryContext(edmModelBuilder.GetEdmModel(), typeof(TEntity), request.ODataFeature().Path);

var oDataOptions = new ODataQueryOptions(oDataQueryContext, request);

var data = new List<TEntity>((IQueryable<TEntity>)oDataOptions.ApplyTo(dataSet));
```

## Konfiguration Frontend

Das `DxDataGrid` von _DevExtreme_ bietet eine umfangreiche Funktionalität mit verschiedenen Datenquellen sowie einer Konfigurierbarkeit.
Dazu ist die Tabelle in verschiedene Segmente einzuteilen.

1. Datenquelle + Datendefinition
2. Anzeige von Text
   1. Übersetzungen
3. Aktionen
   1. Filtern
   2. Sortieren
   3. Bearbeiten
   4. Row-Click
   5. Inputs auf cell- oder Tabellen-ebene
4. 


## Anwendungsfälle abdecke
Eine OData Schnittstelle kann sehr schnell wachsen und den exisitierenden Implementierungen - Backend & Frontend technisch - zu groß werden.  
Deshalb ist es notwendig möglichst alle Anwendungsfälle einer Tabelle zu definieren & durch Beispiele Lösungsansätze zu prüfen.

### 1. Anzeige von Feldern mit primitiven Datentypen

Die einfachste Form der Darstellung gelingt mit primitiven Datentypen, da sie ihre eigene Darstellung direkt beinhalten.
Dazu gehören:
- string
- number (sowohl Ganzzahl als auch Dezimalzahl)
- boolean

Weitere Felder sind etwas spezifischer, lassen sich jedoch auch nahezu direkt Abbilden:
- date (**Problem**: Konvertierung zu einem nutzerverständlichem Format)
- enum (**Problem**: Bekannte auswahl von Elementen (strings))

### 2. verschachtelte Objekte & Listen
**Problem**: 
- automatisch zusammengebaute filter- und sortier-Queries
- welche Werte werden in Tabelle angezeigt?
