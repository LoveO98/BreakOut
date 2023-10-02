using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using SharpDX.Direct3D9;
using static System.Formats.Asn1.AsnWriter;

namespace BreakOut_Ver1
{
    public class Brick
    {
        Texture2D brickTex;
        public Vector2 pos;
        int row;
        public Rectangle hitBox;
        public bool isVisible = true;
        public bool powerupBricks;
        public int pwrUpBrick;
        public bool hit;
        public bool hit2;
        Ball ball;

        public Rectangle explosionBoxBrick;

        public bool splitBall;
        public int ballNr;
        public Vector2 brickCentre;
        public float explosionTimer = 0.00f;
        public enum PowerUps
        {
            extraBall,
            pierceBall,
            splitBall,
            explodingBrick,
            reverseControlls,
            slowShip
        }
        public PowerUps powerUps;
        public Brick(Texture2D brickTex, int posX, int posY, int row)
        {
            this.brickTex = brickTex;
            this.pos = new Vector2(posX, posY);
            this.row = row;
            this.hitBox = new Rectangle((int)pos.X, (int)pos.Y, brickTex.Width, brickTex.Height);
            Random rnd = new Random();
            pwrUpBrick = rnd.Next(3, 4);
            
            brickCentre = new Vector2(pos.X + brickTex.Width / 2, pos.Y + brickTex.Height / 2);
        }

        public void Update(GameTime gameTime)
        {
            

            

            if (powerupBricks)
            {
                
                if (hit)
                {
                    hit2 = true;

                    switch (pwrUpBrick)
                    {
                        case 1:
                            Game1.ballAmount++;
                            break;

                        case 2:
                            powerUps = PowerUps.pierceBall;
                            break;

                        case 3:

                            powerUps = PowerUps.splitBall;
                            break;

                        case 4:
                            powerUps = PowerUps.explodingBrick;
                            explosionBoxBrick = new Rectangle((int)brickCentre.X - Game1.brickExplosionTex.Width / 2, (int)brickCentre.Y - Game1.brickExplosionTex.Height / 2, Game1.brickExplosionTex.Width, Game1.brickExplosionTex.Height);
                            if (!hit)
                            {
                                explosionBoxBrick = new Rectangle(-1000, -1000, 0, 0);
                            }
                            explosionTimer = 1f;
                            break;
                            
                        case 5:
                            powerUps = PowerUps.reverseControlls;
                            break;

                        case 6:
                            powerUps = PowerUps.slowShip;
                            break;

                    }
                    hit = false;
                }
            }
            if (!isVisible)
            {
                this.hitBox = new Rectangle(-100, -100, 0, 0);

            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
            {
                if (powerupBricks)
                {
                    switch (pwrUpBrick)
                    {
                        case 1:
                            spriteBatch.Draw(brickTex, pos, Color.Blue);
                            break;

                        case 2:
                            spriteBatch.Draw(brickTex, pos, Color.Purple);
                            break;

                        case 3:
                            spriteBatch.Draw(brickTex, pos, Color.White);
                            break;

                        case 4:
                            spriteBatch.Draw(brickTex, pos, Color.Black);
                            break;

                        case 5:
                            spriteBatch.Draw(brickTex, pos, Color.Pink);
                            break;

                        case 6:
                            spriteBatch.Draw(brickTex, pos, Color.Beige);
                            break;
                    }
                }
                else
                {
                    if (row == 0)
                    {
                        spriteBatch.Draw(brickTex, pos, Color.Red);
                    }
                    else if (row == 1)
                    {
                        spriteBatch.Draw(brickTex, pos, Color.Orange);
                    }
                    else if (row == 2)
                    {
                        spriteBatch.Draw(brickTex, pos, Color.Yellow);
                    }
                    else if (row >= 3)
                    {
                        spriteBatch.Draw(brickTex, pos, Color.Green);
                    }
                }
                

                

            
            }
            
            if (hit2)
            {
                spriteBatch.Draw(Game1.brickExplosionTex, new Vector2((int)brickCentre.X - Game1.brickExplosionTex.Width / 2, (int)brickCentre.Y - Game1.brickExplosionTex.Height / 2), Color.White * explosionTimer);
                if (explosionTimer >= 0)
                {
                    explosionTimer -= 0.03f;
                }
            }

        }
    }
}
