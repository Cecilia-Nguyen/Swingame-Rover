using System;
using SwinGameSDK;

namespace Rover
{
    public class MainClass
    {
        public static void Main()
        {
            //Open the game window 
            Environment theEnvironment = new Environment(800,800,1,10);

            int gameWidth = theEnvironment.Width + 400;
            int gameHeight = theEnvironment.Height;
			int lineInterval = gameHeight / 20;

            SwinGame.OpenGraphicsWindow ("Rover", gameWidth, gameHeight);

            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                SwinGame.ProcessEvents();
                //Draw Backgrounds
                SwinGame.ClearScreen(Color.White);
                SwinGame.FillRectangle(Color.Tan, 0, 0, theEnvironment.Width, theEnvironment.Height);

				//Draw Lines
				for (int i = 0; i < theEnvironment.Width / lineInterval; i++) 
				{
					SwinGame.DrawLine (Color.Grey, i * lineInterval, theEnvironment.Height, i * lineInterval, 0); //Vertical
					SwinGame.DrawLine (Color.Grey, 0, i * lineInterval, theEnvironment.Width - 1, i * lineInterval); //Horizontal
				}

				//User Input
				if (SwinGame.KeyTyped (KeyCode.vk_TAB)) { theEnvironment.SelectNextRover(); }

                theEnvironment.Update ();

                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}