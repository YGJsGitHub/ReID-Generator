using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using GTA;
using GTA.Math;
using GTA.Native;
using DWORD = System.Int32;

struct Loction
{
    public double posX;
    public double posY;
    public double posZ;
}

namespace ReID_Generator
{
    public class ReID_Gen : Script
    {
        //Initialize menu
        GTA.Menu menu_0a, menu_1a;
        //Initialize weather
        string weather = "Default";
        //Recycle ped
        Ped tmpped;

        //Random seed
        Random ran = new Random(1);
        //Camera view angle
        Vector3[] cams = {
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 6d), Y = (float)Math.Cos(Math.PI / 18d * 6d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 7d), Y = (float)Math.Cos(Math.PI / 18d * 7d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 8d), Y = (float)Math.Cos(Math.PI / 18d * 8d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 9d), Y = (float)Math.Cos(Math.PI / 18d * 9d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 10d), Y = (float)Math.Cos(Math.PI / 18d * 10d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 11d), Y = (float)Math.Cos(Math.PI / 18d * 11d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 12d), Y = (float)Math.Cos(Math.PI / 18d * 12d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 13d), Y = (float)Math.Cos(Math.PI / 18d * 13d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 14d), Y = (float)Math.Cos(Math.PI / 18d * 14d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 15d), Y = (float)Math.Cos(Math.PI / 18d * 15d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 16d), Y = (float)Math.Cos(Math.PI / 18d * 16d), Z = 0.2f},
           // new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 17d), Y = (float)Math.Cos(Math.PI / 18d * 17d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 18d), Y = (float)Math.Cos(Math.PI / 18d * 18d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 19d), Y = (float)Math.Cos(Math.PI / 18d * 19d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 20d), Y = (float)Math.Cos(Math.PI / 18d * 20d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 21d), Y = (float)Math.Cos(Math.PI / 18d * 21d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 22d), Y = (float)Math.Cos(Math.PI / 18d * 22d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 23d), Y = (float)Math.Cos(Math.PI / 18d * 23d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 24d), Y = (float)Math.Cos(Math.PI / 18d * 24d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 25d), Y = (float)Math.Cos(Math.PI / 18d * 25d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 26d), Y = (float)Math.Cos(Math.PI / 18d * 26d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 27d), Y = (float)Math.Cos(Math.PI / 18d * 27d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 28d), Y = (float)Math.Cos(Math.PI / 18d * 28d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 29d), Y = (float)Math.Cos(Math.PI / 18d * 29d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 30d), Y = (float)Math.Cos(Math.PI / 18d * 30d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 31d), Y = (float)Math.Cos(Math.PI / 18d * 31d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 32d), Y = (float)Math.Cos(Math.PI / 18d * 32d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 33d), Y = (float)Math.Cos(Math.PI / 18d * 33d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 34d), Y = (float)Math.Cos(Math.PI / 18d * 34d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 35d), Y = (float)Math.Cos(Math.PI / 18d * 35d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 0d), Y = (float)Math.Cos(Math.PI / 18d * 0d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 1d), Y = (float)Math.Cos(Math.PI / 18d * 1d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 2d), Y = (float)Math.Cos(Math.PI / 18d * 2d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 3d), Y = (float)Math.Cos(Math.PI / 18d * 3d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 4d), Y = (float)Math.Cos(Math.PI / 18d * 4d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 5d), Y = (float)Math.Cos(Math.PI / 18d * 5d), Z = 0.2f},
        };

        Vector3[] cams2 = {
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 0d), Y = (float)Math.Cos(Math.PI / 18d * 0d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 1d), Y = (float)Math.Cos(Math.PI / 18d * 1d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 2d), Y = (float)Math.Cos(Math.PI / 18d * 2d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 3d), Y = (float)Math.Cos(Math.PI / 18d * 3d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 4d), Y = (float)Math.Cos(Math.PI / 18d * 4d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 5d), Y = (float)Math.Cos(Math.PI / 18d * 5d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 6d), Y = (float)Math.Cos(Math.PI / 18d * 6d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 7d), Y = (float)Math.Cos(Math.PI / 18d * 7d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 8d), Y = (float)Math.Cos(Math.PI / 18d * 8d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 9d), Y = (float)Math.Cos(Math.PI / 18d * 9d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 10d), Y = (float)Math.Cos(Math.PI / 18d * 10d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 11d), Y = (float)Math.Cos(Math.PI / 18d * 11d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 12d), Y = (float)Math.Cos(Math.PI / 18d * 12d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 13d), Y = (float)Math.Cos(Math.PI / 18d * 13d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 14d), Y = (float)Math.Cos(Math.PI / 18d * 14d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 15d), Y = (float)Math.Cos(Math.PI / 18d * 15d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 16d), Y = (float)Math.Cos(Math.PI / 18d * 16d), Z = 0.2f},
           // new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 17d), Y = (float)Math.Cos(Math.PI / 18d * 17d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 18d), Y = (float)Math.Cos(Math.PI / 18d * 18d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 19d), Y = (float)Math.Cos(Math.PI / 18d * 19d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 20d), Y = (float)Math.Cos(Math.PI / 18d * 20d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 21d), Y = (float)Math.Cos(Math.PI / 18d * 21d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 22d), Y = (float)Math.Cos(Math.PI / 18d * 22d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 23d), Y = (float)Math.Cos(Math.PI / 18d * 23d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 24d), Y = (float)Math.Cos(Math.PI / 18d * 24d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 25d), Y = (float)Math.Cos(Math.PI / 18d * 25d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 26d), Y = (float)Math.Cos(Math.PI / 18d * 26d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 27d), Y = (float)Math.Cos(Math.PI / 18d * 27d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 28d), Y = (float)Math.Cos(Math.PI / 18d * 28d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 29d), Y = (float)Math.Cos(Math.PI / 18d * 29d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 30d), Y = (float)Math.Cos(Math.PI / 18d * 30d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 31d), Y = (float)Math.Cos(Math.PI / 18d * 31d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 32d), Y = (float)Math.Cos(Math.PI / 18d * 32d), Z = 0.2f},
            new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 33d), Y = (float)Math.Cos(Math.PI / 18d * 33d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 34d), Y = (float)Math.Cos(Math.PI / 18d * 34d), Z = 0.2f},
            //new Vector3 { X = (float)Math.Sin(Math.PI / 18d * 35d), Y = (float)Math.Cos(Math.PI / 18d * 35d), Z = 0.2f},
        };

        //Ped background
        Loction[] locations =
        {
            new Loction{posX = 533.268, posY = -1435.525, posZ = 29.355},
            new Loction{posX = 1244.965, posY = -1440.827, posZ = 35.053},
            new Loction{posX = 2517.980, posY = 851.251, posZ = 87.459},

            /*
            new Loction{posX = -2080.352, posY = 1190.396, posZ = 290.490},
            new Loction{posX = -1426.068, posY = -1341.568, posZ = 3.724},
            new Loction{posX = -2080.352, posY = 1190.396, posZ = 290.490},
            new Loction{posX = 2859.957, posY = 196.323, posZ = 3.724},
            new Loction{posX = 1083.522, posY = -411.249, posZ = 67.157},*/
        };

        //Useless ped
        int[] errHash = { 11, 12, 27, 35, 44, 54, 111, 122, 174, 175, 188, 167, 189, 210, 233, 261, 264, 310, 331, 339, 453, 406, 422, 430, 446, 474, 475, 484, 485, 509, 522, 531, 577, 581, 617, 632, 643, 666, 742 };

        //Build function
        public ReID_Gen()
        {
            GTA.MenuButton btnTest = new MenuButton("Test");
            btnTest.Activated += delegate { Test(); };
            GTA.MenuButton btnCaptureAllInOne = new MenuButton("CaptureAllInOne");
            btnCaptureAllInOne.Activated += delegate { CaptureAllInOne(); };
            GTA.MenuButton btnCapture = new MenuButton("Capture");
            btnCapture.Activated += delegate { capture(); };
            GTA.MenuButton btnCreate = new MenuButton("Create");
            btnCreate.Activated += delegate { create(); };
            GTA.MenuButton btnCloth = new MenuButton("Cloth");
            btnCloth.Activated += delegate { setCloth(); };
            GTA.MenuButton btnWeather = new MenuButton("Weather");
            btnWeather.Activated += delegate { ChooseFunction(FunctionMode.Weather); };
            GTA.MenuButton btnHourForward = new MenuButton("Hour Forward");
            btnHourForward.Activated += delegate { HourForward(); };
            GTA.MenuButton btnHourBack = new MenuButton("Hour Back");
            btnHourBack.Activated += delegate { HourBack(); };
            menu_0a = new GTA.Menu("ReID Generator", new GTA.IMenuItem[]
            {
                btnCaptureAllInOne, btnCapture, btnCreate, btnCloth, btnWeather,btnHourForward, btnHourBack, btnTest,
            });

            GTA.MenuButton btnBlizzard = new MenuButton("Blizzard");
            btnBlizzard.Activated += delegate { ChooseWeather(Weather.Blizzard); };
            GTA.MenuButton btnClear = new MenuButton("Clear");
            btnClear.Activated += delegate { ChooseWeather(Weather.Clear); };
            GTA.MenuButton btnClearing = new MenuButton("Clearing");
            btnClearing.Activated += delegate { ChooseWeather(Weather.Clearing); };
            GTA.MenuButton btnClouds = new MenuButton("Clouds");
            btnClouds.Activated += delegate { ChooseWeather(Weather.Clouds); };
            GTA.MenuButton btnExtrasunny = new MenuButton("Extrasunny");
            btnExtrasunny.Activated += delegate { ChooseWeather(Weather.ExtraSunny); };
            GTA.MenuButton btnFoggy = new MenuButton("Foggy");
            btnFoggy.Activated += delegate { ChooseWeather(Weather.Foggy); };
            GTA.MenuButton btnNetural = new MenuButton("Netural");
            btnNetural.Activated += delegate { ChooseWeather(Weather.Neutral); };
            GTA.MenuButton btnOvercast = new MenuButton("Overcast");
            btnOvercast.Activated += delegate { ChooseWeather(Weather.Overcast); };
            GTA.MenuButton btnSmog = new MenuButton("Smog");
            btnSmog.Activated += delegate { ChooseWeather(Weather.Smog); };
            GTA.MenuButton btnSnowlight = new MenuButton("Snowlight");
            btnSnowlight.Activated += delegate { ChooseWeather(Weather.Snowlight); };

            menu_1a = new GTA.Menu("Weather", new GTA.IMenuItem[]
            {
                btnBlizzard, btnClear, btnClearing, btnClouds, btnExtrasunny,
                btnFoggy, btnNetural, btnOvercast, btnSmog,
                btnSnowlight,
            });


            menu_0a.HasFooter = false;
            menu_1a.HasFooter = false;

            LeftKey = Keys.NumPad4;
            RightKey = Keys.NumPad6;
            UpKey = Keys.NumPad8;
            DownKey = Keys.NumPad2;
            ActivateKey = Keys.NumPad5;
            BackKey = Keys.NumPad0;

            this.KeyDown += OnKeyDown;
        }

        //Open main menu
        void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                View.CloseAllMenus();
                View.AddMenu(menu_0a);
            }
        }

        //Capture all ped
        void CaptureAllInOne()
        {
            Function.Call(Hash.DESTROY_ALL_CAMS, true);

            //Index of ped
            int modcnt = 0;
            int locNum = 0;
            foreach (uint modhash in Enum.GetValues(typeof(PedHash)))
            {
                //Change it if you dont want to start in first ped
                if (modcnt <= -1)
                {
                    modcnt++;
                    continue;
                }
                //Skip error ped
                if (Array.IndexOf(errHash, modcnt) != -1)
                {
                    modcnt++;
                    continue;
                }
                this.tmpped = Game.Player.Character;

                //Change background
                if (locNum >= 3)
                {
                    locNum = 0;
                }
                Function.Call(Hash.SET_ENTITY_COORDS, Game.Player.Character, locations[locNum].posX, locations[locNum].posY, locations[locNum].posZ, 1, 0, 0, 1);
                locNum++;

                //Change ped
                Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, World.CreatePed((Int32)modhash, Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 0, 0))), 198);
                tmpped.Delete();
                Wait(2000);

                //Take picture
                capture(modcnt);

                modcnt++;
            }
        }

        //Left for test
        void Test()
        {
            /*
            //Change ped
            this.tmpped = Game.Player.Character;
            Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, World.CreatePed(PedHash.Abigail, Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 0, 0))), 198);
            tmpped.Delete();
            Wait(2000);
            */

            /*
            int modcnt = 0;
            foreach (uint modhash in Enum.GetValues(typeof(PedHash)))
            {
                if (modcnt <= -1)//Change it if you dont want to start in first ped.
                {
                    modcnt++;
                    continue;
                }
                if (Array.IndexOf(errHash, modcnt) != -1)
                {
                    modcnt++;
                    continue;
                }
                this.tmpped = Game.Player.Character;

                //Change ped
                Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, World.CreatePed((Int32)modhash, Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 0, 0))), 198);
                tmpped.Delete();
                Wait(500);

                UI.ShowSubtitle(modcnt.ToString(),500);

                modcnt++;
            }
            */
            /*
            int locNum = 0;
            Function.Call(Hash.SET_ENTITY_COORDS, Game.Player.Character, locations[locNum].posX, locations[locNum].posY, locations[locNum].posZ, 1, 0, 0, 1);*/
        }

        //Capture one ped
        void capture(int n)
        {
            //Check if the folder is exist
            bool existFlag = false;
            //Image number counter
            int picNum = 0;
            //Check if the camera is the first one
            bool firstCap = true;

            int angcnt = 0;
            //Create script camera
            Vector3 myPos = Game.Player.Character.Position;
            Camera cam1 = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", true);

            //Weather Cycle
            foreach (Weather weaMode in Enum.GetValues(typeof(WeatherMode)))
            {
                if ((existFlag == true) & (picNum == 0))
                {
                    break;
                }
                ChooseWeather(weaMode);

                //Light Cycle
                foreach (LightMode light in Enum.GetValues(typeof(LightMode)))
                {
                    if ((existFlag == true) & (picNum == 0))
                    {
                        break;
                    }

                    SetGameHour((int)light);
                    angcnt = 0;
                    foreach (Vector3 camAng in cams)
                    {
                        string pathname = GetFoldPath((int)weaMode, (int)light, n, angcnt, ref existFlag);

                        if ((existFlag == true) & (picNum == 0))
                        {
                            break;
                        }
                        picNum++;

                        int a = 3;

                        if (firstCap == true)
                        {
                            Wait(10);
                            /*
                            //Set Camera Location
                            Vector3 camAng1 = cams2[picNum - 1];
                            Vector3 camPos = Game.Player.Character.GetOffsetInWorldCoords(camAng1 * a);*/

                            Vector3 camPos = Game.Player.Character.GetOffsetInWorldCoords(camAng * a);
                            Function.Call<bool>(Hash.SET_CAM_COORD, cam1.GetHashCode(), camPos.X, camPos.Y, camPos.Z);

                            //Point cam at actor
                            Function.Call(Hash.POINT_CAM_AT_COORD, cam1.GetHashCode(), Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z);

                            //Convert to script camera
                            Function.Call(Hash.RENDER_SCRIPT_CAMS, true, false, 0, 1, 0);
                            Wait(1);
                            firstCap = false;
                        }

                        else
                        {
                            //Set Camera Location
                            Vector3 camPos = Game.Player.Character.GetOffsetInWorldCoords(camAng * a);
                            Function.Call<bool>(Hash.SET_CAM_COORD, cam1.GetHashCode(), camPos.X, camPos.Y, camPos.Z);

                            //Point cam at actor
                            Function.Call(Hash.POINT_CAM_AT_COORD, cam1.GetHashCode(), Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z);

                            //Convert to script camera
                            Function.Call(Hash.RENDER_SCRIPT_CAMS, true, false, 0, 1, 0);
                            //Wait(1);
                        }

                        //Log information
                        string actorStr = Enum.GetName(typeof(PedHash), (uint)Game.Player.Character.Model.GetHashCode());
                        string location = "[" + Game.Player.Character.Position.X.ToString("0.000") + ", " + Game.Player.Character.Position.Y.ToString("0.000") + ", " + Game.Player.Character.Position.Z.ToString("0.000") + "]";
                        string time = World.CurrentDayTime.ToString();
                        string weather = this.weather;
                        string angle = "[" + (Math.Atan(camAng.Y / camAng.X)).ToString() + "]";

                        angcnt++;

                        Bitmap catchBmp = new Bitmap(200, 470);
                        Graphics g = Graphics.FromImage(catchBmp);
                        g.CopyFromScreen(new Point(Screen.AllScreens[0].Bounds.Width / 3 + 180, Screen.AllScreens[0].Bounds.Height / 6 + 160), new Point(0, 0), new Size(200, 470));

                        catchBmp.Save(pathname);
                        UI.ShowSubtitle(pathname);
                        WriteToFile(angcnt.ToString(), location, time, weather, angle, actorStr);
                        Wait(1);
                    }
                }
            }

            //Convert to main camera
            Function.Call(Hash.RENDER_SCRIPT_CAMS, false, false, 0, 1, 0);
            //Destory all camera
            Function.Call(Hash.DESTROY_ALL_CAMS, true);
        }

        //Capture one ped
        void capture()
        {
            int n = 600;
            bool existFlag = false;
            int picNum = 0;
            while (IsFolderExist(n))
            {
                UI.ShowSubtitle(n.ToString() + "exist!", 10);
                n++;
                Wait(10);
            }
            Vector3 myPos = Game.Player.Character.Position;

            Camera cam1 = Function.Call<Camera>(Hash.CREATE_CAM, "DEFAULT_SCRIPTED_CAMERA", true);

            bool firstCap = true;
            foreach (Weather weaMode in Enum.GetValues(typeof(WeatherMode)))
            {
                ChooseWeather(weaMode);
                foreach (LightMode light in Enum.GetValues(typeof(LightMode)))
                {
                    SetGameHour((int)light);
                    int angcnt = 0;
                    foreach (Vector3 camAng in cams)
                    {
                        string pathname = GetFoldPath((int)weaMode, (int)light, n, angcnt, ref existFlag);

                        picNum++;

                        int a = 3;
                        //Set Camera Location
                        Vector3 camPos = Game.Player.Character.GetOffsetInWorldCoords(camAng * a);
                        Function.Call<bool>(Hash.SET_CAM_COORD, cam1.GetHashCode(), camPos.X, camPos.Y, camPos.Z);

                        //Point cam at actor
                        Function.Call(Hash.POINT_CAM_AT_COORD, cam1.GetHashCode(), Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z);

                        //Convert to script camera
                        Function.Call(Hash.RENDER_SCRIPT_CAMS, true, false, 0, 1, 0);
                        if (firstCap == true)
                        {
                            Wait(3000);
                            firstCap = false;
                        }

                        //Log information
                        string actorStr = Enum.GetName(typeof(PedHash), (uint)Game.Player.Character.Model.GetHashCode());
                        string location = "[" + Game.Player.Character.Position.X.ToString("0.000") + ", " + Game.Player.Character.Position.Y.ToString("0.000") + ", " + Game.Player.Character.Position.Z.ToString("0.000") + "]";
                        string time = World.CurrentDayTime.ToString();
                        string weather = this.weather;
                        string angle = "[" + (Math.Atan(camAng.Y / camAng.X)).ToString() + "]";

                        angcnt++;

                        Bitmap catchBmp = new Bitmap(200, 470);
                        Graphics g = Graphics.FromImage(catchBmp);
                        g.CopyFromScreen(new Point(Screen.AllScreens[0].Bounds.Width / 3 + 180, Screen.AllScreens[0].Bounds.Height / 6 + 160), new Point(0, 0), new Size(200, 470));

                        catchBmp.Save(pathname);
                        UI.ShowSubtitle(pathname);
                        WriteToFile(angcnt.ToString(), location, time, weather, angle, actorStr);
                        Wait(1);
                    }
                }
            }

            //Convert to main camera
            Function.Call(Hash.RENDER_SCRIPT_CAMS, false, false, 0, 1, 0);
            //Destory all camera
            Function.Call(Hash.DESTROY_ALL_CAMS, true);
        }

        //Create specific ped
        void create()
        {
            this.tmpped = Game.Player.Character;
            Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, World.CreatePed(PedHash.Trevor, Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 5, 0))), true, true);
            tmpped.Delete();
        }

        //Change ped cloth
        void setCloth()
        {
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 100; j++)
                {
                    int drawable = ran.Next(0, 10) % 10;
                    int texture = ran.Next(0, 10) % 10;
                    if (Function.Call<bool>(Hash.IS_PED_COMPONENT_VARIATION_VALID, Game.Player.Character, i, drawable, texture))
                    {
                        Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character, i, drawable, texture, 0);
                        break;
                    }
                }
        }

        //Change menu
        void ChooseFunction(FunctionMode funcMode)
        {
            switch (funcMode)
            {
                case FunctionMode.Weather:
                    {
                        View.CloseAllMenus();
                        View.AddMenu(menu_1a);
                        break;
                    }
            }
        }

        //Choose weather
        void ChooseWeather(Weather weaMode)
        {
            if((int)weaMode == -1)
            {

            }
            else if (((int)weaMode == 1) | ((int)weaMode == 5) | ((int)weaMode == 6) | ((int)weaMode == 7) | ((int)weaMode == 8) | ((int)weaMode == 10) | ((int)weaMode == 13))
            {

            }
            else
            {
                Function.Call(Hash.SET_WEATHER_TYPE_NOW_PERSIST, Enum.GetName(typeof(Weather), weaMode));
                this.weather = Enum.GetName(typeof(Weather), weaMode);
            }
        }

        //Set time forward
        void HourForward()
        {
            int h = World.CurrentDayTime.Hours;
            int m = World.CurrentDayTime.Minutes;
            if (h == 23) { h = 0; }
            else { h++; }
            Function.Call(Hash.SET_CLOCK_TIME, h, m, 0);
            UI.ShowSubtitle("Set time to " + World.CurrentDayTime.ToString());
        }

        //Set time
        void SetGameHour(int hour)
        {
            Function.Call(Hash.SET_CLOCK_TIME, hour, 0, 0);
            UI.ShowSubtitle("Set time to " + World.CurrentDayTime.ToString());
        }

        //Set time back
        void HourBack()
        {
            int h = World.CurrentDayTime.Hours;
            int m = World.CurrentDayTime.Minutes;
            if (h == 0) { h = 23; }
            else { h--; }
            Function.Call(Hash.SET_CLOCK_TIME, h, m, 0);
            UI.ShowSubtitle("Set time to " + World.CurrentDayTime.ToString());
        }

        //Write log
        void WriteToFile(string user, string location, string time, string weather, string angle, string actorped)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@".\scripts\ReID_Generator_log.txt", true))
                {
                    string datetimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
                    string logStr = "[" + datetimeStr + "] (" + user + ") " + "Loc:{" + location + "} Time:{" + time + "} Weather:{" + weather + "} Ang:{" + angle + "} Actor:{" + actorped + "}";
                    sw.WriteLine(logStr);
                }
            }
            catch
            {
                UI.Notify("Failed to save!");
            }
        }

        //Get ID save path
        string GetFoldPath(int wea, int light, int n, int angcnt, ref bool exist)
        {
            //Change to your pathname here↓
            string folderpath = "G:\\IMG_new\\" + n.ToString().PadLeft(4, '0');
            if (false == System.IO.Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
                exist = false;
                UI.ShowSubtitle(folderpath);
            }
            else
            {
                exist = true;
            }
            string weaCode, lightCode, foldpath;
            switch (wea)
            {
                case 0:
                    weaCode = "-1";
                    break;
                case 1:
                    weaCode = "00";
                    break;
                case 2:
                    weaCode = "01";
                    break;
                case 3:
                    weaCode = "02";
                    break;
                case 4:
                    weaCode = "03";
                    break;
                case 9:
                    weaCode = "04";
                    break;
                case 11:
                    weaCode = "05";
                    break;
                case 12:
                    weaCode = "06";
                    break;
                default:
                    weaCode = "00";
                    break;
            }
            switch (light)
            {
                case 0:
                    lightCode = "00";
                    break;
                case 5:
                    lightCode = "01";
                    break;
                case 8:
                    lightCode = "02";
                    break;
                case 12:
                    lightCode = "03";
                    break;
                case 18:
                    lightCode = "04";
                    break;
                case 19:
                    lightCode = "05";
                    break;
                case 20:
                    lightCode = "06";
                    break;
                default:
                    lightCode = "00";
                    break;
            }
            foldpath = folderpath + "\\" + n.ToString().PadLeft(4, '0') + "_C" + angcnt.ToString().PadLeft(2, '0') + "_W" + weaCode + "_L" + lightCode +  ".jpg";
            return foldpath;
        }

        //Check if folder exist
        bool IsFolderExist(int n)
        {
            string folderpath = "G:\\IMG_new\\" + n.ToString().PadLeft(4, '0');
            if (false == System.IO.Directory.Exists(folderpath))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        enum FunctionMode
        {
            Appearance, Weather,
        }

        enum AppearMode
        {
            Character, Cloth, Skin, Hair, Shape,
        }

        enum WeatherMode
        {
            ExtraSunny = 0,
            Clear = 1,
            Clouds = 2,
            Smog = 3,
            Foggy = 4,
            Neutral = 9,
            Blizzard = 11,
            Snowlight = 12,
        }

        enum LightMode
        {
            Midnight = 0,
            Dawn = 5,
            Forenoon = 8,
            Noon = 12,
            Afternoon = 18,
            Dusk = 19,
            Night = 20,
        }
    }
}

