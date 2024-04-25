using TextRPG.Scene;

namespace TextRPG
{
    internal class EntryPoint
    {
        static void Main(string[] args)
        {
            bool misLoop = false;
            MainScene Ms = new MainScene();
            Ms.Initialize();
            while(!misLoop)
            {
                Ms.Loop();
                misLoop = Ms.IsLoop;
            }
        }
    }
}
