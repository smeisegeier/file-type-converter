// See https://aka.ms/new-console-template for more information
using System.Net;
using Rki.CancerData.Clinical.TableConverter.App;
using Rki.CancerData.Clinical.TableConverter.App.BLL;


Globals.TargetDb = Globals.db_zfkd_qscore;

// Step0_fhirToJson.Start();
// Step0_xmlToJson.Start();
Step0_sqlTableToCsv.Start();

// Step1_jsonToCsv.Start();

// Step2_csvToSql.Start();

// Step2_jsonToSql.Start();

// Step3_sqlToSqlTable.Start();
//Step3_csvToJsonOut.Start();



Console.WriteLine("App done");

// ??? how to assign a sql table to server?
