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
        public string Name { get; protected set; }
        public int Damage { get; protected set; }
        public int Health { get; protected set; }
        public int Armor { get; protected set; }
        public int Speed { get; protected set; }
        public bool IsAlive => Health > 0;

        public virtual void TakeDamage(int value)
        {
            Health -= value - Armor;
        }

        public virtual void UseSkill(Human human)
        {
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"{Name}: hp - {Health}, armor - {Armor}, damage - {Damage}");
        }

        public virtual void TakeDamageThrougArmor(int value)
        {
            Health -= value;
        }

        public virtual void DestroyArmor()
        {
            int armorCount = 5;

            if (Armor > 0)
            {
                Console.WriteLine($"{Name} теряет немного брони");
                Armor -= armorCount;
            }
            else
            {
                Console.WriteLine($"{Name} совершенно без брони");
            }

            if (Armor < 0)
            {
                Armor = 0;
            }
        }
    }

    class Warrior : Human
    {
        public Warrior()
        {
            Name = "WAR";
            Damage = 312;
            Health = 3500;
            Armor = 40;
            Speed = 2;
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
            int chance = 5;
            int hitCount = random.Next(chance);

            Console.WriteLine($"{Name} наносит {hitCount} быстрых удара(ов)");

            for (int i = 0; i < hitCount; i++)
            {
                human.TakeDamage(Damage);
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
            Name = "rog";
            Health = 2200;
            Damage = 520;
            Armor = 33;
            Speed = 7;
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
        private int _maxHealth;
        private int _healingPower;
        public Paladin()
        {
            Name = "Pal";
            Damage = 180;
            Armor = 50;
            Health = 4000;
            Speed = 1;
            _maxHealth = Health;
            _healingPower = 500;
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
            Console.WriteLine($"{Name} исцеляется");
            Health += _healingPower;

            if (Health > _maxHealth)
            {
                Health = _maxHealth;
            }
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }
    }

    class Warlock : Human
    {
        private int _lifeDrinePower;

        public Warlock()
        {
            Name = "warlock";
            Damage = 200;
            Armor = 15;
            Health = 2000;
            Speed = 5;
            _lifeDrinePower = 200;
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
            Console.WriteLine($"{Name} вытягивает жизненную силу");
            human.TakeDamageThrougArmor(_lifeDrinePower);
            Health += _lifeDrinePower;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }
    }

    class Assasin : Human
    {
        private int _superDamage;

        public Assasin()
        {
            Name = "assasin";
            Damage = 400;
            Armor = 35;
            Health = 2100;
            Speed = 10;
            _superDamage = 9999999;
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
            int chanceCount = 7;
            int valueSuccess = 3;
            int chance = random.Next(chanceCount);

            if (chance == valueSuccess)
            {
                Console.WriteLine($"{Name} наносит смертельный удар");
                human.TakeDamageThrougArmor(_superDamage);
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
            PickHandler(out _oneFighter, _twoFighter);

            Console.WriteLine("Выберите второго бойца");
            PickHandler(out _twoFighter, _oneFighter);

            FightHandler();
        }

        private void PickHandler(out Human chosenhuman, Human enemyHuman)
        {
            if (Int32.TryParse(Console.ReadLine(), out int userInput) && userInput <= _fighters.Count && userInput > 0 && enemyHuman != _fighters[userInput - 1])
            {
                chosenhuman = _fighters[userInput - 1];
            }
            else
            {
                Console.WriteLine("Ошибка ввода или боец уже вабран, выберите другого");
                PickHandler(out chosenhuman, enemyHuman);
            }
        }

        private void FightHandler()
        {
            Console.Clear();

            while (_oneFighter.IsAlive && _twoFighter.IsAlive)
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
            if (_oneFighter.IsAlive == false && _twoFighter.IsAlive == false)
            {
                Console.WriteLine("Оба бойца проиграли");
            }

            if (_oneFighter.IsAlive == false)
            {
                Console.WriteLine("Побеждает " + _twoFighter.Name);
            }

            if (_twoFighter.IsAlive == false)
            {
                Console.WriteLine("Побеждает " + _oneFighter.Name);
            }
        }
    }
}
