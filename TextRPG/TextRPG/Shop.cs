using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;
using TextRPG.Parentclass;
using TextRPG.Parentclass.Childclass;

namespace TextRPG
{
    internal class Shop : IFramework
    {
        public int Gold { get { return mGold; } set { mGold = value; } }
        int mGold = 0;
        bool isShoping = false;
        Item bronzeArmor;
        Item ironArmor;
        Item dimArmor;
        Item bronzeWepon;
        Item ironWepon;
        Item dimWepon;
        Dictionary<int, Item> nodes = new Dictionary<int, Item>();
        Dictionary<int, Item> inventory;


        public Shop()
        {
            bronzeArmor = new Armor("갑옷", "수련자 갑옷", "수련에 도움을 주는 갑옷이다.", 1000, 5);
            ironArmor = new Armor("갑옷", "무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷이다.", 2100, 9);
            dimArmor = new Armor("갑옷", "스파르타 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500, 15);
            bronzeWepon = new Weapon("무기", "낡은 검", "쉽게 볼 수있는 낡은 검이다.", 600, 2);
            ironWepon = new Weapon("무기", "청동 도끼", " 어디선가 사용됐던거 같은 도끼입니다", 1500,5);
            dimWepon = new Weapon("무기", "스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 3100, 7);
        }

        public void Initialize()
        {
            nodes.Add(1, bronzeArmor);
            nodes.Add(2, ironArmor);
            nodes.Add(3, dimArmor);
            nodes.Add(4, bronzeWepon);
            nodes.Add(5, ironWepon);
            nodes.Add(6, dimWepon);
        }

        public void Update()
        {

        }

        public void Render()
        {

        }

        public void Loop()
        {

        }

        public Dictionary<int, Item> keyValues_in { get { return inventory; } set { inventory = value; } }


        

        public void OpenShop()
        {

            
            ShopTxt(false);
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int num = IsChecking(Console.ReadLine());

            if (num == 1)
            {
                foreach (KeyValuePair<int, Item> node in nodes)
                {
                    node.Value.IsBuy = true;
                }
                ShopTxt(true);
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                int num1 = IsCheckingsize(Console.ReadLine(), nodes.Count);

                if (num1 == 0)
                {
                    return;
                }

                while (!isShoping)
                {
                    if (num1 == 0)
                    {
                        isShoping = true;
                    }
                    else if (nodes[num1].IsSoldOut == false)
                    {
                        // 만약 골드가 없으면 
                        if (nodes[num1].Gold > mGold)
                        {
                            ShopTxt(true);
                            Console.WriteLine();
                            Console.WriteLine("0. 나가기");
                            Console.WriteLine();
                            Console.WriteLine("돈이 부족합니다.");
                            Console.Write("다시입력하세요. : ");
                            num1 = IsCheckingsize(Console.ReadLine(), nodes.Count);
                        }
                        // 골드가 있으면
                        else
                        {
                            // 계산한 후
                            nodes[num1].IsSoldOut = true;
                            mGold -= nodes[num1].Gold;
                            keyValues_in.Add(keyValues_in.Count + 1, nodes[num1]);
                            // 추가 구매 유무 확인
                            ShopTxt(true);
                            Console.WriteLine();
                            Console.WriteLine("0. 나가기");
                            Console.WriteLine();
                            Console.WriteLine("더 구매하시겠습니까?");
                            Console.Write("다시입력하세요 : ");
                            num1 = IsCheckingsize(Console.ReadLine(), nodes.Count);
                        }
                    }
                    else if (nodes[num1].IsSoldOut == true)
                    {
                        ShopTxt(true);
                        Console.WriteLine();
                        Console.WriteLine("0. 나가기");
                        Console.WriteLine();
                        Console.WriteLine("판매가 되어서 구매할수없습니다..");
                        Console.Write("다시입력하세요. : ");
                        num1 = IsCheckingsize(Console.ReadLine(), nodes.Count);
                    }
                }

            }
            else if (num == 0)
            {
                return;
            }
        }
        public void ShopTxt(bool value)
        {
            Console.Clear();

            if (!value)
            {
                Console.WriteLine("상점");
            }
            else
            {
                Console.Write("상점");
                Console.WriteLine("-아이템 구매");
            }

            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(Gold + "G");

            foreach (KeyValuePair<int, Item> node in nodes)
            {
                if (node.Value is Armor)
                {
                    Armor armor = (Armor)node.Value; 

                    if (node.Value.IsBuy == false)
                    {
                        if (node.Value.IsSoldOut == false)
                        {
                            Console.WriteLine("-" + node.Value.Name + "| " +
                                "방어력" + armor.GuardPoint + "| " + node.Value.Detail +
                                "| " + node.Value.Gold + "G");
                        }
                        else
                        {
                            Console.WriteLine("-" + node.Value.Name + "| " +
                                 "방어력" + armor.GuardPoint + "| " + node.Value.Detail +
                                 "| " + node.Value.SoldOut);
                        }

                    }
                    else
                    {
                        if (node.Value.IsSoldOut == false)
                        {
                            Console.WriteLine("-" + node.Key + node.Value.Name + "| " +
                                "방어력 " + armor.GuardPoint + "| " + node.Value.Detail +
                                "| " + node.Value.Gold + "G");
                        }
                        else
                        {
                            Console.WriteLine("-" + node.Key + node.Value.Name + "| " +
                                 "방어력 " + armor.GuardPoint + "| " + node.Value.Detail +
                                 "| " + node.Value.SoldOut);
                        }
                    }

                }
                else if (node.Value is Weapon)
                {
                    Weapon weapon = (Weapon)node.Value;

                    if (node.Value.IsBuy == false)
                    {
                        if (node.Value.IsSoldOut == false)
                        {
                            Console.WriteLine("-" + node.Value.Name + " " +
                             "공격력 " + weapon.HitPoint + "| " + node.Value.Detail +
                            "| " + node.Value.Gold + "G");
                        }
                        else
                        {
                            Console.WriteLine("-" + node.Value.Name + "| " +
                            "공격력 " + weapon.HitPoint + "| " + node.Value.Detail +
                           "| " + node.Value.SoldOut);
                        }
                    }
                    else
                    {
                        if (node.Value.IsSoldOut == false)
                        {
                            Console.WriteLine("-" + node.Key + node.Value.Name + "| " +
                             "공격력 " + weapon.HitPoint + "| " + node.Value.Detail +
                            "| " + node.Value.Gold + "G");
                        }
                        else
                        {
                            Console.WriteLine("-" + node.Key + node.Value.Name + "| " +
                            "공격력 " + weapon.HitPoint + "| " + node.Value.Detail +
                           "| " + node.Value.SoldOut);
                        }
                    }
                }
            }


        }




        int IsChecking(string value)
        {
            int temp = 0;
            bool vailed = false;

            while (!vailed)
            {
                if (int.TryParse(value, out temp))
                {
                    vailed = true;
                }
                else
                {
                    Console.Write("잘못된 입력입니다 :");
                    temp = -1;
                }

                if (!(temp != 0 || temp != 1))
                {
                    Console.Write("잘못된 입력입니다 : ");
                    temp = IsChecking(Console.ReadLine());
                }
            }
            return temp;
        }

        int IsCheckingsize(string value, int num)
        {
            int temp = 0;
            bool vailed = false;

            while (!vailed)
            {
                if (int.TryParse(value, out temp))
                {
                    vailed = true;
                }
                else
                {
                    Console.Write("잘못된 입력입니다 :");
                    temp = -1;
                }

                if (temp < 0 && temp > num)
                {
                    Console.Write("잘못된 입력입니다 : ");
                    temp = IsChecking(Console.ReadLine());
                }
            }
            return temp;
        }
    }
}
