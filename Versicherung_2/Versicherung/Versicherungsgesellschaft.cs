using System.Collections.Generic;

namespace Versicherung
{
    internal class Versicherungsgesellschaft
    {
        private List<Versicherungsvertrag> vertraege;

        public string Name { get; set; }
        public List<Versicherungsvertrag> Vertraege => vertraege;

        public Versicherungsgesellschaft(string name)
        {
            Name = name;
            vertraege = new List<Versicherungsvertrag>();
        }

        public void AddVertrag(Versicherungsvertrag vertrag)
        {
            if (vertrag != null && !vertraege.Contains(vertrag))
            {
                vertraege.Add(vertrag);
            }
        }

    }
}
