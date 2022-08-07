using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LaightTask
{
    /*
     Классс для создания экземпляров танка. Содержит в себе методы управления действиями
    */
    class Tank
    {
        //Свойство танка броня
        private int armor;
        //Свойство танка жизни
        private int life;
        //Свойство танка урон
        private int damage;
        public int Armor
        {
            get { return armor; }
            set { armor = value; }
        }
        public int Life
        {
            get { return life; }
            set { life = value; }
        }
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        //Конструктор класса
        public Tank(int armor, int life, int damage) { this.Armor = armor; this.Life = life; this.Damage = damage; }

        //Метод для стрельбы
        //При вызове метода от запаса жизни танка отнимается четыре(значение урона)
        public void Shot()
        {
            int life = Life; //Переменная, в которой будет храниться обновленное значение жизней
            if (life > 0)
            {
                life = Life - Damage + Armor;
                Console.WriteLine("Нанесено 4 урона");
                Console.WriteLine("Осталось жизней: " + life);
                Life = life;
            }
            else Console.WriteLine("Поражение!");
        }

        //Метод для починки
        //При вызове метода к счетчику жизни прибавляется единица
        public void Repair()
        {
           
            int life = Life + 1;
            Console.WriteLine("Жизнь восстановленна!" + "\n" + "Текущее кол-во жизней:" + life);
            Life = life;
        }

        //Метод для вывода ко-во жизней
        public void PrintLife()
        {
            Console.WriteLine($"Кол-во жизней {life}");

        }
    }
}
