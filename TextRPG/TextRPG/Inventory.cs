using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{

    internal class Inventory
    {
        Dictionary<int , Node> keyValuePairs = new Dictionary<int , Node>();

        public void InventoryTxt()
        {
            bool cheaking = false;

            while (!cheaking)
            {
                InventoryListTxt();

                Console.WriteLine("1. 장착관리");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");

                int num = IsChecking(Console.ReadLine());
                if(num == 1) 
                {
                    bool checknum = false;
                    while (!checknum)
                    {
                        InventoryListTxt();

                        Console.WriteLine("0. 나가기");
                        int itemnum = IsChecking(Console.ReadLine());
                        if (itemnum == 0) 
                        {
                            checknum = true;
                        }
                    }
                }
                else if (num == 0)
                {
                    cheaking = true;
                }
            }
        }

        void InventoryListTxt() 
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유중인 아이템을 관리 할수 있습니다.");
            Console.WriteLine("[아이템 목록]");


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
    }
}
