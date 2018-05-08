using System;
using SwinGameSDK;

namespace Rover
{
    public class MainClass
    {
        public static void Main()
        {
            //Open the game window
            Environment theEnvironment = new Environment(800,800,1,1);

            int gameWidth = theEnvironment.Width + 400;
            int gameHeight = theEnvironment.Height;

            SwinGame.OpenGraphicsWindow ("Rover", gameWidth, gameHeight);

            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                SwinGame.ProcessEvents();

                SwinGame.ClearScreen(Color.White);
                SwinGame.FillRectangle(Color.Tan, 0, 0, theEnvironment.Width, theEnvironment.Height);
                SwinGame.DrawFramerate(0,0);

                theEnvironment.Update ();

                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}