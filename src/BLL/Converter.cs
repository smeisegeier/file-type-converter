using DextersLabor.Helper;
using Hl7.Fhir.Model;
using Rki.CancerData.Clinical.TableConverter.App.Models;

namespace Rki.CancerData.Clinical.TableConverter.App.BLL;

public static class Converter
{

    public static List<SqlRow> FhirResourceToJSon(string resourceId, string baseUrl, Type fhirType)
    {
        var list = new List<SqlRow>();

        // copy fhir object to new list using implicit conversion
        if (fhirType == typeof(CodeSystem))
        {
            var codeSystem = FhirSupport.GetFhirResourceById(resourceId, typeof(CodeSystem), baseUrl) as CodeSystem;
            codeSystem.Concept.ForEach(x => list.Add(x));
        }

        if (fhirType == typeof(ValueSet))
        {
            var valueSet = FhirSupport.GetFhirResourceById(resourceId, typeof(ValueSet), baseUrl) as ValueSet;
            valueSet.Compose.Include.First().Concept.ForEach(x => list.Add(x));
        }

        return list;
    }


    /// <summary>
    /// Gets all file names (.extension) from asset subfolder according to type (csv, json etc,)
    /// </summary>
    /// <param name="type">SerializerType</param>
    /// <returns>string[] of all files</returns>
    public static string[] GetAllFilesInDir(StructureSupport.SerializerType type) =>
        Directory.GetFiles(ConverterObject.GetFolderPathInTemp(
            type)
            , $"*.{type}", SearchOption.TopDirectoryOnly);



}
