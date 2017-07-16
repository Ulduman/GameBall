using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameObjects;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        Graphics formCanva;
        Ball ball;
        Racket racket1, racket2;
        GameField gf;
        Random rnd = new Random();
        double stepx = 5;

        public Form1()
        {
            InitializeComponent();
            formCanva = this.CreateGraphics();
            gf = new GameField((double)(this.Width / 2 - 150), (double)(this.Height / 2 - 100), (double)(this.Width / 2 + 150), (double)(this.Height / 2 + 100));
            racket1 = new Racket((double)gf.x1, (double)(this.Height / 2 - 15), (double)(gf.x1 + 5), (double)(this.Height / 2 + 15));
            racket2 = new Racket((double)(gf.x2 - 5), (double)(this.Height / 2 - 15), (double)(gf.x2), (double)(this.Height / 2 + 15));

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            formCanva.Clear(this.BackColor);
            gf.Draw(ref formCanva);
            ball.Check(gf.y1, gf.y2);
            ball.Move(stepx);
            ball.Draw(ref formCanva);
            racket1.Draw(ref formCanva);
            racket2.Draw(ref formCanva);
            racket1.CheckPoint(ref ball, ref stepx);
            racket2.CheckPoint(ref ball, ref stepx);

            if (gf.x2 < ball.x2 || gf.x1 > ball.x1)
            {
                timer1.Stop();
                if(gf.x2 < ball.x2)
                {
                    label2.Text = Int32.Parse(label2.Text) + 1 + "";
                }else if(gf.x1 > ball.x1)
                {
                    label1.Text = Int32.Parse(label1.Text) + 1 + "";
                }

            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 'w')
            {

                if (racket1.y1 > gf.y1)
                {
                    racket1.Move(-5);
                    
                }

            } else if (e.KeyChar == 's')
            {
                if (racket1.y2 < gf.y2)
                {
                    racket1.Move(5);
                    
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        { 
            if (e.Y >= gf.y1 && e.Y+ racket2.dy <= gf.y2)
            {
                racket2.y1 = e.Y;
                racket2.y2 = e.Y + racket2.dy;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ball = new Ball((double)(this.Width / 2 - 5), (double)(this.Height / 2 - 5), (double)(this.Width / 2 + 5), (double)(this.Height / 2 + 5));
            ball.Trace(ball.x1, ball.y1, rnd.Next(0, this.Width), rnd.Next(0, this.Height));

            while (ball.a == 0)
            {
                ball.Trace(ball.x1, ball.y1, rnd.Next(0, this.Width), rnd.Next(0, this.Height));
            }

            gf.Draw(ref formCanva);
            ball.Draw(ref formCanva);
            racket1.Draw(ref formCanva);
            racket2.Draw(ref formCanva);
            timer1.Start();
        }



 
    }
}
