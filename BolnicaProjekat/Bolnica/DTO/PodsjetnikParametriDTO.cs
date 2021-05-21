using System;

namespace DTO
{
    public class PodsjetnikParametriDTO
    {
        public int IdPacijenta { get; set; }
        public DateTime VrijemePojavljivanja { get; set; }
        public string Tekst { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }

        public PodsjetnikParametriDTO(int idPacijenta, DateTime vrijemePojavljivanja, string tekst, DateTime pocetak, DateTime kraj)
        {
            IdPacijenta = idPacijenta;
            VrijemePojavljivanja = vrijemePojavljivanja;
            Tekst = tekst;
            Pocetak = pocetak;
            Kraj = kraj;
        }
    }
}
