using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DragonGame
{
    public class Dragon:GameObject
    {
        
        public Dragon(string path):base(path)
        {

        }
        public override void DrawSprite(Graphics g, int x,int y)
        {
            g.DrawImage(Sprite, x,y, new Rectangle(96 * Step, 96 * State, 96, 96), GraphicsUnit.Pixel);
        }
        public override void Next()
        {
            Step = (Step + 1) % 4;
        }
        public override void NextState()
        {
            State = (State + 1) % 4;
        }
        public override void NextPosition()
        {
            base.NextPosition();
        }


    }
}