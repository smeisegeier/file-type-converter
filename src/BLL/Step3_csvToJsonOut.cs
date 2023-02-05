using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DextersLabor.Helper;
using Hl7.Fhir.Model;
using Rki.CancerData.Clinical.TableConverter.App;
using Rki.CancerData.Clinical.TableConverter.App.Models;

namespace Rki.CancerData.Clinical.TableConverter.App.BLL;

public class Step3_csvToJsonOut
{

    public static void Start()
    {
        foreach (var path in Converter.GetAllFilesInDir(StructureSupport.SerializerType.csv))
        {
            (new ConverterObject()
            {
                DbConnection = Globals.db_local_testdb,
                TableConnection = new SqlSupportTableConnection(Path.GetFileNameWithoutExtension(path))
            })
            .ToJsonOutFromCsv()
            .ToFile();
        }

    }

}
