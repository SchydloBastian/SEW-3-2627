using System.Collections.Generic;

namespace Versicherung
{
    internal class Person
    {
        private List<Versicherungsvertrag> versicherungen;
        private List<Versicherungsvertrag> mitversicherter;

        public string Vorname { get; set; }
        public string Nachname { get; set; }

        public List<Versicherungsvertrag> Versicherungen => versicherungen;
        public List<Versicherungsvertrag> Mitversicherter => mitversicherter;

        public Person(string vorname, string nachname)
        {
            Vorname = vorname;
            Nachname = nachname;
            versicherungen = new List<Versicherungsvertrag>();
            mitversicherter = new List<Versicherungsvertrag>();
        }

        public void AddVersicherung(Versicherungsvertrag vertrag)
        {
            if (vertrag != null && !versicherungen.Contains(vertrag))
            {
                versicherungen.Add(vertrag);
            }
        }

        public void AddMitversichert(Versicherungsvertrag vertrag)
        {
            if (vertrag != null && !mitversicherter.Contains(vertrag))
            {
                mitversicherter.Add(vertrag);
            }
        }

    }
}
