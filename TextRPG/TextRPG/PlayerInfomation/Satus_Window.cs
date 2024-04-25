using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;

namespace TextRPG.PlayerInfomation
{ 

    internal class Satus_Window : IFramework
    {

        /// <summary>
        /// value 변수
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////
        private PlayerInfo mplayerInfo;
        // 이것 너무 반복적이다 추상화로 나중에 빼야지.
        private bool misLoop = false;
        private bool misRender = false;

        /// <summary>
        /// Function 함수
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////
        public void Initialize()
        {

        }
        
        public void Initialize(PlayerInfo value)
        {
            mplayerInfo = value;
        }

        public void Update()
        {
            if(!misRender)
            {
                misRender = true;
                return;
            }
            int num = IsChecking(Console.ReadLine());

            if (num == 0)
            {
                misLoop = true; 
                return;
            }
        }

        public void Render()
        {
            Console.Clear();

            Console.WriteLine($"chad ({mplayerInfo.Job})");
            Console.WriteLine($"공격력 : {mplayerInfo.TotalHitPoint}  {mplayerInfo.SubHitPoint_Str} ");
            Console.WriteLine($"방어력 : {mplayerInfo.TotalGuardPoint} {mplayerInfo.SubGuardPoint_Str}");
            Console.WriteLine($"체력 : {mplayerInfo.Hp} {mplayerInfo.SubHp}");
            Console.WriteLine($"Gold : {mplayerInfo.Gold}");
            Console.WriteLine();
            Console.WriteLine($"0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
        }

        public void Loop()
        {
            while (!misLoop)
            {
                Update();
                Render();
            }
            misLoop = false;
            misRender = false;
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

                if (temp != 0)
                {
                    Console.Write("잘못된 입력입니다 : ");
                    temp = IsChecking(Console.ReadLine());
                    return temp;
                }
            }
            return temp;
        }

    }
}
