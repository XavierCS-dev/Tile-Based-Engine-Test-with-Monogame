using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace pseudo_3D_test
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private int[,] gameMap;
        private Texture2D floor;
        private Texture2D shownWall;
        private Texture2D hiddenWall;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            gameMap = new int[10, 10]
            {
                { 2,1,1,1,1,1,1,1,1,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,0,0,0,0,0,0,0,0,2},
                { 2,2,2,2,2,2,2,2,2,2}
            };

            BuildWorld.Build(gameMap);

            _graphics.PreferredBackBufferWidth = 1500;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 1000;   // set this value to the desired height of your window
            _graphics.ApplyChanges();
            TargetElapsedTime = TimeSpan.FromSeconds(1 / 2.0f);



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            floor = Content.Load<Texture2D>("None");
            shownWall = Content.Load<Texture2D>("Revealed");
            hiddenWall = Content.Load<Texture2D>("Hidden");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            Random numGen = new Random();
            for (int i = 0; i < gameMap.GetLength(0); ++i)
            {
                for (int j = 0; j < gameMap.GetLength(0); ++j)
                {
                    gameMap[j, i] = numGen.Next(0, 3);
                }
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            BuildWorld.Draw(_spriteBatch, gameMap, floor, shownWall, hiddenWall);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
