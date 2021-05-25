
using Kontroler;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DTO;

namespace Bolnica.view.sekretar.registracija
{
    /// <summary>
    /// Interaction logic for RegistracijaLekara.xaml
    /// </summary>
    public partial class RegistracijaLekara : Page
    {
        public RegistracijaLekara()
        {
            InitializeComponent();
            this.rbrMusko.IsChecked = true;
            this.inputDatum.SelectedDate = DateTime.Now;
        }

        private void RegistrujLekara_Click(object sender, RoutedEventArgs e)
        {
            LekarDTO dto = new LekarDTO();
            dto.Ime = this.inputIme.Text;
            dto.Prezime = this.inputPrezime.Text;
            dto.Jmbg = this.inputJMBG.Text;
            dto.Telefon = this.inputTelefon.Text;
            dto.AdresaStanovanja = this.inputAdresa.Text;
            dto.KorisnickoIme = this.inputKorisnickoIme.Text;
            dto.Sifra = this.inputLozinka.Text;
            dto.Specijalizacija = this.inputSpecijalizacija.Text;
            dto.Email = this.inputEmail.Text;
            dto.Drzavljanstvo = this.inputDrzavljansto.Text;
            if (this.rbrMusko.IsChecked == true)
                dto.Pol = Pol.Musko;
            else
                dto.Pol = Pol.Zensko;
            dto.DatumRodjenja = (DateTime)inputDatum.SelectedDate;
            LekarKontroler kontroler = new LekarKontroler();
            kontroler.DodajLekara(dto);
            //kontroler.DodajLekara();
        }
    }
}
