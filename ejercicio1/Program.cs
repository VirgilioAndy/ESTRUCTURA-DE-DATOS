using System;

class Nodo
{
    public int Valor { get; set; }
    public Nodo Siguiente { get; set; }

    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

class ListaEnlazada
{
    private Nodo cabeza;

    public ListaEnlazada()
    {
        cabeza = null;
    }

    // Agregar nodo al final de la lista
    public void Agregar(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
        }
        else
        {
            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
    }

    // Buscar cuántas veces aparece un valor
    public int Buscar(int valor)
    {
        int contador = 0;
        Nodo actual = cabeza;

        while (actual != null)
        {
            if (actual.Valor == valor)
            {
                contador++;
            }
            actual = actual.Siguiente;
        }

        if (contador == 0)
        {
            Console.WriteLine($"El dato {valor} no fue encontrado.");
        }
        else
        {
            Console.WriteLine($"El dato {valor} se encontró {contador} veces.");
        }

        return contador;
    }

    // Mostrar la lista
    public void Mostrar()
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.Valor + " ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaEnlazada lista = new ListaEnlazada();

        // Agregar algunos valores a la lista
        lista.Agregar(5);
        lista.Agregar(8);
        lista.Agregar(5);
        lista.Agregar(12);

        Console.WriteLine("Lista actual:");
        lista.Mostrar();

        // Buscar un valor en la lista
        Console.Write("Ingrese un valor a buscar: ");
        int valorBuscado = int.Parse(Console.ReadLine());
        lista.Buscar(valorBuscado);
    }
}
