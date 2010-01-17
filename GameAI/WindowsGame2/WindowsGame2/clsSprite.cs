using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    using Microsoft.Xna.Framework.Graphics;   // For Texture2D
    using Microsoft.Xna.Framework;
    
    class clsSprite
    {
        
       
        public Texture2D texture { get; set; }  // Sprite texture, read-only property
        private Vector2 screenSize { get; set; } // Screen size
        public Vector2 velocity { get; set; }
        public Vector2 position
        {
            get ; 
            set ;
        }  
        public Vector2 size { get; set; }      // Sprite size in pixels
        public clsSprite(Texture2D newTexture, Vector2 newPosition, Vector2 newSize, int ScreenWidth, int ScreenHeight)
        {
            texture = newTexture;
            position = newPosition;
            size = newSize;
            screenSize = new Vector2(ScreenWidth, ScreenHeight);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
        public void Move()
        {
            // If we'll move out of the screen, invert velocity
            // Checking right boundary
            if (position.X + size.X + velocity.X > screenSize.X)
                velocity = new Vector2(-velocity.X, velocity.Y);
            // Checking bottom boundary
            if (position.Y + size.Y + velocity.Y > screenSize.Y)
                velocity = new Vector2(velocity.X, -velocity.Y);
            // Checking left boundary
            if (position.X + velocity.X < 0)
                velocity = new Vector2(-velocity.X, velocity.Y);
            // Checking upper  boundary
            if (position.Y + velocity.Y < 0)
                velocity = new Vector2(velocity.X, -velocity.Y);
            // Since we adjusted the velocity, just add it to the current position
            position += velocity;
        }
        public bool Collides(clsSprite otherSprite)
        {
            // Check if two sprites collide
            if (this.position.X + this.size.X > otherSprite.position.X &&
                this.position.X < otherSprite.position.X + otherSprite.size.X &&
                this.position.Y + this.size.Y > otherSprite.position.Y &&
                this.position.Y < otherSprite.position.Y + otherSprite.size.Y)
                return true;
            else
                return false;
        }
    }
}
