using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Satus_Window
    {

        private int level = 1;
        private string mJob = "전사";
        private int mHitPoint = 10;
        private int mGuardPoint = 5;
        private int mHp = 100;
        private int mMoney = 1500;
        private string mSubHitPoint = " ";
        private string mSubGuardPoint = " ";
        private string mSubHp = " ";
        public int Gold { get { return mMoney; } set { mMoney = value; } }
        public string SubHitPoint { get { return mSubHitPoint; } set { mSubHitPoint = value; } }
        public int GuardPoint { get { return mGuardPoint; } set { mGuardPoint = value; } }
        ////////////////////////////////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////////////////////////////////////
        public void Statuc_Window()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine($"chad ({mJob})");
                Console.WriteLine($"공격력 : {mHitPoint}  {mSubHitPoint} ");
                Console.WriteLine($"방어력 : {mGuardPoint} {mSubGuardPoint}");
                Console.WriteLine($"체력 : {mHp} {mSubHp}");
                Console.WriteLine($"Gold : {mMoney}");
                Console.WriteLine();
                Console.WriteLine($"0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                int num = IsChecking(Console.ReadLine());

                if (num == 0)
                {
                    return;
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

                if (temp != 0)
                {
                    Console.Write("잘못된 입력입니다 : ");
                    temp = IsChecking(Console.ReadLine());
                }
            }
            return temp;
        }

    }
}
