using System;

namespace DTO
{
    public class ParametriUzimanjaTerapijeDTO
    {
        public DateTime PocetakTerapije { get; set; }
        public DateTime KrajTerapije { get; set; }
        public int VremenskiRazmak { get; set; }
        public int PredlozenoVrijeme { get; set; }
        public int DnevniBrojUzimanja { get; set; }

        public ParametriUzimanjaTerapijeDTO(DateTime pocetakTerapije, DateTime krajTerapije, int vremenskiRazmak, int predlozenoVrijeme, int dnevniBrojUzimanja)
        {
            PocetakTerapije = pocetakTerapije;
            KrajTerapije = krajTerapije;
            VremenskiRazmak = vremenskiRazmak;
            PredlozenoVrijeme = predlozenoVrijeme;
            DnevniBrojUzimanja = dnevniBrojUzimanja;
        }
    }
}
