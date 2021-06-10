using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Model;
using Kontroler;
using DTO;

namespace Bolnica.view.upravnik.prostorije
{
    /// <summary>
    /// Interaction logic for DodajProstorijuForma.xaml
    /// </summary>
    public partial class DodajProstorijuForma : Window
    {

        public ProstorijeKontroler ProstorijeKontrolerObjekat { get; set; }
        private TipProstorije tipProstorije;

        private PrikazProstorija refPrikazProstorija = null;
        private PrikazOperacionihSala refPrikazOperacionihSala = null;
        private PrikazSobaZaPregled refPrikazSobaZaPregled = null;

        public DodajProstorijuForma(PrikazProstorija refPrikazProstorija,
                                    PrikazOperacionihSala refPrikazOperacionihSala,
                                    PrikazSobaZaPregled refPrikazSobaZaPregled,
                                    TipProstorije tipProstorije)
        {
            ProstorijeKontrolerObjekat = new ProstorijeKontroler();
            this.refPrikazProstorija = refPrikazProstorija;
            this.refPrikazOperacionihSala = refPrikazOperacionihSala;
            this.refPrikazSobaZaPregled = refPrikazSobaZaPregled;
            this.editProstorija = null;
            this.tipProstorije = tipProstorije;

            InitializeComponent();
        }

        private Prostorija editProstorija;
        public DodajProstorijuForma(PrikazProstorija refPrikazProstorija,
                                    PrikazOperacionihSala refPrikazOperacionihSala,
                                    PrikazSobaZaPregled refPrikazSobaZaPregled, 
                                    Prostorija editProstorija)
        {
            ProstorijeKontrolerObjekat = new ProstorijeKontroler();
            this.refPrikazProstorija = refPrikazProstorija;
            this.refPrikazOperacionihSala = refPrikazOperacionihSala;
            this.refPrikazSobaZaPregled = refPrikazSobaZaPregled;
            this.editProstorija = editProstorija;
            this.tipProstorije = editProstorija.TipProstorije;

            InitializeComponent();
            initEdit();
        }
        private void initEdit()
        {
            inputIDprostorije.Text = Convert.ToString(editProstorija.Broj);
            inputSprat.Text = Convert.ToString(editProstorija.Sprat);
            inputPovrsina.Text = Convert.ToString(editProstorija.Povrsina);
        }


        private void close_win(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Potvrdi_btn(object sender, RoutedEventArgs e)
        {

            if(editProstorija == null) 
            {
                ProstorijaDTO prostorijaDTO = new ProstorijaDTO(-1, tipProstorije, Convert.ToString(inputIDprostorije.Text), Convert.ToInt32(inputSprat.Text), Convert.ToDouble(inputPovrsina.Text));
                ProstorijeKontrolerObjekat.DodajProstoriju(prostorijaDTO);
            }
            else
            {
                ProstorijaDTO editProstorijaDTO = new ProstorijaDTO(editProstorija.Id, tipProstorije, Convert.ToString(inputIDprostorije.Text), Convert.ToInt32(inputSprat.Text), Convert.ToDouble(inputPovrsina.Text));
                ProstorijeKontrolerObjekat.AzurirajProstoriju(editProstorijaDTO);


            }

            if (refPrikazProstorija != null) refPrikazProstorija.azurirajPrikaz();
            if (refPrikazOperacionihSala != null) refPrikazOperacionihSala.azurirajPrikaz();
            if (refPrikazSobaZaPregled != null) refPrikazSobaZaPregled.azurirajPrikaz();


            this.Close();
        }
    }
}
