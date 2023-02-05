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

    public static void Start(SqlSupportDbConnection dbConnection)
    {
        foreach (var path in Converter.GetAllFilesInDir(StructureSupport.SerializerType.csv))
        {
            (new ConverterObject()
            {
                DbConnection = dbConnection,
                TableConnection = new SqlSupportTableConnection(Path.GetFileNameWithoutExtension(path))
            })
            .ToSqlFromCsv()
            .ToFile();
        }
    }

}
