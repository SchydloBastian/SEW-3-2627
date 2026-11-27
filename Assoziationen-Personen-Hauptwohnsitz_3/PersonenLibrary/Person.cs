using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PersonenLibrary
{
    public class Person
    {
        public int ID { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Email { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public Adresse Hauptwohnsitz { get; set; }

        public Person() { }

        public Person(int id, string vorname, string nachname, string email, DateTime geburtsdatum, Adresse hauptwohnsitz)
        {
            if (string.IsNullOrWhiteSpace(vorname) || string.IsNullOrWhiteSpace(nachname))
                throw new ArgumentException("Vorname und Nachname müssen angegeben werden.");

            if (hauptwohnsitz == null)
                throw new ArgumentException("Hauptwohnsitz muss angegeben werden.");

            ID = id;
            Vorname = vorname;
            Nachname = nachname;
            Email = email;
            Geburtsdatum = geburtsdatum;
            Hauptwohnsitz = hauptwohnsitz;
        }

        public override string ToString()
        {
            return $"{Vorname} {Nachname}";
        }
    }
}