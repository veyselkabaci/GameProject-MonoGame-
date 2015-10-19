using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HologramSpriteManager;
using OrbitGame.GameObjects;
using Microsoft.Xna.Framework.Input;

namespace OrbitGame
{
    
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        
        Texture2D imgBackground;
        PlayerCharacter TheCharacter;
        //public static MonsterCharacter1 TheMonster1;
        bool bGameOver = false;
        public static Point p;
        public static Rectangle PlayerBounds;
        Fire TheFire;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            SpriteManager.ContentShell = Content;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            SpriteManager.GameTime = 0;
            TheCharacter = new PlayerCharacter();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        /// 
       
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteManager.spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            
            imgBackground = Content.Load<Texture2D>("Sprites/background");
            TheCharacter = AnimationSpecReader.PopulateAnimations<PlayerCharacter>(@".\Content\Specs\Player1.json");
            //TheMonster1 = AnimationSpecReader.PopulateAnimations<MonsterCharacter1>(@".\Content\Specs\Monster.json");
            //TheFire = AnimationSpecReader.PopulateAnimations<Fire>(@".\Content\Specs\Missile.json");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            SpriteManager.GameTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            PlayerBounds = TheCharacter.Bounds;

            if (bGameOver)
                return;
            
            p=TheCharacter.Update();
            GameStatic.Update();
            


            for(int i=0;i < GameStatic.monsters.Count;i++)
            {
                
                Rectangle MonsterBounds = GameStatic.monsters[i].Bounds;
                if(PlayerBounds.Intersects(MonsterBounds))
                {
                    
                    if (GameStatic.monsters[i].died == false)
                    {
                        TheCharacter.ChangeAnimation("die");
                        bGameOver = true;
                    }
                    
                }
                for (int j = 0; j < GameStatic.PlayerFire.Count; j++)
                {
                    Rectangle FireBound = GameStatic.PlayerFire[j].Bounds;
                    if(MonsterBounds.Intersects(FireBound))
                    {
                        GameStatic.monsters[i].died = true;
                        GameStatic.PlayerFire[j].hit = true;
                    }
                }
            }

            for (int i = 0; i < GameStatic.monsters2.Count; i++)
            {

                Rectangle MonsterBounds2 = GameStatic.monsters2[i].Bounds;
                if (PlayerBounds.Intersects(MonsterBounds2))
                {

                    if (GameStatic.monsters2[i].died == false)
                    {
                        TheCharacter.ChangeAnimation("die");
                        bGameOver = true;
                    }

                }
                for (int j = 0; j < GameStatic.PlayerFire.Count; j++)
                {
                    Rectangle FireBound = GameStatic.PlayerFire[j].Bounds;
                    if (MonsterBounds2.Intersects(FireBound))
                    {
                        GameStatic.monsters2[i].died = true;
                        GameStatic.PlayerFire[j].hit = true;
                    }
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        Rectangle rBackground = new Rectangle(0, 0, 800, 600);
        

        protected override void Draw(GameTime gameTime)
        {
            this.graphics.PreferredBackBufferWidth = 800;
            this.graphics.PreferredBackBufferHeight = 600;
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            SpriteManager.spriteBatch.Begin();
            SpriteManager.spriteBatch.Draw(imgBackground, rBackground, Color.White);

            //Rectangle rChar = new Rectangle(100, 100, 33, 48);
            //Rectangle rChar = new Rectangle(TheCharacter.pPosition.X , TheCharacter.pPosition.Y, 33, 48);
            TheCharacter.Draw();
            GameStatic.Draw();
            //TheMonster1.Draw();
            //SpriteManager.spriteBatch.Draw(imgChar, rChar, Color.White);
            SpriteManager.spriteBatch.End();     
            base.Draw(gameTime);
        }
    }
}
