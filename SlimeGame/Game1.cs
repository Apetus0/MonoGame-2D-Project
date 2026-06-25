using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;
using MonoGameLibrary.Input;
using System;
namespace SlimeGame
{
    public class Game1 : Core
    {
        // Defines the slime animated sprite.
        private AnimatedSprite _slime;

        // Defines the bat animated sprite.
        private AnimatedSprite _bat;


        //// Defines the slime sprite.
        //private Sprite _slime;

        //// Defines the bat sprite.
        //private Sprite _bat;


        //// texture region that defines the slime sprite in the atlas.
        //private TextureRegion _slime;
        //// texture region that defines the bat sprite in the atlas.
        //private TextureRegion _bat;

        // Tracks the position of the slime.
        private Vector2 _slimePosition;

        // Speed multiplier when moving.
        private const float MOVEMENT_SPEED = 5.0f;

        //// Tracks the position of the bat.
        //private Vector2 _batPosition;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //monogame texture logo
        private Texture2D _logo;

        public Game1() : base("Dungeon Slime", 1280, 720, false)
        {

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //_logo = Content.Load<Texture2D>("images/logo");

            // Load the atlas texture using the content manager
            //Texture2D atlasTexture = Content.Load<Texture2D>("images/atlas");

            //  Create a TextureAtlas instance from the atlas
            //TextureAtlas atlas = new TextureAtlas(atlasTexture);

            // Create the texture atlas from the XML configuration file
            TextureAtlas atlas = TextureAtlas.FromFile(Content, "images/atlas-definition.xml");


            ////// add the slime region to the atlas.
            ////atlas.AddRegion("slime", 0, 0, 20, 20);

            ////// add the bat region to the atlas.
            ////atlas.AddRegion("bat", 20, 0, 20, 20);
            //// retrieve the slime region from the atlas.
            //_slime = atlas.GetRegion("slime");
            //// retrieve the bat region from the atlas.
            //_bat = atlas.GetRegion("bat");

            //// Create the slime sprite from the atlas.
            //_slime = atlas.CreateSprite("slime");
            //_slime.Scale = new Vector2(4.0f, 4.0f); // Set the scale of the slime sprite

            //// Create the bat sprite from the atlas.
            //_bat = atlas.CreateSprite("bat");
            //_bat.Scale = new Vector2(4.0f, 4.0f); // Set the scale of the bat sprite"

            // Create the slime animated sprite from the atlas.
            _slime = atlas.CreateAnimatedSprite("slime-animation");
            _slime.Scale = new Vector2(4.0f, 4.0f); // Set the scale of the slime sprite

            // Create the bat animated sprite from the atlas.
            _bat = atlas.CreateAnimatedSprite("bat-animation");
            _bat.Scale = new Vector2(4.0f, 4.0f); // Set the scale of the bat sprite"
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // Update the slime animated sprite.
            _slime.Update(gameTime);
            // Update the bat animated sprite.
            _bat.Update(gameTime);


            // TODO: Add your update logic here

            // Check for keyboard input and handle it.
            CheckKeyboardInput();

            // Check for gamepad input and handle it.
            CheckGamePadInput();

            base.Update(gameTime);
        }

        private void CheckKeyboardInput()
        {
            ////get the state of the keyboard input
            //KeyboardState keyboardState = Keyboard.GetState();

            //// if the space key is held down, the movement speed increased by 1.5
            //float speed = MOVEMENT_SPEED;
            //if (keyboardState.IsKeyDown(Keys.Space))
            //{
            //    speed *= 1.5f;
            //}

            //// if the w or up keys are down, move the slime up on the screen
            //if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
            //{
            //    _slimePosition.Y -= speed;
            //}

            //// if the s or down keys are down, move the slime down on the screen
            //if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
            //{
            //    _slimePosition.Y += speed;
            //}
            ////if the a or left keys are down, move the slime to the left on the screen
            //if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
            //{
            //    _slimePosition.X -= speed;
            //}
            //// if the d or right keys are down, move the slime to the right on the screen
            //if(keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            //{
            //    _slimePosition.X += speed;
            //}

            // If the space key is held down, the movement speed increases by 1.5
        float speed = MOVEMENT_SPEED;
            if (Input.Keyboard.IsKeyDown(Keys.Space))
            {
                speed *= 1.5f;
            }

            // If the W or Up keys are down, move the slime up on the screen.
            if (Input.Keyboard.IsKeyDown(Keys.W) || Input.Keyboard.IsKeyDown(Keys.Up))
            {
                _slimePosition.Y -= speed;
            }

            // if the S or Down keys are down, move the slime down on the screen.
            if (Input.Keyboard.IsKeyDown(Keys.S) || Input.Keyboard.IsKeyDown(Keys.Down))
            {
                _slimePosition.Y += speed;
            }

            // If the A or Left keys are down, move the slime left on the screen.
            if (Input.Keyboard.IsKeyDown(Keys.A) || Input.Keyboard.IsKeyDown(Keys.Left))
            {
                _slimePosition.X -= speed;
            }

            // If the D or Right keys are down, move the slime right on the screen.
            if (Input.Keyboard.IsKeyDown(Keys.D) || Input.Keyboard.IsKeyDown(Keys.Right))
            {
                _slimePosition.X += speed;
            }

        }

        private void CheckGamePadInput()
        {
            //GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

            //// If the A button is held down, the movement speed increases by 1.5
            //// and the gamepad vibrates as feedback to the player.
            //float speed = MOVEMENT_SPEED;
            //if (gamePadState.IsButtonDown(Buttons.A))
            //{
            //    speed *= 1.5f;
            //    GamePad.SetVibration(PlayerIndex.One, 1.0f, 1.0f);
            //}
            //else
            //{
            //    GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);
            //}

            //// Check thumbstick first since it has priority over which gamepad input
            //// is movement.  It has priority since the thumbstick values provide a
            //// more granular analog value that can be used for movement.
            //if (gamePadState.ThumbSticks.Left != Vector2.Zero)
            //{
            //    _slimePosition.X += gamePadState.ThumbSticks.Left.X * speed;
            //    _slimePosition.Y -= gamePadState.ThumbSticks.Left.Y * speed;
            //}
            //else
            //{
            //    // If DPadUp is down, move the slime up on the screen.
            //    if (gamePadState.IsButtonDown(Buttons.DPadUp))
            //    {
            //        _slimePosition.Y -= speed;
            //    }

            //    // If DPadDown is down, move the slime down on the screen.
            //    if (gamePadState.IsButtonDown(Buttons.DPadDown))
            //    {
            //        _slimePosition.Y += speed;
            //    }

            //    // If DPapLeft is down, move the slime left on the screen.
            //    if (gamePadState.IsButtonDown(Buttons.DPadLeft))
            //    {
            //        _slimePosition.X -= speed;
            //    }

            //    // If DPadRight is down, move the slime right on the screen.
            //    if (gamePadState.IsButtonDown(Buttons.DPadRight))
            //    {
            //        _slimePosition.X += speed;
            //    }
            //}
            GamePadInfo gamePadOne = Input.GamePads[(int)PlayerIndex.One];

            // If the A button is held down, the movement speed increases by 1.5
            // and the gamepad vibrates as feedback to the player.
            float speed = MOVEMENT_SPEED;
            if (gamePadOne.IsButtonDown(Buttons.A))
            {
                speed *= 1.5f;
                gamePadOne.SetVibration(1.0f, TimeSpan.FromSeconds(1));
            }
            else
            {
                gamePadOne.StopVibration();
            }

            // Check thumbstick first since it has priority over which gamepad input
            // is movement.  It has priority since the thumbstick values provide a
            // more granular analog value that can be used for movement.
            if (gamePadOne.LeftThumbStick != Vector2.Zero)
            {
                _slimePosition.X += gamePadOne.LeftThumbStick.X * speed;
                _slimePosition.Y -= gamePadOne.LeftThumbStick.Y * speed;
            }
            else
            {
                // If DPadUp is down, move the slime up on the screen.
                if (gamePadOne.IsButtonDown(Buttons.DPadUp))
                {
                    _slimePosition.Y -= speed;
                }

                // If DPadDown is down, move the slime down on the screen.
                if (gamePadOne.IsButtonDown(Buttons.DPadDown))
                {
                    _slimePosition.Y += speed;
                }

                // If DPapLeft is down, move the slime left on the screen.
                if (gamePadOne.IsButtonDown(Buttons.DPadLeft))
                {
                    _slimePosition.X -= speed;
                }

                // If DPadRight is down, move the slime right on the screen.
                if (gamePadOne.IsButtonDown(Buttons.DPadRight))
                {
                    _slimePosition.X += speed;
                }
            }
        }

        private Vector2 _test = new Vector2(100, 100);
        //protected override void Draw(GameTime gameTime)
        //{
        //    GraphicsDevice.Clear(Color.CornflowerBlue);

        //    // TODO: Add your drawing code here

        //    // begin the sprite batch to prepare for rendering
        //    SpriteBatch.Begin();

        //    //draw the logo texture
        //    //SpriteBatch.Draw(_logo, _test, Color.White);
        //    SpriteBatch.Draw(
        //        _logo, //texture
        //        //new Vector2( //position with it at top left, so math needed
        //        //    (Window.ClientBounds.Width * 0.5f) - (_logo.Width * 0.5f),
        //        //    (Window.ClientBounds.Height * 0.5f) - (_logo.Height * 0.5f)),
        //        new Vector2(
        //            Window.ClientBounds.Width,
        //            Window.ClientBounds.Height) * 0.5f,
        //        null, //source rectangle
        //        //Color.White * 0.5f, //color with 50% transparency
        //        Color.White, //color
        //        //0.0f, //rotation
        //        MathHelper.ToRadians(0), //built in mathhelper for rotation
        //        //Vector2.Zero, //origin top left
        //        new Vector2( //origin center now
        //            _logo.Width,
        //            _logo.Height) * 0.5f,
        //        1.0f, //scale
        //              //new Vector2(1.5f, 0.5f), //scale in particular way
        //        SpriteEffects.None, //effects
        //        //SpriteEffects.FlipHorizontally | //flip horizontal and vertical with bitwise operator
        //        //SpriteEffects.FlipVertically,
        //        0.0f //layerdepth


        //        );

        //    //. always end the sprite batch when finished
        //    SpriteBatch.End();

        //    base.Draw(gameTime);
        //}
        protected override void Draw(GameTime gameTime)
        {
            // Clear the back buffer.
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //// The bounds of the icon within the texture.
            //Rectangle iconSourceRect = new Rectangle(0, 0, 128, 128);

            //// The bounds of the word mark within the texture.
            //Rectangle wordmarkSourceRect = new Rectangle(150, 34, 458, 58);

            //// Begin the sprite batch to prepare for rendering.
            //SpriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack);

            //// Draw only the icon portion of the texture.
            //SpriteBatch.Draw(
            //    _logo,              // texture
            //    new Vector2(        // position
            //        Window.ClientBounds.Width,
            //        Window.ClientBounds.Height) * 0.5f,
            //    iconSourceRect,     // sourceRectangle
            //    Color.White,        // color
            //    0.0f,               // rotation
            //    new Vector2(        // origin
            //        iconSourceRect.Width,
            //        iconSourceRect.Height) * 0.5f,
            //    1.0f,               // scale
            //    SpriteEffects.None, // effects
            //    1.0f                // layerDepth
            //);

            //// Draw only the word mark portion of the texture.
            //SpriteBatch.Draw(
            //    _logo,              // texture
            //    new Vector2(        // position
            //      Window.ClientBounds.Width,
            //      Window.ClientBounds.Height) * 0.5f,
            //    wordmarkSourceRect, // sourceRectangle
            //    Color.White,        // color
            //    0.0f,               // rotation
            //    new Vector2(        // origin
            //      wordmarkSourceRect.Width,
            //      wordmarkSourceRect.Height) * 0.5f,
            //    1.0f,               // scale
            //    SpriteEffects.None, // effects
            //    0.0f                // layerDepth
            //);
            // Begin the sprite batch to prepare for rendering.
            SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

            //// Draw the slime texture region at a scale of 4.0
            //_slime.Draw(SpriteBatch, Vector2.Zero, Color.White, 0.0f, Vector2.One, 4.0f, SpriteEffects.None, 0.0f);

            //// Draw the bat texture region 10px to the right of the slime at a scale of 4.0
            //_bat.Draw(SpriteBatch, new Vector2(_slime.Width * 4.0f + 10, 0), Color.White, 0.0f, Vector2.One, 4.0f, SpriteEffects.None, 0.0f);

            // Draw the slime sprite.
            //_slime.Draw(SpriteBatch, Vector2.Zero);

            _slime.Draw(SpriteBatch, _slimePosition);

            // Draw the bat sprite 10px to the right of the slime.
            _bat.Draw(SpriteBatch, new Vector2(_slime.Width + 10, 0));

            // Always end the sprite batch when finished.
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
