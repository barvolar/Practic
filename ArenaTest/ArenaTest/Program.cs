using System;
using System.Collections.Generic;

namespace ArenaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena();
            arena.ShowAllFighters();
            arena.Pick();
            arena.FightHandler();
        }
    }

    //abstract class Human
    //{
    //    protected int HealthPoint;
    //    protected int Damage;
    //    protected int Armor;
    //    public int ARM { get; private set; }

    //    public abstract void TakeDamage(int value);
    //    public abstract void SSSS(Human human);

    //    public abstract void DestroyArmor();
    //    public abstract void Healing();

    //    public abstract int ReturnDamage();
    //    public abstract int ReturnArmor();
    //    public abstract int ReturnHealthPont();
    //}

    //class Rogue : Human
    //{
    //    public Rogue()
    //    {
    //        HealthPoint = 600;
    //        Damage = 340;
    //        Armor = 20;
    //    }

    //    public override void TakeDamage(int value)
    //    {
    //        HealthPoint -= value-Armor;
    //    }
    //    public override void SSSS(Human human)
    //    {
    //        human.DestroyArmor();
    //    }

    //    public override int ReturnArmor()
    //    {
    //        return Armor;
    //    }
    //    public override int ReturnDamage()
    //    {
    //        return Damage;
    //    }
    //    public override int ReturnHealthPont()
    //    {
    //        return HealthPoint;
    //    }
    //    public override void DestroyArmor()
    //    {
    //        Armor = 0;
    //    }
    //}

    //class Mage : Human
    //{
    //    public Mage()
    //    {
    //        HealthPoint = 800;
    //        Damage = 500;
    //        Armor = 2;
    //    }

    //    public override void TakeDamage(int value)
    //    {
    //        HealthPoint -= value-Armor;
    //    }

    //    public override int ReturnArmor()
    //    {
    //        return Armor;
    //    }
    //    public override int ReturnDamage()
    //    {
    //        return Damage;
    //    }
    //    public override int ReturnHealthPont()
    //    {
    //        return HealthPoint;
    //    }
    //    public override void DestroyArmor()
    //    {
    //        Armor = 0;
    //    }
    //}

    class Arena
    {
        private List<Human> _fighters;
        private Human _oneFighter;
        private Human _twoFighter;

        public Arena()
        {
            _fighters = new List<Human>();
            AddFighters();
        }


        public void FightHandler()
        {
            Random random = new Random();
            int numberRound = 1;
            while (_oneFighter.ReturnHP() > 0 &&   _twoFighter.ReturnHP() > 0)
            {
                Console.WriteLine("\nРаунд " + numberRound);
                ShowInfo();
                _oneFighter.Attack(_twoFighter);
                _twoFighter.Attack(_oneFighter);
                numberRound++;
                //Console.ReadKey();
            }
            if (_twoFighter.ReturnHP() <= 0 && _oneFighter.ReturnHP() <= 0)
            {
                Console.WriteLine("Все погибли");
            }
            else if (_oneFighter.ReturnHP() <= 0)
            {
                Console.WriteLine($"Побеждает {_twoFighter.ReturnName()}");
            }
            else if (_twoFighter.ReturnHP() <= 0)
            {
                Console.WriteLine($"Побеждает {_oneFighter.ReturnName()}");
            }
           
        }

        private void ShowInfo()
        {
            _oneFighter.ShowInfo();
            _twoFighter.ShowInfo();
        }
        public void Pick()
        {
            Console.WriteLine("Выберите бойца номер 1");
            PickHandler(out _oneFighter);
            Console.WriteLine("Выберите бойца номре 2 ");
            PickHandler(out _twoFighter);
        }
        public void ShowAllFighters()
        {
            for (int i = 0; i < _fighters.Count; i++)
            {
                Console.WriteLine($"{i+1} {_fighters[i].ReturnName()}");
            }
        }
        private void PickHandler(out Human human)
        {
            if ((Int32.TryParse(Console.ReadLine(), out int valueInput)) && valueInput > 0 && valueInput <= _fighters.Count)
            {
                human = _fighters[valueInput - 1];
            }
            else
            {
                Console.WriteLine("Ошибка ввода выбран боец под номером 1");
                human = _fighters[0];
            }
        }
        private void AddFighters()
        {
            _fighters.Add(new Warlok());
            _fighters.Add(new Warrior());
            _fighters.Add(new Rogue());
            _fighters.Add(new MadnesMage());
            _fighters.Add(new Paladin());
        }
    }

    class Human
    {
        protected string Name;
        protected int HP;
        protected int Damage;
        protected int Armor;

        public virtual void Attack(Human human)
        {
            Random random = new Random();
            if (random.Next(4) == 2)
            {
                Ability(human);
            }
            else
            {
                Hit(human);
            }
        }

        public virtual void Hit(Human human)
        {         
            if (human.Armor > 0)
            {
                human.HP -= Damage / human.Armor;
            }
            else
            {
                human.HP -= Damage;
            }
        }
    
        public virtual void DestroyArmor()
        {
            Armor = 0;
        }

        public virtual void Ability(Human human)
        {

        }
        public virtual void LifeDrine(Human human)
        {
            human.HP -= 300;
            HP += 300;
        }
        public virtual void ShowInfo()
        {
            Console.WriteLine($"{Name} : Количество жизни {HP}");
        }

        
        public virtual int ReturnHP()
        {
            return HP;
        }
        public virtual int ReturnArmor()
        {
            return Armor;

        }
        public virtual int ReturnDamage()
        {
            return Damage;
        }
        public virtual string ReturnName()
        {
            return Name;
        }
    }
    class Rogue : Human
    {

        public Rogue()
        {
            HP = 900;
            Armor = 30;
            Damage = 320;
            Name = "Rog";
        }

        public override void Attack(Human human)
        {
            base.Attack(human);
        }

        public override void Hit(Human human)
        {
            Console.WriteLine(Name+" Пытается убить оппонента");
            base.Hit(human);
        }

        public override void Ability(Human human)
        {
            Random random = new Random();
            int luck = random.Next(5);
            if (luck == 3 && human.ReturnArmor() > 0)
            {
                human.DestroyArmor();
                Console.WriteLine($"{Name} сломал вражескую броню");
            }
            else
            {
                Console.WriteLine("не удалось сломать вражескую броню");
            }

        }

        public override void DestroyArmor()
        {
            base.DestroyArmor();
        }
        public override int ReturnArmor()
        {
            return base.ReturnArmor();
        }
        public override int ReturnHP()
        {
            return base.ReturnHP();
        }
        public override int ReturnDamage()
        {
            return base.ReturnDamage();
        }
        public override string ReturnName()
        {
            return base.ReturnName();
        }
    }
    class Warrior : Human
    {

        public Warrior()
        {
            HP = 1453;
            Armor = 50;
            Damage = 226;
            Name = "War";
        }

        public override void Attack(Human human)
        {
            base.Attack(human);
        }
        public override void Hit(Human human)
        {
            Console.WriteLine(Name+" наносит удар");
            base.Hit(human);
        }

        public override void Ability(Human human)
        {
            Random random = new Random();
            int HitValue = random.Next(5);

            for (int i = 0; i < HitValue; i++)
            {
                human.Hit(human);
            }
            Console.WriteLine($"{Name} наносит комбинацию из {HitValue} ударов");
        }

        public override void DestroyArmor()
        {
            base.DestroyArmor();
        }
        public override int ReturnArmor()
        {
            return base.ReturnArmor();
        }
        public override int ReturnHP()
        {
            return base.ReturnHP();
        }
        public override int ReturnDamage()
        {
            return base.ReturnDamage();
        }
        public override string ReturnName()
        {
            return base.ReturnName();
        }
    }
    class Paladin : Human
    {
        public Paladin()
        {
            HP = 2000;
            Armor = 70;
            Damage = 150;
            Name = "Paladin";
        }

        public override void Attack(Human human)
        {
            
            base.Attack(human);
        }
        public override void Hit(Human human)
        {
            Console.WriteLine(Name + " бьёт");
            base.Hit(human);
        }

        public override void Ability(Human human)
        {
            HP += 250;
            if (HP > 2000)
            {
                HP = 2000;
            }
            Console.WriteLine($"{Name} исцеляется");
        }
        public override void DestroyArmor()
        {
            base.DestroyArmor();
        }
        public override int ReturnArmor()
        {
            return base.ReturnArmor();
        }
        public override int ReturnHP()
        {
            return base.ReturnHP();
        }
        public override int ReturnDamage()
        {
            return base.ReturnDamage();
        }
        public override string ReturnName()
        {
            return base.ReturnName();
        }
    }
    class Warlok : Human
    {
        public Warlok()
        {
            HP = 1200;
            Armor = 25;
            Damage = 140;
            Name = "Warlok";
        }
        public override void Attack(Human human)
        {
            base.Attack(human);
        }
        public override void Hit(Human human)
        {
            Console.WriteLine(Name+" стреляет адским пламенем");
            base.Hit(human);
        }


        public override void Ability(Human human)
        {
            Console.WriteLine($"{Name} вытягивает жизненную силу из оппонента");
            LifeDrine(human);
        }
      
        public override void DestroyArmor()
        {
            base.DestroyArmor();
        }
        public override int ReturnArmor()
        {
            return base.ReturnArmor();
        }
        public override int ReturnHP()
        {
            return base.ReturnHP();
        }
        public override int ReturnDamage()
        {
            return base.ReturnDamage();
        }
        public override string ReturnName()
        {
            return base.ReturnName();
        }
    }
    class MadnesMage : Human
    {
        public MadnesMage()
        {
            HP = 900;
            Armor = 30;
            Damage = 523;
            Name = "UEBAN";
        }
        public override void Attack(Human human)
        {
            base.Attack(human);
        }
        public override void Hit(Human human)
        {
            Console.WriteLine(Name+" бросает сгусток магической энергии в оппонента");
            base.Hit(human);
        }

        public override void Ability(Human human)
        {
            Random random = new Random();
            int Value = random.Next(5);
            switch (Value)
            {
                case 1:
                    human.LifeDrine(human);
                    Console.WriteLine($"{Name} думает что он варлок и сосёт жизни оппонента");
                    break;
                case 2:
                    human.DestroyArmor();
                    Console.WriteLine($"{Name} прикидывается разбойником и ломает броню оппоненту");
                    break;
                case 3:
                    Hit(human);
                    Hit(human);
                    Console.WriteLine($"{Name} считает себя войном , но силы хватает только на 2 удара");
                    break;
                case 4:
                    int value = 128;
                    while (value > 0)
                    {
                        Hit(human);
                        value--;
                    }
                    Console.WriteLine($"{Name} вспоминает что когда-то смотрел наруто и наносит 128 ударов небес");
                    break;
                case 5:
                    HP = 0;
                    Console.WriteLine($"{Name} почему-то умер");
                    break;
            }
        }

        public override void DestroyArmor()
        {
            base.DestroyArmor();
        }
        public override int ReturnArmor()
        {
            return base.ReturnArmor();
        }
        public override int ReturnHP()
        {
            return base.ReturnHP();
        }
        public override int ReturnDamage()
        {
            return base.ReturnDamage();
        }
        public override string ReturnName()
        {
            return base.ReturnName();
        }
    }
}
