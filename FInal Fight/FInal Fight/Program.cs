using System;

namespace FInal_Fight
{
    class Program
    {
        static void Main(string[] args)
        {
            int userHealth = 100;
            int userDamage = 12;
            int userHealing = 50;
            int userFireball = 70;
            bool userAstralForm = false;
            int userAstralFormTimer = 5;
            string userChoice;


            Random rand = new Random();

            int enemyHealth = 1001;
            int enemyDamage = 20;

            int enemyStrongAttack = 2;
            bool enemyCurse = false;
            int enemyMegaPowerBang = 70;
            int enemyBangCurse = 3;
            int changingDamage = 4;

            Console.WriteLine("Перед вами враг , деритесь \n 1 - атака \n 2 - исцеление \n 3 - огненный шар \n 4 - астральная форма");
            while (enemyHealth > 0 && userHealth > 0)
            {
                if (userAstralForm == true) userAstralFormTimer--;
                if (userAstralFormTimer <= 0)
                {
                    userAstralForm = false;
                    userAstralFormTimer = 5;
                }
                Console.WriteLine("\nHP= " + userHealth + " \nDamage= " + userDamage+ " \nAstralForm= "+userAstralForm);
                Console.WriteLine("Вы атакуете ");
                userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        enemyHealth -= userDamage;
                        Console.WriteLine("Вы нанесли " + userDamage + " урона");
                        break;
                    case "2":
                        userHealth += userHealing;
                        Console.WriteLine("Вы исцелили себе " + userHealing + " едениц, теперь у вас " + userHealth + " здоровья");
                        break;
                    case "3":
                        if (userAstralForm == false)
                        {
                            enemyHealth -= userFireball;
                            Console.WriteLine("FIREBALL наносит врагу " + userFireball + " урона");
                        }
                        else
                        {
                            Console.WriteLine("Ваш FIREBALL превращается в SUPERASTRALLLLNIFAERBALLLL и наносит двойной урон");
                            enemyHealth -= (userFireball * 2);
                        }
                        break;
                    case "4":
                        if (userAstralForm == false && userHealth <= 50 && userAstralFormTimer == 5)
                        {
                            userAstralForm = true;
                            Console.WriteLine("АСТРАЛЬНАЯ ФОРМА ВКЛЮЧЕНА !!!!!!!!!!");
                            userHealth += userHealing;
                            Console.WriteLine("ВОСТОНОВЛЕНО " + userHealing + " ЗДОРОВЬЯ!!!!!");
                            userDamage += enemyDamage;
                            Console.WriteLine("ВАШ УРОН УВЕЛИЧЕН");

                        }
                        else
                        {
                            Console.WriteLine("ВЫ НЕ ГОТОВЫ!!!!! пропуск хода");
                        }
                        break;
                }
                Console.WriteLine("У врага осталось " + enemyHealth + " здоровья");
                Console.WriteLine("Враг атакует");
                int numberAttack = rand.Next(1, 5);
                if (numberAttack == 1)
                {
                    userHealth -= enemyDamage;
                    Console.WriteLine("Вы получили " + enemyDamage + " урона , у вас осталось " + userHealth + " здоровья");
                }
                else if (numberAttack == 2)
                {
                    if (userAstralForm == true && enemyCurse == true)
                    {
                        Console.WriteLine("проклятье извращает вашу астральную форму и мощный удар превращается в MEGAPOWERBANG\n и наносит вам " + enemyMegaPowerBang + " урона");
                    }
                    else
                    {
                        userHealth -= (enemyDamage * enemyStrongAttack);
                        Console.WriteLine("Вы получили " + (enemyStrongAttack * enemyDamage) + " урона , у вас осталось " + userHealth + " здоровья");
                    }
                }
                else if (numberAttack == 3)
                {
                    enemyCurse = true;
                    userDamage -= changingDamage;
                    Console.WriteLine("Вы прокляты, ваш урон уменьшен");
                }
                else if (numberAttack == 4 && enemyCurse == true)
                {
                    if (userAstralForm == true)
                    {
                        Console.WriteLine("Астральная форма защитила вас от урона");
                        userDamage += changingDamage;
                    }
                    else { 
                    enemyCurse = false;
                    userDamage += changingDamage;
                    userHealth -= enemyDamage * enemyBangCurse;
                    Console.WriteLine("Взрыв проклятия, вы получили " + (enemyDamage * enemyBangCurse) + " урона увеличен");
                    }
                }
                else if (userDamage < 0)
                {
                    userDamage = 1;
                }
                if (userHealth <= 0)
                {
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!ВЫ ПОМЕРЛИ !!!!!!!!!!!!!!!!!!!!");
                }
                if (enemyHealth <= 0)
                {
                    Console.WriteLine("!!!!!!!!!!!!ПОБЕДА!!!!!!!!!!!!!");
                }


            }
        }
    }
}
