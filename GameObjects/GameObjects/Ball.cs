using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameObjects
{
    public class Ball : Figure
    {
        public double a, c;
        public void Trace(double x, double y, double z, double f)
        {
            double b;
            b = z - x;
            a = -(y - f)/b;
            c=-(x*f-z*y)/b;
        }
        public void Move(double x)
        {
            x1 = x + x1;
            x2 = x1 + dx;
            y1 = a * x1 + c;
            y2 = y1+dy;
        }

        public Ball(double x, double y, double z, double f){

            x1 = x;
            y1 = y;
            x2 = z;
            y2 = f;
            dy = y2 - y1;
            dx = x2 - x1;

    }

        public void Draw(ref Graphics formCanva)
        {
            formCanva.FillEllipse(Brushes.Black, (float) x1,(float) y1,(float) (dx),(float) (dy));
        }

        public void Check(double y, double f)
        {
            if (y1<=y || y2>=f)
            {
                double k = (y1 + a * x1);
                Trace(x1, y1, 0, k);
            }
        }
    }
}
