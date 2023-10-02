using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace BreakOut_Ver1
{
    public class Padle
    {
        public Vector2 pos;
        
        public int stopX;
        public Texture2D padleTex;
        public Texture2D shieldMidTex;
        public Texture2D shieldSideTex;
        public int velocity;
        Random rnd = new Random();
        public Rectangle hitBoxLeft;
        public Rectangle hitBoxMid;
        public Rectangle hitBoxRight;
        
        
        public MouseState mouseState;
        public MouseState oldMouse;
        
        
        public bool shipHit;
        public float shieldLeftOp = 0.00f;
        public float shieldMidOp = 0.00f;
        public float shieldRightOp = 0.00f;
        public bool pBounceLeft;
        public bool pBounceMid;
        public bool pBounceRight;


        public static System.Drawing.Point MousePosition { get; }

        public Padle(Texture2D padleTex, Texture2D shieldMidTex, Texture2D shieldSideTex, Vector2 pos)
        {
            this.pos = pos;
            this.shieldSideTex = shieldSideTex;
            this.shieldMidTex = shieldMidTex;
            this.padleTex = padleTex;
            
            
            
            this.hitBoxLeft = new Rectangle((int)pos.X, (int)pos.Y, 65, this.padleTex.Height);
            this.hitBoxMid = new Rectangle((int)pos.X+65, (int)pos.Y, 10, this.padleTex.Height);
            this.hitBoxRight = new Rectangle((int)pos.X+85, (int)pos.Y, 65, this.padleTex.Height);

        }

        


        public void Update(GameTime gameTime)
        {

            velocity = 0;
            //Keyboard Controlls
            KeyboardState keyboardState = Keyboard.GetState();
            if(keyboardState.IsKeyDown(Keys.Left))
            {
                this.pos.X -= 10;
                velocity = -10;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                this.pos.X += 10;
                velocity = 10;
            }

            this.hitBoxMid.X = (int)pos.X+65;
            this.hitBoxMid.Y = (int)pos.Y;

            this.hitBoxLeft.X = (int)pos.X;
            this.hitBoxLeft.Y = (int)pos.Y;

            this.hitBoxRight.X = (int)pos.X+85;
            this.hitBoxRight.Y = (int)pos.Y;



            if (pBounceLeft)
            {
                shieldLeftOp = 1.00f;
                pBounceLeft = false;
                
            }

            if (pBounceMid)
            {
                shieldMidOp = 1.00f;
                pBounceMid = false;

            }

            if (pBounceRight)
            {
                shieldRightOp = 1.00f;
                pBounceRight = false;

            }

            if (shieldLeftOp >= 0)
            {
                shieldLeftOp -= 0.02f;
            }
            
            if (shieldMidOp >= 0)
            {
                shieldMidOp -= 0.02f;
            }

            if (shieldRightOp >= 0)
            {
                shieldRightOp -= 0.02f;
            }



            
        }

        public void Draw(SpriteBatch sb)
        {
            
            sb.Draw(padleTex, pos + new Vector2(padleTex.Width / 2, padleTex.Height / 2), null, Color.White, velocity * 0.01f, new Vector2(padleTex.Width/2,padleTex.Height/2), 1f, SpriteEffects.None, 0f);
            
            sb.Draw(shieldSideTex, pos, null, Color.White * shieldLeftOp, 0f, Vector2.Zero, 1f, SpriteEffects.FlipVertically, 0f);
            sb.Draw(shieldMidTex, pos, null, Color.White * shieldMidOp, 0f, Vector2.Zero, 1f, SpriteEffects.FlipVertically, 0f);
            sb.Draw(shieldSideTex, pos, null, Color.White * shieldRightOp, 0f , Vector2.Zero, 1f, SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically, 0f);



        }
    }
}
