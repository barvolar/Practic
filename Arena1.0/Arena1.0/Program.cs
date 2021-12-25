using System;
using System.Collections.Generic;

namespace Arena1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena();
            arena.ShowMenu();
        }
    }

    class Human
    {
        protected string name;
        protected int damage;
        protected int health;
        protected int armor;
        protected int speed;

        public string Name
        {
            get
            {
                return name;
            }
        }
        public int Damage
        {
            get
            {
                return damage;
            }
        }
        public int Speed
        {
            get
            {
                return speed;
            }
        }
        public int Health
        {
            get
            {
                return health;
            }
        }

        public virtual void TakeDamage(int value)
        {
            health -= value - armor;
        }
        public virtual void UseSkill(Human human)
        {
        }
        public virtual void ShowInfo()
        {
            Console.WriteLine($"{name}: hp - {health}, armor - {armor}, damage - {damage}");
        }
        public virtual void TakeDamageThrougArmor(int value)
        {
            health -= value;
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
            speed = 2;
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
            Console.WriteLine($"{name} наносит {hitCount} быстрых удара(ов)");
            for (int i = 0; i < hitCount; i++)
            {
                human.TakeDamage(damage);
            }
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
        }
    }

    class Rogue : Human
    {
        public Rogue()
        {
            name = "rog";
            health = 2200;
            damage = 520;
            armor = 33;
            speed = 7;
        }

        public override void DestroyArmor()
        {
            base.DestroyArmor();
        }
        public override void TakeDamage(int value)
        {
            base.TakeDamage(value);
        }
        public override void UseSkill(Human human)
        {
            human.DestroyArmor();
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
        }
    }

    class Paladin : Human
    {
        public Paladin()
        {
            name = "Pal";
            damage = 180;
            armor = 50;
            health = 4000;
            speed = 1;
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
            Console.WriteLine($"{name} исцеляется");
            health += 300;
            if (health > 4000)
            {
                health = 4000;
            }
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
        }
    }

    class Warlock : Human
    {
        public Warlock()
        {
            name = "warlock";
            damage = 200;
            armor = 15;
            health = 2000;
            speed = 5;
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
            Console.WriteLine($"{name} вытягивает жизненную силу");
            human.TakeDamageThrougArmor(200);
            health += 200;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
        }
    }

    class Assasin : Human
    {
        public Assasin()
        {
            name = "assasin";
            damage = 400;
            armor = 35;
            health = 2100;
            speed = 10;
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
            int chance = random.Next(7);
            if (chance == 3)
            {
                Console.WriteLine($"{name} наносит смертельный удар");
                human.TakeDamageThrougArmor(99999);
            }
            else
            {
                Console.WriteLine("Смертельный удар не удался");
            }
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
        }
    }

    class Arena
    {
        private List<Human> _fighters;
        private Human _oneFighter;
        private Human _twoFighter;

        public Arena()
        {
            _fighters = new List<Human>();
            CreateFighters();
        }

        public void ShowMenu()
        {
            int number = 1;
            foreach (var fighter in _fighters)
            {
                Console.Write(number + ": ");
                fighter.ShowInfo();
                number++;
            }
            Console.WriteLine("Выберите первого бойца");
            PickHandler(out _oneFighter);
            Console.WriteLine("Выберите второго бойца");
            PickHandler(out _twoFighter);
            FightHandler();

        }

        private void PickHandler(out Human human)
        {
            if (Int32.TryParse(Console.ReadLine(), out int userInput) && userInput <= _fighters.Count && userInput > 0)
            {
                human = _fighters[userInput - 1];
            }
            else
            {
                Console.WriteLine("Ошибка ввода");
                PickHandler(out human);
            }
        }

        private void FightHandler()
        {
            Console.Clear();
            Random random = new Random();
            while (_oneFighter.Health > 0 && _twoFighter.Health > 0)
            {
                _oneFighter.ShowInfo();
                _twoFighter.ShowInfo();
                Console.WriteLine();
                if (_oneFighter.Speed > _twoFighter.Speed)
                {
                    Attack(_oneFighter, _twoFighter);
                    Attack(_twoFighter, _oneFighter);
                }
                else
                {
                    Attack(_twoFighter, _oneFighter);
                    Attack(_oneFighter, _twoFighter);
                }
            }
            WinHandler();                      
        }

        private void Attack(Human hittingHuman, Human receivingHuman)
        {
            Random random = new Random();
            int chance = random.Next(5);

            if (chance == 2)
            {
                hittingHuman.UseSkill(receivingHuman);
            }
            else
            {
                Console.WriteLine(hittingHuman.Name + " атакует, сила атаки = " + hittingHuman.Damage);
                receivingHuman.TakeDamage(hittingHuman.Damage);
            }
        }

        private void CreateFighters()
        {
            _fighters.Add(new Warlock());
            _fighters.Add(new Rogue());
            _fighters.Add(new Paladin());
            _fighters.Add(new Warrior());
            _fighters.Add(new Assasin());
        }
        private void WinHandler()
        {
            if (_oneFighter.Health < 0 && _twoFighter.Health < 0)
            {
                Console.WriteLine("Оба бойца проиграли");
            }
            if (_oneFighter.Health < 0)
            {
                Console.WriteLine("Побеждает " + _twoFighter.Name);
            }
            if (_twoFighter.Health < 0)
            {
                Console.WriteLine("Побеждает " + _oneFighter.Name);
            }
        }
    }
}
