using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Parentclass
{
    abstract class Item
    {
        // 초기화로 변경가능것들
        protected string mtype = "";
        protected string mname = "";
        protected string mdetail = "";
        protected int mgold = 0;

        //변경은 있으나 초기화를 기본적으로 받지 않는 것들
        protected bool misSoldOut = false;
        protected bool misEquip = false;
        protected bool misBuy = false;

        // 변경 없는 것들 
        protected string msoldOut = "구매완료";
        protected string mEquip = "[E]";
        
        //생성자
        public Item (string types , string name , string detail, int gold)
        {
            mtype = types;
            mname = name;
            mdetail = detail;
            mgold = gold;
        }

        //Get,Set 함수
        public string Type { get { return mtype; } set { mtype = value; } }
        public string Name { get { return mname; } set { mname = value; } }
        public string Detail { get { return mdetail; } set { mdetail = value; } }
        public int Gold { get { return mgold; } set { mgold = value; } }
        public string SoldOut { get { return msoldOut; } }
        public string Equip { get { return mEquip; } }
        public bool IsEquip { get { return misEquip; } set { misEquip = value; } }
        public bool IsBuy { get { return misBuy; } set { misBuy = value; } } 
        public bool IsSoldOut { get { return misSoldOut; } set { misSoldOut = value; } }

        //무기만 
        //public int hitPoint = 0;
        //방어구만
        //public int guardPoint = 0;

    }
}
