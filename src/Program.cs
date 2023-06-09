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

// Step2_csvToSql.Start("sf");
// Step2_jsonToSql.Start("meta");

// todo still buggy when table already exists?
Step3_sqlToSqlTable.Start();


// Step3_csvToJsonOut.Start();

Console.WriteLine("App done");
