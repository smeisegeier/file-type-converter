using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DextersLabor.Helper;
using Hl7.Fhir.Model;
using Rki.CancerData.Clinical.TableConverter.App;
using Rki.CancerData.Clinical.TableConverter.App.Models;

namespace Rki.CancerData.Clinical.TableConverter.App.BLL;

public class Step2_csvToSql
{

    /// <summary>
    /// Start the app
    /// </summary>
    /// <param name="schemaNameOverride">set a schemaname for sql ddl generation</param>
    public static void Start(string schemaNameOverride = null)
    {
        foreach (var path in Converter.GetAllFilesInDir(StructureSupport.SerializerType.csv))
        {
            (new ConverterObject()
            {
                DbConnection = Globals.TargetDb,
                TableConnection = new SqlSupportTableConnection(Path.GetFileNameWithoutExtension(path), null, schemaNameOverride)
            })
            .ToSqlFromCsv()
            .ToFile();
        }
    }

}
