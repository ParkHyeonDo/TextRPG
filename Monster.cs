using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TextRPG.Program;

namespace TextRPG
{
    public class Monster : Icharacter
    {
        string name;
        int hel;
        int att;
        bool dead;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Health
        {
            get { return hel; }
            set { hel = value; }
        }
        public int Attack
        {
            get { return att; }
            set { att = value; }
        }
        public bool IsDead
        {
            get { return dead; }
            set { dead = value; }
        }

    }

    public class Dragon : Monster
    {

    }

    public class Goblin : Monster
    {

    }
}
