using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_Fantasy_World_Spiel_
{
    internal abstract class Bonus 
    {
        public int X { get; }
        public int Y { get; }
        public int Value { get; set; }

        public Bonus()
        {
            Value = 1;
            X = World.random.Next(0, World.WIDTH);
            Y = World.random.Next(0, World.HEIGHT);
        }

        public virtual void Show()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("B");
        }

    }
}
