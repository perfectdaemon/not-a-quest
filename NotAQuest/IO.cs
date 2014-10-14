using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace NotAQuest
{
    static class IO
    {
        // Используется для получения данных о игре (игрок, текущее состояние и т.п)
        public static Game Game;

        public static bool AllowDebugOutput = false;

        static IO()
        {
            ConsoleColorChanger.SetColor(ConsoleColor.DarkMagenta, Color.FromArgb(128, 30, 40));
            ConsoleColorChanger.SetColor(ConsoleColor.DarkGreen, Color.FromArgb(0, 100, 50));            
        }

        public static void WriteTitle()
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("".PadRight(Console.WindowWidth - 1));
            Console.WriteLine("     Добро пожаловать в квест!".PadRight(Console.WindowWidth - 1));
            Console.WriteLine("".PadRight(Console.WindowWidth - 1));
            Console.WriteLine("     2014, perfect.daemon. Специально для IGDC #114".PadRight(Console.WindowWidth - 1));
            Console.WriteLine("".PadRight(Console.WindowWidth - 1));
        }

        public static void WriteMenu()
        {
            Console.ResetColor();

            Console.WriteLine("1. Играть ");
            Console.WriteLine("2. Выход  ");
        }

        private static void WriteInput()
        {            
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            string input = Game.player == null ? "Вы: " : string.Format("{0} (Вы): ", Game.player.Name);            
            Console.Write(input);
        }

        public static string ReadString()
        {
            WriteInput();            
            string value = Console.ReadLine();
            Console.ResetColor();
            return value;
        }

        public static int ReadInt()
        {
            return ReadInt(-1, -1);
        }

        public static int ReadInt(int min, int max)
        {
            int result = 0;
            bool isCorrect = false;
            do
            {
                isCorrect = int.TryParse(ReadString(), out result)
                    && ( (result >= min && result <= max) || (min < 0 && max < 0) );
            }
            while (!isCorrect);
            return result;                        
        }

        public static Reply ExecuteDialog(Dialog dialog)
        {            
            Write(dialog.Text, ConsoleColor.Black, ConsoleColor.White);
            Write("");
            int i = 1;
            foreach (Reply r in dialog.Replies)
            {
                Write((i++).ToString() + ". " + r.Text, ConsoleColor.Black, ConsoleColor.DarkGreen);
            }
            Write("");
            int result = ReadDialog(dialog);
            Write("");
            return dialog.Replies[result - 1];            
        }

        public static void WriteException(Exception e)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Что-то пошло не так: "
                + e.Message
                + Environment.NewLine
                + "Сохраните это для разработчика и нажмите [Enter] для выхода"
                );
        }

        public static void Write(string text, ConsoleColor back, ConsoleColor fore)
        {
            Console.BackgroundColor = back;
            Console.ForegroundColor = fore;
            Console.WriteLine(text);
        }

        public static void Write(string text, ConsoleColor back)
        {
            Write(text, back, ConsoleColor.White);
        }

        public static void Write(string text)
        {
            Write(text, ConsoleColor.Black, ConsoleColor.White);
        }

        public static void WriteDebug(string text)
        {
            if (AllowDebugOutput)
                Write(" # " + text, ConsoleColor.Black, ConsoleColor.DarkGray);
        }

        public static int ReadDialog(Dialog dialog)
        {
            return ReadInt(1, dialog.Replies.Count);
        }
    }
}