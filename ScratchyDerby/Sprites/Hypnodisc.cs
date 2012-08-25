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
    public class Hypnodisc : Sprite
    {
        public override void Load()
        {
            AddCostume("Hypnodisc");
            Scale = 0.9f;
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
           Rotation = (float) gameTime.TotalGameTime.TotalSeconds * 20f;
        }

    }
}