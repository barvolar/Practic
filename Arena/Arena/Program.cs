//using System;
//using System.Collections.Generic;

//namespace Arena
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Arena arena = new Arena();
//            arena.PickFighter();
//            arena.ShowInfo();
//            arena.Test();
//            arena.ShowInfo();
//        }
//    }

//    class Arena
//    {
//        private List<Human> _fighters;
//        private Human _oneFighter;
//        private Human _twoFighter;

//        public Arena()
//        {
//            _fighters = new List<Human>();
//            CreateFighters();
//        }

//        public void PickFighter()
//        {
//            Console.WriteLine("выберите первого бойца");
//            PickHandler(out _oneFighter);
//            Console.WriteLine("выберите второго бойца");
//            PickHandler(out _twoFighter);
//        }

//        public void FightHandler()
//        {
//            while (_oneFighter.ReturnHealth()>0||_twoFighter.ReturnHealth()>0)
//            {
//                _oneFighter.TakeDamage(_twoFighter.ReturnDamage());
//                _twoFighter.TakeDamage(_oneFighter.ReturnDamage());              
//            }
//            if (_oneFighter.ReturnHealth() < 0)
//            {
//                Console.WriteLine("победил второй боец");
//            }
//            else
//            {
//                Console.WriteLine("победил первый боец");
//            }
//        }

//        public void ShowInfo()
//        {
//            _oneFighter.ChekINfo();
//            _twoFighter.ChekINfo();
//        }

//        private void PickHandler(out Human fighter)
//        {
//            if (Int32.TryParse(Console.ReadLine(), out int valueInput) && valueInput >= 0 && valueInput <= _fighters.Count)
//            {
//                fighter = _fighters[valueInput - 1];
//            }
//            else
//            {
//                Console.WriteLine("Ошибка ввода, выбран первый боец");
//                fighter = _fighters[0];
//            }
//        }

//        private void CreateFighters()
//        {
//            _fighters.Add(new Warrior());
//            _fighters.Add(new Rogue());
//        }

//        public void Test()
//        {
//            _oneFighter.UseSkill(_twoFighter);
//        }
//    }

//    class Human
//    {
//        protected string name;
//        protected int damage;
//        protected int healthPoint;
//        protected int armor;

//        public int Damage { get; protected set; }
//        public int Health { get; protected set; }
//        public int Armor { get; protected set; }

//        public Human()
//        {
//            Damage = damage;
//            Health = healthPoint;
//            Armor = armor;
//        }

//        public virtual void ChekINfo()
//        {
//            Console.WriteLine($"{name}: \nурон - {damage}\nжизни - {healthPoint}");
//        }

//        public virtual int ReturnDamage()
//        {
//            return damage;
//        }

//        public virtual int ReturnHealth()
//        {
//            return healthPoint;
//        }

//        public virtual void UseSkill(Human human)
//        {
            
//        }

//        public virtual void TakeDamage(int damageValue)
//        {
//            healthPoint -= damageValue / armor;
//        }
//    }

//    class Warrior : Human
//    {
//        public Warrior()
//        {
//            name = "war";
//            damage = 100;
//            healthPoint = 500;
//            armor = 10;
//            Health = healthPoint;
//        }

//        public override void TakeDamage(int damageValue)
//        {
//            base.TakeDamage(damageValue);
//        }

//        public override void UseSkill(Human human)
//        {
            
//        }

//        public override int ReturnDamage()
//        {
//            return base.ReturnDamage();
//        }

//        public override int ReturnHealth()
//        {
//            return base.ReturnHealth();
//        }

//        public override void ChekINfo()
//        {
//            base.ChekINfo();
//        }
//    }

//    class Rogue : Human
//    {

//        public int HealthPoint { get; private set; }

//        public Rogue()
//        {
//            name = "rog";
//            damage = 210;
//            healthPoint = 300;
//            armor = 6;

//            HealthPoint = healthPoint;
//        }

//        public override void TakeDamage(int damageValue)
//        {
//            base.TakeDamage(damageValue);
//        }

//        public override int ReturnDamage()
//        {
//            return base.ReturnDamage();
//        }
//        public override int ReturnHealth()
//        {
//            return base.ReturnHealth();
//        }

//        public override void ChekINfo()
//        {
//            base.ChekINfo();
//        }
//    }
//}
