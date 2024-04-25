using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;
using TextRPG.Parentclass;
using TextRPG.Parentclass.Childclass;

namespace TextRPG.PlayerInfomation
{


    internal class Inventory : IFramework
    {

        PlayerInfo mplayrerInfo;
        Dictionary<int, Item> itemDictionary;
        bool isLoop;
        bool isRender;
        Item mfirst;
        Item msecond;
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

        public void Initialize(PlayerInfo value)
        {
            mplayrerInfo = value;
        }

        // 업데이트
        public void Update()
        {
            // 그림이 한번이라도 출력하게 하기위한 체크를 합니다.
            if (!isRender)
            {
                isRender = true;
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

                    // 장착 해제할때
                    if (itemDictionary[itemnum].IsEquip == true)
                    {
                        itemDictionary[itemnum].IsEquip = false;

                        if (itemDictionary[itemnum] is Armor)
                        {
               
                            Armor armor = (Armor)itemDictionary[itemnum];
                            mplayrerInfo.SubTotalGuardPoint -= armor.GuardPoint;
                            mplayrerInfo.TotalGuardPoint = mplayrerInfo.GuardPoint - mplayrerInfo.SubTotalGuardPoint;
                            if (mplayrerInfo.TotalGuardPoint > 0)
                            {
                                mplayrerInfo.SubGuardPoint_Str = $"+{mplayrerInfo.TotalGuardPoint}";
                            }
                            else
                            {
                                mplayrerInfo.SubHitPoint_Str = "";
                            }
                        }
                        else if (itemDictionary[itemnum] is Weapon)
                        {
                            Weapon weapon = (Weapon)itemDictionary[itemnum];
                            mplayrerInfo.SubTotalHitPoint -= weapon.HitPoint;
                            mplayrerInfo.TotalHitPoint = mplayrerInfo.HitPoint - mplayrerInfo.TotalHitPoint;
                            if (mplayrerInfo.TotalHitPoint > 0)
                            {
                                mplayrerInfo.SubHitPoint_Str = $"+{mplayrerInfo.SubTotalHitPoint}";
                            }
                            else
                            {
                                mplayrerInfo.SubHitPoint_Str = "";
                            }
                        }
                    }
                    // 장착할때
                    else
                    {
                        if(mfirst == null)
                        {
                            mfirst = itemDictionary[itemnum];
                        }
                        else
                        {
                            mfirst.IsEquip = false;
                            msecond = itemDictionary[itemnum];
                            msecond.IsEquip = true;
                            mfirst = msecond;
                        }
                        itemDictionary[itemnum].IsEquip = true;
                        if (itemDictionary[itemnum] is Armor )
                        {
                            Armor armor = (Armor)itemDictionary[itemnum];
                            mplayrerInfo.SubTotalGuardPoint += armor.GuardPoint;
                            mplayrerInfo.TotalGuardPoint = mplayrerInfo.GuardPoint + mplayrerInfo.SubTotalGuardPoint;
                            mplayrerInfo.SubGuardPoint_Str = $"+({mplayrerInfo.SubTotalGuardPoint})";
                            mplayrerInfo.IsArmor = true;
                        }
                        else if (itemDictionary[itemnum] is Weapon)
                        {
                            Weapon weapon = (Weapon)itemDictionary[itemnum];
                            mplayrerInfo.SubTotalHitPoint += weapon.HitPoint;
                            mplayrerInfo.TotalHitPoint = mplayrerInfo.HitPoint + mplayrerInfo.SubTotalHitPoint;
                            mplayrerInfo.SubHitPoint_Str = $"+{mplayrerInfo.SubTotalHitPoint}";
                        }
                    }
                }
            }
            else if (num == 0)
            {
                isLoop = true;
            }

        }

        //렌더러
        public void Render()
        {
            InventoryListTxt();

            Console.WriteLine("1. 장착관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
        }

        // 루프
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

                if (temp < 0 || temp > 1)
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
                    return temp;
                }
            }
            return temp;
        }
    }
}
