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

namespace Bolnica.view.upravnik.prostorije
{
    /// <summary>
    /// Interaction logic for DodajSobuZaPregled.xaml
    /// </summary>
    public partial class DodajSobuZaPregledForma : Window
    {
        public DodajSobuZaPregledForma()
        {
            InitializeComponent();
        }

        private Model.SobaZaPreglede editSobaZaPregled;
        public DodajSobuZaPregledForma(Model.SobaZaPreglede editSobaZaPregled)
        {
            InitializeComponent();
            this.editSobaZaPregled = editSobaZaPregled;

            inputIDprostorije.Text = Convert.ToString(editSobaZaPregled.Id);
            inputSprat.Text = Convert.ToString(editSobaZaPregled.Sprat);
            inputPovrsina.Text = Convert.ToString(editSobaZaPregled.Povrsina);
            inputIDInventara.Text = Convert.ToString(editSobaZaPregled.Inventar.IdInventara);
        }

        private void close_win(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Potvrdi_btn(object sender, RoutedEventArgs e)
        {

            if (editSobaZaPregled == null)
            {
                // pravimo novu
                Model.SobaZaPreglede novaSobaZaPregled = new Model.SobaZaPreglede(
                                    Convert.ToInt32(inputIDprostorije.Text),
                                    Convert.ToInt32(inputSprat.Text),
                                    Convert.ToDouble(inputPovrsina.Text),
                                    Convert.ToInt32(inputIDInventara.Text));

                Model.Bolnica.GetInstance.AddSobeZaPreglede(novaSobaZaPregled);
            }
            else
            {
                // editujemo postojecu

                editSobaZaPregled.Id = Convert.ToInt32(inputIDprostorije.Text);
                editSobaZaPregled.Sprat = Convert.ToInt32(inputSprat.Text);
                editSobaZaPregled.Povrsina = Convert.ToDouble(inputPovrsina.Text);
                editSobaZaPregled.Inventar.IdInventara = Convert.ToInt32(inputIDInventara.Text);
            }

            this.Close();
        }

    }
}
