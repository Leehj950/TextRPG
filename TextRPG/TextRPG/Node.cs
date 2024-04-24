using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Node
    {

        public bool isEquip = false;
        public string type = "";
        public string name = "";
        public int hitPoint = 0;
        public int guardPoint = 0;
        public string detail = "";
        public int gold = 0;
        public bool isSoldOut = false;
        public string soldOut = "구매완료";
        public bool isBuy = false;

    }
}
