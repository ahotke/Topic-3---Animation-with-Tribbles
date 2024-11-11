using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Topic_3
{
    public class Game1 : Game
    {
        Texture2D tribbleGreyTexture, tribbleBrownTexture, tribbleCreamTexture, tribbleOrangeTexture;
        Rectangle tribbleGreyRect, tribbleBrownRect, tribbleCreamRect, tribbleOrangeRect, window;
        Vector2 tribbleGreySpeed, tribbleBrownSpeed, tribbleCreamSpeed, tribbleOrangeSpeed;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //Window
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            //Tribble Rectangles
            tribbleGreyRect = new Rectangle(300, 10, 100, 100);
            tribbleBrownRect = new Rectangle(650, 120, 100, 100);
            tribbleCreamRect = new Rectangle(110, 230, 100, 100);
            tribbleOrangeRect = new Rectangle(425, 340, 100, 100);
            //Vectors for speeds
            tribbleGreySpeed = new Vector2(1, 3);
            tribbleBrownSpeed = new Vector2(8, 6);
            tribbleCreamSpeed = new Vector2(3, 2);
            tribbleOrangeSpeed = new Vector2(4, 5);
            base.Initialize();
           
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            tribbleGreyRect.X += (int)tribbleGreySpeed.X;
            tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;
            if (tribbleGreyRect.Right > window.Width || tribbleGreyRect.Left < 0)
                tribbleGreySpeed.X *= -1;
            if (tribbleGreyRect.Bottom > window.Bottom || tribbleGreyRect.Top < 0) 
                tribbleGreySpeed.Y *= -1;

            tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
            tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;
            if (tribbleBrownRect.Right > window.Width || tribbleBrownRect.Left < 0)
                tribbleBrownSpeed.X *= -1;
            if (tribbleBrownRect.Bottom > window.Bottom || tribbleBrownRect.Top < 0) 
                tribbleBrownSpeed.Y *= -1;

            tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
            tribbleCreamRect.Y += (int)tribbleCreamSpeed.Y;
            if (tribbleCreamRect.Right > window.Width || tribbleCreamRect.Left < 0)
                tribbleCreamSpeed.X *= -1;
            if (tribbleCreamRect.Bottom > window.Bottom || tribbleCreamRect.Top < 0) 
                tribbleCreamSpeed.Y *= -1;

            tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
            tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;
            if (tribbleOrangeRect.Right > window.Width || tribbleOrangeRect.Left < 0)
                tribbleOrangeSpeed.X *= -1;
            if (tribbleOrangeRect.Bottom > window.Bottom || tribbleOrangeRect.Top < 0) 
                tribbleOrangeSpeed.Y *= -1;

            if (tribbleGreyRect.Intersects(tribbleBrownRect) || tribbleGreyRect.Intersects(tribbleCreamRect) || tribbleGreyRect.Intersects(tribbleOrangeRect))
            {
                tribbleGreySpeed.X *= -1;
                tribbleGreySpeed.Y *= -1;
            }

            if (tribbleBrownRect.Intersects(tribbleGreyRect) || tribbleBrownRect.Intersects(tribbleCreamRect) || tribbleBrownRect.Intersects(tribbleOrangeRect))
            {
                tribbleBrownSpeed.X *= -1;
                tribbleBrownSpeed.Y *= -1;
            }

            if (tribbleCreamRect.Intersects(tribbleGreyRect) || tribbleCreamRect.Intersects(tribbleBrownRect) || tribbleCreamRect.Intersects(tribbleOrangeRect))
            {
                tribbleCreamSpeed.X *= -1;
                tribbleCreamSpeed.Y *= -1;
            }

            if (tribbleOrangeRect.Intersects(tribbleGreyRect) || tribbleOrangeRect.Intersects(tribbleBrownRect) || tribbleOrangeRect.Intersects(tribbleCreamRect))
            {
                tribbleOrangeSpeed.X *= -1;
                tribbleOrangeSpeed.Y *= -1;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
          
            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);

            _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);

            _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
