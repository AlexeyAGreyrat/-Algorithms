using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Edges
    {
        public Vertex From { get; set; }
        public Vertex FromTo { get; set; }
        public int Wight { get; set; }

        public Edges(Vertex from,Vertex fromTo,int wight=1)
        {
            From = from;
            FromTo = fromTo;
            Wight = wight;
        }
    }
}
