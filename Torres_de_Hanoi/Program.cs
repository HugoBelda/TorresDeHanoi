using System;

namespace Torres_de_Hanoi
{
    public delegate void MostrarSituacionDelegate(Pila ini, Pila aux, Pila fin);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("El Gran Juego de las Torres de Hanoi");
            Console.WriteLine("3 torres");

            Console.WriteLine("Indica el número de discos...");
            int cantidadDiscos = int.Parse(Console.ReadLine());

            Pila ini = new Pila();
            Pila fin = new Pila();
            Pila aux = new Pila();

            for (int i = cantidadDiscos; i >= 1; i--)
            {
                Disco disco = new Disco { Valor = i };
                ini.push(disco);
            }

            Console.WriteLine("Indica I para Iterativo o R para Recursivo...");
            string metodo = Console.ReadLine().ToUpper();


            Console.WriteLine("Situación inicial:");
            MostrarSituacion(ini, aux, fin);
            
            Hanoi hanoi = new Hanoi(MostrarSituacion);
            
            int movimientosRealizados = 0;
            
            if (metodo == "I")
            {
                movimientosRealizados = hanoi.iterativo(cantidadDiscos, ini, fin, aux);
            }
            else if (metodo == "R")
            {
                movimientosRealizados = hanoi.recursivo(cantidadDiscos, ini, fin, aux);
            }
            else
            {
                Console.WriteLine("Método no válido.");
                return;
            }
            

            Console.WriteLine("Situación final:");
            MostrarSituacion(ini, aux, fin);

            Console.WriteLine($"Resuelto en {movimientosRealizados} movimientos");

            Console.WriteLine("Presiona cualquier tecla para salir.");
            Console.ReadKey();
        }

        static void MostrarSituacion(Pila ini, Pila aux, Pila fin)
        {
            Console.WriteLine("Torre INI: " + ImprimirPila(ini));
            Console.WriteLine("Torre AUX: " + ImprimirPila(aux));
            Console.WriteLine("Torre FIN: " + ImprimirPila(fin));
        }

        static string ImprimirPila(Pila pila)
        {
            if (pila.isEmpty())
                return "";

            string result = "";
            foreach (var disco in pila.Elementos)
            {
                result += disco.Valor + ", ";
            }
            return result.TrimEnd(' ', ',');
        }
    }
}