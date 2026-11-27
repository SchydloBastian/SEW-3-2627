using System;

namespace _002_Fantasy_World_Spiel_
{
    class Dragon : Character
    {
        public Dragon(string name) : base(name)
        {
            Color = ConsoleColor.Green;
        }
        public override void Move()
        {

            int randomDirection = World.random.Next(0, 2);
            int distance = World.random.Next(-2, 3);
            int dx = 0;
            int dy = 0;

            if (randomDirection == 0) // horizontal movement
            {
                X += distance;
            }

            
            else // vertical movement
            {
                Y += distance;
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

