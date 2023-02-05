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
