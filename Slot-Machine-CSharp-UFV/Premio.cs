using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine_CSharp_UFV
{
    internal class Premio
    {
        // Propiedades comunes a todos los premios
        public string Nombre { get; set; }
        public int Simbolo1 { get; set; }
        public int Simbolo2 { get; set; }
        public int Simbolo3 { get; set; }

        // Constructor
        public Premio(string nombre, int simbolo1, int simbolo2, int simbolo3)
        {
            Nombre = nombre;
            Simbolo1 = simbolo1;
            Simbolo2 = simbolo2;
            Simbolo3 = simbolo3;
        }
    }
}
