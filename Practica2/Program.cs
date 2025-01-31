using System;
using System.Collections.Generic;

class AtraccionParque
{
    private Queue<string> colaEspera = new Queue<string>();
    private int capacidad = 30;

    public void AgregarPersona(string nombre)
    {
        if (colaEspera.Count < capacidad)
        {
            colaEspera.Enqueue(nombre);
            Console.WriteLine($"{nombre} ha sido agregado a la cola.");
        }
        else
        {
            Console.WriteLine("No hay asientos disponibles.");
        }
    }

    public void AsignarAsientos()
    {
        Console.WriteLine("Asignando asientos:");
        while (colaEspera.Count > 0)
        {
            Console.WriteLine($"{colaEspera.Dequeue()} ha tomado un asiento.");
        }
    }
}

class Program
{
    static void Main()
    {
        AtraccionParque atraccion = new AtraccionParque();
        atraccion.AgregarPersona("Persona 1");
        atraccion.AgregarPersona("Persona 2");
        atraccion.AgregarPersona("Persona 3");
        
        atraccion.AsignarAsientos();
    }
}