using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TextRPG.Program;

namespace TextRPG
{
    public class HealthPotion : IItem
    {
        string name;
        int amount;
        int type;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
    }

    public class StrengthPotion : IItem
        {
            string name;
            int amount;
            int type;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int Amount
            {
                get { return amount; }
                set { amount = value; }
            }
            public int Type
            {
                get { return type; }
                set { type = value; }
            }
        }


}
