using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine_CSharp_UFV
{
    internal class PremioSimple : Premio
    {
        // PROPIEDAD UNICA PREMIO SIMPLE
        public string Consejo { get; set; }

        // CONSTRUCTOR PREMIO SIMPLE
        public PremioSimple(string nombre, int simbolo1, int simbolo2, int simbolo3, string consejo)
            : base(nombre, simbolo1, simbolo2, simbolo3)
        {
            Consejo = consejo;
        }

        // METODO OVERRIDE MUESTRA CONSEJO (sobrescribe al metodo abstracto de la clase padre premio)
        public override void MostrarConsejo()
        {
            Console.WriteLine($" ¡Felicidades! Has ganado un {Nombre} y un Consejo: {Consejo}");
        }
    }
}
