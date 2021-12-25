using System;
using System.Collections.Generic;

namespace Arena1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior();
            Warrior warrior1 = new Warrior();
            Human human = new Human();
            Human human1 = new Human();

            warrior.TakeDamage(warrior1.Damage);

            List<Human> warriors = new List<Human>() { new Warrior(), new Warrior()};
            human = warriors[0];
            human1 = warriors[1];
            human.TakeDamage(human1.Damage);
            human1.TakeDamage(human.Damage);
        }
    }

    class Human
    {
        protected string name;
        protected int damage;
        protected int health;
        protected int armor;

        public int Damage
        {
            get
            {
                return damage;
            }
        }

        public virtual void TakeDamage(int value)
        {
            health -= value - armor;
        }

        public virtual void UseSkill(Human human)
        {

        }



        public virtual void DestroyArmor()
        {
            if (armor > 0)
            {
                Console.WriteLine($"{name} теряет немного брони");
                armor -= 5;
            }
            else
            {
                Console.WriteLine($"{name} совершенно без брони");
            }

            if (armor < 0)
            {
                armor = 0;
            }
        }
    }

    class Warrior : Human
    {
        public Warrior()
        {
            name = "WAR";
            damage = 312;
            health = 3500;
            armor = 40;
        }
      
        public override void TakeDamage(int value)
        {
            base.TakeDamage(value);
        }

        public override void DestroyArmor()
        {
            base.DestroyArmor();
        }

        public override void UseSkill(Human human)
        {
            Random random = new Random();
            int hitCount = random.Next(5);
            for (int  i = 0;  i < hitCount;  i++)
            {
                
            }
        }
    }


}
