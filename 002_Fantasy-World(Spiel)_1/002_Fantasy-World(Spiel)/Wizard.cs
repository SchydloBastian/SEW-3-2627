using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_Fantasy_World_Spiel_
{
    sealed class Wizard : Character
    {
        public Wizard(string name) :base(name)
        {
            this.Color = ConsoleColor.Blue;
        }
        public override void Move()
        {

            int x = World.random.Next(0, 8);
            int dx = 0;
            int dy = 0;

            switch (x) 
            {

                case 0: dx = -1; dy = -1; break;
                case 1: dx = 0; dy = -1; break;
                case 2: dx = 1; dy = -1; break;
                case 3: dx = 1; dy = 0; break;
                case 4: dx = 1; dy = 1; break;
                case 5: dx = 0; dy = 1; break;
                case 6: dx = -1; dy = 1; break;
                case 7: dx = -1; dy = 0; break;

            }
            if (TargetInWorld(X + dx, Y + dy))
                { 
                    X = X + dx;
                    Y = Y + dy;
                }
        }

        public override void Show()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = Color;
            Console.Write(Name);
        }
    }
}
