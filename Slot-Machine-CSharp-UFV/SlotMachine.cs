using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine_CSharp_UFV
{
    internal class SlotMachine
    {
        private const string claveAdmin = "admin";
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
                            Jugar();
                            break;
                        case "2":
                            MostrarPremios();
                            break;
                        case "3":
                            if (ValidarAdmin())
                            {
                                CargarPremios();
                            }
                            else
                            {
                                Console.WriteLine(" Clave incorrecta.");
                            }
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






        private void Jugar()
        {

        }

        private void MostrarPremios()
        {

        }

        private void CargarPremios()
        {

        }










        
        
        private bool ValidarAdmin()
        {
            try
            {
                Console.Write(" Introduce la clave de administrador: ");
                string clave = Console.ReadLine();
                return clave == claveAdmin;
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Se produjo un error: {ex.Message}");
                return false;
            }
        }
    }
}
