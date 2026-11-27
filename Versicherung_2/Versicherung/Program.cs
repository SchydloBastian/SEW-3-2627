using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versicherung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Versicherungsgesellschaft allianz = new Versicherungsgesellschaft("Allianz Versicherung");
            Versicherungsgesellschaft generali = new Versicherungsgesellschaft("Generali Versicherung");

            Person p1 = new Person("Max", "Mustermann");
            Person p2 = new Person("Erika", "Musterfrau");
            Person p3 = new Person("Lukas", "Huber");
            Person p4 = new Person("Sarah", "Gruber");
            Person p5 = new Person("Jonas", "Bauer");

            Versicherungsvertrag v1 = new Versicherungsvertrag("ALZ-1001", allianz, p1);
            v1.AddMitversicherter(p2);

            Versicherungsvertrag v2 = new Versicherungsvertrag("ALZ-1002", allianz, p3);
            v2.AddMitversicherter(p1);

            Versicherungsvertrag v3 = new Versicherungsvertrag("GEN-2001", generali, p4);
            v3.AddMitversicherter(p5);

            Versicherungsvertrag v4 = new Versicherungsvertrag("GEN-2002", generali, p2);
        }
    }
}
