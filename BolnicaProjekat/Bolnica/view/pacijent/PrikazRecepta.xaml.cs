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
using DTO;

namespace Bolnica.view.pacijent
{
    /// <summary>
    /// Interaction logic for PrikazRecepta.xaml
    /// </summary>
    public partial class PrikazRecepta : Window
    {
        public PrikazRecepta(ReceptDTO Recept)
        {
            InitializeComponent();

            naziv.Text = Recept.NazivLeka;
            sifra.Text = Recept.IdLeka.ToString();
            kolicina.Text = Recept.Kolicina.ToString();
            cijena.Text = Recept.Cijena.ToString();
            nacin_koriscenja.Text = Recept.OpisKoriscenja;
            lekar.Text = Recept.ImePrezimeLekara;
            datum_izdavanja.Text = Recept.DatumPropisivanja.ToString();
            datum_isteka.Text = Recept.DatumIsteka.ToString();
        }
    }
}
