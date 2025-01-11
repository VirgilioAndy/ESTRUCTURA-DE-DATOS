using System;
using System.Collections.Generic;
using System.Linq;

public class Contacto
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Direccion { get; set; }
    public string Correo { get; set; }

    public Contacto(string nombre, string telefono, string direccion, string correo)
    {
        Nombre = nombre;
        Telefono = telefono;
        Direccion = direccion;
        Correo = correo;
    }

    public override string ToString()
    {
        return $"Nombre: {Nombre}, Teléfono: {Telefono}, Dirección: {Direccion}, Correo: {Correo}";
    }
}

public class AgendaTelefonica
{
    private List<Contacto> contactos;

    public AgendaTelefonica()
    {
        contactos = new List<Contacto>();
    }

    public void AgregarContacto(Contacto contacto)
    {
        contactos.Add(contacto);
        Console.WriteLine($"Contacto agregado: {contacto.Nombre}");
    }

    public void MostrarContactos()
    {
        if (!contactos.Any())
        {
            Console.WriteLine("La agenda está vacía.");
        }
        else
        {
            Console.WriteLine("Contactos en la agenda:");
            foreach (var contacto in contactos)
            {
                Console.WriteLine(contacto);
            }
        }
    }

    public void BuscarContacto(string nombre)
    {
        var resultados = contactos.Where(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)).ToList();
        if (resultados.Any())
        {
            Console.WriteLine("Resultado de la búsqueda:");
            foreach (var contacto in resultados)
            {
                Console.WriteLine(contacto);
            }
        }
        else
        {
            Console.WriteLine("No se encontró ningún contacto con ese nombre.");
        }
    }

    public void EliminarContacto(string nombre)
    {
        int contactosInicial = contactos.Count;
        contactos = contactos.Where(c => !c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)).ToList();

        if (contactos.Count < contactosInicial)
        {
            Console.WriteLine($"Contacto '{nombre}' eliminado.");
        }
        else
        {
            Console.WriteLine($"No se encontró ningún contacto con el nombre '{nombre}'.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var agenda = new AgendaTelefonica();
        while (true)
        {
            Console.WriteLine("\n--- Menú de Agenda Telefónica ---");
            Console.WriteLine("1. Agregar contacto");
            Console.WriteLine("2. Mostrar contactos");
            Console.WriteLine("3. Buscar contacto");
            Console.WriteLine("4. Eliminar contacto");
            Console.WriteLine("5. Salir");

            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese el teléfono: ");
                    string telefono = Console.ReadLine();
                    Console.Write("Ingrese la dirección: ");
                    string direccion = Console.ReadLine();
                    Console.Write("Ingrese el correo: ");
                    string correo = Console.ReadLine();

                    var nuevoContacto = new Contacto(nombre, telefono, direccion, correo);
                    agenda.AgregarContacto(nuevoContacto);
                    break;

                case "2":
                    agenda.MostrarContactos();
                    break;

                case "3":
                    Console.Write("Ingrese el nombre del contacto a buscar: ");
                    string nombreBuscar = Console.ReadLine();
                    agenda.BuscarContacto(nombreBuscar);
                    break;

                case "4":
                    Console.Write("Ingrese el nombre del contacto a eliminar: ");
                    string nombreEliminar = Console.ReadLine();
                    agenda.EliminarContacto(nombreEliminar);
                    break;

                case "5":
                    Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                    return;

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }
}
