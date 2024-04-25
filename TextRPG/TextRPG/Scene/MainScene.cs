
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Contents;
using TextRPG.Interface;
using TextRPG.PlayerInfomation;

namespace TextRPG.Scene
{
    internal class MainScene : IFramework
    {
        /// <summary>
        /// value 
        /// </summary>
        //////////////////////////////////////////////////////////////////////
        Shop mShop;
        Player mplayer;
        bool isRender;
        bool misLoop;
        /// <summary>
        /// Get,Set 
        /// </summary>
        //////////////////////////////////////////////////////////////////////
        public bool IsLoop { get { return misLoop; } }
        /// <summary>
        /// 생성자
        /// </summary>
        ////////////////////////////////////////////////////////////////////// 
        public MainScene()
        {
            mplayer = new Player();
            mShop = new Shop();
            isRender = false;
        }
        /// <summary>
        /// Function
        /// </summary>
        //////////////////////////////////////////////////////////////////////
        // Awake onEnable Start 초기화 
        public void Initialize()
        {
            mShop.Initialize();
            mplayer.Initialize();
            mShop.Gold = mplayer.PlayerInfo.Gold;
            mShop.keyValues_in = mplayer.Inventory.keyValues;
        }
        // 연산
        public void Update()
        {
            //렌더러 아직 한번도 안돌았으면
            if (isRender == false)
            {
                isRender = true;
                return;
            }
            // 행동할 것을 입력받기
            int input = IsChecking(Console.ReadLine());

            // 입력값 스위칭문에서 찾기
            switch (input)
            {
                case 0:
                    misLoop = true;
                    break;
                case 1:
                    mplayer.PlayerInfo.Gold = mShop.Gold;
                    mplayer.StatusWindowLoop();
                    break;
                case 2:
                    mplayer.Inventory.keyValues = mShop.keyValues_in;
                    mplayer.InventoryLoop();
                    break;
                case 3:
                    mShop.Loop();
                    break;
            }
        }
        // 그리기
        public void Render()
        {
            MainTxt();
        }
        // 무한루프
        public void Loop()
        {
            Update();
            Render();
        }
        // 체크리스트 is가 붙은 이유는 안에서bool형태 연산을 하고 출력한것은 정수형이다.
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
                    temp = -1;
                }

                if (temp < 0 && temp > 4)
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
            Console.WriteLine("0. 게임종료");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
        }
    }


}
