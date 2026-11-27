using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonenLibrary
{
    public class Adresse
    {
        public int Id { get; set; }
        public string Strasse { get; set; }
        public string Hausnummer { get; set; }
        public int PLZ { get; set; }
        public string Ort { get; set; }
        public string Bundesland { get; set; }
        public string Land { get; set; } = "Österreich";

        public Adresse() { }

        public Adresse(int id, string strasse, string hausnummer, int plz, string ort, string bundesland = "Niederösterreich", string land = "Österreich")
        {
            if (string.IsNullOrWhiteSpace(strasse) || string.IsNullOrWhiteSpace(ort))
                throw new ArgumentException("Straße und Ort müssen angegeben werden.");

            if (plz < 1000 || plz > 9999)
                throw new ArgumentException("Die PLZ muss zwischen 1000 und 9999 liegen.");

            Id = id;
            Strasse = strasse;
            Hausnummer = hausnummer;
            PLZ = plz;
            Ort = ort;
            Bundesland = bundesland;
            Land = land;
        }

        public override string ToString()
        {
            string strasseKomplett = string.IsNullOrWhiteSpace(Hausnummer) ? Strasse : $"{Strasse} {Hausnummer}";
            return $"{strasseKomplett}, {PLZ} {Ort}";
        }
    }
}