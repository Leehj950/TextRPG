namespace TextRPG
{
    internal class EntryPoint
    {
        List<int> items = new List<int>();
        
        public EntryPoint() 
        {
            items.Add(0);
        }
        static void Main(string[] args)
        {
            MainScene Ms = new MainScene();
            Ms.Initialize();
            while(true)
            {
                Ms.Loop();
            }
        }

    }
}
