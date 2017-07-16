using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameObjects
{
    public class Racket : Figure
    {
        public void Move(int x)
        {
            this.y1 = this.y1 + x;
            this.y2 = this.y2 + x;
        }

        public Racket(double x, double y, double z, double f)
        {
            x1 = x;
            x2 = z;
            y1 = y;
            y2 = f;
            dx = x2 - x1;
            dy = y2 - y1;
        }

        public void CheckPoint(ref Ball ball, ref double stepx)
        {
            if (((ball.x1<=this.x2 && ball.x1>=this.x1) || (ball.x2 <= this.x2 && ball.x2 >= this.x1)) && ((ball.y1+ball.dy/2)>=this.y1 && (ball.y1 + ball.dy / 2) <= this.y2) )
            {
                stepx = -stepx;
                double k = (ball.y1 + ball.a * ball.x1);
                ball.Trace(ball.x1, ball.y1, 0, k);
            }
        }

        

        public void Draw(ref Graphics formCanva)
        {
            formCanva.FillRectangle(Brushes.Black, (float)x1, (float)y1, (float)(dx), (float)(dy));
        }

    }
}
