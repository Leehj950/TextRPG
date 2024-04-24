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


    internal class Inventory : IFramework
    {
        Dictionary<int, Item> itemDictionary;
        bool isLoop;
        bool isRender;
        public Dictionary<int, Item> keyValues { get { return itemDictionary; } set { itemDictionary = value; } }
        public Inventory()
        {
            isLoop = false;
            isRender = false;
            itemDictionary = new Dictionary<int, Item>();
        }

        // 초기화 
        public void Initialize()
        {

        }

        public void Update()
        {
            // 그림이 한번이라도 출력하게 하기위한 체크를 합니다.
            if (!isRender)
            {
                return;
            }
            int num = IsChecking(Console.ReadLine());
            if (num == 1)
            {
                bool checknum = false;
                while (!checknum)
                {
                    InventoryListTxt();

                    Console.WriteLine("0. 나가기");
                    Console.WriteLine();
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    int itemnum = IsChecking(Console.ReadLine(), itemDictionary.Count);
                    if (itemnum == 0)
                    {
                        break;
                    }

                    if (itemDictionary[itemnum].IsEquip == true)
                    {
                        itemDictionary[itemnum].IsEquip = false;
                        if (itemDictionary[itemnum].Type == "갑옷")
                        {

                        }
                        else if (itemDictionary[itemnum].Type == "무기")
                        {

                        }
                    }

                    else
                    {
                        itemDictionary[itemnum].IsEquip = true;
                        if (itemDictionary[itemnum].Type == "갑옷")
                        {

                        }
                        else if (itemDictionary[itemnum].Type == "무기")
                        {

                        }
                    }
                }
            }
            else if (num == 0)
            {
                isLoop = true;
            }
        }

        public void Render()
        {
            InventoryListTxt();

            Console.WriteLine("1. 장착관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
        }

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

        public void InventoryTxt()
        {
            InventoryListTxt();
            Console.WriteLine("1. 장착관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            int num = IsChecking(Console.ReadLine());
            if (num == 1)
            {
                bool checknum = false;
                while (!checknum)
                {
                    InventoryListTxt();

                    Console.WriteLine("0. 나가기");
                    Console.WriteLine();
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    int itemnum = IsChecking(Console.ReadLine(), itemDictionary.Count);

                    if (itemnum == 0)
                    {
                        return;
                    }

                    if (itemDictionary[itemnum].IsEquip == true)
                    {
                        itemDictionary[itemnum].IsEquip = false;
                        if (itemDictionary[itemnum].Type == "갑옷")
                        {

                        }
                        else if (itemDictionary[itemnum].Type == "무기")
                        {

                        }
                    }

                    else
                    {
                        itemDictionary[itemnum].IsEquip = true;
                        if (itemDictionary[itemnum].Type == "갑옷")
                        {

                        }
                        else if (itemDictionary[itemnum].Type == "무기")
                        {

                        }
                    }
                }
            }
            else if (num == 0)
            {
                isLoop = true;
            }

        }

        void InventoryListTxt()
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유중인 아이템을 관리 할수 있습니다.");
            Console.WriteLine("[아이템 목록]");

            if (itemDictionary != null)
            {
                foreach (KeyValuePair<int, Item> node in itemDictionary)
                {
                    if (node.Value is Armor)
                    {
                        Armor armor = (Armor)node.Value;
                        if (node.Value.IsEquip == false)
                        {


                            Console.WriteLine("-" + node.Key + "." + node.Value.Name + "| " +
                                   "방어력 :" + armor.GuardPoint + "| " + node.Value.Detail +
                                   "| ");


                        }
                        else
                        {
                            Console.WriteLine("-" + node.Key + "." + node.Value.Equip + node.Value.Name + "| " +
                                       "방어력 :" + armor.GuardPoint + "| " + node.Value.Detail +
                                       "| ");
                        }

                    }
                    else if (node.Value is Weapon)
                    {
                        Weapon weapon = (Weapon)node.Value;
                        if (node.Value.IsEquip == false)
                        {
                            Console.WriteLine("-" + node.Key + "." + node.Value.Name + "| " +
                                   "공격력 : " + weapon.HitPoint + "| " + node.Value.Detail +
                                   "| ");
                        }
                        else
                        {
                            Console.WriteLine("-" + node.Key + "." + node.Value.Equip + node.Value.Name + "| " +
                                   "공격력 : " + weapon.HitPoint + "| " + node.Value.Detail +
                                   "| ");
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
                    temp = IsChecking(Console.ReadLine());
                }
            }
            return temp;
        }
        int IsChecking(string value, int num)
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

                if (temp < 0 || temp > num)
                {
                    InventoryListTxt();
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine();
                    Console.Write("잘못된 입력입니다 :");
                    temp = IsChecking(Console.ReadLine());
                }
            }
            return temp;
        }
    }
}
