using System.Xml.Serialization;
using System.Text;
using System.Xml;
using DextersLabor.Helper;
using Rki.CancerData.Clinical.TableConverter.App.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Rki.CancerData.Clinical.TableConverter.App.BLL;

public static class ConverterExtensions
{
    public static ConverterObject ToJsonFromFhir(this ConverterObject con, string resourceId, string baseUrl, Type fhirType)
    {
        con.SourceType = StructureSupport.SerializerType.NONE;
        con.TargetType = StructureSupport.SerializerType.json;

        con.SerializedContent = Converter.FhirResourceToJSon(resourceId, baseUrl, fhirType).ToJson();
        return con;
    }


    public static ConverterObject ToCsvFromJson(this ConverterObject con)
    {
        con.SourceType = StructureSupport.SerializerType.json;
        con.TargetType = StructureSupport.SerializerType.csv;


        var dataTable = JsonSupport.GetDataTableFromJson(File.ReadAllText(con.SourceFilePath));
        con.SerializedContent = SqlSupport
            .GetCsvStringFromDataTable(dataTable)
            .ToBomString();
        return con;
    }

    public static ConverterObject ToSqlFromCsv(this ConverterObject con)
    {
        con.SourceType = StructureSupport.SerializerType.csv;
        con.TargetType = StructureSupport.SerializerType.sql;

        string json = CsvSupport.GetJsonFromCsvFile(con.SourceFilePath);
        con.SerializedContent = SqlSupport.GetSqlDdlFromJson(
            json
            , con.DbConnection
            , con.TableConnection
            , true, false, true, true
        );
        return con;
    }

    public static ConverterObject ToCsvFromSqlTable(this ConverterObject con)
    {
        con.SourceType = StructureSupport.SerializerType.sqltable;
        con.TargetType = StructureSupport.SerializerType.csv;

        var dataTable = SqlSupport.GetDataTableFromSqlConnect(con.DbConnection, con.TableConnection, false);
        con.SerializedContent = SqlSupport
            .GetCsvStringFromDataTable(dataTable)
            .ToBomString();
        return con;
    }

    public static ConverterObject ToJsonOutFromCsv(this ConverterObject con)
    {
        con.SourceType = StructureSupport.SerializerType.csv;
        con.TargetType = StructureSupport.SerializerType.json_out;

        con.SerializedContent = CsvSupport.GetJsonFromCsvFile(con.SourceFilePath);
        return con;
    }

    public static ConverterObject ToJsonFromXml(this ConverterObject con)
    {
        con.SourceType = StructureSupport.SerializerType.xml;
        con.TargetType = StructureSupport.SerializerType.json;

        var xml = File.ReadAllText(con.SourceFilePath);
        con.SerializedContent = xml.ToStrippedJson();
        return con;
    }

    public static ConverterObject ToSqlTableFromSql(this ConverterObject con)
    {
        con.SourceType = StructureSupport.SerializerType.sql;
        con.TargetType = StructureSupport.SerializerType.sqltable;

        con.DbConnection.ExecuteSql(File.ReadAllText(con.SourceFilePath));

        return con;
    }

    public static ConverterObject ToSqlFromJson(this ConverterObject con)
    {
        con.SourceType = StructureSupport.SerializerType.json;
        con.TargetType = StructureSupport.SerializerType.sql;

        con.SerializedContent = SqlSupport.GetSqlDdlFromJson(File.ReadAllText(con.SourceFilePath)
            , con.DbConnection
            , con.TableConnection
            , true, false, true, true
        );
        return con;
    }

    public static ConverterObject ToFile(this ConverterObject con)
    {
        // overriden String.ToFile()
        con.SerializedContent.ToFile(con.TargetFilePath.Replace(
            // normalize file extensions (.json_out -> json)
            $".{StructureSupport.SerializerType.json_out}"
            , ".json")
        );
        return con;
    }


    /// <summary>
    /// Requires xml w/ root element followd by the array
    /// DOES NOT WORK properly when there is only 1 node (then brackets are missing in json, which hurts)
    /// </summary>
    /// <param name="xml"></param>
    /// <param name="isPretty"></param>
    /// <returns></returns>
    public static string? ToStrippedJson(this string xml, bool isPretty = true)
    {
        // todo is there a fix for the array problem? only 1 node in xml -> no []
        var doc = new XmlDocument();
        var doc2 = new XmlDocument();
        doc.LoadXml(xml);

        // get rid of <xml> declaration as first node
        var restriction = doc.DocumentElement;
        // attributes are unwanted
        restriction.Attributes?.RemoveAll();

        // this stripped xml needs to be loaded again into a node
        doc2.LoadXml(restriction?.OuterXml);

        // now create json and its object
        var json = JsonConvert.SerializeObject(doc2);
        var jObject = JObject.Parse(json);

        // approach through the nodes until shape is ok
        var e0 = JsonConvert.SerializeObject(jObject);
        var e1 = JsonConvert.SerializeObject(jObject.First);
        var e2 = JsonConvert.SerializeObject(jObject.First.First);
        var e3 = JsonConvert.SerializeObject(jObject.First.First.First);
        var e4 = JsonConvert.SerializeObject(jObject.First.First.First.First, isPretty ? Newtonsoft.Json.Formatting.Indented : Newtonsoft.Json.Formatting.None);

        return e4;
    }
}
