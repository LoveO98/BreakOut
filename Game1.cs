using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace BreakOut_Ver1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public static Texture2D ballTex;
        public static Texture2D brickTex;
        public static Texture2D padleTex;
        public static Texture2D shieldMidTex;
        public static Texture2D shieldSideTex;
        public static Texture2D startStoryButtonTex;
        public static Texture2D multiplayButtonTex; //
        public static Texture2D coopButtonTex; //
        public static Texture2D vsButtonTex; //
        public static Texture2D exitButtonTex;//
        public static Texture2D backgroundTex; //
        public static Texture2D selectorTex; //
        public static Texture2D infiniteSoloButtonTex; //
        public static Texture2D highScoreTex; //
        public static Texture2D brickExplosionTex;


        public Rectangle explosionBox;
        public Rectangle explosionBox2;
        public Rectangle explosionBox3;

        public int screenWidth;
        public int screenHeight;
        public int nrXBrick = 14;
        public int nrYBrick = 8;
        public static int testCounter = 0;
        public static int testCounter2 = 0;
        public static int testCounter3 = 0;
        public static int stopX;
        public static int stopY;
        public int brickModifier;
        Ball ball;
        public static List<Ball> balls = new List<Ball>();
        Menu menu;
        public Vector2 velocity;
        Brick brick;
        Brick[,] bricks;
        Padle padle;
        public Random rnd = new Random();

        public static int ballAmount = 10000;
        public bool keyCooldown = true;
        public int middleX;
        public static int screenWidth2;
        public int points=0;
        public SpriteFont spritefont;
        Vector2 textPos = new Vector2(700, 500);
        //public static int lives = 1000;
        Vector2 brickSplitPos = Vector2.Zero;
        Vector2 brickCentre;
        public enum GameState
        {
            start, 
            menu, 
            infiniteSolo, 
            mpVs, 
            mpCoop, 
            highScore,
            level1, 
            level2, 
            level3, 
            level4, 
            level5, 
            levelF, 
            score, 
            endScreen
        }
        KeyboardState keyboardState = Keyboard.GetState();
        public static GameState currentGS = GameState.menu;
        //public KeyboardState keyboardState = Keyboard.GetState();
        public static bool quitThisBitch;
        public bool theresANewBallUpInThisBitch;
        public bool drawExplosion;
        public float explosionTimer = 0.00f;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ballTex = Content.Load<Texture2D>(@"ball_breakout");
            brickTex = Content.Load<Texture2D>(@"block_breakout");
            padleTex = Content.Load<Texture2D>(@"SpaceShip1");
            shieldSideTex = Content.Load<Texture2D>(@"SpaceShip1ShieldSide");
            shieldMidTex = Content.Load<Texture2D>(@"SpaceShip1ShieldMid");
            selectorTex = Content.Load<Texture2D>(@"Selector");
            startStoryButtonTex = Content.Load<Texture2D>(@"StartStory");
            multiplayButtonTex = Content.Load<Texture2D>(@"Multiplayer");
            coopButtonTex = Content.Load<Texture2D>(@"CoOp");
            vsButtonTex = Content.Load<Texture2D>(@"Competetive");
            exitButtonTex = Content.Load<Texture2D>(@"Exit");
            backgroundTex = Content.Load<Texture2D>(@"PlaceHolderBG");
            infiniteSoloButtonTex = Content.Load<Texture2D>(@"Infinite1p");
            highScoreTex = Content.Load<Texture2D>(@"HighScores");
            brickExplosionTex = Content.Load<Texture2D>(@"PlaceHolderExplosion");

            menu = new Menu(startStoryButtonTex, multiplayButtonTex, coopButtonTex, vsButtonTex, exitButtonTex, backgroundTex, selectorTex, infiniteSoloButtonTex, highScoreTex);

            screenWidth = graphics.PreferredBackBufferWidth = 1920;
            screenHeight = graphics.PreferredBackBufferHeight = 1080;
            graphics.ApplyChanges();


            stopX = Window.ClientBounds.Width - ballTex.Width;
            stopY = Window.ClientBounds.Height - ballTex.Height;
            middleX = Window.ClientBounds.Width / 2;
            
            //velocity = new Vector2(5, 7);
            
            Vector2 padlePos = new Vector2(middleX, 800);
            screenWidth2 = Window.ClientBounds.Width;
            padle = new Padle(padleTex, shieldMidTex, shieldSideTex, padlePos);

            bricks = new Brick[nrXBrick, nrYBrick];
            

            for (int i = 0; i < nrXBrick; i++)
            {
                for (int j = 0; j < nrYBrick; j++)
                {
                    int x = i * brickTex.Width;
                    int y = j * brickTex.Height;
                    bricks[i, j] = new Brick(brickTex, x, y, j);
                    brickModifier = rnd.Next(5, 6);
                    if (brickModifier == 5)
                    {
                        bricks[i, j].powerupBricks = true;
                    }
                }
                
            }

            

            //int powerupBricks = 0;
            //while(powerupBricks < 10)
            //{
            //    Random rand = new Random();

            //    foreach (Brick brick in bricks)
            //    {

            //        if (rand.Next(0, 10) == 10)
            //        {
            //            brick.powerupBricks = true;
            //            powerupBricks++;
            //        }

            //    }

            //}
            spritefont = Content.Load<SpriteFont>("spritefont1");
            
            



        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (quitThisBitch)
            {
                Exit();
            }

            menu.Update(gameTime);

            //if(lives <= 0)
            //{
            //    currentGS = GameState.start;
            //}

            

            switch (currentGS)
            {
                case GameState.menu:


                    break;


                case GameState.infiniteSolo:

                    
                    
                    if (keyboardState.IsKeyUp(Keys.X))
                    {
                        keyCooldown = false;
                    }

                    if (keyboardState.IsKeyDown(Keys.X) && !keyCooldown && ballAmount > 0)
                    {
                        theresANewBallUpInThisBitch = true;
                        keyCooldown = true;
                    }

                    if (theresANewBallUpInThisBitch)
                    {
                        if (keyboardState.IsKeyDown(Keys.Left))
                        {
                            velocity = new Vector2(-3, -5);
                        }
                        else if (keyboardState.IsKeyDown(Keys.Right))
                        {
                            velocity = new Vector2(3, -5);
                        }
                        else if (keyboardState.IsKeyDown(Keys.Up))
                        {
                            velocity = new Vector2(0, -7);
                        }
                        else
                        {
                            velocity = new Vector2(0, -5);
                        }
                        balls.Add(ball = new Ball(ballTex, stopX, stopY, padle.pos, velocity));
                        ballAmount--;
                        theresANewBallUpInThisBitch = false;
                    }


                    //for (int i = 0; i < bricks.GetLength(0); i++)
                    //{
                    //    for (int j = 0; j < bricks.GetLength(1); j++)
                    //    {
                    //        bricks[i,j].Update(gameTime);
                    //    }
                    //}
                    
                    foreach (Ball ball in balls.ToList())
                    {
                        ball.Update(padle, gameTime);
                    }
                    
                    padle.Update(gameTime);
                    
                    foreach (Ball ball in balls)
                    {
                        for (int i = 0; i < bricks.GetLength(0); i++)
                        {
                            for (int j = 0; j < bricks.GetLength(1); j++)
                            {
                                brick = bricks[i, j];
                                if (ball.hitBox.Intersects(brick.hitBox))
                                {
                                    brickCentre = new Vector2((int)brick.pos.X + brickTex.Width / 2, (int)brick.pos.Y + brickTex.Height / 2);
                                    brick.isVisible = false;
                                    brick.hit = true;
                                    bricks[i, j].Update(gameTime);
                                    
                                    switch (brick.powerUps)
                                    {
                                        case Brick.PowerUps.pierceBall:
                                            ball.pierceBrick = true;
                                            break;

                                        case Brick.PowerUps.splitBall:
                                            brickSplitPos = new Vector2(brick.pos.X, brick.pos.Y + brickTex.Height);
                                            break;

                                        case Brick.PowerUps.explodingBrick:
                                            
                                            explosionBox = new Rectangle((int)brickCentre.X - brickExplosionTex.Width / 2, (int)brickCentre.Y - brickExplosionTex.Height / 2, brickExplosionTex.Width, brickExplosionTex.Height);
                                            
                                            break;
                                    }
                                    
                                    if (!ball.pierceBrick)

                                    {
                                        ball.bounce = true;
                                    }
                                    
                                    points += 100;

                                }
                                for (int k = 0; k < bricks.GetLength(0); k++)
                                {
                                    for (int l = 0; l < bricks.GetLength(1); l++)
                                    {
                                        if (explosionBox.Intersects(brick.hitBox))
                                        {
                                            brickCentre = new Vector2((int)brick.pos.X + brickTex.Width / 2, (int)brick.pos.Y + brickTex.Height / 2);
                                            brick.isVisible = false;
                                            brick.hit = true;
                                            bricks[k, l].Update(gameTime);

                                            switch (brick.powerUps)
                                            {


                                                case Brick.PowerUps.splitBall:
                                                    brickSplitPos = new Vector2(brick.pos.X, brick.pos.Y + brickTex.Height);
                                                    break;

                                                case Brick.PowerUps.explodingBrick:

                                                    explosionBox = new Rectangle((int)brickCentre.X - brickExplosionTex.Width / 2, (int)brickCentre.Y - brickExplosionTex.Height / 2, brickExplosionTex.Width, brickExplosionTex.Height);

                                                    break;
                                            }



                                            points += 100;
                                        }
                                    }
                                }

                                
                                //if (explosionBox2.Intersects(brick.hitBox))
                                //{
                                //    brickCentre = new Vector2((int)brick.pos.X + brickTex.Width / 2, (int)brick.pos.Y + brickTex.Height / 2);
                                //    brick.isVisible = false;
                                //    brick.hit = true;
                                //    bricks[i, j].Update(gameTime);

                                //    switch (brick.powerUps)
                                //    {


                                //        case Brick.PowerUps.splitBall:
                                //            brickSplitPos = new Vector2(brick.pos.X, brick.pos.Y + brickTex.Height);
                                //            break;

                                //        case Brick.PowerUps.explodingBrick:

                                //            explosionBox3 = new Rectangle((int)brickCentre.X - brickExplosionTex.Width / 2, (int)brickCentre.Y - brickExplosionTex.Height / 2, brickExplosionTex.Width, brickExplosionTex.Height);

                                //            break;
                                //    }



                                //    points += 100;
                                //}
                                //if (explosionBox3.Intersects(brick.hitBox))
                                //{
                                //    brickCentre = new Vector2((int)brick.pos.X + brickTex.Width / 2, (int)brick.pos.Y + brickTex.Height / 2);
                                //    brick.isVisible = false;
                                //    brick.hit = true;
                                //    bricks[i, j].Update(gameTime);

                                //    switch (brick.powerUps)
                                //    {


                                //        case Brick.PowerUps.splitBall:
                                //            brickSplitPos = new Vector2(brick.pos.X, brick.pos.Y + brickTex.Height);
                                //            break;

                                //        case Brick.PowerUps.explodingBrick:

                                //            explosionBox = new Rectangle((int)brickCentre.X - brickExplosionTex.Width / 2, (int)brickCentre.Y - brickExplosionTex.Height / 2, brickExplosionTex.Width, brickExplosionTex.Height);

                                //            break;
                                //    }



                                //    points += 100;
                                //}
                            }
                            
                        }

                    }


                    

                    if (brickSplitPos != Vector2.Zero)
                    {
                        
                        int velocityTemp = rnd.Next(-5,6);
                        velocity = new Vector2(velocityTemp, -5);
                        balls.Add(ball = new Ball(ballTex, stopX, stopY, brickSplitPos, velocity));
                        brickSplitPos = Vector2.Zero;
                    }
                    


                    break;
            }

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            switch (currentGS)
            {

                case GameState.menu:
                    menu.Draw(spriteBatch);
                    
             
                    
                    break;


                case GameState.infiniteSolo:

                    foreach (Ball ball in balls)
                    {
                        ball.Draw(spriteBatch);
                    }

                    
                    padle.Draw(spriteBatch);

                    for (int i = 0; i < bricks.GetLength(0); i++)
                    {
                        for (int j = 0; j < bricks.GetLength(1); j++)
                        {
                            bricks[i, j].Draw(spriteBatch);
                            
                        }

                    }

                    
                    

                    spriteBatch.DrawString(spritefont, "Points: " + points, textPos, Color.Yellow);
                    spriteBatch.DrawString(spritefont, "Balls Left: " + ballAmount, new Vector2(700, 550), Color.Yellow);
                    spriteBatch.DrawString(spritefont, "Test1: " + testCounter, new Vector2(700, 600), Color.Yellow);
                    spriteBatch.DrawString(spritefont, "Test2: " + testCounter2, new Vector2(700, 650), Color.Yellow);
                    spriteBatch.DrawString(spritefont, "Test3: " + testCounter3, new Vector2(700, 700), Color.Yellow);
                    spriteBatch.DrawString(spritefont, "Active balls: " + balls.Count, new Vector2(700, 750), Color.Yellow);

                    break;
            }


            
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}