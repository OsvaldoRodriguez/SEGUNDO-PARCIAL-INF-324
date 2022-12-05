using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGUNDO_PARCIAL_OFICIAL
{
    class PuntoColor
    {
        public int x, y;
        public double mediaR, mediaG, mediaB;

        public string concat()
        {
            string aux = "";
            aux += x.ToString() + " ";
            aux += y.ToString() + " ";
            aux += mediaR.ToString() + " ";
            aux += mediaG.ToString() + " ";
            aux += mediaB.ToString() + " ";
            //aux += x.ToString() + " ";

            return aux;
        }
    }
}
