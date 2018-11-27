using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonGame
{
    public class Boom :GameObject
    {
        public Boom(string path) : base(path) {  }



        public override void DrawSprite(Graphics g,int x,int y)
        {
            g.DrawImage(Sprite, x, y, new Rectangle(72 * Step,72*State , 72, 72), GraphicsUnit.Pixel);
        }
        public override void Next()
        {
            Step = (Step + 1) % 8;
        }
        public override void NextPosition()
        {
            base.NextPosition();
        }
        public override void NextState()
        {
            base.NextState();
        }

    }
}
