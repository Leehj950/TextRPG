using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TextRPG.Parentclass.Childclass
{
    internal class Armor : Item
    {
        private int mguardPoint = 0;
        // 
        public Armor(string types1, string name,string detail,int gold  ,int guardpoint) 
            : base (types1, name, detail, gold)
        { 
            mguardPoint = guardpoint;
        }

        public int GuardPoint { get { return mguardPoint; } }
    }
}
