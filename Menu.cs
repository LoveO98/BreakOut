using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakOut_Ver1
{
    public class Menu
    {
        Texture2D startStoryButtonTex;
        Texture2D infiniteSoloButtonTex;
        Texture2D multiplayButtonTex;
        Texture2D coopButtonTex;
        Texture2D vsButtonTex;
        Texture2D exitButtonTex;
        Texture2D backgroundTex;
        Texture2D selectorTex;
        Texture2D highScoreTex;
        public bool keyCooldown;
        public bool twoPlayerMenu;
        public enum MenuStateB
        {
            start1p,
            start1pInf,
            start2p,
            start2pVs,
            start2pCoop,
            hichScore,
            exit
        }
        public enum MenuState
        {
            menu,
            start1p,
            start1pInf,
            start2p,
            start2pVs,
            start2pCoop,
            hichScore,
            exit
        }

        public MenuStateB menuStateB = MenuStateB.start1p;
        public MenuState menuState = MenuState.menu;
        public Menu(Texture2D startStoryButtonTex, Texture2D multiplayButtonTex, Texture2D coopButtonTex, Texture2D vsButtonTex, Texture2D exitButtonTex, Texture2D backgroundTex, Texture2D selectorTex, Texture2D infiniteSoloButtonTex, Texture2D highScoreTex)
        {
            this.startStoryButtonTex = startStoryButtonTex;
            this.multiplayButtonTex = multiplayButtonTex;
            this.coopButtonTex = coopButtonTex;
            this.vsButtonTex = vsButtonTex;
            this.exitButtonTex = exitButtonTex;
            this.backgroundTex = backgroundTex;
            this.selectorTex = selectorTex;
            this.infiniteSoloButtonTex = infiniteSoloButtonTex;
            this.highScoreTex = highScoreTex;
            
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            switch (menuState)
            {
                case MenuState.menu:

                    


                    switch (menuStateB)
                    {
                        case MenuStateB.start1p:
                            if (keyboardState.IsKeyDown(Keys.X))
                            {

                            }

                            if (!keyCooldown)
                            {
                                if (keyboardState.IsKeyDown(Keys.Down))
                                {
                                    keyCooldown = true;
                                    menuStateB = MenuStateB.start1pInf;
                                }


                            }
                            if (keyboardState.IsKeyUp(Keys.Up) && keyboardState.IsKeyUp(Keys.Down))
                            {
                                keyCooldown = false;
                            }

                            break;

                        case MenuStateB.start1pInf:
                            if (keyboardState.IsKeyDown(Keys.X))
                            {
                                Game1.currentGS = Game1.GameState.infiniteSolo;
                            }

                            if (!keyCooldown)
                            {
                                if (keyboardState.IsKeyDown(Keys.Up))
                                {
                                    keyCooldown = true;
                                    menuStateB = MenuStateB.start1p;
                                }
                                else if (keyboardState.IsKeyDown(Keys.Down))
                                {
                                    keyCooldown = true;
                                    menuStateB = MenuStateB.start2p;
                                }


                            }
                            if (keyboardState.IsKeyUp(Keys.Up) && keyboardState.IsKeyUp(Keys.Down))
                            {
                                keyCooldown = false;
                            }
                            break;

                        case MenuStateB.start2p:
                            if (keyboardState.IsKeyDown(Keys.X))
                            {
                                menuState = MenuState.start2p;
                                menuStateB = MenuStateB.start2pCoop;
                            }

                            if (!keyCooldown)
                            {
                                if (keyboardState.IsKeyDown(Keys.Up))
                                {
                                    keyCooldown = true;
                                    menuStateB = MenuStateB.start1pInf;
                                }
                                else if (keyboardState.IsKeyDown(Keys.Down))
                                {
                                    keyCooldown = true;
                                    menuStateB = MenuStateB.hichScore;
                                }
                            }
                            if (keyboardState.IsKeyUp(Keys.Up) && keyboardState.IsKeyUp(Keys.Down))
                            {
                                keyCooldown = false;
                            }
                            break;

                        case MenuStateB.start2pCoop:

                            break;

                        case MenuStateB.start2pVs:

                            break;

                        case MenuStateB.hichScore:
                            if (!keyCooldown)
                            {
                                if (keyboardState.IsKeyDown(Keys.Up))
                                {
                                    keyCooldown = true;
                                    menuStateB = MenuStateB.start2p;
                                }
                                else if (keyboardState.IsKeyDown(Keys.Down))
                                {
                                    keyCooldown = true;
                                    menuStateB = MenuStateB.exit;
                                }
                            }
                            if (keyboardState.IsKeyUp(Keys.Up) && keyboardState.IsKeyUp(Keys.Down))
                            {
                                keyCooldown = false;
                            }
                            break;

                        case MenuStateB.exit:
                            if (keyboardState.IsKeyDown(Keys.X))
                            {
                                Game1.quitThisBitch = true;
                            }

                            if (!keyCooldown)
                            {
                                if (keyboardState.IsKeyDown(Keys.Up))
                                {
                                    keyCooldown = true;
                                    menuStateB = MenuStateB.hichScore;
                                }


                            }
                            if (keyboardState.IsKeyUp(Keys.Up) && keyboardState.IsKeyUp(Keys.Down))
                            {
                                keyCooldown = false;
                            }


                            break;
                    }

                    break;

                case MenuState.start1p:


                    break;

                case MenuState.start1pInf:


                    break;

                case MenuState.start2p:

                    

                    if (keyboardState.IsKeyDown(Keys.Escape))
                    {
                        menuState = MenuState.menu;
                        menuStateB = MenuStateB.start2p;
                    }

                    switch (menuStateB)
                    {

                        case MenuStateB.start2pCoop:
                            
                            if (!keyCooldown)
                            {
                                if (keyboardState.IsKeyDown(Keys.Down))
                                {
                                    keyCooldown = true;
                                    menuStateB = MenuStateB.start2pVs;
                                }
                            }
                            if (keyboardState.IsKeyUp(Keys.Up) && keyboardState.IsKeyUp(Keys.Down))
                            {
                                keyCooldown = false;
                            }

                            break;

                        case MenuStateB.start2pVs:
                            
                            if (!keyCooldown)
                            {
                                if (keyboardState.IsKeyDown(Keys.Up))
                                {
                                    keyCooldown = true;
                                    menuStateB = MenuStateB.start2pCoop;
                                }
                            }
                            if (keyboardState.IsKeyUp(Keys.Up) && keyboardState.IsKeyUp(Keys.Down))
                            {
                                keyCooldown = false;
                            }

                            break;
                    }

                    break;

                case MenuState.start2pCoop:


                    break;

                case MenuState.start2pVs:


                    break;

                case MenuState.hichScore:


                    break;

                case MenuState.exit:


                    break;
            }


            

        }


        public void Draw(SpriteBatch sb)
        {

            KeyboardState keyboardState = Keyboard.GetState();

            switch (menuState)
            {
                case MenuState.menu:

                    sb.Draw(backgroundTex, new Vector2(0, 0), Color.White);
                    sb.Draw(startStoryButtonTex, new Vector2(960 - startStoryButtonTex.Width / 2, 350), Color.White);
                    sb.Draw(infiniteSoloButtonTex, new Vector2(960 - infiniteSoloButtonTex.Width / 2, 420), Color.White);
                    sb.Draw(multiplayButtonTex, new Vector2(960 - multiplayButtonTex.Width / 2, 490), Color.White);
                    sb.Draw(highScoreTex, new Vector2(960 - highScoreTex.Width / 2, 560), Color.White);
                    sb.Draw(exitButtonTex, new Vector2(960 - exitButtonTex.Width / 2, 630), Color.White);



                    switch (menuStateB)
                    {
                        case MenuStateB.start1p:
                            sb.Draw(selectorTex, new Vector2(730, 360), Color.White);
                            sb.Draw(startStoryButtonTex, new Vector2(960 - startStoryButtonTex.Width / 2, 350), null, Color.White, 0f, new Vector2(42, 6), 1.5f, SpriteEffects.None, 0f);


                            



                            break;

                        case MenuStateB.start1pInf:
                            sb.Draw(selectorTex, new Vector2(730, 430), Color.White);
                            sb.Draw(infiniteSoloButtonTex, new Vector2(960 - infiniteSoloButtonTex.Width / 2, 420), null, Color.White, 0f, new Vector2(42, 6), 1.5f, SpriteEffects.None, 0f);

                            






                            break;

                        case MenuStateB.start2p:

                            sb.Draw(selectorTex, new Vector2(730, 500), Color.White);
                            sb.Draw(multiplayButtonTex, new Vector2(960 - multiplayButtonTex.Width / 2, 490), null, Color.White, 0f, new Vector2(42, 6), 1.5f, SpriteEffects.None, 0f);

                            

                            break;

                        case MenuStateB.hichScore:

                            sb.Draw(selectorTex, new Vector2(730, 570), Color.White);
                            sb.Draw(highScoreTex, new Vector2(960 - highScoreTex.Width / 2, 560), null, Color.White, 0f, new Vector2(42, 6), 1.5f, SpriteEffects.None, 0f);

                            


                            break;

                        case MenuStateB.exit:

                            sb.Draw(selectorTex, new Vector2(730, 640), Color.White);
                            sb.Draw(exitButtonTex, new Vector2(960 - exitButtonTex.Width / 2, 630), null, Color.White, 0f, new Vector2(42, 6), 1.5f, SpriteEffects.None, 0f);

                            


                            break;

                    }

                    break;

                case MenuState.start1p:
                    

                    break;

                case MenuState.start1pInf:


                    break;

                case MenuState.start2p:

                    sb.Draw(backgroundTex, new Vector2(0, 0), Color.White);
                    sb.Draw(coopButtonTex, new Vector2(960 - coopButtonTex.Width / 2, 350), Color.White);
                    sb.Draw(vsButtonTex, new Vector2(960 - vsButtonTex.Width / 2, 420), Color.White);

                    

                    switch (menuStateB)
                    {

                        case MenuStateB.start2pCoop:
                            sb.Draw(selectorTex, new Vector2(730, 360), Color.White);
                            sb.Draw(coopButtonTex, new Vector2(960 - coopButtonTex.Width / 2, 350), null, Color.White, 0f, new Vector2(42, 6), 1.5f, SpriteEffects.None, 0f);
                            

                            break;

                        case MenuStateB.start2pVs:
                            sb.Draw(selectorTex, new Vector2(730, 430), Color.White);
                            sb.Draw(vsButtonTex, new Vector2(960 - vsButtonTex.Width / 2, 420), null, Color.White, 0f, new Vector2(42, 6), 1.5f, SpriteEffects.None, 0f);

                            

                            break;
                    }

                    break;

                case MenuState.start2pCoop:


                    break;

                case MenuState.start2pVs:


                    break;

                case MenuState.hichScore:


                    break;

                case MenuState.exit:


                    break;
            }



            








        }
    }
}
