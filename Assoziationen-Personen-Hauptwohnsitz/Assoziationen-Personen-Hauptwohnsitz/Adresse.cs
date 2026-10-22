using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assoziationen_Personen_Hauptwohnsitz
{
    internal class Adresse
    {
        public string Strasse { get; set; }
        public string Hausnummer { get; set; }
        public int PLZ { get; set; }
        public string Ort { get; set; }
        public string Bundesland { get; set; }
        public string Land { get; set; } = "Österreich";


        public Adresse()
        {
           
        }

        public Adresse(string strasse, string hausnummer, int plz, string ort, string bundesland, string land = "Österreich")
        {
            if (strasse == null || hausnummer == null || plz == null || ort == null || bundesland == null)
            {
                throw new ArgumentException("Alle Parameter müssen angegeben werden.");
            }

            else
            {
                Strasse = strasse;
                Hausnummer = hausnummer;
                Ort = ort;
                Bundesland = bundesland;
                Land = land;

                if (plz > 1000 && plz < 9999)
                {
                    PLZ = plz;
                }
                else
                {
                    throw new ArgumentException("Die PLZ muss zwischen 1000 und 9999 liegen.");
                }
            }     
        }

        public override string ToString()
        {
            return $"{Strasse} {Hausnummer}, {PLZ} {Ort}, {Bundesland}, {Land}";
        }
    }
}
