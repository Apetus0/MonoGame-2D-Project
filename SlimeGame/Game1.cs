using SlimeGame.Scenes;
using Gum.Forms;
using Gum.Forms.Controls;
using MonoGameLibrary;
using MonoGameGum;
using Microsoft.Xna.Framework.Media;


namespace SlimeGame
{
    public class Game1 : Core
    {
        // The background theme song.
        private Song _themeSong;

        public Game1() : base("Dungeon Slime", 1280, 720, false)
        {

        }

        protected override void Initialize()
        {
            base.Initialize();

            // Start playing the background music.
            Audio.PlaySong(_themeSong);

            // Initialize the Gum UI service
            InitalizeGum();

            // Start the game with the title scene.
            ChangeScene(new TitleScene());
        }

        private void InitalizeGum()
        {
            // Initialize the Gum service. The second parameter specifies
            // the version of the default visuals to use. v3 is the latest
            Gum.GumService.Default.Initialize(this, DefaultVisualsVersion.V3);

            // tell the gum service which content manager to use. We will tell it to use the global
            // content manager from our core.
            Gum.GumService.Default.ContentLoader.XnaContentManager = Core.Content;

            // Register keyboard input for ui control
            FrameworkElement.KeyboardsForUiControl.Add(Gum.GumService.Default.Keyboard);

            // Register gamepad input for ui control
            FrameworkElement.GamePadsForUiControl.AddRange(Gum.GumService.Default.Gamepads);

            // Customize the tab reverse UI navigation to also trigger whe the 
            // keyboard UP arrow key ios pushed
            FrameworkElement.TabReverseKeyCombos.Add(
                new KeyCombo() { PushedKey = (Gum.Forms.Input.Keys)Microsoft.Xna.Framework.Input.Keys.Up });

            // Customize the tab UI navigation to also trigger when the keyboard
            // Down arrow key is pushed.
            FrameworkElement.TabKeyCombos.Add(
               new KeyCombo() { PushedKey = (Gum.Forms.Input.Keys)Microsoft.Xna.Framework.Input.Keys.Down });

            // The assets created for the ui were done so at 1/4 the size to keep the size of the
            // texture atlas small. so we will set the default canvas size to be 1/4th the size of
            //the game's resolution then tell gum to zoom in by a factor of 4
            Gum.GumService.Default.CanvasWidth = GraphicsDevice.PresentationParameters.BackBufferWidth / 4.0f;
            Gum.GumService.Default.CanvasHeight = GraphicsDevice.PresentationParameters.BackBufferHeight / 4.0f;
            Gum.GumService.Default.Renderer.Camera.Zoom = 4.0f;
        }

        protected override void LoadContent()
        {
            // Load the background theme music.
            _themeSong = Content.Load<Song>("audio/theme");
        }
    }
}