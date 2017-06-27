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
            y1 = y1 + x;
            y2 = y2 + x;
        }

        public Racket(int x, int y, int z, int f, Color cl)
        {
            x1 = x;
            x2 = z;
            y1 = y;
            y2 = f;
            color = cl;
        }

        public bool CheckPoint(GameField gm)
        {
            if (y1 < gm.y1 || y2 > gm.y2)
            {
                return false;
            }else{
                return true;
            }
        }

    }
}
