using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragonGame
{
    public partial class Form1 : Form
    {
        private string path;
        private string path_name;
        private string path_name1;
        private Dragon dragon;
        private Bitmap buffer;
        private Boom boom;
        int PositionX;
        int PositionY;
        private int count;
        Random r1 = new Random();
        Random r2 = new Random();
        bool mouse;
        public Form1()
        {
            InitializeComponent();

        }
        bool IsBomb = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            path = Path.GetFullPath(Environment.CurrentDirectory);
            path_name = @"\dragon.png";
            dragon=new Dragon(path + path_name);            
            path_name1 = @"\bom.png";
            boom=new Boom(path + path_name1);
            buffer = new Bitmap(this.Width, this.Height);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            dragon.Next();
            dragon.NextPosition();
            Graphics buffGraphics = Graphics.FromImage(buffer);
            buffGraphics.Clear(Color.White);
            dragon.DrawSprite(buffGraphics, dragon.X, dragon.Y);
            boom.DrawSprite(buffGraphics, boom.X, boom.Y);
            this.CreateGraphics().DrawImage(buffer, 0, 0);

            if (Math.Abs(dragon.X - boom.X) < boom.Sprite.Width / 16 && Math.Abs(dragon.Y - boom.Y) < boom.Sprite.Height / 12)
            {
                timer1.Stop();
                timer2.Start();
                timer2.Interval = 100;
                this.CreateGraphics().Clear(Color.White);
                if (!boom.Destroy)
                {
                    if (boom.Stop)
                    {
                        dragon.Stop = true;
                        boom.Stop = false;
                    }
                }
                else
                    this.CreateGraphics().Clear(Color.White);

            }
            else
            {
                if (count == 20)
                {
                    boom.X = r1.Next(buffer.Width);
                    boom.Y = r2.Next(buffer.Height);
                    count = 0;
                }
                count++;
                Mouse();


            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            dragon.X = (this.Height / 2) - 48;
            dragon.Y = (this.Width / 2) - 48;
            boom.X = this.Width / 2 - boom.Sprite.Width / 4;
            boom.Y = this.Height / 2 - boom.Sprite.Height / 4;
            timer1.Interval = 80;
            timer1.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void btnChangeState_Click(object sender, EventArgs e)
        {
            dragon.NextState();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            mouse = false;
            if (mouse == false)
            {
                if (e.KeyCode == Keys.W)
                {
                    dragon.Y = dragon.Y- 10;
                    dragon.State = 3;
                }
                if (e.KeyCode == Keys.S)
                {
                    dragon.Y = dragon.Y + 10;
                    dragon.State = 0;
                }
                if (e.KeyCode == Keys.A)
                {
                    dragon.X = dragon.X - 10;
                    dragon.State = 1;
                }
                if (e.KeyCode == Keys.D)
                {
                    dragon.X = dragon.X + 10;
                    dragon.State = 2;
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Start();
            PositionX = e.X;
            PositionY = e.Y;
            mouse = true;
        }
        private void Mouse()
        {
            if (mouse == true)
            {
                if (dragon.X < PositionX)
                {
                    dragon.State = 2;
                    if (dragon.X < PositionX - 48)
                    {
                        dragon.X = dragon.X + 50;
                    }
                    else
                    {
                        if (dragon.Y < PositionY)
                        {
                            dragon.State = 0;
                            if (dragon.Y < PositionY - 48)
                            {
                                dragon.Y = dragon.Y + 50;
                            }
                            else
                            {
                                timer1.Stop();
                            }
                        }
                        else
                        {
                            if (dragon.Y > PositionY)
                            {
                                if (dragon.Y > PositionY - 48)
                                {
                                    dragon.State = 3;
                                    dragon.Y = dragon.Y - 50;
                                }
                                else
                                {
                                    timer1.Stop();
                                }
                            }
                        }
                    }
                }
                if (dragon.X > PositionX)
                {
                    dragon.State = 1;
                    if (dragon.X > PositionX - 48)
                    {
                        dragon.X = dragon.X -50;
                    }
                    else
                    {
                        if (dragon.Y < PositionY)
                        {
                            dragon.State = 0;
                            if (dragon.Y < PositionY - 48)
                            {
                                dragon.Y = dragon.Y + 50;
                            }
                            else
                            {
                                timer1.Stop();
                            }
                        }
                        else
                        {
                            dragon.State = 3;
                            if (dragon.Y > PositionY - 48)
                            {
                                dragon.Y = dragon.Y - 50;
                            }
                            else
                            {
                                timer1.Stop();
                            }
                        }
                    }
                }
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            boom.Next();
            Graphics buffGraphics = Graphics.FromImage(buffer);
            buffGraphics.Clear(Color.White);

            boom.DrawSprite(buffGraphics, boom.X, boom.Y);


            this.CreateGraphics().DrawImage(buffer, 0, 0);

            if (boom.Step == 4)
            {
                timer2.Stop();
                this.CreateGraphics().Clear(Color.White);
            }
        }
    }
}
    


    

