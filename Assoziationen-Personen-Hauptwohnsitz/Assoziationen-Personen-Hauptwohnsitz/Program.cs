using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assoziationen_Personen_Hauptwohnsitz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Adresse adressePerson1 = new Adresse("Musterstraße 1", "12a", 1212, "Musterstadt", "Wien");
            Person person1 = new Person(1, "Max", "Mustermann", "max.Mustermann@example.com", new DateTime(1990, 1, 1), adressePerson1);
            Console.WriteLine(person1);
        }
    }
}
