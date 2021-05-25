using DTO;
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
using Model;
using Kontroler;

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for PageLekarIzmena.xaml
    /// </summary>
    public partial class PageLekarIzmena : Page
    {
        private LekarDTO lekarDto;
        public PageLekarIzmena(LekarDTO dto)
        {
            InitializeComponent();
            lekarDto = dto;
            ucitajPodatkeLekara();
        }

        void ucitajPodatkeLekara()
        {
            this.inputIme.Text = lekarDto.Ime;
            this.inputPrezime.Text = lekarDto.Prezime;
            this.inputJMBG.Text = lekarDto.Jmbg;
            this.inputTelefon.Text = lekarDto.Telefon;
            this.inputAdresa.Text = lekarDto.AdresaStanovanja;
            this.inputEmail.Text = lekarDto.Email;
            this.inputDrzavljansto.Text = lekarDto.Drzavljanstvo;
            inputDatum.SelectedDate = lekarDto.DatumRodjenja;
        }

        private void SacuvajIzmene_Click(object sender, RoutedEventArgs e)
        {
            LekarDTO noviLekar = new LekarDTO(lekarDto);
            noviLekar.Ime = this.inputIme.Text;
            noviLekar.Prezime = this.inputPrezime.Text;
            noviLekar.Telefon = this.inputTelefon.Text;
            noviLekar.AdresaStanovanja = this.inputAdresa.Text;
            noviLekar.Email = this.inputEmail.Text;
            noviLekar.Drzavljanstvo = this.inputDrzavljansto.Text;
            noviLekar.DatumRodjenja = (DateTime)inputDatum.SelectedDate;
            LekarKontroler kontroler = new LekarKontroler();
            kontroler.AzurirajLekara(noviLekar);
        }
    }
}
