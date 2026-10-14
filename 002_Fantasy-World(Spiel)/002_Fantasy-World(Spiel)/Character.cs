using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _002_Fantasy_World_Spiel_.Program;

namespace _002_Fantasy_World_Spiel_
{
    abstract class Character : IMoveable, IShowable
    {
        public ConsoleColor Color {  get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public string Name { get; set; }

        public Character(string name) 
        { 
            this.Name = name;
            X = World.random.Next(0, World.WIDTH);
            Y = World.random.Next(0, World.HEIGHT);
        }

        public abstract void Move();

        public abstract void Show();

        public bool TargetInWorld(int x, int y) 
        {
            if (x >= 0 && y >= 0 && x < World.WIDTH && y < World.HEIGHT) return true;            
            return false;
        }
    }
}
