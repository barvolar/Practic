using System;
using System.Collections.Generic;

namespace ArenaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Human> humans = new List<Human>();

            for (int i = 0; i < humans.Count; i++)
            {
                humans[i].ShowInfo();
            }
        }


    }

    class Human
    {
        protected string name;
        protected int hp;
        protected int damage;
        protected int armor;

        public virtual void ShowInfo()
        {
            Console.WriteLine($"name - {name}||||||||||||||||hp - {hp}");
        }

        public virtual void TakeDamage(Human human)
        {
            hp -= human.damage - armor;
        }
    }

    
}
