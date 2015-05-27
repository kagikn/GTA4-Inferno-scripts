using System;
using System.Windows.Forms;
using GTA;
using _InputChecker;

namespace Inferno.Scripts
{
    //神風パトカー
    public class TamifulPoliceCar : Script
    {
        InputChecker inputCheckerMOD = new InputChecker();
        bool ActiveFlag;
        Random rnd;

        public TamifulPoliceCar()
        {
            ActiveFlag = false;
            rnd = new Random();
            inputCheckerMOD.AddCheckKeys(new Keys[] { Keys.T, Keys.A, Keys.M, Keys.I, Keys.P });
            inputCheckerMOD.AddCheckKeys(new Keys[] { Keys.A, Keys.L, Keys.L, Keys.O, Keys.N });
            Interval = 5000;
            this.Tick += new EventHandler(this._Tick);
            KeyDown += new GTA.KeyEventHandler(_KeyDown);
        }

        private void _Tick(object sender, EventArgs e)
        {

            if (ActiveFlag)
            {
                if (Player.WantedLevel > 0)
                {
                    //手配度が付いているとき

                    Vehicle[] allV = Cacher.GetVehicles(Player.Character.Position,50.0f);

                    for (int i = 0, length = allV.Length; i < length; i++)
                    {
                        if (!Exists(allV[i])) { continue; }

                        Ped ped = allV[i].GetPedOnSeat(VehicleSeat.Driver);
                        if(!Exists(ped)){continue;}
                        if (ped == Player.Character) { continue; }

                        if (GTA.Native.Function.Call<bool>("IS_CHAR_IN_ANY_POLICE_VEHICLE", ped))
                        {
                            //近くにある人が乗っている警察車両を発火させる
                            if (rnd.Next(0, 101) < 30)
                            {
                                if (allV[i].PetrolTankHealth > 0) {
                                    allV[i].PetrolTankHealth = -rnd.Next(500, 900); 
                                }
                            }
                        }

                    }
                }
            }
        }


        void _KeyDown(object sender, GTA.KeyEventArgs e)
        {
            inputCheckerMOD.AddInputKey(e.Key);

            if (inputCheckerMOD.Check(1))
            {
                ActiveFlag = true;
            }

            if (inputCheckerMOD.Check(0))
            {
                if (ActiveFlag)
                {
                    ActiveFlag = false;
                    Game.DisplayText("TamiPato OFF", 4000);
                }
                else
                {
                    ActiveFlag = true;
                    Game.DisplayText("TamiPato ON", 4000);
                }
            }


        }
    }
}
