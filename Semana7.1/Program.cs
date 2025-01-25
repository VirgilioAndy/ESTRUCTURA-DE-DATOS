using System;
using System.Collections.Generic;

class VerificacionParentesis
{
    // Método principal que inicia el programa
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la fórmula matemática para verificar si está balanceada:");
        string formula = Console.ReadLine();

        bool estaBalanceada = VerificarBalanceo(formula);

        if (estaBalanceada)
        {
            Console.WriteLine("La fórmula está balanceada.");
        }
        else
        {
            Console.WriteLine("La fórmula no está balanceada.");
        }
    }

    /// <summary>
    /// Verifica si una cadena de fórmula matemática tiene paréntesis balanceados.
    /// </summary>
    /// <param name="formula">La fórmula matemática a evaluar.</param>
    /// <returns>Verdadero si los paréntesis están balanceados, falso de lo contrario.</returns>
    static bool VerificarBalanceo(string formula)
    {
        // Pila para rastrear los paréntesis abiertos
        Stack<char> pila = new Stack<char>();

        // Diccionario para mapear los paréntesis de cierre con su correspondiente apertura
        Dictionary<char, char> pares = new Dictionary<char, char>
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

        foreach (char caracter in formula)
        {
            // Si el carácter es un paréntesis de apertura, lo agregamos a la pila
            if (caracter == '(' || caracter == '[' || caracter == '{')
            {
                pila.Push(caracter);
            }
            // Si el carácter es un paréntesis de cierre
            else if (caracter == ')' || caracter == ']' || caracter == '}')
            {
                // Verificamos si la pila está vacía (significa que falta un paréntesis de apertura)
                if (pila.Count == 0)
                {
                    return false;
                }

                // Sacamos el último paréntesis de la pila
                char ultimoAbierto = pila.Pop();

                // Verificamos si el paréntesis de cierre coincide con el de apertura
                if (pares[caracter] != ultimoAbierto)
                {
                    return false;
                }
            }
        }

        // Si al final la pila está vacía, los paréntesis están balanceados
        return pila.Count == 0;
    }
}
