using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.PlayerInfomation
{
    internal class PlayerInfo
    {
        /// <summary>
        /// Value 변수
        /// </summary>
        /////////////////////////////////////////////////
        // 나중에
        //private int mlevel;
        //private int mExperinceBar;
        
        /// 현재 쓰고 있는 것들
        private string mJob;
        private float mHitPoint;
        private int mGuardPoint;
        private int mHp;
        private int mGold;
        private string mSubHitPoint;
        private string mSubGuardPoint;
        private string mSubHp;
        private float mtotalHitPoint;
        private int mtotalGuardPoint;
        private float mSubtotalHitPoint;
        private int mSubtotalGuardPoint;
        private bool misArmor;

        /// <summary>
        /// 생성자
        /// </summary>
        //////////////////////////////////////////////////
        public PlayerInfo()
        {
            //mlevel = 1;
            //mExperinceBar = 10;
            mJob = "전사";
            mHitPoint = 10;
            mGuardPoint = 5;
            mHp = 100;
            mGold = 15000;
            mSubHitPoint = "";
            mSubGuardPoint = "";
            mSubHp = "";
            //다합친거
            mtotalHitPoint = mHitPoint;
            mtotalGuardPoint = mGuardPoint;

            // 장비만 증가한것
            mSubtotalHitPoint = 0;
            mSubtotalGuardPoint = 0;
        }

        /// <summary>
        /// Get, Set
        /// </summary>
        /////////////////////////////////////////////////////
        public string Job {  get { return mJob; } set { mJob = value; } }
        public float HitPoint { get { return mHitPoint; } set { mHitPoint = value; } }
        public int GuardPoint { get { return mGuardPoint; } set { mGuardPoint = value; } }
        public int Hp {  get { return mHp; } set { mHp = value; } }
        public int Gold { get { return mGold; } set { mGold = value; } }
        public string SubHitPoint_Str { get { return mSubHitPoint; } set { mSubHitPoint = value; } }
        public string SubGuardPoint_Str { get { return mSubGuardPoint; } set { mSubGuardPoint = value;  }  }
        public string SubHp { get { return mSubHp; } set { mSubHp = value; } }
        public float TotalHitPoint { get { return mtotalHitPoint; } set { mtotalHitPoint = value; } }
        public int TotalGuardPoint { get { return mtotalGuardPoint; } set { mtotalGuardPoint = value; } }
        public bool IsArmor { get { return misArmor; } set { misArmor = value; } }
        public float SubTotalHitPoint { get { return mSubtotalHitPoint; } set { mSubtotalHitPoint = value; } }
        public int SubTotalGuardPoint { get { return mSubtotalGuardPoint; } set { mSubtotalGuardPoint = value; } }

    }
}
