using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DextersLabor.Helper;

namespace Rki.CancerData.Clinical.TableConverter.App;

public static class Globals
{
    public static StructureSupport.HostType HostType = ReflectionSupport.GetHostNameType(ReflectionSupport.GetHostName());

    public const string PATHSUFFIX_FILESDIR = "temp";
    public const string URL_DKTK = "https://fhir.simplifier.net/oncology";
    public const string URL_HL7 = "https://fhir.simplifier.net/r4";
    public readonly static string? SERVER_PROD = System.Configuration.ConfigurationManager.AppSettings.Get("server_prod");
    public readonly static string? SERVER_TEST = System.Configuration.ConfigurationManager.AppSettings.Get("server_test");


    public static SqlSupportDbConnection db_zfkd_qscore = new SqlSupportDbConnection("Qscore", Globals.SERVER_PROD);
    public static SqlSupportDbConnection db_local_testdb = new SqlSupportDbConnection("TestDb");
    public static SqlSupportDbConnection db_zfkd_fhirmeta = new SqlSupportDbConnection("FhirMeta", Globals.SERVER_PROD);
    public static SqlSupportDbConnection db_zfkd_offis_dwh = new SqlSupportDbConnection("KKrModel_RKI", Globals.SERVER_PROD);
    public static SqlSupportDbConnection db_zfkd_caress = new SqlSupportDbConnection("CARESS9100_2021", Globals.SERVER_PROD);
    public static SqlSupportDbConnection db_zfkd_epi = new SqlSupportDbConnection("ZfkdEpi2022", Globals.SERVER_PROD);
    public static SqlSupportDbConnection db_zfkd_meta = new SqlSupportDbConnection("ZfkdMeta2022", Globals.SERVER_PROD);

}
