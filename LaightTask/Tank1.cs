using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaightTask
{
    class Tank1
    {
        public virtual void Print2(ref int life, ref int damage, ref int protection) => Console.WriteLine($"Броня: {protection} Жизни:{life} Урон: {damage}");
        public virtual int Shot(ref int life, ref int damage, ref int protection)
        {
            
            life  = (life + protection - damage);
             
            return life;
        }

        public void Repair(ref int life)
        {
            life++;

        }
    }

    class PcTank : Tank1
    {
        public byte pc_life;
        public byte pc_damage;
        public byte pc_protection;
       
        public PcTank()
        {
            pc_damage = 0;
            pc_life = 0;
            pc_protection = 0;  
        }
        public override void Print2(ref int pc_life, ref int pc_damage, ref int pc_protection) => Console.WriteLine($"Броня противника: {pc_protection} Жизни противника:{pc_life} Урон противника: {pc_damage}");
        
    }

    class UserTank : Tank1
    {
        public byte life;
        public byte damage;
        public byte protection;
      
        public UserTank()
        {
            life = 0;
            damage = 0;
            protection = 0;
        }
        public override void Print2(ref int life, ref int damage, ref int protection) => Console.WriteLine($"Ваша Броня: {protection} Ваши Жизни:{life} Ваш Урон: {damage}");
    }
}
