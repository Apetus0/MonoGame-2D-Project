using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;
namespace SlimeGame
{
    public class Game1 : Core
    {
        // Defines the slime sprite.
        private Sprite _slime;

        // Defines the bat sprite.
        private Sprite _bat;


        //// texture region that defines the slime sprite in the atlas.
        //private TextureRegion _slime;
        //// texture region that defines the bat sprite in the atlas.
        //private TextureRegion _bat;

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

            // Create the slime sprite from the atlas.
            _slime = atlas.CreateSprite("slime");
            _slime.Scale = new Vector2(4.0f, 4.0f); // Set the scale of the slime sprite

            // Create the bat sprite from the atlas.
            _bat = atlas.CreateSprite("bat");
            _bat.Scale = new Vector2(4.0f, 4.0f); // Set the scale of the bat sprite"

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
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
            _slime.Draw(SpriteBatch, Vector2.Zero);

            // Draw the bat sprite 10px to the right of the slime.
            _bat.Draw(SpriteBatch, new Vector2(_slime.Width + 10, 0));

            // Always end the sprite batch when finished.
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
