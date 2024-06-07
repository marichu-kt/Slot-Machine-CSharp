using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine_CSharp_UFV
{
    internal class SlotMachine
    {
        public void MenuPrincipal()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine(" ╔═════════════════════════════╗");
                    Console.WriteLine(" ║  1. Jugar                   ║");
                    Console.WriteLine(" ║  2. Mostrar premios         ║");
                    Console.WriteLine(" ║  3. Cargar premios (Admin)  ║");
                    Console.WriteLine(" ║  4. Salir                   ║");
                    Console.WriteLine(" ╚═════════════════════════════╝");
                    Console.WriteLine();
                    Console.Write(" Elige una opción: ");
                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            break;
                        case "2":
                            break;
                        case "3":
                            break;
                        case "4":
                            Console.WriteLine(" Saliendo del programa...");
                            return;
                        default:
                            Console.WriteLine(" Opción no válida.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Se produjo un error: {ex.Message}");
                }
            }
        }
    }
}
