using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_Fantasy_World_Spiel_
{
    internal class Program
    {
        public interface IMoveable
        {
            void Move();
        }

        public interface IShowable
        {
            void Show();
        }   
        static void Main(string[] args)
        {
            Wizard w = new Wizard("Merlin");
            Dragon d = new Dragon("Zeberus");

            while (Console.ReadKey().Key != ConsoleKey.Escape) 
            {
                Console.Clear();
                w.Move();        
                w.Show();

                d.Move();
                d.Show();
            }


        }
    }
}
