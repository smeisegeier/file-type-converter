using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DextersLabor.Helper;
using Hl7.Fhir.Model;
using Rki.CancerData.Clinical.TableConverter.App;
using Rki.CancerData.Clinical.TableConverter.App.Models;

namespace Rki.CancerData.Clinical.TableConverter.App.BLL;

public class Step3_sqlToSqlTable
{

    public static void Start()
    {
        foreach (var path in Converter.GetAllFilesInDir(StructureSupport.SerializerType.sql))
        {
            (new ConverterObject()
            {
                DbConnection = Globals.TargetDb,
                TableConnection = new SqlSupportTableConnection(Path.GetFileNameWithoutExtension(path))
            })
            .ToSqlTableFromSql();

        }
    }

}
