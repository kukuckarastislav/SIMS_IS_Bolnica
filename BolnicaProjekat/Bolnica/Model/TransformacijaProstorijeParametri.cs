using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TransformacijaProstorijeParametri
    {
        public TipProstorije TipProstorijeA { get; set; }
        public string BrojA { get; set; }
        public int SpratA { get; set; }
        public double PovrsinaA { get; set; }

        public TipProstorije TipProstorijeB { get; set; }
        public string BrojB { get; set; }
        public int SpratB { get; set; }
        public double PovrsinaB { get; set; }

        public TransformacijaProstorijeParametri(TipProstorije tipProstorijeA, string brojA, int spratA, double povrsinaA, TipProstorije tipProstorijeB, string brojB, int spratB, double povrsinaB)
        {
            TipProstorijeA = tipProstorijeA;
            BrojA = brojA;
            SpratA = spratA;
            PovrsinaA = povrsinaA;
            TipProstorijeB = tipProstorijeB;
            BrojB = brojB;
            SpratB = spratB;
            PovrsinaB = povrsinaB;
        }
    }
}
