#region usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScratchyXna;
using Microsoft.Xna.Framework;
#endregion


namespace ScratchyXna
{
    public class Mugatu : Sprite
    {
        public override void Load()
        {
            AddCostume("Mugatu");
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            Rotation = (float) gameTime.TotalGameTime.TotalSeconds * -80f;
            Scale = 0.5f + (float)Math.Sin(gameTime.TotalGameTime.TotalSeconds * 2) * .3f;
        }

    }
}