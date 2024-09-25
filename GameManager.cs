using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static TextRPG.Program;

namespace TextRPG
{
    public class GameManager
    {
        StringBuilder openMent = new StringBuilder();
        Stage stage = new Stage();
        HealthPotion healthPotion = new HealthPotion();
        StrengthPotion strengthPotion = new StrengthPotion();
        Armor armor = new Armor();
        SpartaSpear spartaSpear = new SpartaSpear();
        OldSword oldSword = new OldSword();
        NoviceArmor noviceArmor = new NoviceArmor();
        SpartaArmor spartaArmor = new SpartaArmor();
        BronzeAxe bronzeAxe = new BronzeAxe();

        

        int choose;
        int switchNumber;
        string chooseMent1 = "원하시는 행동을 입력해주세요";
        string chooseMentRetry = "다시 선택해주세요";
        string chooseMentBuy = "구매를 완료했습니다.";
        string chooseMentNotEnough = "Gold가 부족합니다.";
        string chooseMentEnough = "이미 보유한 아이템 입니다.";

        bool retry = false;
        string isCharEquip;

        //나중에 수정해야될거
        int level = 1;
        string chad = "전사";
        string charName;
        int attack = 10;
        int deffence = 5;
        int health = 100;
        int gold = 1500;


        List<string> inventory = new List<string>();

        List<string> equipment = new List<string>();
        List<int> equipmentAttack = new List<int>();
        List<int> equipmentDeffence = new List<int>();
        List<string> equipmentManual = new List<string>();
        List<int> equipmentPrice = new List<int>();

        List<string> charEquipment = new List<string>();
        List<int> chaEquipAttack = new List<int>();
        List<int> chaEquipDeffence = new List<int>();

        List<string> shopItem = new List<string>();
        List<int> shopItemAttack = new List<int>();
        List<int> shopItemDeffence = new List<int>();
        List<string> shopItemManual = new List<string>();
        List<int> shopItemPrice = new List<int>();
        public void start() {

            /*openMent.Append("환영합니다.");
           Console.Write(openMent);
           Thread.Sleep(1000);
           openMent.Replace("환영합니다.",".");
           Console.Write(openMent);
           Thread.Sleep(1000);
           Console.WriteLine(openMent);
           Thread.Sleep(1000);*/
            ShopSetting();
            Setting();
            Thread.Sleep(1000);

            mainpageView();

            

        }

        public void Setting()
        {

            Console.WriteLine("당신의 이름을 입력해주세요");
            string name = Console.ReadLine();

            Warrior warrior = new Warrior()
            {
                Name = name,
                Health = 100,
                Attack = 5,
                IsDead = false
            };
            charName = warrior.Name;
            equipment.Add(shopItem[1]);
            equipment.Add(shopItem[5]);
            equipment.Add(shopItem[3]);

            equipmentAttack.Add(shopItemAttack[1]);
            equipmentAttack.Add(shopItemAttack[5]);
            equipmentAttack.Add(shopItemAttack[3]);

            equipmentDeffence.Add(shopItemDeffence[1]);
            equipmentDeffence.Add(shopItemDeffence[5]);
            equipmentDeffence.Add(shopItemDeffence[3]);

            equipmentManual.Add(shopItemManual[1]);
            equipmentManual.Add(shopItemManual[5]);
            equipmentManual.Add(shopItemManual[3]);

        }

        public void mainpageView()
        {
           
            do
            {
                Console.Clear();
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.WriteLine("1. 상태보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("");
                if (!retry)
                {
                    Console.WriteLine(chooseMent1);
                }else
                {
                    Console.WriteLine(chooseMentRetry);
                }
                Console.Write(">> ");

                try
                {
                    choose = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    choose = 0;
                }

                switch (choose)
                {
                    case 1: statView(); retry = false; break;
                    case 2: inventoryView(); retry = false; break;
                    case 3: ShopView(); retry = false; break;
                    default: retry = true; break;
                }
            } while (choose < 1 || choose > 3);

        }

        public void statView()
        {
            
            do
            {
                Console.Clear();
                EquipMent();
                Console.WriteLine(charName);
                if (level < 10)
                {
                    Console.WriteLine("Lv. 0" + level);
                }
                else
                {
                    Console.WriteLine("Lv. " + level);
                }
                Console.WriteLine("Chad ( " + chad + " )");
                if (chaEquipAttack.Count > 0)
                {
                    int sum = 0;
                        for (int i = 0; i < chaEquipAttack.Count; i++)
                        {
                            sum += chaEquipAttack[i];
                        }
                    Console.WriteLine("공격력 : " + attack + " (+" + sum + ")");
                }
                else
                {
                    Console.WriteLine("공격력 : " + attack);
                }
                if (chaEquipDeffence.Count > 0)
                {
                    int sum = 0;
                    for (int i = 0; i < chaEquipDeffence.Count; i++)
                    {
                        sum += chaEquipDeffence[i];
                    }
                    Console.WriteLine("방어력 : " + deffence + " (+" + sum + ")");
                }
                else {
                    Console.WriteLine("방어력 : " + deffence);
                }
                Console.WriteLine("체력 : " + health);
                Console.WriteLine("Gold : " + gold + " G");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                if (!retry)
                {
                    Console.WriteLine(chooseMent1);
                }
                else
                {
                    Console.WriteLine(chooseMentRetry);
                }
                Console.Write(">> ");
                try
                {
                    choose = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    choose = 99;
                }

                if (choose == 0)
                {
                    retry = false;
                    return;
                }
                else
                {
                    retry = true;
                }
            } while (retry);
        }

        public void inventoryView()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine("");
                foreach (string equip in equipment)
                {
                        Console.WriteLine("- " + equip + "\t" + equipmentManual[equipment.IndexOf(equip)]);
                    
                }
                foreach (string inven in inventory)
                {
                    Console.WriteLine("- " + inven);
                }
                Console.WriteLine("1. 장착관리");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("");
                if (!retry)
                {
                    Console.WriteLine(chooseMent1);
                }
                else
                {
                    Console.WriteLine(chooseMentRetry);
                }
                Console.Write(">>");

                try
                {
                    choose = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    choose = 99;
                }

                if (choose == 0)
                {
                    retry = false;
                    return;
                }
                else if (choose == 1)
                {
                    retry = false;
                    equipmentView();
                }
                else
                {
                    retry = true;
                }
            } while (retry);
        }

        public void equipmentView()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine("");
                foreach (string equip in equipment)
                {
                    if (charEquipment.Contains(equip))
                    {
                        Console.WriteLine("- " + (equipment.IndexOf(equip) + 1) + " [E]" + equip +"\t" + equipmentManual[equipment.IndexOf(equip)]);
                    }
                    else {
                        Console.WriteLine("- " + (equipment.IndexOf(equip) + 1) + " " + equip + "\t" + equipmentManual[equipment.IndexOf(equip)]);
                    }
                }
                Console.WriteLine("0. 나가기");
                Console.WriteLine("");
                if (!retry)
                {
                    Console.WriteLine(chooseMent1);
                }
                else
                {
                    Console.WriteLine(chooseMentRetry);
                }
                Console.Write(">>");
                try
                {
                    choose = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    choose = 99;
                }
                if ((choose-1) < equipment.Count && choose != 0)
                {
                    isCharEquip = equipment[choose - 1];


                            if (charEquipment.Contains(isCharEquip))
                            {
                                OffTypeEquipment();
                                retry = false;

                            }
                            else if (!charEquipment.Contains(isCharEquip))
                            {
                                TypeEquipment();
                                retry = false;
                            }



                    
                    equipmentView();


                }
                else if (choose == 0)
                {
                    return;
                }
                else
                {
                    retry = true;
                }


            }while (retry);
        }

        public void ShopView() {
            
            do
            {         
                Console.Clear();
                switch (switchNumber)
                {
                    case 0:
                        Console.WriteLine("");
                        Console.WriteLine("");
                        break;
                    case 1:
                        Console.WriteLine(chooseMentBuy);
                        Console.WriteLine("");
                        break;
                    case 2:
                        Console.WriteLine(chooseMentNotEnough);
                        Console.WriteLine("");
                        break;
                    case 3:
                        Console.WriteLine(chooseMentEnough);
                        Console.WriteLine("");
                        break;
                }
                Console.WriteLine("[보유 골드]");
                Console.WriteLine(gold + " ");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                foreach (string str in shopItem) {

                    if (equipment.Contains(str))
                    {
                        Console.WriteLine("- " + (shopItem.IndexOf(str) + 1) + " " + str + "    \t"
                            + shopItemManual[shopItem.IndexOf(str)] + "  \t | " +"판매완료");
                    }
                    else
                    {
                        Console.WriteLine("- " + (shopItem.IndexOf(str) + 1) + " " + str + "    \t"
                            + shopItemManual[shopItem.IndexOf(str)] + "  \t | " + shopItemPrice[shopItem.IndexOf(str)] + " G");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine("");
                if (!retry)
                {
                    Console.WriteLine(chooseMent1);
                }
                else
                {
                    Console.WriteLine(chooseMentRetry);
                }
                Console.Write(">>");
                try
                {
                    choose = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    choose = 99;
                }
                if (choose != 0 && choose != 99)
                {
                    if (gold >= shopItemPrice[choose - 1] && !equipment.Contains(shopItem[choose - 1]))
                    {

                        ShopBuy(choose - 1);
                        retry = false;
                        gold -= shopItemPrice[choose - 1];
                        switchNumber = 1;
                        ShopView();
                    }
                    else if (gold < shopItemPrice[choose - 1] && !equipment.Contains(shopItem[choose - 1]))
                    {
                        retry = false;
                        switchNumber = 2;
                        ShopView();
                    }
                    else if (equipment.Contains(shopItem[choose-1]))
                    {
                        retry = false;
                        switchNumber = 3;
                        ShopView();
                    }
                }
                else if (choose == 0) {
                    switchNumber = 0;
                    return;
                }
                else
                {
                    retry = true;
                }


            } while (retry);
        }




        public void EquipMent()
        {
            attack = 10;
            deffence = 5;
            //equipAttack = 0;
           // equipDeffence = 0;
            
            for (int i = 0; i < charEquipment.Count; i++) {
                
                try
                {


                 /*   equipAttack += charEquipAttack[i];
                    attack += equipAttack;
                    equipDeffence += charEquipDeffence[i];
                    deffence += equipDeffence;*/
                }
                catch (Exception e) {
                    return;
                }
            }


        }
         
        public void TypeEquipment()
        {
                
                    if (isCharEquip.Equals(armor.Name) && !charEquipment.Contains(armor.Name))
                    {
                        charEquipment.Add(isCharEquip);
                        chaEquipAttack.Add(armor.Attack);
                        chaEquipDeffence.Add(armor.Deffence);
                    }
                    else if (isCharEquip.Equals(spartaSpear.Name) && !charEquipment.Contains(spartaSpear.Name))
                    {
                        charEquipment.Add(isCharEquip);
                        chaEquipAttack.Add(spartaSpear.Attack);
                        chaEquipDeffence.Add(spartaSpear.Deffence);
                    }
            else if (isCharEquip.Equals(oldSword.Name) && !charEquipment.Contains(oldSword.Name))
            {
                charEquipment.Add(isCharEquip);
                chaEquipAttack.Add(oldSword.Attack);
                chaEquipDeffence.Add(oldSword.Deffence);
            }
            else if (isCharEquip.Equals(noviceArmor.Name) && !charEquipment.Contains(noviceArmor.Name))
            {
                charEquipment.Add(isCharEquip);
                chaEquipAttack.Add(noviceArmor.Attack);
                chaEquipDeffence.Add(noviceArmor.Deffence);
            }
            else if (isCharEquip.Equals(spartaArmor.Name) && !charEquipment.Contains(spartaArmor.Name))
            {
                charEquipment.Add(isCharEquip);
                chaEquipAttack.Add(spartaArmor.Attack);
                chaEquipDeffence.Add(spartaArmor.Deffence);
            }
            else if (isCharEquip.Equals(bronzeAxe.Name) && !charEquipment.Contains(bronzeAxe.Name))
            {
                charEquipment.Add(isCharEquip);
                chaEquipAttack.Add(bronzeAxe.Attack);
                chaEquipDeffence.Add(bronzeAxe.Deffence);
            }
            else
                    {

                    }

                
            
        }

        public void OffTypeEquipment() {
            
                if (isCharEquip.Equals(armor.Name) && charEquipment.Contains(armor.Name))
                {
                    charEquipment.Remove(armor.Name);
                    chaEquipAttack.Remove(armor.Attack);
                    chaEquipDeffence.Remove(armor.Deffence);
                }
                else if (isCharEquip.Equals(spartaSpear.Name) && charEquipment.Contains(spartaSpear.Name))
                {
                    charEquipment.Remove(spartaSpear.Name);
                    chaEquipAttack.Remove(spartaSpear.Attack);
                    chaEquipDeffence.Remove(spartaSpear.Deffence);
                  }
                else if (isCharEquip.Equals(oldSword.Name) && charEquipment.Contains(oldSword.Name))
                {
                charEquipment.Remove(oldSword.Name);
                chaEquipAttack.Remove(oldSword.Attack);
                chaEquipDeffence.Remove(oldSword.Deffence);
            }
                else if (isCharEquip.Equals(noviceArmor.Name) && charEquipment.Contains(noviceArmor.Name))
                {
                charEquipment.Remove(noviceArmor.Name);
                chaEquipAttack.Remove(noviceArmor.Attack);
                chaEquipDeffence.Remove(noviceArmor.Deffence);
            }
                else if (isCharEquip.Equals(spartaArmor.Name) && charEquipment.Contains(spartaArmor.Name))
                {
                charEquipment.Remove(spartaArmor.Name);
                chaEquipAttack.Remove(spartaArmor.Attack);
                chaEquipDeffence.Remove(spartaArmor.Deffence);
            }
                else if (isCharEquip.Equals(bronzeAxe.Name) && charEquipment.Contains(bronzeAxe.Name))
                {
                charEquipment.Remove(bronzeAxe.Name);
                chaEquipAttack.Remove(bronzeAxe.Attack);
                chaEquipDeffence.Remove(bronzeAxe.Deffence);
            }


        }

        public void ShopSetting() {
            shopItem.Add(noviceArmor.Name);
            shopItem.Add(armor.Name);
            shopItem.Add(spartaArmor.Name);
            shopItem.Add(oldSword.Name);
            shopItem.Add(bronzeAxe.Name);
            shopItem.Add(spartaSpear.Name);

            shopItemAttack.Add(noviceArmor.Attack);
            shopItemAttack.Add(armor.Attack);
            shopItemAttack.Add(spartaArmor.Attack);
            shopItemAttack.Add(oldSword.Attack);
            shopItemAttack.Add(bronzeAxe.Attack);
            shopItemAttack.Add(spartaSpear.Attack);

            shopItemDeffence.Add(noviceArmor.Deffence);
            shopItemDeffence.Add(armor.Deffence);
            shopItemDeffence.Add(spartaArmor.Deffence);
            shopItemDeffence.Add(oldSword.Deffence);
            shopItemDeffence.Add(bronzeAxe.Deffence);
            shopItemDeffence.Add(spartaSpear.Deffence);

            shopItemManual.Add(noviceArmor.Manual);
            shopItemManual.Add(armor.Manual);
            shopItemManual.Add(spartaArmor.Manual);
            shopItemManual.Add(oldSword.Manual);
            shopItemManual.Add(bronzeAxe.Manual);
            shopItemManual.Add(spartaSpear.Manual);

            shopItemPrice.Add(noviceArmor.Price);
            shopItemPrice.Add(armor.Price);
            shopItemPrice.Add(spartaArmor.Price);
            shopItemPrice.Add(oldSword.Price);
            shopItemPrice.Add(bronzeAxe.Price);
            shopItemPrice.Add(spartaSpear.Price);

        }

        public void ShopBuy(int i) {
            if (i <= shopItem.Count)
            {
                equipment.Add(shopItem[i]);
                equipmentAttack.Add(shopItemAttack[i]);
                equipmentDeffence.Add(shopItemDeffence[i]);
                equipmentManual.Add(shopItemManual[i]);
            }
            else { }
        }

    }
}
