using System;

class Nodo
{
    public int Dato;
    public Nodo Izquierdo, Derecho;
    
    public Nodo(int dato)
    {
        Dato = dato;
        Izquierdo = Derecho = null;
    }
}

class ArbolBinario
{
    private Nodo Raiz;

    public ArbolBinario()
    {
        Raiz = null;
    }

    public void Insertar(int dato)
    {
        Raiz = InsertarRec(Raiz, dato);
    }

    private Nodo InsertarRec(Nodo raiz, int dato)
    {
        if (raiz == null)
            return new Nodo(dato);

        if (dato < raiz.Dato)
            raiz.Izquierdo = InsertarRec(raiz.Izquierdo, dato);
        else if (dato > raiz.Dato)
            raiz.Derecho = InsertarRec(raiz.Derecho, dato);

        return raiz;
    }

    public void InOrden()
    {
        InOrdenRec(Raiz);
        Console.WriteLine();
    }

    private void InOrdenRec(Nodo raiz)
    {
        if (raiz != null)
        {
            InOrdenRec(raiz.Izquierdo);
            Console.Write(raiz.Dato + " ");
            InOrdenRec(raiz.Derecho);
        }
    }

    public void ImprimirArbol()
    {
        ImprimirArbolRec(Raiz, "", true);
    }

    private void ImprimirArbolRec(Nodo nodo, string indentacion, bool esDerecho)
    {
        if (nodo != null)
        {
            Console.WriteLine(indentacion + (esDerecho ? "└── " : "├── ") + nodo.Dato);
            ImprimirArbolRec(nodo.Izquierdo, indentacion + (esDerecho ? "    " : "│   "), false);
            ImprimirArbolRec(nodo.Derecho, indentacion + (esDerecho ? "    " : "│   "), true);
        }
    }
}

class Program
{
    static void Main()
    {
        ArbolBinario arbol = new ArbolBinario();
        int[] valores = { 10, 5, 15, 3, 7, 20 };
        
        foreach (int val in valores)
        {
            arbol.Insertar(val);
        }
        
        Console.WriteLine("Árbol binario:");
        arbol.ImprimirArbol();
    }
}
