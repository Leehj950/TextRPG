using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;

namespace TextRPG.PlayerInfomation
{

    internal class Player : IFramework
    {

        /// <summary>
        /// Value
        /// </summary>
        //////////////////////////////////////////////////////////


        private PlayerInfo mplayerInfo;
        private Inventory minventory;
        private Satus_Window mstatusWindow;
        
        /// <summary>
        /// 생성자
        /// </summary>
        ///////////////////////////////////////////////////////////
        
        public PlayerInfo PlayerInfo { get { return mplayerInfo; } }
        public Inventory Inventory { get { return minventory; } }  
        public Satus_Window Satus_Window { get { return mstatusWindow; } }
        public Player()
        {
            minventory = new Inventory();
            mstatusWindow = new Satus_Window();
            mplayerInfo = new PlayerInfo();
        }

        /// <summary>
        /// Function
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void Initialize()
        {
            minventory.Initialize(mplayerInfo);
            mstatusWindow.Initialize(mplayerInfo);
        }

        public void Update()
        {
            minventory.Update();
            mstatusWindow.Update();
        }

        public void Render()
        {

        }

        public void Loop()
        {

        }

        public void InventoryLoop()
        {
            minventory.Loop();
        }

        public void StatusWindowLoop()
        {
            mstatusWindow.Loop();
        }
    }
}
