// See https://aka.ms/new-console-template for more information
using System.Net;
using Rki.CancerData.Clinical.TableConverter.App;
using Rki.CancerData.Clinical.TableConverter.App.BLL;


// Step0_fhirToJson.Start();
// Step0_xmlToJson.Start();
// Step0_sqlTableToCsv.Start();

// Step1_jsonToCsv.Start();

Step2_csvToSql.Start(Globals.db_zfkd_fhirmeta);

// Step2_jsonToSql.Start();

// Step3_sqlToSqlTable.Start(Globals.db_zfkd_fhirmeta);
//Step3_csvToJsonOut.Start();



Console.WriteLine("App done");

// todo how to assign a sql table to server?
