#region usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
#endregion


namespace ScratchyXna
{
    class TestScreen : Scene
    {
        Text ScoreText;
        Text RestartText;
        Text HappyText;
        Hypnodisc hypnodisc;
        Mugatu mugatu;


        /// <summary>
        /// Load the game over screen
        /// </summary>
        public override void Load()
        {
           // GridStyle = GridStyles.Ticks;
            BackgroundColor = Color.Black;
            FontName = "QuartzMS";

            // Add the score text
            ScoreText = AddText(new Text
            {
                Alignment = HorizontalAlignments.Left,
                VerticalAlign = VerticalAlignments.Top,
                Scale = .4f,
                Position = new Vector2(-100f, 100f),
                Color = Color.White
            });

            // Add the start key text
            RestartText = AddText(new Text
            {
                Value = "Press SPACE to Play Again",
                Position = new Vector2(0f, -100f),
                Alignment = HorizontalAlignments.Center,
                VerticalAlign = VerticalAlignments.Bottom,
                AnimationType = TextAnimations.Typewriter,
                AnimationSeconds = 0.2,
                Scale = 0.5f,
                Color = Color.Lime
            });
            if (Game.Platform == GamePlatforms.XBox)
            {
                RestartText.Value = "Press START to Play Again";
            }
            else if (Game.Platform == GamePlatforms.WindowsPhone)
            {
                RestartText.Value = "TAP to Play Again";
            }

            AddSound("happyhappy");
            hypnodisc = AddSprite<Hypnodisc>();
            mugatu = AddSprite<Mugatu>();
            HappyText = AddText(new Text {
                Value = "HAPPY",
                Color = Color.OrangeRed,
                Scale = 3,
                Position = new Vector2(0, 90),
                Alignment = HorizontalAlignments.Center });
        }


        /// <summary>
        /// Start the game over screen
        /// </summary>
        public override void StartScene()
        {
            // Display the final score
            ScoreText.Value = "Score: Kickass"; // +SpaceInvaders.score;

            PlaySound("happyhappy", true);
        }


        /// <summary>
        /// Update the game over screen
        /// </summary>
        /// <param name="gameTime">Time since the last update</param>
        public override void Update(GameTime gameTime)
        {
            HappyText.X = (float)Math.Sin(gameTime.TotalGameTime.TotalSeconds) * 20;
            HappyText.Color = new Color(
                (int)(Math.Sin(gameTime.TotalGameTime.TotalSeconds) * 255f),
                (int)(Math.Sin(gameTime.TotalGameTime.TotalSeconds * 1.3) * 255f),
                (int)(Math.Sin(gameTime.TotalGameTime.TotalSeconds * 2) * 255f));

            if (Keyboard.KeyPressed(Keys.H))
            {
                //HappyText.Y = -50;
                HappyText.VerticalAlign = VerticalAlignments.Top;
                // HappyText.Position = new Vector2(0, 0);
                Sprite HappySprite = HappyText.CreateSprite();
                //HappySprite.Costume.YCenter = VerticalAlignments.Bottom;
                //AddSprite(HappySprite);
                hypnodisc.Stamp(HappySprite, StampMethods.Cutout);
                HappySprite.X -= 1;
                HappySprite.Y += 1;
                hypnodisc.Stamp(HappySprite, StampMethods.Normal);
            }

            if (Keyboard.KeyPressed(Keys.S))
            {
                mugatu.Costume.YCenter = VerticalAlignments.Top;
                //mugatu.X = Random.Next(-100, 100);
                //mugatu.Y = Random.Next(-100, 100);
                //mugatu.X = -80;
                //mugatu.Y = -80;
                //hypnodisc.X = -80;
                //hypnodisc.Y = -80;
                //hypnodisc.Stamp(mugatu, StampMethods.Cutout);
                hypnodisc.Stamp(mugatu, StampMethods.Normal);
                //mugatu.X = 0;
                //mugatu.Y = 0;
                //hypnodisc.X = 0;
                //hypnodisc.Y = 0;
            }

            // Space key to play again
            if (Keyboard.KeyPressed(Keys.Space))
            {
                //todo: also do this for phone tap
                //todo: also do this for xbox a button
                ShowScene("play");
            }

        }

    }
}
