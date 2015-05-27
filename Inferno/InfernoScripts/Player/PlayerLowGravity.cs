using System;
using System.Windows.Forms;
using GTA;
using _InputChecker;

namespace Inferno.Scripts
{
    //ふわふわするやつだ
    public class PlayerLowGravity : Script
    {
        InputChecker inputCheckerMOD = new InputChecker();

        Random rnd;

        public PlayerLowGravity()
        {

            rnd = new Random();
            inputCheckerMOD.AddCheckKeys(new Keys[] { Keys.A, Keys.L, Keys.L, Keys.O, Keys.N });
            Interval = 80;
            this.Tick += new EventHandler(this.MakeLowGravity);
        }

        private void MakeLowGravity(object sender, EventArgs e)
        {
            if (!Player.Character.isInVehicle())
            {
                if (Game.isGameKeyPressed(GameKey.Jump) && Game.isGameKeyPressed(GameKey.Sprint))
                {

                    Player.Character.ApplyForce(new Vector3(0, 0, 0.9f));

                }
                
            }
        }
    }
}
