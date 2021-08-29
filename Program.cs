using System;

namespace testGame
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            using (var game = new Painter())
                game.Run();
        }
    }
}