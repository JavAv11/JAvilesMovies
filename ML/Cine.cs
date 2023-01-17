using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Cine
    {
        public int IdCine { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Venta { get; set; }

        public ML.Zona Zona { get; set; }

        public List<object>Cines { get; set; }


        public double TotalSum { get; set; }
        public double VentaN { get; set; }
        public double VentaS { get; set; }
        public double VentaE { get; set; }
        public double VentaO { get; set; }
    }
}
