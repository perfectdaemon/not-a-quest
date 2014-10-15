/*
 * Квест
 */

using System;

namespace NotAQuest
{
    class Program
    {      
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight / 2);
            if (args.Length > 0)
                IO.AllowDebugOutput = args[0] == "-debug";

            try
            {
                Game game = new Game();
                game.Start();
                switch (game.state)
                { 
                    case ExitState.FromMenu:                        
                        break;
                }
            }
            catch (Exception e)
            {
                IO.WriteException(e);
                IO.ReadString();
            }
        }        
    }     
}
