using System;
using System.Collections.Generic;

class TorresDeHanoi
{
    // Método principal que inicia el programa
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese el número de discos:");
        int n = int.Parse(Console.ReadLine()); // Número de discos

        // Inicializamos las tres pilas que representan las torres
        Stack<int> torreOrigen = new Stack<int>();
        Stack<int> torreAuxiliar = new Stack<int>();
        Stack<int> torreDestino = new Stack<int>();

        // Llenamos la torre origen con los discos (del más grande al más pequeño)
        for (int i = n; i >= 1; i--)
        {
            torreOrigen.Push(i);
        }

        // Mostramos el estado inicial de las torres
        MostrarTorres(torreOrigen, torreAuxiliar, torreDestino);

        // Llamamos al método recursivo para resolver el problema
        ResolverTorresDeHanoi(n, torreOrigen, torreDestino, torreAuxiliar);

        Console.WriteLine("\n¡Problema resuelto! Torre destino:");
        MostrarTorre(torreDestino);
    }

    /// <summary>
    /// Resuelve el problema de las Torres de Hanoi de forma recursiva.
    /// </summary>
    /// <param name="n">Número de discos a mover.</param>
    /// <param name="origen">Torre origen de los discos.</param>
    /// <param name="destino">Torre destino de los discos.</param>
    /// <param name="auxiliar">Torre auxiliar para mover discos temporalmente.</param>
    static void ResolverTorresDeHanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar)
    {
        if (n == 1)
        {
            // Caso base: mover un disco directamente de origen a destino
            destino.Push(origen.Pop());
            MostrarTorres(origen, auxiliar, destino);
            return;
        }

        // Paso 1: Mover n-1 discos de origen a auxiliar usando destino como torre temporal
        ResolverTorresDeHanoi(n - 1, origen, auxiliar, destino);

        // Paso 2: Mover el disco más grande de origen a destino
        destino.Push(origen.Pop());
        MostrarTorres(origen, auxiliar, destino);

        // Paso 3: Mover los n-1 discos de auxiliar a destino usando origen como torre temporal
        ResolverTorresDeHanoi(n - 1, auxiliar, destino, origen);
    }

    /// <summary>
    /// Muestra el estado actual de las tres torres.
    /// </summary>
    /// <param name="origen">Torre origen.</param>
    /// <param name="auxiliar">Torre auxiliar.</param>
    /// <param name="destino">Torre destino.</param>
    static void MostrarTorres(Stack<int> origen, Stack<int> auxiliar, Stack<int> destino)
    {
        Console.WriteLine("\nEstado actual de las torres:");
        Console.WriteLine("Torre Origen: " + string.Join(", ", origen));
        Console.WriteLine("Torre Auxiliar: " + string.Join(", ", auxiliar));
        Console.WriteLine("Torre Destino: " + string.Join(", ", destino));
    }

    /// <summary>
    /// Muestra los discos en una torre específica.
    /// </summary>
    /// <param name="torre">La pila que representa la torre.</param>
    static void MostrarTorre(Stack<int> torre)
    {
        Console.WriteLine(string.Join(", ", torre));
    }
}
