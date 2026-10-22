using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assoziationen_Personen_Hauptwohnsitz
{
    internal class Person : Adresse
    {
        public int ID { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Email { get; set; }
        public DateTime Geburtsdatum { get; set; }

        public Adresse Hauptwohnsitz { get; set; }

        public Person()
        {
          
        }

        public Person(int id, string vorname, string nachname, string email, DateTime geburtsdatum, Adresse hauptwohnsitz)
        {
            if (!string.IsNullOrWhiteSpace(email) && email.Contains("@") == true && hauptwohnsitz != null && geburtsdatum < DateTime.Now)
            {
                ID = id;
                Vorname = vorname;
                Nachname = nachname;
                Email = email;
                Geburtsdatum = geburtsdatum;
                Hauptwohnsitz = hauptwohnsitz;
            }
            else
            {
                throw new ArgumentException("Ungültige E-Mail-Adresse oder Hauptwohnsitz nicht angegeben.");
            }
            
        }

        public int BerecheAlter()
        {
            string[] datums = Geburtsdatum.ToString("dd.MM.yyyy").Split('.');
            int tag = Convert.ToInt32(datums[0]);
            int monat = Convert.ToInt32(datums[1]);
            int jahr = Convert.ToInt32(datums[2]);

            DateTime heute = DateTime.Now;
            int alter = heute.Year - jahr;   

            if (heute.Month < monat || (heute.Month == monat && heute.Day < tag))
            {
                alter--;
            }

            return alter; 
        }

        public string VollerName()
        {
            return $"{Vorname} {Nachname}";
        }
        public override string ToString()
        {
            return $"ID: {ID}, Name: {Vorname} {Nachname}, Email: {Email}, Geburtsdatum: {Geburtsdatum.ToString("dd.MM.yyyy")}, Hauptwohnsitz: {Hauptwohnsitz}";
        }

    }
}