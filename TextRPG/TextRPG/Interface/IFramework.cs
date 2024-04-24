using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Interface
{
    internal interface IFramework
    {
        void Initialize();
        void Update();
        void Render();
        void Loop();
    }
}
