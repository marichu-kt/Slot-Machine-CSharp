using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine_CSharp_UFV
{
    internal class SlotMachine
    {
        private List<Premio> premios = new List<Premio>();
        private const string claveAdmin = "admin123";
        private List<string> frasesMotivacionales = new List<string>
        {
            " ¡GIRA Y GANA UNA VIDA MEJOR!",
            " ¡TRIPLE 7 = SALUD, FELICIDAD Y LIBERTAD!",
            " ¡CONSIGUE EL BONO DE UNA VIDA MEJOR!",
            " ¡EL JACKPOT ESTA CERCA!",
            " ¡LA SLOT MACHINE ESTA CALIENTE!"
        };        public void MenuPrincipal()
            
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
            try
            {
                int[,] rodillos = new int[3, 3];
                Random rand = new Random();

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        rodillos[i, j] = rand.Next(0, 10);
                    }
                }

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(" ▄▀▄▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▄▀▄");
                Console.WriteLine(" █ █      C L E O P A T R A     █ █");
                Console.WriteLine(" ▀▄▀▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▀▄▀");
                Console.WriteLine("    ╔════════╦════════╦════════╗");

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write($"    ║   {rodillos[i, j]}");
                    }
                    Console.WriteLine("    ║");

                    if (i < 2)
                    {
                        Console.WriteLine("    ╠════════╬════════╬════════╣");
                    }
                    else
                    {
                        Console.WriteLine("    ╚════════╩════════╩════════╝");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("  ╔═══════════════════════╗");
                Console.WriteLine("  ║   1. Jugar de nuevo   ║");
                Console.WriteLine("  ║   2. Salir            ║");
                Console.WriteLine("  ╚═══════════════════════╝");
                Console.WriteLine();
                Console.Write(" Elige una opción: ");
                int opcion = int.Parse(Console.ReadLine()); 

                if (opcion == 1)
                {
                    Jugar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Se produjo un error durante el juego: {ex.Message}");
            }
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
