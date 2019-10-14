using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;

namespace RPH.Oftamed
{
    partial class DBConnection
    {
        public static void GetListItems()
        {
            string json = new WebClient().DownloadString("http://corectie-pio.ro/db.php");
            ListaMedicamente = JsonConvert.DeserializeObject<List<Medicament>>(json);

            /*ListaMedicamente.Add(new Medicament()
            {
                Ghid = "Ghid medicamente antiglaucomentoase",
                Tip = "Analogi de prostaglandine",
                Crt = "a",
                Substanta = "b",
                FormaFarmaceutica = "c",
                DenumireComerciala = "d",
                CoplataPacient = "e",
                PretFarmacie = "f",
                CompanieProducatoare = "g",
                ModDeActiune = "h",
                ReducereIop = "i",
                ContraIndicatii = "j",
                EfecteAdverse = "k",
            });*/
        }
    }
}
