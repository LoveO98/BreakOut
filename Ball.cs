using System;
using System.Collections.Generic;
using System.Linq;
//using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BreakOut_Ver1
{
    public class Ball
    {
        
        public Vector2 pos;
        public int stopX;
        public int stopY;
        
        public Texture2D ballTex;
        public Vector2 velocity;
        Random rnd = new Random();
        public Rectangle hitBox;
        public bool bounce;
        public bool pBounceLeft;
        public bool pBounceMid;
        public bool pBounceRight;
        public bool pBounceSideL;
        public bool pBounceSideR;
        public bool pierceBrick;
        //Game1 game;
        public bool isBalling;
        public bool keyCooldown = true;
        
        public Ball(Texture2D ballTex, int stopX, int stopY, Vector2 pos, Vector2 velocity)
        {
            this.ballTex = ballTex;
            this.pos = pos;
            this.stopX = stopX;
            this.stopY = stopY;
            this.velocity = velocity;
            this.pos.X = this.pos.X + Game1.padleTex.Width / 2 - this.ballTex.Width / 2;
            this.pos.Y = this.pos.Y - this.ballTex.Height;

            this.hitBox = new Rectangle((int)this.pos.X, (int)this.pos.Y, ballTex.Width, ballTex.Height);
            
        }
        public void Update(Padle padle, GameTime gameTime)
        {
            
            if (hitBox.Intersects(padle.hitBoxMid))
            {
                pierceBrick = false;
                if (hitBox.Bottom - 7 <= padle.hitBoxMid.Top)
                {
                    pBounceMid = true;
                    padle.pBounceMid = true;
                }
                

            }
            else if (hitBox.Intersects(padle.hitBoxLeft))
            {
                pierceBrick = false;
                if (hitBox.Bottom - 7 <= padle.hitBoxLeft.Top)
                {
                    pBounceLeft = true;
                    padle.pBounceLeft = true;
                }
                else
                {
                    pBounceSideL = true;
                    padle.pBounceLeft = true;
                }

            }
            else if (hitBox.Intersects(padle.hitBoxRight))
            {
                pierceBrick = false;
                if (hitBox.Bottom - 7 <= padle.hitBoxRight.Top)
                {
                    pBounceRight = true;
                    padle.pBounceRight = true;
                }
                else
                {
                    pBounceSideR = true;
                    padle.pBounceRight = true;
                }

            }

            

            if (bounce)
            {
                velocity.Y *= -1;
                bounce = false;
            }

            if (pBounceMid)
            {
                velocity.Y *= -1;
                velocity.X = 0;



                pBounceMid = false;

            }

            if (pBounceRight)
            {
                velocity.Y *= -1;
                if (velocity.X < 3)
                {
                    velocity.X = 3;
                }
                else
                {
                    velocity.X += 3;
                }

                pBounceRight = false;
            }

            if (pBounceLeft)
            {
                velocity.Y *= -1;
                if (velocity.X > -3)
                {
                    velocity.X = -3;
                }
                else
                {
                    velocity.X += -3;
                }

                pBounceLeft = false;
            }

            if (pos.X <= 0 || pos.X >= stopX)
            {

                velocity.X *= -1;
            }

            if (pBounceSideL)
            {
                velocity.X = Math.Abs(velocity.X);
                if (velocity.X == 0)
                {
                    velocity.X = 5;
                }
                velocity.X *= -1;
                pBounceSideL = false;
            }

            if (pBounceSideR)
            {

                velocity.X = Math.Abs(velocity.X);
                if (velocity.X == 0)
                {
                    velocity.X = 5;
                }
                pBounceSideR = false;
            }

            if (pos.Y <= 0)
            {
                velocity.Y = Math.Abs(velocity.Y);
                //velocity.Y *= -1;
            }

            if (pos.Y >= stopY)
            {
                //Game1.balls.Remove(this);
                velocity.Y = 0;
                velocity.X = 0;

            }

            if (velocity.X > 9)
            {
                velocity.X = 9;
            }

            if (velocity.X < -9)
            {
                velocity.X = -9;
            }


            pos.X = pos.X + velocity.X;
            pos.Y = pos.Y + velocity.Y;
            hitBox.X = (int)pos.X;
            hitBox.Y = (int)pos.Y;




        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(ballTex, pos, Color.Red);
            
        }

    }
}
