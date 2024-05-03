using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Hanoi
    {
        private int movimientosRecursivo = 0;
        private readonly MostrarSituacionDelegate mostrarSituacion;

        public Hanoi(MostrarSituacionDelegate mostrarSituacionDelegate)
        {
            this.mostrarSituacion = mostrarSituacionDelegate;
        }

        public void mover_disco(Pila a, Pila b)
        {
            if (a.isEmpty())
            {
                a.push(b.pop());
            }
            else if (b.isEmpty())
            {
                b.push(a.pop());
            }
            else
            {
                Disco discoA = a.Elementos[a.Top - 1];
                Disco discoB = b.Elementos[b.Top - 1];

                if (discoA.Valor < discoB.Valor)
                {
                    b.push(a.pop());
                }
                else
                {
                    a.push(b.pop());
                }
            }
        }

        public int iterativo(int n, Pila ini, Pila fin, Pila aux)
        {
            int movimientos = 0;

            if (n % 2 != 0)
            {
                while (!IsSolved(ini, aux, fin, n))
                {
                    mover_disco(ini, fin);
                    movimientos++;
                    Console.WriteLine($"Situación tras el movimiento {movimientos}");
                    mostrarSituacion(ini, aux, fin);
                    if (IsSolved(ini, aux, fin, n))
                        break;

                    mover_disco(ini, aux);
                    movimientos++;
                    Console.WriteLine($"Situación tras el movimiento {movimientos}");
                    mostrarSituacion(ini, aux, fin);
                    if (IsSolved(ini, aux, fin, n))
                        break;

                    mover_disco(aux, fin);
                    movimientos++;
                    Console.WriteLine($"Situación tras el movimiento {movimientos}");
                    mostrarSituacion(ini, aux, fin);
                }
            }
            else
            {
                while (!IsSolved(ini, aux, fin, n))
                {
                    mover_disco(ini, aux);
                    movimientos++;
                    Console.WriteLine($"Situación tras el movimiento {movimientos}");
                    mostrarSituacion(ini, aux, fin);
                    if (IsSolved(ini, aux, fin, n))
                        break;

                    mover_disco(ini, fin);
                    movimientos++;
                    Console.WriteLine($"Situación tras el movimiento {movimientos}");
                    mostrarSituacion(ini, aux, fin);
                    if (IsSolved(ini, aux, fin, n))
                        break;

                    mover_disco(aux, fin);
                    movimientos++;
                    Console.WriteLine($"Situación tras el movimiento {movimientos}");
                    mostrarSituacion(ini, aux, fin);
                }
            }

            return movimientos;
        }

        
        public int recursivo(int n, Pila ini, Pila fin, Pila aux)
        {

                if (n == 1)
                {
                    mover_disco(ini, fin);
                    movimientosRecursivo++;
                    Console.WriteLine($"Situación tras el movimiento {movimientosRecursivo}");
                    mostrarSituacion(ini, aux, fin);
                }
                else
                {
                    recursivo(n - 1, ini, aux, fin);
        
                    mover_disco(ini, fin);
                    movimientosRecursivo++;
                    Console.WriteLine($"Situación tras el movimiento {movimientosRecursivo}");
                    mostrarSituacion(ini, aux, fin);
        
                    recursivo(n - 1, aux, fin, ini);
                }

                return movimientosRecursivo;
            }

        private bool IsSolved(Pila ini, Pila aux, Pila fin, int numDiscos)
        {
            return ini.isEmpty() && aux.isEmpty() && fin.Size == numDiscos;
        }
        
    }

}