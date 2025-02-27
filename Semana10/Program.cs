using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Generar ciudadanos ficticios
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add($"Ciudadano {i}");
        }

        // Generar ciudadanos vacunados con Pfizer
        HashSet<string> vacunadosPfizer = new HashSet<string>();
        for (int i = 1; i <= 75; i++)
        {
            vacunadosPfizer.Add($"Ciudadano {i}");
        }

        // Generar ciudadanos vacunados con AstraZeneca
        HashSet<string> vacunadosAstraZeneca = new HashSet<string>();
        for (int i = 76; i <= 150; i++)
        {
            vacunadosAstraZeneca.Add($"Ciudadano {i}");
        }

        // Generar ciudadanos vacunados con ambas vacunas
        HashSet<string> vacunadosAmbas = new HashSet<string>();
        for (int i = 151; i <= 200; i++)
        {
            vacunadosAmbas.Add($"Ciudadano {i}");
        }

        // Listado de ciudadanos no vacunados
        HashSet<string> ciudadanosNoVacunados = new HashSet<string>(ciudadanos);
        ciudadanosNoVacunados.ExceptWith(vacunadosPfizer);
        ciudadanosNoVacunados.ExceptWith(vacunadosAstraZeneca);
        ciudadanosNoVacunados.ExceptWith(vacunadosAmbas);
        
        // Listado de ciudadanos con ambas vacunas
        HashSet<string> ciudadanosConDosVacunas = new HashSet<string>(vacunadosAmbas);
        
        // Listado de ciudadanos que solo han recibido Pfizer
        HashSet<string> ciudadanosSoloPfizer = new HashSet<string>(vacunadosPfizer);
        ciudadanosSoloPfizer.ExceptWith(vacunadosAmbas);
        
        // Listado de ciudadanos que solo han recibido AstraZeneca
        HashSet<string> ciudadanosSoloAstraZeneca = new HashSet<string>(vacunadosAstraZeneca);
        ciudadanosSoloAstraZeneca.ExceptWith(vacunadosAmbas);
        
        // Imprimir resultados
        ImprimirListado("Ciudadanos no vacunados", ciudadanosNoVacunados);
        ImprimirListado("Ciudadanos con dos vacunas", ciudadanosConDosVacunas);
        ImprimirListado("Ciudadanos solo con Pfizer", ciudadanosSoloPfizer);
        ImprimirListado("Ciudadanos solo con AstraZeneca", ciudadanosSoloAstraZeneca);
    }

    static void ImprimirListado(string titulo, HashSet<string> lista)
    {
        Console.WriteLine($"\n{titulo} ({lista.Count}):");
        foreach (var ciudadano in lista)
        {
            Console.WriteLine(ciudadano);
        }
    }
}
