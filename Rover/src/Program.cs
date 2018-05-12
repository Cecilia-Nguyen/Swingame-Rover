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
				if (SwinGame.KeyTyped (KeyCode.vk_a)) { theEnvironment.SelectedRover.Attach (theEnvironment.SelectedDevice); }
				if (SwinGame.KeyTyped (KeyCode.vk_d)) { theEnvironment.SelectedRover.Remove (theEnvironment.SelectedDevice); }
				if (SwinGame.KeyTyped (KeyCode.vk_SPACE)) 
				{
					if(theEnvironment.SelectedDevice.Attached)
					{
						theEnvironment.SelectedRover.Use (theEnvironment.SelectedDevice);
					}else 
					{
						Console.WriteLine (theEnvironment.SelectedDevice.Name + " is not attached");
					}

				}

                //Handle Numbers
				//TODO - Make numbers more compact
				if (SwinGame.KeyTyped (KeyCode.vk_1)) 
				{ 
					theEnvironment.SelectDevice(theEnvironment.SelectedRover.Devices[0]); 
				}
				if (SwinGame.KeyTyped (KeyCode.vk_2)) 
				{
					theEnvironment.SelectDevice(theEnvironment.SelectedRover.Devices[1]); 
                }
				if (SwinGame.KeyTyped (KeyCode.vk_3)) 
				{
					theEnvironment.SelectDevice(theEnvironment.SelectedRover.Devices[2]); 
                }
				if (SwinGame.KeyTyped (KeyCode.vk_4)) 
				{
					theEnvironment.SelectDevice(theEnvironment.SelectedRover.Devices[3]); 
                }
				if (SwinGame.KeyTyped (KeyCode.vk_5)) 
				{
					theEnvironment.SelectDevice(theEnvironment.SelectedRover.Devices[4]); 
                }
				if (SwinGame.KeyTyped (KeyCode.vk_6)) 
				{
					theEnvironment.SelectDevice(theEnvironment.SelectedRover.Devices[5]); 
                }
				if (SwinGame.KeyTyped (KeyCode.vk_7)) 
				{
					theEnvironment.SelectDevice(theEnvironment.SelectedRover.Devices[6]); 
                }
				if (SwinGame.KeyTyped (KeyCode.vk_8)) 
				{
					theEnvironment.SelectDevice(theEnvironment.SelectedRover.Devices[7]); 
                }
				if (SwinGame.KeyTyped (KeyCode.vk_9)) 
				{
					theEnvironment.SelectDevice(theEnvironment.SelectedRover.Devices[8]); 
                }

                



				theEnvironment.Update ();

                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}