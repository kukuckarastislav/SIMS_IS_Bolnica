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

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for WindowIzmenaPodataka.xaml
    /// </summary>
    public partial class WindowIzmenaPodataka : Window
    {
        public WindowIzmenaPodataka(Pacijent p)
        {
            InitializeComponent();
        }

        private void LoadPacijentData(Pacijent p)
        {
            inputIme.Text = p.Ime;
            inputPrezime.Text = p.Prezime;
            inputId.Text = p.IdPacijenta;
            inputKorisnickoIme.Text = p.KorisnickoIme;
            inputSifra.Text = p.Sifra;
            inputTelefon.Text = p.Telefon;
            inputDatum.Text = p.DatumRodjenja.ToString();
            inputDrzavljanstvo.Text = p.Drzavljanstvo;
            inputAdresa.Text = p.AdresaStanovanja;
            inputJmbg.Text = p.Jmbg;
            inputEmail.Text = p.Email;
        }
    }
}
