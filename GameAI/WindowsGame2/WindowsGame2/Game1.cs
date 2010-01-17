using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace WindowsGame2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        clsSprite mySprite1;
        clsSprite mySprite2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 500;
            graphics.PreferredBackBufferHeight = 300;
            
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            

            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            
            mySprite1 = new clsSprite(Content.Load<Texture2D>("ball"),
                          new Vector2(0f, 0f), new Vector2(64f, 64f),graphics.PreferredBackBufferWidth,graphics.PreferredBackBufferHeight);
            mySprite1.velocity = new Vector2(1, 1);
            mySprite2 = new clsSprite(Content.Load<Texture2D>("ball"),
                          new Vector2(218f, 118f), new Vector2(64f, 64f), graphics.PreferredBackBufferWidth,graphics.PreferredBackBufferHeight);
            mySprite2.velocity = new Vector2(3, -3);
           
            spriteBatch = new SpriteBatch(GraphicsDevice);
     
        }

        
        protected override void UnloadContent()
        {
            mySprite1.texture.Dispose();
            mySprite2.texture.Dispose();
        }

        
        protected override void Update(GameTime gameTime)
        {
          
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            mySprite1.Move();
            mySprite2.Move();
            if (mySprite1.Collides(mySprite2))
            {
                Vector2 tempVelocity = mySprite1.velocity;
                mySprite1.velocity = mySprite2.velocity;
                mySprite2.velocity = tempVelocity;
            }

            base.Update(gameTime);
           
        }

       
        protected override void Draw(GameTime gameTime)
        {
           
            GraphicsDevice.Clear(Color.CornflowerBlue);

           

            spriteBatch.Begin(SpriteBlendMode.AlphaBlend);
            mySprite1.Draw(spriteBatch);
            mySprite2.Draw(spriteBatch);
            spriteBatch.End();

         

            base.Draw(gameTime);
        }
    }
}
