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
        Racket racket;
        GameField gf;
        Random rnd = new Random();
        double stepx=1;
        
        public Form1()
        {
            InitializeComponent();
            formCanva = this.CreateGraphics();
            ball = new Ball((double) (this.Width/2-5), (double) (this.Height/2 -5), (double) (this.Width/2 +5), (double) (this.Height/2 +5));
            gf = new GameField((double) (this.Width / 2 - 150), (double)(this.Height / 2 - 100), (double)(this.Width / 2 + 150), (double)(this.Height / 2 + 100));
            ball.Trace(ball.x1, ball.y1, rnd.Next(0, this.Width), rnd.Next(0, this.Height));
            while (ball.a == 0)
            {
                ball.Trace(ball.x1, ball.y1, rnd.Next(0, this.Width), rnd.Next(0, this.Height));
            }
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            formCanva.Clear(this.BackColor);
            gf.Draw(ref formCanva);
            ball.Check(gf.y1, gf.y2);
            ball.Move(stepx);
            ball.Draw(ref formCanva);
            if (gf.x2 <= ball.x2 || gf.x1>=ball.x1)
            {
                double k = (ball.y1 + ball.a * ball.x1);
                ball.Trace(ball.x1, ball.y1, 0, k);
                stepx = -stepx;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            gf.Draw(ref formCanva);
            ball.Draw(ref formCanva);
            timer1.Start();

        }

        
    }
}
