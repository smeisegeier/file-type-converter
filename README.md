# file-type-converter

## about

- all-in-one tool for converting database related files between `sql`, `csv`, `json`

## use-cases

### step 0 get data into start condition

- get `json` from fire resources (valuesSet / codeSystem)
- get `json` from `xml`
- get `csv` from `sql-table`

### step 1 get data into `csv` as anchor-format

- get `csv` from `json`

### step 2 transfer towards databases

- transfer `csv` into `sql` (ddl-script)
- transfer `csv` into `sql` (ddl-script)

### step 3 endpoints

- load sql on server
- transfer `json` to `sql`

## built with

### dependencies

- `dexters-labor` >= v0.9.5.0
- `jsonToSql` uses modified code from https://github.com/srinudhulipalla/JsonToSQL

### used packages

```xml
  <ItemGroup>
    <PackageReference Include="CsvHelper" Version="30.0.0" />
    <PackageReference Include="Hl7.Fhir.R4" Version="4.3.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="6.0.10" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="6.0.10" />
    <PackageReference Include="Newtonsoft.Json" Version="13.0.1" />
    <PackageReference Include="PgpCore" Version="5.8.1" />
    <PackageReference Include="Saxon-HE" Version="10.8.0" />
    <PackageReference Include="System.Configuration.ConfigurationManager" Version="7.0.0" />
  </ItemGroup>
```

### local settings

- to avoid exposing passwd to public, all credentials are retrieved from a untracked file `.config/settings.config`
- passwd reside in secure vault like bitwarden
- file is copied to `/bin` via `.csproj` include command
- `settings.config`

```xml
<?xml version="1.0" encoding="utf-8"?>
<appSettings>
    <add key="server_rki_prod" value="xxx" />
    <add key="server_rki_test" value="yyy" />
</appSettings>
```

- `.csproj`

```xml
  <ItemGroup>
    <Content Include="../.config/**">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </Content>
  </ItemGroup>
```

- link settings file in `app.config`

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <appSettings configSource="settings.config" />
</configuration>
```

## xslt

### goal

- given `xml` files shall be transformed via `xslt`

### setup

1. install `saxon-he` ("_home edition_") via **nuget**
1. install `deltaXML` **extension** for vscode
1. organize files in folder (eg xslt)
   1. `test-source.xml`
   2. `transform.xslt`
1. for `xslt`: _select language mode_ in vscode, assign file extensions etc
1. via **F1** menu _configure build task_ and select the new saxon-js task. it is now integrated in `task.json`
1. configure the task to use `${fileDirname}`

```json
{
  "type": "xslt-js",
  "label": "xslt-js: Saxon-JS Transform (New)",
  "xsltFile": "${file}",
  "xmlSource": "${fileDirname}/test-source.xml",
  "resultPath": "${fileDirname}/result.xml",
  "group": {
    "kind": "build"
  },
  "problemMatcher": ["$saxon-xslt-js"]
}
```

7. `ctrl-shift-B` or _run build task_ (package loads components on first use) when _within_ the xslt

### resources

- [data2type](https://www.data2type.de/xml-xslt-xslfo/xslt#c45)
- [SO](https://stackoverflow.com/questions/38267254/xslt-apply-two-different-template-in-sequence)
- [deltaXML](https://marketplace.visualstudio.com/items?itemName=deltaxml.xslt-xpath)
