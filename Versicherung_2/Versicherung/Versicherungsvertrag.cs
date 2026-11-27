using System;
using System.Collections.Generic;

namespace Versicherung
{
    internal class Versicherungsvertrag
    {
        private Versicherungsgesellschaft versicherungsgesellschaft;
        private Person versicherungsnehmer;
        private List<Person> mitversicherte;

        public string Vertragsnummer { get; set; }
        public Versicherungsgesellschaft Versicherungsgesellschaft => versicherungsgesellschaft;
        public Person Versicherungsnehmer => versicherungsnehmer;
        public List<Person> Mitversicherte => mitversicherte;

        public Versicherungsvertrag(string vertragsnummer, Versicherungsgesellschaft gesellschaft, Person versicherungsnehmer)
        {
            Vertragsnummer = vertragsnummer;
            this.versicherungsgesellschaft = gesellschaft ?? throw new ArgumentNullException(nameof(gesellschaft));
            this.versicherungsnehmer = versicherungsnehmer ?? throw new ArgumentNullException(nameof(versicherungsnehmer));
            this.mitversicherte = new List<Person>();

            gesellschaft.AddVertrag(this);
            versicherungsnehmer.AddVersicherung(this);
        }

        public void AddMitversicherter(Person person)
        {
            if (person == null) return;

            if (person == versicherungsnehmer)
            {
                throw new InvalidOperationException("Der Versicherungsnehmer kann nicht gleichzeitig Mitversicherter im selben Vertrag sein (XOR-Regel).");
            }

            if (!mitversicherte.Contains(person))
            {
                mitversicherte.Add(person);
                person.AddMitversichert(this);
            }
        }

    }
}
