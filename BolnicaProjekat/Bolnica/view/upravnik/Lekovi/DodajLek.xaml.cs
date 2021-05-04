using Model;
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

namespace Bolnica.view.upravnik.Lekovi
{
    /// <summary>
    /// Interaction logic for DodajLek.xaml
    /// </summary>
    public partial class DodajLek : Window
    {
        public DodajLek()
        {
            InitializeComponent();
        }

        private void odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void potvrdi_Click(object sender, RoutedEventArgs e)
        {
            int id = Repozitorijum.LekoviRepozitorijum.GetInstance.GetAll().Count;
            Lek lek = new Lek(id+1,inputSifra.Text,inputNaziv.Text,false,inputOpis.Text,Convert.ToInt32(inputKolicina.Text),Convert.ToDouble(inputCena.Text),0);  //ovaj obj se ne pravi ovdje ali neka ga zasad
            Kontroler.LekoviKontroler Kontroler = new Kontroler.LekoviKontroler();
            Kontroler.DodajLek(lek);
            this.Close();

        }
    }
}
