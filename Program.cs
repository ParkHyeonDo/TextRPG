using System.Reflection.Metadata;
using System.Text;
using System.Xml.Linq;


namespace TextRPG
{ 

    internal class Program
    {
        

        public interface Icharacter {
            string Name { get; set; }
            int Health { get; set; }
            int Attack { get; set; }
            bool IsDead { get; set; }

            void TakeDamage(int damage) {
                Health -= damage;
                Console.WriteLine("(이)가 "+damage+" 의 피해를 입었습니다.");
                if (Health < 0) { 
                    IsDead = true;
                    Console.WriteLine("(이)가 사망하였습니다.");
                }
                
            }
        }

        public interface IItem { 
        string Name { get; set; }
        int Amount { get; set; }


            void Use(Warrior warrior) {
                if (Name.Equals("HealthPotion")) {
                    Console.WriteLine(Name + " 을(를) 사용 하여" + Amount + "를 회복했습니다.");
                } else if (Name.Equals("StrengthPotion")){
                    Console.WriteLine(Name + " 을(를) 사용 하여" + Amount + "의 데미지가 증가했습니다.");
                }
            }

        }



        

        





        static void Main(string[] args)
        {
            
           GameManager gameManager = new GameManager();
            gameManager.start();

        }
    }

       
}
