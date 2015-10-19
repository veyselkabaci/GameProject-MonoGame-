using HologramSpriteManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OrbitGame.GameObjects
{
    class GameStatic
    {
        public static List<MonsterCharacter> monsters=new List<MonsterCharacter>();
        public static List<Monster2> monsters2 = new List<Monster2>();
        public static List<Fire> PlayerFire=new List<Fire>();
        static float last=0,last2=0,last3=0,create=1200,create2=400,create3=5000;
        static bool b = true,b1=true;
        public static Fire Fire { get; set; }

        public static void Update()
        {
            ManageMonsters();
            ManageMonster2();
            for(int i=0;i < monsters.Count;i++)
            {
                if (monsters[i].died == false)
                {
                    monsters[i].Update(Game1.p);
                }
                
            }

            for (int i = 0; i < monsters2.Count; i++)
            {
                if (monsters2[i].died == false)
                {
                    monsters2[i].Update();
                }

            }

            for (int i = 0; i < PlayerFire.Count; i++)
            {
                if(PlayerFire[i].hit==false)
                {
                    PlayerFire[i].Update();
                }
                
            }
            DeleteItems();
        }
        public static void Draw()
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].died==false)
                {
                    monsters[i].Draw();
                }
                
            }

            for (int i = 0; i < monsters2.Count; i++)
            {
                if (monsters2[i].died == false)
                {
                    monsters2[i].Draw();
                }

            }

            for (int i = 0; i < PlayerFire.Count(); i++)
            {
                if (PlayerFire[i].hit == false)
                {
                    PlayerFire[i].Draw();
                }
            }
        }

        public static void ManageMonsters()
        {
            
            float timepassed=SpriteManager.GameTime-last;
            if(b==true)
            {
                
                MonsterCharacter TheMonster = AnimationSpecReader.PopulateAnimations<MonsterCharacter>(@".\Content\Specs\Monster.json");
                int x=new Random().Next(4);
                if(x==0)
                {
                    TheMonster.Position.X = 0;
                    TheMonster.Position.Y = (new Random()).Next(601);
                }else if(x==1)
                {
                    TheMonster.Position.X = 800;
                    TheMonster.Position.Y = (new Random()).Next(601);
                }else if(x==2)
                {
                    TheMonster.Position.X = (new Random()).Next(801);
                    TheMonster.Position.Y = 0;
                }else
                {
                    TheMonster.Position.X = (new Random()).Next(801);
                    TheMonster.Position.Y = 600;
                }
                
                monsters.Add(TheMonster);
                b = false;
            }
            if(timepassed>=create)
            {
                MonsterCharacter TheMonster = AnimationSpecReader.PopulateAnimations<MonsterCharacter>(@".\Content\Specs\Monster.json");
                int x = new Random().Next(4);
                if (x == 0)
                {
                    TheMonster.Position.X = 0;
                    TheMonster.Position.Y = (new Random()).Next(601);
                }
                else if (x == 1)
                {
                    TheMonster.Position.X = 800;
                    TheMonster.Position.Y = (new Random()).Next(601);
                }
                else if (x == 2)
                {
                    TheMonster.Position.X = (new Random()).Next(801);
                    TheMonster.Position.Y = 0;
                }
                else
                {
                    TheMonster.Position.X = (new Random()).Next(801);
                    TheMonster.Position.Y = 600;
                }
                monsters.Add(TheMonster);
                last=SpriteManager.GameTime;
            }
        }

        public static void Shoot(int bIsUp, int X, int Y, int itype)
        {
            float timepassed = SpriteManager.GameTime - last2;
            Fire TheFire = new Fire();
            if (b1 == true)
            {

                    if (itype == 0)
                        TheFire = AnimationSpecReader.PopulateAnimations<Fire>(@".\Content\Specs\fire1.json");


                TheFire.Position.X = X;
                TheFire.Position.Y = Y;
                TheFire.bIsUp = bIsUp;
                PlayerFire.Add(TheFire);
                b1 = false;
            }
            if (timepassed >= create2)
            {

                    if (itype == 0)
                        TheFire = AnimationSpecReader.PopulateAnimations<Fire>(@".\Content\Specs\fire1.json");

                TheFire.Position.X = X;
                TheFire.Position.Y = Y;
                TheFire.bIsUp = bIsUp;
                PlayerFire.Add(TheFire);
                last2 = SpriteManager.GameTime;
            }

        }

        public static void ManageMonster2()
        {
            float timepassed = SpriteManager.GameTime - last3;
            if (b == true)
            {

                Monster2 TheMonster = AnimationSpecReader.PopulateAnimations<Monster2>(@".\Content\Specs\json1.json");

                TheMonster.Position.X = (new Random()).Next(200,500);

                monsters2.Add(TheMonster);
                b = false;
            }
            if (timepassed >= create3)
            {
                Monster2 TheMonster = AnimationSpecReader.PopulateAnimations<Monster2>(@".\Content\Specs\json1.json");

                TheMonster.Position.X = (new Random()).Next(200,500);

                monsters2.Add(TheMonster);
                last3 = SpriteManager.GameTime;
            }
        }

        public static void DeleteItems()
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].died == true)
                {
                    monsters.RemoveAt(i);
                    i--;
                }

            }

            for (int i = 0; i < monsters2.Count; i++)
            {
                if (monsters2[i].died == true)
                {
                    monsters2.RemoveAt(i);
                    i--;
                }

            }

            for (int i = 0; i < PlayerFire.Count(); i++)
            {
                if (PlayerFire[i].hit == true)
                {
                    PlayerFire.RemoveAt(i);
                    i--;
                }
            }
        }

    }
}
