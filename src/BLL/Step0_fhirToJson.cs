using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DextersLabor.Helper;
using Hl7.Fhir.Model;
using Rki.CancerData.Clinical.TableConverter.App;
using Rki.CancerData.Clinical.TableConverter.App.Models;

namespace Rki.CancerData.Clinical.TableConverter.App.BLL;

public class Step0_fhirToJson
{
    /// <summary>
    /// Fetches all given fhir res to json
    /// GetStoragePath is still needed, since using a conversion object here would be bloat
    /// </summary>

    public static void Start()
    {

        (new ConverterObject()
        {
            DbConnection = null,
            TableConnection = new SqlSupportTableConnection("dktk_GradingCS")
        })
        .ToJsonFromFhir("fdb03369-75c5-4f4f-92fb-8c64ee3eec91", Globals.URL_DKTK, typeof(CodeSystem))
        .ToFile();

        (new ConverterObject()
        {
            DbConnection = null,
            TableConnection = new SqlSupportTableConnection("dktk_FMLokalisationCS")
        })
        .ToJsonFromFhir("7d8c5d13-fe00-45f0-b145-acf8491a0e22", Globals.URL_DKTK, typeof(CodeSystem))
        .ToFile();

        (new ConverterObject()
        {
            DbConnection = null,
            TableConnection = new SqlSupportTableConnection("dktk_TNMTCS")
        })
        .ToJsonFromFhir("bdc639c4-0d8f-4cda-864c-ba560d46bd77", Globals.URL_DKTK, typeof(CodeSystem))
        .ToFile();

        (new ConverterObject()
        {
            DbConnection = null,
            TableConnection = new SqlSupportTableConnection("dktk_UiccstadiumCS")
        })
        .ToJsonFromFhir("44035ccf-89b8-4ffb-9e69-dbbd15774fa3", Globals.URL_DKTK, typeof(CodeSystem))
        .ToFile();

        (new ConverterObject()
        {
            DbConnection = null,
            TableConnection = new SqlSupportTableConnection("dktk_OPOPSVersionCS")
        })
        .ToJsonFromFhir("7d7476db-860e-4073-96d4-b16bcf532bc6", Globals.URL_DKTK, typeof(CodeSystem))
        .ToFile();

        (new ConverterObject()
        {
            DbConnection = null,
            TableConnection = new SqlSupportTableConnection("dktk_TNMMCS")
        })
        .ToJsonFromFhir("a90df76d-a1b0-405e-81b3-d674b4e0ab47", Globals.URL_DKTK, typeof(CodeSystem))
        .ToFile();

        (new ConverterObject()
        {
            DbConnection = null,
            TableConnection = new SqlSupportTableConnection("dktk_TNMNCS")
        })
        .ToJsonFromFhir("468c0b00-9fc6-43ea-9f0e-6f9d645bc258", Globals.URL_DKTK, typeof(CodeSystem))
        .ToFile();


        (new ConverterObject()
        {
            DbConnection = null,
            TableConnection = new SqlSupportTableConnection("hl7_TNM_T")
        })
        .ToJsonFromFhir("30dd8707-67b6-48df-8ca9-33ae316d40f5", Globals.URL_HL7, typeof(ValueSet))
        .ToFile();

        (new ConverterObject()
        {
            DbConnection = null,
            TableConnection = new SqlSupportTableConnection("hl7_TNM_UICC")
        })
        .ToJsonFromFhir("2726d0da-7f8a-4456-ae28-94e6d45de678", Globals.URL_HL7, typeof(ValueSet))
        .ToFile();

    }

}
