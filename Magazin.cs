using System;

public class Class1
{
	public Class1()
	{
		int priceCrystal=5;

		Console.WriteLine("Введите количество ваших золотых");
		int myGold = Convert.ToInt32(Console.ReadLine());
		
		Console.WriteLine("Здравствуйте , сколько кристалов вы хотите купить?");
		int crystalCount = Convert.ToInt32(Console.ReadLine());

		Console.WriteLine("Вы купили " + crystalCount * priceCrystal + " и у вас осталось " + myGold - priceCrystal * crystalCount);

	}
}
