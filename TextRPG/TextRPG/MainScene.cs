
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;

namespace TextRPG
{
    internal class MainScene : IFramework
    {
        Satus_Window Sw;
        Inventory In;
        Shop Sh;

        bool isRender;
        bool isLoop;
        public MainScene() 
        {
            Sw = new Satus_Window();
            In = new Inventory();
            Sh = new Shop();
            isRender = false;
            isLoop = true;
        }

        // Awake onEnable Start 초기화 
        public void Initialize()
        {
            MainTxt();
            Sh.Initialize();
            Sh.Gold = Sw.Gold;
            Sh.keyValues_in = In.keyValues;
        }
        // 연산
        public void Update()
        {
            //렌더러 아직 한번도 안돌았으면
            if(isRender == false )
            {
                isRender = true;
                return;
            }

            int input = IsChecking(Console.ReadLine());

            switch (input)
            {
                case 0:

                    break;
                case 1:
                    Sw.Gold = Sh.Gold;
                    Sw.Statuc_Window();
                    break;
                case 2:
                    In.keyValues = Sh.keyValues_in;
                    In.InventoryTxt();
                    break;
                case 3:
                    Sh.OpenShop();
                    break;
            }
        }
        // 그리기
        public void Render()
        {
            MainTxt();
        }

        public void Loop()
        {
            Update();
            Render();
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
            Console.Clear();
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
