using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameObjects
{
    public class Figure
    {
        public double x1, y1, x2, y2, dy, dx;
        

    }

    public struct GameField{
       public double x1, y1, x2, y2;
        public GameField (double x,double y,double z,double f)
        {
            x1 = x;
            y1 = y;
            x2 = z;
            y2 = f;
        }
        public void Draw(ref Graphics formCanva)
        {
            formCanva.DrawRectangle(Pens.Black, (float)x1, (float)y1, (float)(x2 - x1-1), (float)(y2 - y1));
        }

    }

}
