using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DextersLabor.Helper;

namespace Rki.CancerData.Clinical.TableConverter.App;

public static class Globals
{
    public static StructureSupport.HostType HostType = ReflectionSupport.GetHostNameType(ReflectionSupport.GetHostName());

    public static SqlSupportDbConnection TargetDb { get; set; }

    public const string PATHSUFFIX_FILESDIR = "temp";       // where to process the data
    public const string URL_DKTK = "https://fhir.simplifier.net/oncology";
    public const string URL_HL7 = "https://fhir.simplifier.net/r4";
    public readonly static string? SERVER_RKI_PROD = System.Configuration.ConfigurationManager.AppSettings.Get("server_rki_prod");
    public readonly static string? SERVER_RKI_TEST = System.Configuration.ConfigurationManager.AppSettings.Get("server_rki_test");


    public static SqlSupportDbConnection db_zfkd_qscore { get; private set; } = new SqlSupportDbConnection("Qscore", Globals.SERVER_RKI_PROD);
    public static SqlSupportDbConnection db_local_testdb { get; private set; } = new SqlSupportDbConnection("TestDb");
    public static SqlSupportDbConnection db_zfkd_fhirmeta { get; private set; } = new SqlSupportDbConnection("FhirMeta", Globals.SERVER_RKI_PROD);
    public static SqlSupportDbConnection db_zfkd_offis_dwh { get; private set; } = new SqlSupportDbConnection("KKrModel_RKI", Globals.SERVER_RKI_PROD);
    public static SqlSupportDbConnection db_zfkd_caress { get; private set; } = new SqlSupportDbConnection("CARESS9100_2021", Globals.SERVER_RKI_PROD);
    public static SqlSupportDbConnection db_zfkd_epi { get; private set; } = new SqlSupportDbConnection("ZfkdEpi2022", Globals.SERVER_RKI_PROD);
    public static SqlSupportDbConnection db_zfkd_meta { get; private set; } = new SqlSupportDbConnection("ZfkdMeta2022", Globals.SERVER_RKI_PROD);

}
