using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{

    internal class Player
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

        Inventory minventory;
        Satus_Window mstatusWindow;
        public Player() 
        {
            minventory = new Inventory();
            mstatusWindow = new Satus_Window();
        }

        public void InventoryLoop()
        {
            minventory.Loop();
        }

        public void StatusWindow()
        {
          //  mstatusWindow.Loop();
        }
    }
}
