using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    public class Pila
    {
        public int Size { get; set; }
  
        public int Top { get; set; }
        public List<Disco> Elementos { get; set; }

        public Pila()
        {
            Size = 0;
            Top = 0;
            Elementos = new List<Disco>();
        }

        public void push(Disco d)
        {
            Elementos.Add(d);
            Top++;
            Size++;
        }

        public Disco pop()
        {
            Disco disco = Elementos[Top - 1];
            Elementos.RemoveAt(Top - 1);
            Top--;
            Size--;
            return disco;
        }

        public bool isEmpty()
        {
            if (Elementos.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}