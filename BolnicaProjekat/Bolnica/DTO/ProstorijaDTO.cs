using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProstorijaDTO
    {
        public ProstorijaDTO(int id, TipProstorije tipProstorije, string broj, int sprat, double povrsina)
        {
            Id = id;
            TipProstorije = tipProstorije;
            Broj = broj;
            Sprat = sprat;
            Povrsina = povrsina;
        }
        public ProstorijaDTO()
        {
            
        }
        public int Id { get; set; }
        public TipProstorije TipProstorije { get; set; }
        public string Broj { get; set; }
        public int Sprat { get; set; }
        public double Povrsina { get; set; }

        private string brojSprat;
        public string BrojSprat
        {
            get
            {
                return Broj + "/" + Sprat;
            }
            set
            {
                brojSprat = value;
            }
        }

        public override string ToString()
        {
            return BrojSprat;
        }
    }
}
