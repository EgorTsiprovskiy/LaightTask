using System;

namespace LaightTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int action; // переменная, которая будет отвечать за действие пользователя 
            //Создаем два танка, первый для пользователя, второй для компьютера
            Tank tank1 = new Tank(2, 2, 4);
            Tank tank2 = new Tank(2, 6, 6);
            Console.WriteLine("Правила игры:" + "\n");
            Console.WriteLine("Игра представляет собой текстовый бой двух танков");
            Console.WriteLine("Цель игры: свести жизни вражеского танка к нулю");
            Console.WriteLine("В данной версии игры предоставляется два варианта действий: выстрел и перезарядка" + "\n");

            Console.WriteLine("Начало игры!");
            //Вызываем метод для отображения кол-во жизней
            Console.WriteLine($"Кол-во жизней игрока:");
            tank1.PrintLife();
            Console.WriteLine($"Кол-во жизней компьютера:");
            tank2.PrintLife();
            Console.WriteLine();

            //Цикл который выполняется, пока у вражеского танка есть жизни, игра добрая, в данной версии проиграть нельзя)
            while (tank1.Life >= 0)
            {
                Console.WriteLine("Выберете дейсвтие:" + "\n" + "1.Выстрел" + "\n" + "2.Починка");
                action = Convert.ToInt32(Console.ReadLine()); //Переменная для хранения выбранного действия
                //Цикл обработки выбора действия, если пользователем была введена еденица, то вызовется метод выстрела, если двойка, то метод ремонта
                if (action == 1)
                {
                    if (tank2.Life > 0)
                    {
                        tank2.Shot();
                        //Рандом кривой, на одно действие
                        Console.WriteLine();
                        Console.WriteLine("Ход компьютера!");
                        //Задается рандомное число от 1 до 2, для выбора действия
                        Random rand = new Random(2);
                        float actionComp = rand.Next();
                        //Если 1 - выстрел,то 2 - ремонт
                        if (actionComp == 1)
                        {
                            tank1.Shot();
                        }
                        else
                        {
                            tank2.Repair();
                        }
                        Console.WriteLine();
                        tank1.PrintLife();
                        tank2.PrintLife();
                    }
                    else Console.WriteLine("Вы выиграли!!");
                }
                else if (action == 2)
                {
                    tank1.Repair();
                    Console.WriteLine("Ход компьютера!");
                    Random rand = new Random();
                    int actionComp = rand.Next(1, 2);
                    if (actionComp == 1)
                    {
                        tank1.Shot();
                    }
                    else
                    {
                        tank2.Repair();
                    }
                    tank1.PrintLife();
                    tank2.PrintLife();
                }
                else
                {
                    Console.WriteLine("Вы не правильно ввели действие (выберете действие цифрой 1 или 2)");
                }
                //Конструкция для продолжения игры, взял с интернета
                //Ломается при выборе не символа
                //Предлагается выбрать, продолжить игру или закончить, при вводе символа отличного от n игра будет продолжена
                Console.WriteLine("Продолжить? y-да, n-нет (y/n)");
                ConsoleKeyInfo c = Console.ReadKey();
                Console.WriteLine();
                if (c.KeyChar == 'n') break;
            }
            Console.ReadKey();
        }
    }
}
