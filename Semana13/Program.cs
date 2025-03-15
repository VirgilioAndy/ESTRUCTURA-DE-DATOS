using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> catalogo = new List<string>();

        // Permitir que el usuario ingrese los títulos de las revistas
        Console.WriteLine("Ingrese 10 títulos de revistas:");

        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Revista {i + 1}: ");
            string titulo = Console.ReadLine();
            catalogo.Add(titulo);
        }

        while (true)
        {
            Console.WriteLine("\n📚 MENÚ 📚");
            Console.WriteLine("1. Buscar un título (Iterativo)");
            Console.WriteLine("2. Buscar un título (Recursivo)");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "3") break;

            Console.Write("\nIngrese el título a buscar: ");
            string tituloBuscado = Console.ReadLine();

            bool encontrado = false;

            if (opcion == "1")
            {
                encontrado = BusquedaIterativa(catalogo, tituloBuscado);
            }
            else if (opcion == "2")
            {
                encontrado = BusquedaRecursiva(catalogo, tituloBuscado, 0);
            }
            else
            {
                Console.WriteLine("❌ Opción no válida.");
                continue;
            }

            Console.WriteLine(encontrado ? "✅ Encontrado" : "❌ No encontrado");
        }
    }

    static bool BusquedaIterativa(List<string> lista, string titulo)
    {
        foreach (string revista in lista)
        {
            if (revista.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    static bool BusquedaRecursiva(List<string> lista, string titulo, int indice)
    {
        if (indice >= lista.Count) return false;
        if (lista[indice].Equals(titulo, StringComparison.OrdinalIgnoreCase)) return true;
        return BusquedaRecursiva(lista, titulo, indice + 1);
    }
}
