using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine_CSharp_UFV
{
    internal class SlotMachine
    {
        // LISTA PREMIOS CARGADOS
        private List<Premio> premios = new List<Premio>();

        // CLAVE VALIDAR ADMIN
        private const string claveAdmin = "a";

        // LISTA FRASES MOTIVACIONALES
        private List<string> frasesMotivacionales = new List<string>
        {
            " ¡GIRA Y GANA UNA VIDA MEJOR!",
            " ¡TRIPLE 7 = SALUD, FELICIDAD Y LIBERTAD!",
            " ¡CONSIGUE EL BONO DE UNA VIDA MEJOR!",
            " ¡EL JACKPOT ESTA CERCA!",
            " ¡LA SLOT MACHINE ESTA CALIENTE!"
        };
        
        // MENU DE INICIO
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
                catch (Exception ex) // CAPTURAMOS EXCEPCIONES
                {
                    Console.WriteLine($" Se produjo un error: {ex.Message}");
                }
            }
        }

        private void Jugar()
        {
            try
            {
                int[,] rodillos = new int[3, 3]; // GENERAMOS MATRIZ (3 filas, 3 columnas)
                Random rand = new Random();      // CON NUMEROS ALEATORIOS

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        rodillos[i, j] = rand.Next(0, 10); // RANGO DE NUMEROS (0-9)
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
                    Console.WriteLine("    ║"); // CAMBIAR RENGLON

                    if (i < 2) // CUANDO HAY MENOS DE DOS FILAS
                    {
                        Console.WriteLine("    ╠════════╬════════╬════════╣");
                    }
                    else // CUANDO ACABAN LAS 3 FILAS
                    {
                        Console.WriteLine("    ╚════════╩════════╩════════╝");
                    }
                }

                VerificarLineaGanadora(rodillos); // VERIFICAMOS SI LA LÍNEA ES CORRECTA

                Console.WriteLine();
                Console.WriteLine("    ╔═══════════════════════╗");
                Console.WriteLine("    ║   1. Jugar de nuevo   ║");
                Console.WriteLine("    ║   2. Salir            ║");
                Console.WriteLine("    ╚═══════════════════════╝");
                Console.WriteLine();
                Console.Write("    Elige una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                if (opcion == 1)
                {
                    Jugar();
                }
            }
            catch (Exception ex) // CAPTURAMOS EXCEPCIONES
            {
                Console.WriteLine($"    Se produjo un error durante el juego: {ex.Message}");
            }
        }

        
        private void VerificarLineaGanadora(int[,] rodillos)
        {
            Random rnd = new Random(); // CREAMOS LA INSTANCIA RANDOM 

            int filaCentral = 1;
            int primerNumero = rodillos[filaCentral, 0];
            bool tresIguales = true;

            for (int j = 1; j < 3; j++)
            {
                if (rodillos[filaCentral, j] != primerNumero)
                {
                    tresIguales = false;
                    break;
                }
            }

            if (tresIguales)
            {
                Console.WriteLine();
                Console.WriteLine("  ╔══════════════════════════════╗");
                Console.WriteLine("  ║  ¡Felicidades! ¡Has ganado!  ║");
                Console.WriteLine("  ╚══════════════════════════════╝");
                Console.WriteLine($"  {frasesMotivacionales[rnd.Next(frasesMotivacionales.Count)]}");

                // CONSEJOS
                Premio premioGanado = ObtenerPremioGanado(primerNumero);
                if (premioGanado != null)
                {
                    if (premioGanado is PremioSimple)
                    {
                        PremioSimple premioSimple = (PremioSimple)premioGanado;
                        Console.WriteLine();
                        Console.WriteLine($"   Consejo: {premioSimple.Consejo}");
                    }
                    else if (premioGanado is PremioAleatorio)
                    {
                        PremioAleatorio premioAleatorio = (PremioAleatorio)premioGanado;
                        double randomValue = rnd.NextDouble();
                        if (randomValue <= premioAleatorio.ProbabilidadConsejo1)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"   Consejo: {premioAleatorio.Consejo1}");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine($"   Consejo: {premioAleatorio.Consejo2}");
                        }
                    }
                }
                return;
            }

            Console.WriteLine();
            Console.WriteLine("  ╔═══════════════════════════════════════╗");
            Console.WriteLine("  ║  ¡Inténtalo de nuevo! ¡Ya casi está!  ║");
            Console.WriteLine("  ╚═══════════════════════════════════════╝");
        }

















        private void MostrarPremios()
        {

        }

        private void CargarPremios()
        {

        }









        // COMPROBAMOS SI LA CONTRASEÑA ESCRITA COINCIDE CON LA CLAVE ADMIN
        private bool ValidarAdmin()
        {
            try
            {
                Console.Write(" Introduce la clave de administrador: ");
                string clave = Console.ReadLine();
                return clave == claveAdmin;
            }
            catch (Exception ex) // CAPTURAMOS EXCEPCIONES
            {
                Console.WriteLine($" Error al validar la contraseña: {ex.Message}");
                return false;
            }
        }
    }
}

