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
    /// Interaction logic for DodajBolesnickuProstorijuForma.xaml
    /// </summary>
    public partial class DodajBolesnickuProstorijuForma : Window
    {
        public ProstorijeKontroler ProstorijeKontrolerObjekat { get; set; }
        private TipProstorije tipProstorije;
        private PrikazBolesnickihProstorija refPrikazBolesnickihProstorija = null;
        public DodajBolesnickuProstorijuForma(PrikazBolesnickihProstorija refPrikazBolesnickihProstorija,
                                              TipProstorije tipProstorije)
        {
            ProstorijeKontrolerObjekat = new ProstorijeKontroler();
            this.refPrikazBolesnickihProstorija = refPrikazBolesnickihProstorija;
            this.tipProstorije = tipProstorije;
            editBolesnickaSoba = null;
            InitializeComponent();
        }


        private Prostorija editBolesnickaSoba;
        public DodajBolesnickuProstorijuForma(PrikazBolesnickihProstorija refPrikazBolesnickihProstorija,
                                              Prostorija editBolesnickaSoba)
        {
            ProstorijeKontrolerObjekat = new ProstorijeKontroler();
            InitializeComponent();
            this.editBolesnickaSoba = editBolesnickaSoba;
            this.refPrikazBolesnickihProstorija = refPrikazBolesnickihProstorija;
            inputIDprostorije.Text = Convert.ToString(editBolesnickaSoba.Broj);
            inputSprat.Text = Convert.ToString(editBolesnickaSoba.Sprat);
            inputPovrsina.Text = Convert.ToString(editBolesnickaSoba.Povrsina);
            inputBrKreveta.Text = Convert.ToString(editBolesnickaSoba.BrojKreveta);
            inputBrSlobKreveta.Text = Convert.ToString(editBolesnickaSoba.BrojSlobodnihKreveta);
        }

        private void close_win(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Potvrdi_btn(object sender, RoutedEventArgs e)
        {
            if (editBolesnickaSoba == null)
            {
                ProstorijaDTO prostorijaDTO = new ProstorijaDTO(-1, tipProstorije, Convert.ToString(inputIDprostorije.Text), Convert.ToInt32(inputSprat.Text), Convert.ToDouble(inputPovrsina.Text), Convert.ToInt32(inputBrKreveta.Text), Convert.ToInt32(inputBrSlobKreveta.Text));
                ProstorijeKontrolerObjekat.DodajProstoriju(prostorijaDTO);
            }
            else
            {
                ProstorijaDTO prostorijaDTO = new ProstorijaDTO(editBolesnickaSoba.Id, tipProstorije, Convert.ToString(inputIDprostorije.Text), Convert.ToInt32(inputSprat.Text), Convert.ToDouble(inputPovrsina.Text), Convert.ToInt32(inputBrKreveta.Text), Convert.ToInt32(inputBrSlobKreveta.Text));
                ProstorijeKontrolerObjekat.AzurirajProstoriju(prostorijaDTO);
            }


            refPrikazBolesnickihProstorija.azurirajPrikaz();

            this.Close();
        }

    }
}
