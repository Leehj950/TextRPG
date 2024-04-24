
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class MainScene
    {
        Satus_Window Sw = new Satus_Window();
        Inventory In = new Inventory();
        Shop Sh = new Shop();
        public void MainSceneWindow()
        {
            Sh.init();
            Sh.Gold = Sw.Gold;
            Console.Clear();
            MainTxt();
            int input = IsChecking(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Sw.Gold = Sh.Gold;
                    Sw.Statuc_Window();
                    break;
                case 2:
                    In.InventoryTxt();
                    break;
                case 3:
                    Sh.Gold = Sw.Gold; 
                    Sh.OpenShop();
                    break;
            }
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
                    Console.WriteLine("올바른 숫자값이 아닙니다.");
                    return -1;
                }

                if (temp < 0 && temp > 3)
                {
                    Console.Write("잘못된 입력입니다 : ");
                    temp = IsChecking(Console.ReadLine());
                }
            }
            return temp;
        }
        void MainTxt()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리 ");
            Console.WriteLine("3. 상점");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

        }
    }


}
