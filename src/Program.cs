// See https://aka.ms/new-console-template for more information
using System.Net;
using Rki.CancerData.Clinical.TableConverter.App;
using Rki.CancerData.Clinical.TableConverter.App.BLL;



Globals.TargetDb = Globals.db_zfkd_meta_clin;

Console.WriteLine("App started on " + Globals.HostType);


// Step0_fhirToJson.Start();
// Step0_xmlToJson.Start();
// Step0_sqlTableToCsv.Start();

// Step1_jsonToCsv.Start();

Step2_csvToSql.Start("meta");
// Step2_jsonToSql.Start("meta");

// todo still buggy when table already exists? -> move sql drop statement w/ schema to dexterslab
Step3_sqlToSqlTable.Start();


// Step3_csvToJsonOut.Start();

Console.WriteLine("App done");
