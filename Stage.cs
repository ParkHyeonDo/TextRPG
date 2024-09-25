using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Stage
    {
        int stageLevel;


        Goblin goblin = new Goblin()
        {
            Name = "고블린",
            Health = 10,
            Attack = 1,
            IsDead = false
        };
        Dragon dragon = new Dragon()
        {
            Name = "드래곤",
            Health = 200,
            Attack = 20,
            IsDead = false
        };
        HealthPotion healthPotion = new HealthPotion()
        {
            Name = "체력회복물약",
            Amount = 50,
            Type = 0
        };
        StrengthPotion strengthPotion = new StrengthPotion()
        {
            Name = "공격력 강화물약",
            Amount = 5,
            Type = 1
        };


        public void start()
        {
            if (stageLevel < 5)
            {
                //고블린 생성
            }
            else if (stageLevel >= 5 && stageLevel < 10)
            {
                //드래곤 생성
            }

        }
    }
}
