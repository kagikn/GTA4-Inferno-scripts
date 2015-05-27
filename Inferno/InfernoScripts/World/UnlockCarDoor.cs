using System;
using System.Windows.Forms;
using GTA;
using _InputChecker;

namespace Inferno.Scripts
{
    //周辺の車の鍵をあける
    public class CarLockOff : Script
    {
        InputChecker inputCheckerMOD = new InputChecker();

        Random rnd;

        public CarLockOff()
        {
            rnd = new Random();
            inputCheckerMOD.AddCheckKeys(new Keys[] { Keys.L, Keys.O, Keys.C, Keys.K });
            KeyDown += new GTA.KeyEventHandler(UnlockEveryCarDoor);
        }


        void UnlockEveryCarDoor(object sender, GTA.KeyEventArgs e)
        {
            inputCheckerMOD.AddInputKey(e.Key);

            if (inputCheckerMOD.Check(0))
            {
                Vehicle[] v = Cacher.GetVehicles(Player.Character.Position, 50.0f);

                for (int i = 0, length = v.Length; i < length; i++)
                {
                    if (Exists(v))
                    {
                        v[i].DoorLock = DoorLock.None;
                        Game.DisplayText("ドアロック解除", 4000);
                    }
                }

            }


        }
    }
}
