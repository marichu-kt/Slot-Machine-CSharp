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


        // METODO JUGAR
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


        // COMPROBAMOS SI LA LÍNEA ES GANADORA
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

            if (tresIguales) // SOLO SI LOS 3 NUMEROS DE LA FILA CENTRAL SON IGUALES
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


        // BUSCAR PREMIO CORRESPONDIENTE A LA LINEA GANADORA
        private Premio ObtenerPremioGanado(int numeroGanador)
        {
            // BUSCAR EN LA LISTA PREMIOS LOS SIMBOLOS CORRESPONDIENTES
            foreach (var premio in premios)
            {
                if (premio.Simbolo1 == numeroGanador && premio.Simbolo2 == numeroGanador && premio.Simbolo3 == numeroGanador)
                {
                    return premio;
                }
            }
            return null;
        }


        // MOSTRAMOS LOS PREMIOS DE LA LISTA PREMIOS (previamente cargados desde el CSV)
        private void MostrarPremios()
        {
            Console.WriteLine();
            Console.WriteLine(" Premios disponibles:");
            foreach (var premio in premios)
            {
                Console.WriteLine($" - {premio.Nombre} (Símbolos: {premio.Simbolo1}, {premio.Simbolo2}, {premio.Simbolo3})");
            }
            Console.WriteLine(" Presiona cualquier tecla para volver al menú.");
            Console.ReadKey();
        }


        // CARGAR PREMIOS
        private void CargarPremios()
        {
            try
            {
                Console.Write(" Introduce la ruta del archivo CSV: ");
                string rutaArchivo = Console.ReadLine();

                if (File.Exists(rutaArchivo))
                {
                    string[] lineas = File.ReadAllLines(rutaArchivo); 
                    List<Premio> nuevosPremios = new List<Premio>(); // LISTA NUEVOS PREMIOS CARGADOS

                    foreach (string linea in lineas)
                    {
                        try
                        {
                            string[] campos = linea.Split(';');        // SEPARADOR (;)

                            int tipoPremio = int.Parse(campos[0]);     // CAMPO 0 = TIPO PREMIO (1 Simplre / 2 Aleatorio)
                            string nombrePremio = campos[1];           // CAMPO 1 = NOMBRE PREMIO
                            int simbolo1 = int.Parse(campos[2]);       // SIMBOLO 1 (primer numero de la matriz central)
                            int simbolo2 = int.Parse(campos[3]);       // SIMBOLO 2 (segundo numero de la matriz central)
                            int simbolo3 = int.Parse(campos[4]);       // SIMBOLO 3 (tercer numero de la matriz central)

                            if (tipoPremio == 1)                       // PREMIO SIMPLE
                            {
                                string consejo = campos[5];           // CONSEJO ÚNICO
                                PremioSimple premioSimple = new PremioSimple(nombrePremio, simbolo1, simbolo2, simbolo3, consejo);
                                nuevosPremios.Add(premioSimple);
                            }
                            else if (tipoPremio == 2)                  // PREMIO ALEATORIO 
                            {
                                string consejo1 = campos[5];           // CONSEJO ALEATORIO 1
                                string consejo2 = campos[6];           // CONSEJO ALEATORIO 2
                                double probabilidad = double.Parse(campos[7]); // PROBABILIDAD DEL CONSEJO ALEATORIO 1

                                PremioAleatorio premioAleatorio = new PremioAleatorio(nombrePremio, simbolo1, simbolo2, simbolo3, consejo1, consejo2, probabilidad);
                                nuevosPremios.Add(premioAleatorio);
                            }
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine($" Error al cargar los premios: {ex.Message}");
                        }
                    }

                    // REEMPLAZAR PREMIOS POR OTROS NUEVOS (desde la carga de archivos CSV)
                    premios = nuevosPremios;
                    Console.WriteLine(" Premios cargados correctamente.");
                }
                else
                {
                    Console.WriteLine(" El archivo no existe.");
                }
            }
            catch (Exception ex) // CAPTURAMOS EXCEPCIONES
            {
                Console.WriteLine($" Error al cargar los premios: {ex.Message}");
            }
            Console.WriteLine(" Presiona cualquier tecla para volver al menú.");
            Console.ReadKey();
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
