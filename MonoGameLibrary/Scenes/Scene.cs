using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MonoGameLibrary.Scenes
{
    public abstract class Scene : IDisposable
    {
        // Gets the contentmanager used for loading scene-specific assets
        // Assets loaded through this ContentManager will be automatically unloaded when this scene ends.
        protected ContentManager Content { get; }
        // Gets a value that indicates if the scene has been disposed of
        public bool IsDisposed { get; private set; }

        // create a new scene instance

        public Scene()
        {
            // Create a new content manager for the scene 
            Content = new ContentManager(Core.Content.ServiceProvider);

            // Set the root directory for content to the same as the root directory
            // as the games content
            Content.RootDirectory = Core.Content.RootDirectory;
        }
        // Finalizer, called when object is cleaned up by garbage collector
        ~Scene() => Dispose(false);

        // Initializes the scene
        // When overriding this in a derived class, ensure that base.Initialize()
        // still called as this is when LoadContent is called
        public virtual void Initialize()
        {
            LoadContent();
        }

        // Override to prevent logic to load content for the scene
        public virtual void LoadContent()
        {
        }
        // Unloads scene-specific content
        public virtual void UnloadContent()
        {
            Content.Unload();
        }
        // Updates this scene.
        // <param name="gameTime">A snapshot of the timing values for the current frame.</param>
        public virtual void Update(GameTime gameTime) { }

        //Draws this scene.
        // <param name="gameTime">A snapshot of the timing values for the current frame.</param>
        public virtual void Draw(GameTime game) { }

        // Disposes of this scene.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        // Disposes of this scene. 
        // Indicates whether managed resources should be disposed.  This value is only true when called from the main
        // Dispose method.  When called from the finalizer, this will be false.
        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed)
            {
                return;
            }
            if (disposing)
            {
                UnloadContent();
                Content.Dispose();
            }
            IsDisposed = true;
        }
    }
}
