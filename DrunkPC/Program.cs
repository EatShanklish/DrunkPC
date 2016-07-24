using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace DrunkPC
{
    class Program
    {
        public static Random _random = new Random();

        //--------------------------------------entry point--------------
        static void Main(string[] args)
        {
            Console.WriteLine("DrunkPC Application by Shanklish");

            //creates all threads that manipulate the PC
            Thread drunkMouseThread = new Thread(new ThreadStart(DrunkMouseThread));
            Thread drunkKeyboardThread = new Thread(new ThreadStart(DrunkKeyboardThread));
            Thread drunkSoundThread = new Thread(new ThreadStart(DrunkSoundThread));
            Thread drunkPopupThread = new Thread(new ThreadStart(DrunkPopupThread));

            //Starts all threads
            drunkMouseThread.Start();
            drunkKeyboardThread.Start();
            drunkSoundThread.Start();
            drunkPopupThread.Start();

            //waits for user input
            Console.Read();

            //kills all applications
            drunkMouseThread.Abort();
            drunkKeyboardThread.Abort();
            drunkSoundThread.Abort();
            drunkPopupThread.Abort();

        }
        #region Thread Functions
        //this thread will randomly affect the mouse movements
        public static void DrunkMouseThread()
        {
            Console.WriteLine("DrunkMouseThread Started");

            int movex = 0;
            int movey = 0;


            while (true)
            {
                Console.WriteLine(Cursor.Position.ToString());

                //Generate random amount to move the cursor
                movex = _random.Next(20) - 10;
                movey = _random.Next(20) - 10;

                //changes mouse cursor position to new coordinates
                Cursor.Position = new System.Drawing.Point(Cursor.Position.X + movex, Cursor.Position.Y + movey);
                

                Thread.Sleep(20);
            }
        }

        //this will randomly effect the keyboard
        public static void DrunkKeyboardThread()
        {
            Console.WriteLine("DrunkKeyboardThread Started");
            while (true)
            {
                char key = (char)(_random.Next(25) + 65);

                SendKeys.SendWait(key.ToString());
                
                Thread.Sleep(500);
            }
        }

        //this will make random sounds
        public static void DrunkSoundThread()
        {
            Console.WriteLine("DrunkSoundThread Started");

            while (true)
            {
                
                Thread.Sleep(500);
            }
        }

        //this will generate random popups
        public static void DrunkPopupThread()
        {
            Console.WriteLine("DrunkPopupThread Started");

            while (true)
            {
                Thread.Sleep(500);
            }
        }
        #endregion
    }
}
