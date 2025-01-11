using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Ejercicio 1
        Console.WriteLine("Ejercicio 1");
        List<string> subjects = new List<string>();
        Console.WriteLine("Lista vacía: " + string.Join(", ", subjects));
        subjects = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
        Console.WriteLine("Lista inicializada: " + string.Join(", ", subjects));

        // Ejercicio 2
        Console.WriteLine("\nEjercicio 2");
        foreach (var subject in subjects)
        {
            Console.WriteLine("Yo estudio " + subject);
        }

        // Ejercicio 3
        Console.WriteLine("\nEjercicio 3");
        List<string> scores = new List<string>();
        foreach (var subject in subjects)
        {
            string score;
            while (true)
            {
                Console.Write($"¿Qué nota has sacado en {subject}? ");
                score = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(score)) // Asegurar que no esté vacío
                {
                    scores.Add(score);
                    break;
                }
                Console.WriteLine("Por favor, introduce una nota válida.");
            }
        }
        for (int i = 0; i < subjects.Count; i++)
        {
            Console.WriteLine($"En {subjects[i]} has sacado {scores[i]}");
        }

        // Ejercicio 4
        Console.WriteLine("\nEjercicio 4");
        List<int> awarded = new List<int>();
        for (int i = 0; i < 6; i++)
        {
            while (true)
            {
                Console.Write("Introduce un número ganador: ");
                if (int.TryParse(Console.ReadLine(), out int number)) // Validar entrada numérica
                {
                    awarded.Add(number);
                    break;
                }
                Console.WriteLine("Por favor, introduce un número válido.");
            }
        }
        awarded.Sort();
        Console.WriteLine("Los números ganadores son: " + string.Join(", ", awarded));

        // Ejercicio 5
        Console.WriteLine("\nEjercicio 5");
        List<int> numbers = Enumerable.Range(1, 10).ToList();
        for (int i = numbers.Count - 1; i >= 0; i--)
        {
            Console.Write(numbers[i] + (i > 0 ? ", " : ""));
        }
        Console.WriteLine();
    }
}
