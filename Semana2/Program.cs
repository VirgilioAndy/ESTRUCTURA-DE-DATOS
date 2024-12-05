// Clase que representa un círculo
public class Circulo
{
    // Campo privado que almacena el radio del círculo
    private double radio;

    // Constructor que inicializa el radio del círculo
    public Circulo(double radio)
    {
        this.radio = radio;
    }

    // Método para calcular el área del círculo
    public double CalcularArea()
    {
        // Fórmula del área del círculo: π * radio^2
        return Math.PI * Math.Pow(radio, 2);
    }

    // Método para calcular el perímetro del círculo
    public double CalcularPerimetro()
    {
        // Fórmula del perímetro del círculo: 2 * π * radio
        return 2 * Math.PI * radio;
    }
}

// Clase que representa un rectángulo
public class Rectangulo
{
    // Campos privados que almacenan la base y la altura del rectángulo
    private double baseRectangulo;
    private double altura;

    // Constructor que inicializa la base y la altura del rectángulo
    public Rectangulo(double baseRectangulo, double altura)
    {
        this.baseRectangulo = baseRectangulo;
        this.altura = altura;
    }

    // Método para calcular el área del rectángulo
    public double CalcularArea()
    {
        // Fórmula del área del rectángulo: base * altura
        return baseRectangulo * altura;
    }

    // Método para calcular el perímetro del rectángulo
    public double CalcularPerimetro()
    {
        // Fórmula del perímetro del rectángulo: 2 * (base + altura)
        return 2 * (baseRectangulo + altura);
    }
}

// Programa principal para probar las clases Circulo y Rectangulo
public class ProgramaPrincipal
{
    public static void Main(string[] args)
    {
        // Crear un círculo con un radio de 5 unidades
        Circulo circulo = new Circulo(5);
        Console.WriteLine("Área del círculo: " + circulo.CalcularArea());
        Console.WriteLine("Perímetro del círculo: " + circulo.CalcularPerimetro());

        // Crear un rectángulo con base 4 y altura 6 unidades
        Rectangulo rectangulo = new Rectangulo(4, 6);
        Console.WriteLine("Área del rectángulo: " + rectangulo.CalcularArea());
        Console.WriteLine("Perímetro del rectángulo: " + rectangulo.CalcularPerimetro());
    }
}