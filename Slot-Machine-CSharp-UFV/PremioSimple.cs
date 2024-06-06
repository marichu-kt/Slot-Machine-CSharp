using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine_CSharp_UFV
{
    internal class PremioSimple : Premio
    {
        public string Consejo { get; set; }

        public PremioSimple(string nombre, int simbolo1, int simbolo2, int simbolo3, string consejo)
            : base(nombre, simbolo1, simbolo2, simbolo3)
        {
            Consejo = consejo;
        }

        public override void MostrarConsejo()
        {
            Console.WriteLine($"¡Felicidades! Has ganado un {Nombre}. Consejo: {Consejo}");
        }
    }
}
