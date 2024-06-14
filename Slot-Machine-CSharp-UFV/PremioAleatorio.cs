using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine_CSharp_UFV
{
    internal class PremioAleatorio : Premio
    {
        // PROPIEDADES PREMIOS ALEATORIOS
        public string Consejo1 { get; set; }
        public string Consejo2 { get; set; }
        public double ProbabilidadConsejo1 { get; set; }

        // CONSTRUCTOR PREMIOS ALEATORIOS
        public PremioAleatorio(string nombre, int simbolo1, int simbolo2, int simbolo3, string consejo1, string consejo2, double probabilidadConsejo1)
            : base(nombre, simbolo1, simbolo2, simbolo3)
        {
            Consejo1 = consejo1;
            Consejo2 = consejo2;
            ProbabilidadConsejo1 = probabilidadConsejo1;
        }

        // METODO OVERRIDE MUESTRA CONSEJOS ALEATORIOS (sobrescribe al metodo abstracto de la clase padre premio)
        public override void MostrarConsejo()
        {
            // SEGÚN LA PROBABILIDAD SALE EL CONSEJO
            Random rand = new Random();
            double randomConsejo = rand.NextDouble();
            if (randomConsejo <= ProbabilidadConsejo1)
            {
                Console.WriteLine($" ¡Felicidades! Has ganado un {Nombre} y un Consejo: {Consejo1}");
            }
            else
            {
                Console.WriteLine($" ¡Felicidades! Has ganado un {Nombre} y un Consejo: {Consejo2}");
            }
        }
    }
}
