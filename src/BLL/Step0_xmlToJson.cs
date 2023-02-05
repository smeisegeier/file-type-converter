using DextersLabor.Helper;
using Rki.CancerData.Clinical.TableConverter.App.Models;

namespace Rki.CancerData.Clinical.TableConverter.App.BLL;

public class Step0_xmlToJson
{
    /// <summary>
    /// Fetches all given fhire res to json
    /// GetStoragePath is still needed, since using a conversion object here would be bloat
    /// </summary>

    public static void Start()
    {
        foreach (var path in Converter.GetAllFilesInDir(StructureSupport.SerializerType.xml))
        {
            (new ConverterObject()
            {
                DbConnection = null,
                TableConnection = new SqlSupportTableConnection(Path.GetFileNameWithoutExtension(path))
            })
            .ToJsonFromXml()
            .ToFile();
        }


        // (new ConverterObject()
        // {
        //     DbConnection = null,
        //     TableConnection = new SqlSupportTableConnection(Path.GetFileNameWithoutExtension("xml/[dbo]beurteilung_gesamt.xml"), null, true)
        // })
        // .ToJsonFromXml()
        // .ToFile();

    }
}
