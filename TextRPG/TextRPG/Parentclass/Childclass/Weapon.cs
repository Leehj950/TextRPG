using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Parentclass.Childclass
{
    internal class Weapon : Item
    {
        private int mhitPoint = 0;

        public Weapon(string types, string name, string detail, int gold, int hitPoint) 
            : base(types, name, detail, gold)
        {
            mhitPoint = hitPoint;
        }

        public int HitPoint {  get { return mhitPoint; } }
    }
}
