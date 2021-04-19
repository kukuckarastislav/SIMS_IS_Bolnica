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
using Model;
using Kontroler;

namespace Bolnica.view.upravnik.prostorije
{
    /// <summary>
    /// Interaction logic for prostorije.xaml
    /// </summary>
    public partial class Prostorije : Page
    {

        private int aktivanPrikaz = 1;
        private TipProstorije tipProstorije;
        private view.upravnik.prostorije.PrikazProstorija refPrikazProstorija; // obicne prostorije
        private view.upravnik.prostorije.PrikazOperacionihSala refPrikazOperacionihSala;
        private view.upravnik.prostorije.PrikazSobaZaPregled refPrikazSobaZaPregled;
        private view.upravnik.prostorije.PrikazBolesnickihProstorija refPrikazBolesnickihProstorija;

        private ProstorijeKontroler ProstorijeKontrolerObjekat { get; set; }
        public Prostorije()
        {
            ProstorijeKontrolerObjekat = new ProstorijeKontroler();
            InitializeComponent();
            aktiviraj(1);
            refPrikazProstorija = new view.upravnik.prostorije.PrikazProstorija();
            PovrsinaPrikazRaznihProstorija.Content = refPrikazProstorija;
        }


        private void Izmeni_Prostoriju(object sender, RoutedEventArgs e)
        {
            /*
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
            */
            Prostorija pro = null;
            if (aktivanPrikaz == 1)
            {
                pro = refPrikazProstorija.GetSelectedProstorija();
                var dodajProstorijuForma = new Bolnica.view.upravnik.prostorije.DodajProstorijuForma(refPrikazProstorija,
                                                                                                     null,
                                                                                                     null,
                                                                                                     pro);
                dodajProstorijuForma.Show();
            }
            else if (aktivanPrikaz == 2)
            {
                pro = refPrikazOperacionihSala.GetSelectedOperacionaSala();
                var dodajProstorijuForma = new Bolnica.view.upravnik.prostorije.DodajProstorijuForma(null,
                                                                                                     refPrikazOperacionihSala,
                                                                                                     null,
                                                                                                     pro);
                dodajProstorijuForma.Show();
            }

            else if (aktivanPrikaz == 3)
            {
                pro = refPrikazSobaZaPregled.GetSelectedSobaZaPregled();
                var dodajProstorijuForma = new Bolnica.view.upravnik.prostorije.DodajProstorijuForma(null,
                                                                                                     null,
                                                                                                     refPrikazSobaZaPregled,
                                                                                                     pro);
                dodajProstorijuForma.Show();
            }
            else if (aktivanPrikaz == 4)
            {
                pro = refPrikazBolesnickihProstorija.GetSelectedBolesnickaSoba();
                var dodajBolesnickuSobu = new Bolnica.view.upravnik.prostorije.DodajBolesnickuProstorijuForma(refPrikazBolesnickihProstorija,
                                                                                                              pro);
                dodajBolesnickuSobu.Show();
            }
        }

        private void Dodaj_Prostoriju(object sender, RoutedEventArgs e)
        {
            
            if (aktivanPrikaz == 1)
            {
                var dodajProstorijuForma = new Bolnica.view.upravnik.prostorije.DodajProstorijuForma(refPrikazProstorija,
                                                                                                     null, 
                                                                                                     null,
                                                                                                     tipProstorije);
                dodajProstorijuForma.Show();
            }
            else if (aktivanPrikaz == 2)
            {
                var dodajProstorijuForma = new Bolnica.view.upravnik.prostorije.DodajProstorijuForma(null,
                                                                                                     refPrikazOperacionihSala,
                                                                                                     null,
                                                                                                     tipProstorije);
                dodajProstorijuForma.Show();
            }
            
            else if (aktivanPrikaz == 3)
            {
                var dodajProstorijuForma = new Bolnica.view.upravnik.prostorije.DodajProstorijuForma(null,
                                                                                                     null,
                                                                                                     refPrikazSobaZaPregled,
                                                                                                     tipProstorije);
                dodajProstorijuForma.Show();
            }
            else if (aktivanPrikaz == 4)
            {
                var dodajBolesnickuSobu = new Bolnica.view.upravnik.prostorije.DodajBolesnickuProstorijuForma(refPrikazBolesnickihProstorija,
                                                                                                              tipProstorije);
                dodajBolesnickuSobu.Show();
            }
           
            

        }


        private void Obrisi_Prostoriju(object sender, RoutedEventArgs e)
        {
            Prostorija pro = null;
            if (aktivanPrikaz == 1) pro = refPrikazProstorija.GetSelectedProstorija();
            else if (aktivanPrikaz == 2) pro = refPrikazOperacionihSala.GetSelectedOperacionaSala();
            else if (aktivanPrikaz == 3) pro = refPrikazSobaZaPregled.GetSelectedSobaZaPregled();
            else if (aktivanPrikaz == 4) pro = refPrikazBolesnickihProstorija.GetSelectedBolesnickaSoba();



            if (pro == null)
            {
                MessageBox.Show("Niste selektovali ni jednu Prostoriju");
            }
            else
            {
                var rezultat = MessageBox.Show("Zelite da obrisete prostoriju " + pro.BrojSprat, "Brisanje Prostorije", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    ProstorijeKontrolerObjekat.ObrisiProstoriju(pro);
                }
            }

            if (aktivanPrikaz == 1) refPrikazProstorija.azurirajPrikaz();
            else if (aktivanPrikaz == 2) refPrikazOperacionihSala.azurirajPrikaz();
            else if (aktivanPrikaz == 3) refPrikazSobaZaPregled.azurirajPrikaz();
            else if (aktivanPrikaz == 4) refPrikazBolesnickihProstorija.azurirajPrikaz();


        }

        private void aktiviraj(int akt)
        {
            aktivanPrikaz = akt;
            tipProstorije = TipProstorije.Bolnicka;
            Btn_P_prosotrija.Background = Brushes.White;
            Btn_P_op_s.Background = Brushes.White;
            Btn_P_sobPreg.Background = Brushes.White;
            Btn_P_bolSob.Background = Brushes.White;
            switch (aktivanPrikaz)
            {
                case 1:
                    tipProstorije = TipProstorije.Bolnicka;
                    Btn_P_prosotrija.Background = Brushes.LightGray;
                    break;
                case 2:
                    tipProstorije = TipProstorije.OpracionaSala;
                    Btn_P_op_s.Background = Brushes.LightGray;
                    break;
                case 3:
                    tipProstorije = TipProstorije.SobaZaPreglede;
                    Btn_P_sobPreg.Background = Brushes.LightGray;
                    break;
                case 4:
                    tipProstorije = TipProstorije.BolesnickaSoba;
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
