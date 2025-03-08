using System;
using System.Collections.Generic;

class Programa
{
    static void Main()
    {
        // Estructura de datos para almacenar equipos y jugadores
        Dictionary<string, List<string>> equipos = new Dictionary<string, List<string>>();
        int opcion;

        do
        {
            // Menú interactivo
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Registrar equipo y jugadores");
            Console.WriteLine("2. Mostrar todos los equipos");
            Console.WriteLine("3. Consultar jugadores de un equipo");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            // Validación de entrada
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Entrada inválida. Intente de nuevo.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    // Registrar equipo y jugadores
                    Console.Write("Ingrese el nombre del equipo: ");
                    string equipo = Console.ReadLine().Trim();

                    if (equipos.ContainsKey(equipo))
                    {
                        Console.WriteLine("El equipo ya está registrado.");
                        break;
                    }

                    List<string> jugadores = new List<string>();

                    Console.Write("Ingrese el número de jugadores: ");
                    if (!int.TryParse(Console.ReadLine(), out int numJugadores) || numJugadores <= 0)
                    {
                        Console.WriteLine("Número de jugadores inválido.");
                        break;
                    }

                    for (int i = 0; i < numJugadores; i++)
                    {
                        Console.Write($"Ingrese el nombre del jugador {i + 1}: ");
                        jugadores.Add(Console.ReadLine().Trim());
                    }

                    equipos[equipo] = jugadores;
                    Console.WriteLine("Equipo registrado exitosamente.");
                    break;

                case 2:
                    // Mostrar todos los equipos y jugadores
                    if (equipos.Count == 0)
                    {
                        Console.WriteLine("No hay equipos registrados.");
                    }
                    else
                    {
                        Console.WriteLine("\nEquipos registrados:");
                        foreach (var item in equipos)
                        {
                            Console.WriteLine($"Equipo: {item.Key}, Jugadores: {string.Join(", ", item.Value)}");
                        }
                    }
                    break;

                case 3:
                    // Consultar jugadores de un equipo específico
                    Console.Write("Ingrese el nombre del equipo para consultar: ");
                    string equipoConsulta = Console.ReadLine().Trim();

                    if (equipos.TryGetValue(equipoConsulta, out List<string> jugadoresEquipo))
                    {
                        Console.WriteLine($"Jugadores del equipo {equipoConsulta}: {string.Join(", ", jugadoresEquipo)}");
                    }
                    else
                    {
                        Console.WriteLine("El equipo no existe.");
                    }
                    break;

                case 4:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 4);
    }
}