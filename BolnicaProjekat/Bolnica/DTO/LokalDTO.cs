using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DTO
{
    public class LokalDTO
    {
        public Button btnProstorije;
        public Button btnInventar;
        public Button btnMagacin;
        public Button btnLekovi;
        public Button btnOcene;
        public Button btnIzvestaj;
        public Button btnPodesavanje;
        public Button btnOdjaviSe;

        public LokalDTO(Button btnProstorije, Button btnInventar, Button btnMagacin, Button btnLekovi, Button btnOcene, Button btnIzvestaj, Button btnPodesavanje, Button btnOdjaviSe)
        {
            this.btnProstorije = btnProstorije;
            this.btnInventar = btnInventar;
            this.btnMagacin = btnMagacin;
            this.btnLekovi = btnLekovi;
            this.btnOcene = btnOcene;
            this.btnIzvestaj = btnIzvestaj;
            this.btnPodesavanje = btnPodesavanje;
            this.btnOdjaviSe = btnOdjaviSe;
        }

        public void setEng()
        {
            btnInventar.Content = "Inventary";
            btnIzvestaj.Content = "Report";
            btnLekovi.Content = "Drugs";
            btnMagacin.Content = "Magacin";
            btnOcene.Content = "Rewiev";
            btnOdjaviSe.Content = "Log Out";
            btnProstorije.Content = "Rooms";
            btnPodesavanje.Content = "Settings";
        }

        public void setSrb()
        {
            btnInventar.Content = "Inventari";
            btnIzvestaj.Content = "Izvestaj";
            btnLekovi.Content = "Lekovi";
            btnMagacin.Content = "Magacin";
            btnOcene.Content = "Ocene";
            btnOdjaviSe.Content = "Odjavi se";
            btnProstorije.Content = "Prostorije";
            btnPodesavanje.Content = "Podesavanje";
        }
    }
}
