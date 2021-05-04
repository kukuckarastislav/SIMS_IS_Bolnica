using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class ParametriNaprednePretrageDTO
    {
        public string PretragaNaziv { get; set; }
        public string PretragaSifra { get; set; }

        public double CenaOd { get; set; }
        public double CenaDo { get; set; }

        public int KolicinaOd { get; set; }
        public int KolicinaDo { get; set; }

        public bool CheckMagacin { get; set; }
        public bool CheckBolnicka { get; set; }
        public bool CheckBolesnickaSoba { get; set; }
        public bool CheckOpracionaSala { get; set; }
        public bool CheckSobaZaPreglede { get; set; }

        public bool CheckStaticka { get; set; }
        public bool CheckDinamicka { get; set; }

        public ParametriNaprednePretrageDTO(string pretragaNaziv, string pretragaSifra, 
            double cenaOd, double cenaDo, int kolicinaOd, int kolicinaDo, 
            bool checkMagacin, bool checkBolnicka, bool checkBolesnickaSoba, bool checkOpracionaSala, bool checkSobaZaPreglede, 
            bool checkStaticka, bool checkDinamicka)
        {
            PretragaNaziv = pretragaNaziv;
            PretragaSifra = pretragaSifra;
            CenaOd = cenaOd;
            CenaDo = cenaDo;
            KolicinaOd = kolicinaOd;
            KolicinaDo = kolicinaDo;
            CheckMagacin = checkMagacin;
            CheckBolnicka = checkBolnicka;
            CheckBolesnickaSoba = checkBolesnickaSoba;
            CheckOpracionaSala = checkOpracionaSala;
            CheckSobaZaPreglede = checkSobaZaPreglede;
            CheckStaticka = checkStaticka;
            CheckDinamicka = checkDinamicka;
        }

    }
}
