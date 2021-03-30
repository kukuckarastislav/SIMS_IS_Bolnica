using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.view.upravnik.prostorije
{
    /// <summary>
    /// Interaction logic for prostorije.xaml
    /// </summary>
    public partial class Prostorije : Page
    {

        private int aktivanPrikaz = 1;
        private view.upravnik.prostorije.PrikazProstorija refPrikazProstorija; // obicne prostorije
        private view.upravnik.prostorije.PrikazOperacionihSala refPrikazOperacionihSala;
        private view.upravnik.prostorije.PrikazSobaZaPregled refPrikazSobaZaPregled;
        private view.upravnik.prostorije.PrikazBolesnickihProstorija refPrikazBolesnickihProstorija;

        public Prostorije()
        {
            InitializeComponent();
            aktiviraj(1);
            refPrikazProstorija = new view.upravnik.prostorije.PrikazProstorija();
            PovrsinaPrikazRaznihProstorija.Content = refPrikazProstorija;
        }


        private void Izmeni_Prostoriju(object sender, RoutedEventArgs e)
        {
            /*
            Model.Prostorija pro = DataGridPrikazProstorija.SelectedItem as Model.Prostorija;
            if (pro == null) return;

            var dodajProstorijuForma = new Bolnica.view.upravnik.prostorije.DodajProstorijuForma(pro);
            dodajProstorijuForma.Show();

            DataGridPrikazProstorija.Items.Refresh();
            */

            if (aktivanPrikaz == 1)
            {
                Model.Prostorija editProstorija = refPrikazProstorija.GetSelectedProstorija();
                var dodajProstorijuForma = new Bolnica.view.upravnik.prostorije.DodajProstorijuForma(editProstorija);
                dodajProstorijuForma.Show();
            }
            else if (aktivanPrikaz == 2)
            {
                Model.OperacionaSala editOperacionaSala = refPrikazOperacionihSala.GetSelectedOperacionaSala();
                var dodajOperacionuSaluForma = new Bolnica.view.upravnik.prostorije.DodajOperacionuSaluForma(editOperacionaSala);
                dodajOperacionuSaluForma.Show();
            }
            else if (aktivanPrikaz == 3)
            {
                Model.SobaZaPreglede editSobaZaPregled = refPrikazSobaZaPregled.GetSelectedSobaZaPregled();
                var dodajSobuZaPregledForma = new Bolnica.view.upravnik.prostorije.DodajSobuZaPregledForma(editSobaZaPregled);
                dodajSobuZaPregledForma.Show();
            }
            else if (aktivanPrikaz == 4)
            {
                Model.BolesnickaSoba editBolesnickaSoba = refPrikazBolesnickihProstorija.GetSelectedBolesnickaSoba();
                var dodajBolesnickuSobu = new Bolnica.view.upravnik.prostorije.DodajBolesnickuProstorijuForma(editBolesnickaSoba);
                dodajBolesnickuSobu.Show();
            }
        }

        private void Dodaj_Prostoriju(object sender, RoutedEventArgs e)
        {

            if (aktivanPrikaz == 1)
            {
                var dodajProstorijuForma = new Bolnica.view.upravnik.prostorije.DodajProstorijuForma();
                dodajProstorijuForma.Show();
            }
            else if (aktivanPrikaz == 2)
            {
                var dodajOperacionuSaluForma = new Bolnica.view.upravnik.prostorije.DodajOperacionuSaluForma();
                dodajOperacionuSaluForma.Show();
            }
            else if (aktivanPrikaz == 3)
            {
                var dodajSobuZaPregledForma = new Bolnica.view.upravnik.prostorije.DodajSobuZaPregledForma();
                dodajSobuZaPregledForma.Show();
            }
            else if (aktivanPrikaz == 4)
            {
                var dodajBolesnickuSobu = new Bolnica.view.upravnik.prostorije.DodajBolesnickuProstorijuForma();
                dodajBolesnickuSobu.Show();
            }
        }


        private void Obrisi_Prostoriju(object sender, RoutedEventArgs e)
        {

            if(aktivanPrikaz == 1)
            {
                Model.Prostorija pro = refPrikazProstorija.GetSelectedProstorija();
                if (pro != null)
                { 
                    Model.Bolnica.GetInstance.RemoveProstorije(pro);
                }

            }
            else if(aktivanPrikaz == 2)
            {
                Model.OperacionaSala opSala = refPrikazOperacionihSala.GetSelectedOperacionaSala();
                if (opSala != null)
                {
                    Model.Bolnica.GetInstance.RemoveOperacioneSale(opSala);
                }
            }
            else if(aktivanPrikaz == 3)
            {
                Model.SobaZaPreglede SzP = refPrikazSobaZaPregled.GetSelectedSobaZaPregled();
                if (SzP != null)
                {
                    Model.Bolnica.GetInstance.RemoveSobeZaPreglede(SzP);
                }
            }
            else if(aktivanPrikaz == 4)
            {
                Model.BolesnickaSoba bs = refPrikazBolesnickihProstorija.GetSelectedBolesnickaSoba();
                if (bs != null)
                {
                    Model.Bolnica.GetInstance.RemoveBolesnickeSobe(bs);
                }
            }
            
            /*
            Model.Prostorija pro = DataGridPrikazProstorija.SelectedItem as Model.Prostorija;
            if(pro != null)
            {
                //Model.Bolnica.GetInstance.RemoveProstorijeByID(pro.Id);
                Model.Bolnica.GetInstance.RemoveProstorije(pro);
            }
            
            /* 
            var selektovanaProstorija = DataGridPrikazProstorija.SelectedItem;
            if (selektovanaProstorija != null)
            {
                KolekcijaProstorija.Remove((Model.Prostorija)selektovanaProstorija);
            }
            */




        }

        private void aktiviraj(int akt)
        {
            aktivanPrikaz = akt;
            Btn_P_prosotrija.Background = Brushes.White;
            Btn_P_op_s.Background = Brushes.White;
            Btn_P_sobPreg.Background = Brushes.White;
            Btn_P_bolSob.Background = Brushes.White;
            switch (aktivanPrikaz)
            {
                case 1:
                    Btn_P_prosotrija.Background = Brushes.LightGray;
                    break;
                case 2:
                    Btn_P_op_s.Background = Brushes.LightGray;
                    break;
                case 3:
                    Btn_P_sobPreg.Background = Brushes.LightGray;
                    break;
                case 4:
                    Btn_P_bolSob.Background = Brushes.LightGray;
                    break;
            }

        }

        private void Btn_prikazi_prosotrije(object sender, RoutedEventArgs e)
        {
            aktiviraj(1);
            refPrikazProstorija = new view.upravnik.prostorije.PrikazProstorija();
            PovrsinaPrikazRaznihProstorija.Content = refPrikazProstorija;
        }

        private void Btn_prikazi_op_sale(object sender, RoutedEventArgs e)
        {
            aktiviraj(2);
            refPrikazOperacionihSala = new view.upravnik.prostorije.PrikazOperacionihSala();
            PovrsinaPrikazRaznihProstorija.Content = refPrikazOperacionihSala;
        }

        private void Btn_prikazi_sobe_za_pregled(object sender, RoutedEventArgs e)
        {
            aktiviraj(3);
            refPrikazSobaZaPregled = new view.upravnik.prostorije.PrikazSobaZaPregled();
            PovrsinaPrikazRaznihProstorija.Content = refPrikazSobaZaPregled;
        }

        private void Btn_prikazi_bolesnicke_sobe(object sender, RoutedEventArgs e)
        {
            aktiviraj(4);
            refPrikazBolesnickihProstorija = new view.upravnik.prostorije.PrikazBolesnickihProstorija();
            PovrsinaPrikazRaznihProstorija.Content = refPrikazBolesnickihProstorija;
        }
    }
}
