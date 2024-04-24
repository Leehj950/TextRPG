using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Shop
    {
        public int Gold { get { return mGold; } set { mGold = value; } } 
        int mGold = 0;

        Node bronzeArmor = new Node();
        Node ironArmor = new Node();
        Node dimArmor = new Node();
        Node bronzeWepon = new Node();
        Node ironWepon = new Node();
        Node dimWepon = new Node();

        Dictionary<int, Node> nodes = new Dictionary<int, Node>();


        public void init()
        {
            ArmorInit();
            WeponInit();
            nodes.Add(1, bronzeArmor);
            nodes.Add(2, ironArmor);
            nodes.Add(3, dimArmor);
            nodes.Add(4, bronzeWepon);
            nodes.Add(5, ironWepon);
            nodes.Add(6, dimWepon);
        }



        public void OpenShop()
        {
            ShopTxt();
            Console.Write(">>");
            int num = IsChecking(Console.ReadLine());

            if (num == 1)
            {
                foreach(KeyValuePair<int,Node> node in nodes)
                {
                    node.Value.isBuy = true;
                }
                ShopTxt();
            }
            else if (num == 0)
            {
                return;
            }
        }
        public void ShopTxt()
        {
            Console.Clear();
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(Gold + "G");

            foreach (KeyValuePair<int, Node> node in nodes)
            {
                if (node.Value.type == "갑옷")
                {
                    if (node.Value.isBuy == false)
                    {
                        if (node.Value.isSoldOut == false)
                        {
                            Console.WriteLine("-" + node.Value.name + "| " +
                                "방어력" + node.Value.guardPoint + "| " + node.Value.detail +
                                "| " + node.Value.gold+ "G");
                        }
                        else
                        {
                            Console.WriteLine("-" + node.Value.name + "| " +
                                 "방어력" + node.Value.guardPoint + "| " + node.Value.detail +
                                 "| " + node.Value.soldOut);
                        }

                    }
                    else
                    {
                        if (node.Value.isSoldOut == false)
                        {
                            Console.WriteLine("-" + node.Key + node.Value.name + "| " +
                                "방어력 " + node.Value.guardPoint + "| " + node.Value.detail +
                                "| " + node.Value.gold+"G");
                        }
                        else
                        {
                            Console.WriteLine("-" + node.Key + node.Value.name + "| " +
                                 "방어력 " + node.Value.guardPoint + "| " + node.Value.detail +
                                 "| " + node.Value.soldOut);
                        }
                    }

                }
                else if (node.Value.type == "무기")
                {
                    if (node.Value.isBuy == false)
                    {
                        if (node.Value.isSoldOut == false)
                        {
                            Console.WriteLine("-" + node.Value.name + " " +
                             "공격력 " + node.Value.hitPoint + "| " + node.Value.detail +
                            "| " + node.Value.gold+"G");
                        }
                        else
                        {
                            Console.WriteLine("-" + node.Value.name + "| " +
                            "공격력 " + node.Value.hitPoint + "| " + node.Value.detail +
                           "| " + node.Value.soldOut);
                        }
                    }
                    else
                    {
                        if (node.Value.isSoldOut == false)
                        {
                            Console.WriteLine("-" + node.Key + node.Value.name + "| " +
                             "공격력 " + node.Value.hitPoint + "| " + node.Value.detail +
                            "| " + node.Value.gold+"G");
                        }
                        else
                        {
                            Console.WriteLine("-" + node.Key + node.Value.name + "| " +
                            "공격력 " + node.Value.hitPoint + "| " + node.Value.detail +
                           "| " + node.Value.soldOut);
                        }
                    }
                }
            }
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

        }

        void ArmorInit()
        {
            // 수련자 갑옷
            bronzeArmor.type = "갑옷";
            bronzeArmor.name = "수련자 갑옷";
            bronzeArmor.guardPoint = 5;
            bronzeArmor.detail = "수련에 도움을 주는 갑옷이다.";
            bronzeArmor.gold = 1000;
            // 무쇠 갑옷
            ironArmor.type = "갑옷";
            ironArmor.name = "무쇠갑옷";
            ironArmor.guardPoint = 9;
            ironArmor.detail = "무쇠로 만들어져 튼튼한 갑옷이다.";
            ironArmor.gold = 2100;
            // 스파르타 갑옷 
            dimArmor.type = "갑옷";
            dimArmor.name = "스파르타 갑옷";
            dimArmor.guardPoint = 15;
            dimArmor.detail = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.";
            dimArmor.gold = 3500;
        }

        void WeponInit()
        {
            // 낡은 검
            bronzeWepon.type = "무기";
            bronzeWepon.name = "낡은 검";
            bronzeWepon.hitPoint = 2;
            bronzeWepon.detail = "쉽게 볼 수있는 낡은 검이다.";
            bronzeWepon.gold = 600;
            // 청동 도끼
            ironWepon.type = "무기";
            ironWepon.name = "청동 도끼";
            ironWepon.hitPoint = 5;
            ironWepon.detail = " 어디선가 사용됐던거 같은 도끼입니다";
            ironWepon.gold = 1500;
            // 스파르타의 창
            dimWepon.type = "무기";
            dimWepon.name = "스파르타의 창";
            dimWepon.hitPoint = 7;
            dimWepon.detail = "스파르타의 전사들이 사용했다는 전설의 창입니다.";
            dimWepon.gold = 3100;
        }

        static int IsChecking(string value)
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
    }
}
