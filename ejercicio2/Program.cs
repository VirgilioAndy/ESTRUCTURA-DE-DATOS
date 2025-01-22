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

    // Eliminar nodos fuera de un rango
    public void EliminarPorRango(int min, int max)
    {
        while (cabeza != null && (cabeza.Valor < min || cabeza.Valor > max))
        {
            cabeza = cabeza.Siguiente;
        }

        Nodo actual = cabeza;
        while (actual != null && actual.Siguiente != null)
        {
            if (actual.Siguiente.Valor < min || actual.Siguiente.Valor > max)
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
            }
            else
            {
                actual = actual.Siguiente;
            }
        }
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
        Random random = new Random();

        // Generar 50 números aleatorios entre 1 y 999
        for (int i = 0; i < 50; i++)
        {
            lista.Agregar(random.Next(1, 1000));
        }

        Console.WriteLine("Lista inicial:");
        lista.Mostrar();

        // Pedir rango al usuario
        Console.Write("Ingrese el valor mínimo del rango: ");
        int min = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el valor máximo del rango: ");
        int max = int.Parse(Console.ReadLine());

        // Eliminar nodos fuera del rango
        lista.EliminarPorRango(min, max);
        Console.WriteLine("Lista después de eliminar nodos fuera del rango:");
        lista.Mostrar();
    }
}
