using System;
using System.Collections.Generic;
using System.Linq;

class Grafo
{
    Dictionary<string, List<string>> adyacencia = new();

    public void AgregarNodo(string nodo)
    {
        if (!adyacencia.ContainsKey(nodo))
            adyacencia[nodo] = new List<string>();
    }

    public void AgregarArista(string origen, string destino)
    {
        AgregarNodo(origen);
        AgregarNodo(destino);
        adyacencia[origen].Add(destino);
        adyacencia[destino].Add(origen);
    }

    public void CalcularMetricas()
    {
        Console.WriteLine("Centralidad de Grado:");
        foreach (var nodo in adyacencia.Keys)
        {
            Console.WriteLine($"  {nodo}: {adyacencia[nodo].Count}");
        }

        Console.WriteLine("\nCentralidad de Cercanía:");
        foreach (var nodo in adyacencia.Keys)
        {
            var sumaDistancias = SumaDistancias(nodo);
            double cercania = sumaDistancias > 0 ? 1.0 / sumaDistancias : 0;
            Console.WriteLine($"  {nodo}: {cercania:F2}");
        }

        Console.WriteLine("\nCentralidad de Intermediación:");
        var betweenness = new Dictionary<string, double>();
        foreach (var n in adyacencia.Keys) betweenness[n] = 0.0;

        var nodos = adyacencia.Keys.ToList();

        for (int i = 0; i < nodos.Count; i++)
        {
            for (int j = 0; j < nodos.Count; j++)
            {
                if (i == j) continue;
                var caminos = EncontrarCaminosCortos(nodos[i], nodos[j]);

                foreach (var camino in caminos)
                {
                    foreach (var n in camino.Skip(1).Take(camino.Count - 2))
                    {
                        betweenness[n] += 1.0 / caminos.Count;
                    }
                }
            }
        }

        foreach (var nodo in betweenness.Keys)
        {
            Console.WriteLine($"  {nodo}: {betweenness[nodo]:F2}");
        }
    }

    private int SumaDistancias(string inicio)
    {
        var visitado = new HashSet<string>();
        var distancia = new Dictionary<string, int>();
        var cola = new Queue<string>();

        cola.Enqueue(inicio);
        distancia[inicio] = 0;
        visitado.Add(inicio);

        while (cola.Count > 0)
        {
            var actual = cola.Dequeue();
            foreach (var vecino in adyacencia[actual])
            {
                if (!visitado.Contains(vecino))
                {
                    distancia[vecino] = distancia[actual] + 1;
                    cola.Enqueue(vecino);
                    visitado.Add(vecino);
                }
            }
        }

        return distancia.Values.Sum();
    }

    private List<List<string>> EncontrarCaminosCortos(string inicio, string fin)
    {
        var resultado = new List<List<string>>();
        var cola = new Queue<List<string>>();
        cola.Enqueue(new List<string> { inicio });

        var visitado = new HashSet<string>();

        int minLongitud = int.MaxValue;

        while (cola.Count > 0)
        {
            var camino = cola.Dequeue();
            var ultimo = camino.Last();

            if (camino.Count > minLongitud) continue;

            if (ultimo == fin)
            {
                if (camino.Count < minLongitud)
                {
                    resultado.Clear();
                    minLongitud = camino.Count;
                }
                resultado.Add(new List<string>(camino));
                continue;
            }

            foreach (var vecino in adyacencia[ultimo])
            {
                if (!camino.Contains(vecino))
                {
                    var nuevoCamino = new List<string>(camino) { vecino };
                    cola.Enqueue(nuevoCamino);
                }
            }
        }

        return resultado;
    }
}

class Programa
{
    static void Main()
    {
        Grafo grafo = new();
        grafo.AgregarArista("A", "B");
        grafo.AgregarArista("A", "D");
        grafo.AgregarArista("B", "C");
        grafo.AgregarArista("B", "E");
        grafo.AgregarArista("D", "E");

        grafo.CalcularMetricas();
    }
}
