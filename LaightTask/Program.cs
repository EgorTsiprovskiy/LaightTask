using System;

namespace LaightTask
{
    class Program
    {
        enum Action
        {
            Damage = 1,
            Repair = 2

        }


        static void Main(string[] args)
        {

            Console.WriteLine("Правила игры:" + "\n");
            Console.WriteLine("Игра представляет собой текстовый бой двух танков");
            Console.WriteLine("Цель игры: свести жизни вражеского танка к нулю");
            Console.WriteLine("В данной версии игры предоставляется два варианта действий: выстрел и перезарядка" + "\n");


            Random rnd = new Random();

            //Создаем два танка, первый для пользователя, второй для компьютера
            Console.WriteLine("Введите броню игрока:");
            int armor = GetCharacteristics();
            Console.WriteLine("Введите урон игрока:");
            int damage = GetCharacteristics();
            Console.WriteLine("Введите жизни игрока:");
            int life = GetCharacteristics();
            Console.WriteLine("Введите броню компьютера:");
            int pc_armor = GetCharacteristics();
            Console.WriteLine("Введите урон компьютера:");
            int pc_damage = GetCharacteristics();
            Console.WriteLine("Введите жизни компьютера:");
            int pc_life = GetCharacteristics();

            //int pc_life = Convert.ToInt32(Console.ReadLine());
            PcTank pcTank = new PcTank();
            //UserTank userTank = new UserTank { user_life = life, user_damage = damage, user_protection = armor, pc_life = { pc_life = pc_life } };
            UserTank userTank = new UserTank();
            pcTank.Print2(ref pc_life, ref pc_damage, ref pc_armor);
            userTank.Print2(ref life, ref damage, ref armor);
            Console.WriteLine("Доступные действия:" + "\n");
            Console.WriteLine("1 - Выстрел" + "\n" + "2 - Ремонт(Получаем 1 жизнь)" + "\n");

            while (pc_life > 0 || life > 0)
            {
                for (int i = 0; i < 1; i++)
                {
                    //Console.WriteLine("Ваш ход! Введите действие:");
                    int user_action = GetAction();
                 
                    ChoiceUserAction((Action)user_action);
                    Console.WriteLine("#################" + "\n");
                    if (life <= 0)
                    {
                        Console.WriteLine("Вы проиграли( ");
                        Environment.Exit(0);
                    }
                    if (pc_life <= 0)
                    {
                        Console.WriteLine("Вы победили!");
                        Environment.Exit(0);
                    }
                    for (int j = 0; j < 1; j++)
                    {
                        Console.WriteLine("Ход компьютера!");
                        
                        int pc_action = rnd.Next(1,3);
                        Console.WriteLine(pc_action);
                        ChoicePCAction((Action)pc_action);
                        pcTank.Print2(ref pc_life, ref pc_damage, ref pc_armor);
                        userTank.Print2(ref life, ref damage, ref armor);
                    }
                }
                
            }

            void ChoiceUserAction(Action action)
            {
                switch (action)
                {
                    case Action.Damage:
                        userTank.Shot(ref pc_life, ref damage, ref pc_armor);
                        Console.Write("Ваши показатели:");
                        userTank.Print2(ref life, ref damage, ref armor);
                        Console.WriteLine("Показатели компьютера:");
                        pcTank.Print2(ref pc_life, ref pc_damage, ref pc_armor);
                        Console.Clear();
                        break;
                    case Action.Repair:
                        userTank.Repair(ref life);
                        Console.Write("Ваши показатели:");
                        userTank.Print2(ref life, ref damage, ref armor);
                        Console.WriteLine();
                        Console.WriteLine("Показатели компьютера:");
                        pcTank.Print2(ref pc_life, ref pc_damage, ref pc_armor);
                        Console.Clear();
                        break;
                }
            }

            void ChoicePCAction(Action action)
            {
                switch (action)
                {
                    case Action.Damage:
                        userTank.Shot(ref life, ref pc_damage, ref armor);
                        Console.Write("Ваши показатели:" + "\n");
                        userTank.Print2(ref life, ref damage, ref armor);
                        Console.Write("Показатели компьютера:" + "\n");
                        pcTank.Print2(ref pc_life, ref pc_damage, ref pc_armor);
                        Console.WriteLine();
                        break;
                    case Action.Repair:
                        userTank.Repair(ref pc_life);
                        Console.Write("Ваши показатели:" + "\n");
                        userTank.Print2(ref life, ref damage, ref armor);
                        Console.WriteLine("Показатели компьютера:" + "\n");
                        pcTank.Print2(ref pc_life, ref pc_damage, ref pc_armor);
                        Console.WriteLine();
                        break;
                }
            }
            
            static int GetCharacteristics()
            {
                int number;
                string input = Console.ReadLine();
                bool isConverted = int.TryParse(input, out number);
                if (isConverted)
                {
                    if (number < 1)
                    {
                        isConverted = false;
                    }

                }
                while (!isConverted)
                {
                    Console.WriteLine("Нужно ввести число!");
                    input = Console.ReadLine();
                    isConverted = int.TryParse(input, out number);
                    if (!isConverted)
                    {
                        if (number < 1 || number > 100)
                        {
                            isConverted = false;
                           
                        }
                    }
                }
                return number;

            }
            static int GetAction()
            {
                int number;
                Console.WriteLine("Введите действие:");
                string input = Console.ReadLine();
                bool isConverted = int.TryParse(input, out number);
                Console.WriteLine(number);
                if (isConverted)
                {
                    if (number < 1 || number > 2)
                    {
                        isConverted = false;
                    }
                        
                }

                while(!isConverted)
                {
                    Console.WriteLine("Для выбора действия введите число (1-выстрел, 2-ремонт)");
                    input = Console.ReadLine();
                    isConverted = int.TryParse(input, out number);
                    if (!isConverted)
                    {
                        if (number < 1 || number > 2)
                        {
                            isConverted = false;
                        }
                    }
                }
                return number;
            }
        }
    }
}
