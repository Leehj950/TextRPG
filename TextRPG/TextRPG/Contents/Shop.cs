using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TextRPG.Interface;
using TextRPG.Parentclass;
using TextRPG.Parentclass.Childclass;

namespace TextRPG.Contents
{
    internal class Shop : IFramework
    {
        /// <summary>
        /// Value 변수
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        int mGold = 0;
        int startsecne = 0;
        bool isRender = false;
        bool isLoop = false;
        bool isShoping = false;
        Item bronzeArmor;
        Item ironArmor;
        Item dimArmor;
        Item bronzeWepon;
        Item ironWepon;
        Item dimWepon;
        Dictionary<int, Item> mshopList = new Dictionary<int, Item>();
        Dictionary<int, Item> minventory;

        /// <summary>
        /// Get, Set 
        /// </summary>
        ////////////////////////////////////////////////////////////////////////
        public Dictionary<int, Item> keyValues_in { get { return minventory; } set { minventory = value; } }
        public int Gold { get { return mGold; } set { mGold = value; } }
        /// <summary>
        /// 생성자
        /// </summary>
        ///////////////////////////////////////////////////////////////////////
        
        public Shop()
        {
            bronzeArmor = new Armor("갑옷", "수련자 갑옷", "수련에 도움을 주는 갑옷이다.", 1000, 5);
            ironArmor = new Armor("갑옷", "무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷이다.", 2100, 9);
            dimArmor = new Armor("갑옷", "스파르타 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500, 15);
            bronzeWepon = new Weapon("무기", "낡은 검", "쉽게 볼 수있는 낡은 검이다.", 600, 2);
            ironWepon = new Weapon("무기", "청동 도끼", " 어디선가 사용됐던거 같은 도끼입니다", 1500, 5);
            dimWepon = new Weapon("무기", "스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 3100, 7);
        }

        /// <summary>
        /// Function 함수
        /// </summary>
        ///////////////////////////////////////////////////////////////////////
        ///
        //초기화
        public void Initialize()
        {
            mshopList.Add(1, bronzeArmor);
            mshopList.Add(2, ironArmor);
            mshopList.Add(3, dimArmor);
            mshopList.Add(4, bronzeWepon);
            mshopList.Add(5, ironWepon);
            mshopList.Add(6, dimWepon);
        }
        //업데이트
        public void Update()
        {
            isShoping = false;
            if (isRender == false)
            {
                isRender = true;
                return;
            }
            int num = IsChecking(Console.ReadLine());

            if (num == 1)
            {
                foreach (KeyValuePair<int, Item> node in mshopList)
                {
                    node.Value.IsBuy = true;
                }
                ShopTxt(num);
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                int num1 = IsCheckingsize(Console.ReadLine(), mshopList.Count);

                if (num1 == 0)
                {
                    isLoop = true;
                    return;
                }

                while (!isShoping)
                {
                    if (num1 == 0)
                    {
                        isShoping = true;
                    }
                    else if (mshopList[num1].IsSoldOut == false)
                    {
                        // 만약 골드가 없으면 
                        if (mshopList[num1].Gold > mGold)
                        {
                            ShopTxt(num);
                            Console.WriteLine();
                            Console.WriteLine("0. 나가기");
                            Console.WriteLine();
                            Console.WriteLine("돈이 부족합니다.");
                            Console.Write("다시입력하세요. : ");
                            num1 = IsCheckingsize(Console.ReadLine(), mshopList.Count);
                        }
                        // 골드가 있으면
                        else
                        {
                            // 계산한 후
                            mshopList[num1].IsSoldOut = true;
                            mGold -= mshopList[num1].Gold;
                            keyValues_in.Add(keyValues_in.Count + 1, mshopList[num1]);
                            // 추가 구매 유무 확인
                            ShopTxt(num);
                            Console.WriteLine();
                            Console.WriteLine("0. 나가기");
                            Console.WriteLine();
                            Console.WriteLine("더 구매하시겠습니까?");
                            Console.Write("다시입력하세요 : ");
                            num1 = IsCheckingsize(Console.ReadLine(), mshopList.Count);
                        }
                    }
                    else if (mshopList[num1].IsSoldOut == true)
                    {
                        ShopTxt(num);
                        Console.WriteLine();
                        Console.WriteLine("0. 나가기");
                        Console.WriteLine();
                        Console.WriteLine("판매가 되어서 구매할수없습니다..");
                        Console.Write("다시입력하세요. : ");
                        num1 = IsCheckingsize(Console.ReadLine(), mshopList.Count);
                    }
                }
            }
            // 아이템 판매를 위한 if문
            else if (num == 2)
            {
                while(!isShoping)
                {
                    SellTxt();
                    int sellnum = IsCheckingsize(Console.ReadLine(),mshopList.Count);
                    
                    if(sellnum == 0)
                    {
                        isShoping = true;
                        break;
                    }

                    if(sellnum > minventory.Count)
                    {
                        continue;
                    }

                    if (minventory[sellnum].IsEquip == true)
                    {
                        minventory[sellnum].IsEquip = false;
                        float SellGold = minventory[sellnum].Gold * 0.85f;
                        mGold += (int)SellGold;
                        minventory.Remove(sellnum);
                        
                    }
                    else
                    {
                        float SellGold = minventory[sellnum].Gold * 0.85f;
                        mGold += (int)SellGold;
                        minventory.Remove(sellnum);
                    }
                }
            }
            else if (num == 0)
            {
                isLoop = true;
                return;
            }
        }
        //렌더러
        public void Render()
        {
            ShopTxt(startsecne);
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
        }
        //루프
        public void Loop()
        {
            while (!isLoop)
            {
                Update();
                Render();
            }
            isLoop = false;
            isRender = false;
        }

        //메인 화면및 상점 화면
        void ShopTxt(int value)
        {
            Console.Clear();

            if (value == 0)
            {
                Console.WriteLine("상점");
            }
            else if (value == 1)
            {
                Console.Write("상점");
                Console.WriteLine("-아이템 구매");
            }


            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(Gold + "G");

            foreach (KeyValuePair<int, Item> itemlist in mshopList)
            {
                if (itemlist.Value is Armor)
                {
                    Armor armor = (Armor)itemlist.Value;

                    if (itemlist.Value.IsBuy == false)
                    {
                        if (itemlist.Value.IsSoldOut == false)
                        {
                            Console.WriteLine("-" + itemlist.Value.Name + "| " +
                                "방어력" + armor.GuardPoint + "| " + itemlist.Value.Detail +
                                "| " + itemlist.Value.Gold + "G");
                        }
                        else
                        {
                            Console.WriteLine("-" + itemlist.Value.Name + "| " +
                                 "방어력" + armor.GuardPoint + "| " + itemlist.Value.Detail +
                                 "| " + itemlist.Value.SoldOut);
                        }

                    }
                    else
                    {
                        if (itemlist.Value.IsSoldOut == false)
                        {
                            Console.WriteLine("-" + itemlist.Key + itemlist.Value.Name + "| " +
                                "방어력 " + armor.GuardPoint + "| " + itemlist.Value.Detail +
                                "| " + itemlist.Value.Gold + "G");
                        }
                        else
                        {
                            Console.WriteLine("-" + itemlist.Key + itemlist.Value.Name + "| " +
                                 "방어력 " + armor.GuardPoint + "| " + itemlist.Value.Detail +
                                 "| " + itemlist.Value.SoldOut);
                        }
                    }

                }
                else if (itemlist.Value is Weapon)
                {
                    Weapon weapon = (Weapon)itemlist.Value;

                    if (itemlist.Value.IsBuy == false)
                    {
                        if (itemlist.Value.IsSoldOut == false)
                        {
                            Console.WriteLine("-" + itemlist.Value.Name + " " +
                             "공격력 " + weapon.HitPoint + "| " + itemlist.Value.Detail +
                            "| " + itemlist.Value.Gold + "G");
                        }
                        else
                        {
                            Console.WriteLine("-" + itemlist.Value.Name + "| " +
                            "공격력 " + weapon.HitPoint + "| " + itemlist.Value.Detail +
                           "| " + itemlist.Value.SoldOut);
                        }
                    }
                    else
                    {
                        if (itemlist.Value.IsSoldOut == false)
                        {
                            Console.WriteLine("-" + itemlist.Key + itemlist.Value.Name + "| " +
                             "공격력 " + weapon.HitPoint + "| " + itemlist.Value.Detail +
                            "| " + itemlist.Value.Gold + "G");
                        }
                        else
                        {
                            Console.WriteLine("-" + itemlist.Key + itemlist.Value.Name + "| " +
                            "공격력 " + weapon.HitPoint + "| " + itemlist.Value.Detail +
                           "| " + itemlist.Value.SoldOut);
                        }
                    }
                }
            }
        }
        //판매 화면 및 상점 화면
        void SellTxt()
        {
            Console.Clear();
            Console.Write("상점");
            Console.WriteLine("-아이템 판매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine( Gold + "G");
            foreach (KeyValuePair<int, Item> items in minventory)
            {
                if (minventory.Count == 0)
                {
                    Console.WriteLine("아이템이 없습니다.");
                    break;
                }

                if (items.Value is Armor)
                {
                    Armor armor = (Armor)items.Value;
                    if (items.Value.IsEquip == false)
                    {
                        Console.WriteLine("-" + items.Key + "." + items.Value.Name + "| " +
                               "방어력 :" + armor.GuardPoint + "| " + items.Value.Detail +
                               "| ");
                    }
                    else
                    {
                        Console.WriteLine("-" + items.Key + "." + items.Value.Equip + items.Value.Name + "| " +
                        "방어력 :" + armor.GuardPoint + "| " + items.Value.Detail +
                        "| ");
                    }

                }
                else if (items.Value is Weapon)
                {
                    Weapon weapon = (Weapon)items.Value;
                    if (items.Value.IsEquip == false)
                    {
                        Console.WriteLine("-" + items.Key + "." + items.Value.Name + "| " +
                        "공격력 : " + weapon.HitPoint + "| " + items.Value.Detail +
                               "| ");
                    }
                    else
                    {
                        Console.WriteLine("-" + items.Key + "." + items.Value.Equip + items.Value.Name + "| " +
                        "공격력 : " + weapon.HitPoint + "| " + items.Value.Detail +
                        "| ");
                    }
                }
            }
            Console.WriteLine("0.나가기");
            Console.WriteLine();
            Console.WriteLine("판매하실 번호를 입력해주세요.");
            Console.Write(">>");
        }

        // 체크하는 함수 
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

                if (temp < 0 || temp > 2)
                {
                    Console.Write("잘못된 입력입니다 : ");
                    temp = IsChecking(Console.ReadLine());
                    return temp;
                }
            }
            return temp;
        }
        // 체크하는 함수 오버라이딩
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
                    return temp;
                }
            }
            return temp;
        }
        // 
    }
}
