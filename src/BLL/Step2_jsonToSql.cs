using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DextersLabor.Helper;
using Hl7.Fhir.Model;
using Rki.CancerData.Clinical.TableConverter.App;
using Rki.CancerData.Clinical.TableConverter.App.Models;

namespace Rki.CancerData.Clinical.TableConverter.App.BLL;

public class Step2_jsonToSql
{

    public static void Start(string schemaNameOverride = null)
    {

        foreach (var path in Converter.GetAllFilesInDir(StructureSupport.SerializerType.json))
        {
            (new ConverterObject()
            {
                DbConnection = Globals.db_zfkd_fhirmeta,
                TableConnection = new SqlSupportTableConnection(Path.GetFileNameWithoutExtension(path), null, schemaNameOverride)
            })
            .ToSqlFromJson()
            .ToFile();
        }

    }

}
