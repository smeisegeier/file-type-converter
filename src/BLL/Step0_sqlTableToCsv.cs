using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DextersLabor.Helper;
using Rki.CancerData.Clinical.TableConverter.App;
using Rki.CancerData.Clinical.TableConverter.App.Models;

namespace Rki.CancerData.Clinical.TableConverter.App.BLL;

public class Step0_sqlTableToCsv
{
    public static void Start()
    {
        var zfkd_meta = new List<object> {
            // "[meta]Batches_persistent"
            // ,new SqlSupportTableConnection("[meta]Checks_persistent","SELECT TOP 100 * FROM [meta].[ColumnCheck] TABLESAMPLE(200 rows)")
            // ,new SqlSupportTableConnection("[meta]Frequencies_persistent","SELECT TOP 100 * FROM [meta].[ColumnCheck] TABLESAMPLE(200 rows)")
            // ,"[meta]ColumnCheck"
            // ,"[meta]ColumnMapping"
            // ,"[meta]ColumnMaster"
            // ,"[meta]ColumnTransform"
            // ,"[meta]dim_AGRP10"
            // ,"[meta]dim_AGRP15"
            // ,"[meta]dim_AGRP44"
            // ,"[meta]dim_AGRP5"
            // ,"[meta]dim_AGRP75"
            // ,"[meta]dim_AGRP01_bis_130"
            // ,"[meta]dim_BevStandard"
            // ,new SqlSupportTableConnection("[meta]dim_Date","SELECT TOP 100 * FROM [meta].[dim_Date] TABLESAMPLE(200 rows)")
            // ,"[meta]dim_DSICH"
            // ,"[meta]dim_NUTS_1_BL"
            // ,"[meta]dim_NUTS_2_RB"
            // ,"[meta]dim_NUTS_3_LK"
            // ,"[meta]dim_Siedlungstyp"
            "[meta]dtSiteHistology"
            };

        var zfkd_qscore = new List<object> {
            // "[meta]dim_HISCDIG",
            // "[meta]dim_ColumnCheck",
            // "[meta]dim_ICD10",
            "[meta]dim_ICD10DREI"
            // "[meta]dim_ICD10_Gruppe1",
            // "[meta]dim_ICD10_Gruppe3",
            // "[meta]dim_ICD10_GruppeKID"
            // "[meta]dim_ICD10_GruppeEuropa",
            // "[meta]dim_ICD10_GruppeEuropa_2"
            };
        // var zfkd_offis_dwh = new List<object> { "sf_ops", "sf_protocol", "sf_substance" };
        // var zfkd_epi = new List<object> { new SqlSupportTableConnection("[02_original]_Union", "select top 10 * from [02_original]._Union TABLESAMPLE(2000 rows)") };

        // var local_testdb = new List<object> { "Imiras" };

        // internal network only
        if (Globals.HostType == StructureSupport.HostType.RKI_VIRTUAL)
        {
            zfkd_meta.ForEach(x => { convert(Globals.db_zfkd_meta_epi, x); });
            zfkd_qscore.ForEach(x => { convert(Globals.db_zfkd_qscore, x); });
            // zfkd_offis_dwh.ForEach(x => { convert(Globals.db_zfkd_offis_dwh, x); });
            //zfkd_epi.ForEach(x => { convert(Globals.db_zfkd_epi, x); });

        }

        // if (Globals.HostType == StructureSupport.HostType.OTHER ||
        //     Globals.HostType == StructureSupport.HostType.RKI_NOTEBOOK)
        // {
        //     local_testdb.ForEach(x => { convert(Globals.db_local_testdb, x); });
        // }
    }

    private static void convert(SqlSupportDbConnection dbCon, object tableCon)
    {
        var realTableCon = (tableCon is string) ? new SqlSupportTableConnection(tableCon.ToString()) : tableCon;
        (new ConverterObject()
        {
            DbConnection = dbCon,
            TableConnection = realTableCon as SqlSupportTableConnection
        })
        .ToCsvFromSqlTable()
        .ToFile();
    }

}
