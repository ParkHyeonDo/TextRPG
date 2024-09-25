using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG
{
   

    public interface ICharEquip
    {
        string Name { get; set; }
        int Attack { get; set; }
        int Deffence { get; set; }
        string Manual { get; set; }
        int Price {  get; set; }

    }
        

    public class Armor : ICharEquip {
        string name = "무쇠갑옷";
        int att = 0;
        int def = 5;
        string manual = " | 방어력 +5 | 무쇠로 만들어져 튼튼한 갑옷입니다.";
        int price = 2000;

        public string Name
        {
                get { return name; }
                set { name = "무쇠갑옷" ; }
        }
        public int Attack
        {
            get { return att; }
            set { att = 0; }
        }
        public int Deffence
        {
            get { return def; }
            set { def = 5; }
        }
        public string Manual
        {
            get { return manual; }
            set { manual = " | 방어력 +5 | 무쇠로 만들어져 튼튼한 갑옷입니다."; }
        }
        public int Price
        {
            get { return price; }
            set { price = 2000; }
        }
    }

    public class SpartaSpear : ICharEquip
    {
        string name = "스파르타 창";
        int att = 7;
        int def = 0;
        string manual = " | 공격력 +7 | 스파르타의 전사들이 사용했다는 전설의 창입니다.";
        int price = 4500;
        public string Name
        {
            get { return name; }
            set { name = "스파르타 창"; }
        }
        public int Attack
        {
            get { return att; }
            set { att = 7; }
        }
        public int Deffence
        {
            get { return def; }
            set { def = 0; }
        }
        public string Manual
        {
            get { return manual; }
            set { manual = " | 공격력 +7 | 스파르타의 전사들이 사용했다는 전설의 창입니다."; }
        }
        public int Price
        {
            get { return price; }
            set { price = 4500; }
        }

    }


    public class OldSword : ICharEquip
    {
        string name = "낡은 검";
        int att = 2;
        int def = 0;
        string manual = " | 공격력 +2 | 쉽게 볼 수 있는 낡은 검 입니다.";
        int price = 600;
        public string Name
        {
            get { return name; }
            set { name = "낡은 검"; }
        }
        public int Attack
        {
            get { return att; }
            set { att = 2; }
        }
        public int Deffence
        {
            get { return def; }
            set { def = 0; }
        }
        public string Manual
        {
            get { return manual; }
            set { manual = " | 공격력 +2 | 쉽게 볼 수 있는 낡은 검 입니다."; }
        }
        public int Price
        {
            get { return price; }
            set { price = 600; }
        }

    }

    public class NoviceArmor : ICharEquip
    {
        string name = "수련자 갑옷";
        int att = 0;
        int def = 2;
        string manual = " | 방어력 +2 | 수련에 도움을 주는 갑옷입니다.";
        int price = 1000;
        public string Name
        {
            get { return name; }
            set { name = "수련자 갑옷"; }
        }
        public int Attack
        {
            get { return att; }
            set { att = 0; }
        }
        public int Deffence
        {
            get { return def; }
            set { def = 2; }
        }

        public string Manual
        {
            get { return manual; }
            set { manual = " | 방어력 +2 | 수련에 도움을 주는 갑옷입니다."; }
        }
        public int Price
        {
            get { return price; }
            set { price = 1000; }
        }

    }

    public class SpartaArmor : ICharEquip
    {
        string name = "스파르타의 갑옷";
        int att = 0;
        int def = 10;
        string manual = " | 방어력 +10 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.";
        int price = 3500;
        public string Name
        {
            get { return name; }
            set { name = "스파르타의 갑옷"; }
        }
        public int Attack
        {
            get { return att; }
            set { att = 0; }
        }
        public int Deffence
        {
            get { return def; }
            set { def = 10; }
        }

        public string Manual
        {
            get { return manual; }
            set { manual = " | 방어력 +10 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다."; }
        }
        public int Price
        {
            get { return price; }
            set { price = 3500; }
        }

    }

    public class BronzeAxe : ICharEquip
    {
        string name = "청동 도끼";
        int att = 5;
        int def = 0;
        string manual = " | 공격력 +5 | 어디선가 사용했던거 같은 도끼입니다.";
        int price = 1500;
        public string Name
        {
            get { return name; }
            set { name = "청동 도끼"; }
        }
        public int Attack
        {
            get { return att; }
            set { att = 5; }
        }
        public int Deffence
        {
            get { return def; }
            set { def = 0; }
        }

        public string Manual
        {
            get { return manual; }
            set { manual = " | 공격력 +5 | 어디선가 사용했던거 같은 도끼입니다."; }
        }
        public int Price
        {
            get { return price; }
            set { price = 1500; }
        }

    }


}


