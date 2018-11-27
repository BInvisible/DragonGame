using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonGame
{
    public abstract class GameObject
    {
        private int state;
        private int step;
        private Bitmap sprite;
        private int x;
        private int y;
        private int width;
        private int height;
        private bool stop;
        private bool destroy;
        public int Step
        {
            get
            {
                return step;
            }

            set
            {
                step = value;
            }
        }

        public int State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }


        public Bitmap Sprite
        {
            get
            {
                return sprite;
            }

            set
            {
                sprite = value;
            }
        }

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public bool Stop
        {
            get
            {
                return stop;
            }

            set
            {
                stop = value;
            }
        }

        public bool Destroy
        {
            get
            {
                return destroy;
            }

            set
            {
                destroy = value;
            }
        }

        public GameObject(string path)
        {
            Sprite = (Bitmap)Image.FromFile(path);
            State = 0;
            Step = 0;
        }
        public abstract void DrawSprite(Graphics g, int x, int y);
        public virtual void Next()
        {
            
        }
        public virtual void NextState()
        {
            
        }

        public virtual void NextPosition()
        {
            if (State == 0)
                Y = Y + 1;
            if (State == 1)
                X = X - 1;
            if (State == 2)
                X = X + 1;
            if (State == 3)
                Y = Y - 1;
        }
        public void Des()
        {
            Stop = true;
            Destroy = true;
        }
    
    }
}
