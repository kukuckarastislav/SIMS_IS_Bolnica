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
    /// Interaction logic for DodajBolesnickuProstorijuForma.xaml
    /// </summary>
    public partial class DodajBolesnickuProstorijuForma : Window
    {
        public DodajBolesnickuProstorijuForma()
        {
            InitializeComponent();
        }


        private Model.BolesnickaSoba editBolesnickaSoba;
        public DodajBolesnickuProstorijuForma(Model.BolesnickaSoba editBolesnickaSoba)
        {
            InitializeComponent();
            this.editBolesnickaSoba = editBolesnickaSoba;

            inputIDprostorije.Text = Convert.ToString(editBolesnickaSoba.Id);
            inputSprat.Text = Convert.ToString(editBolesnickaSoba.Sprat);
            inputPovrsina.Text = Convert.ToString(editBolesnickaSoba.Povrsina);
            inputBrKreveta.Text = Convert.ToString(editBolesnickaSoba.BrojKreveta);
            inputBrSlobKreveta.Text = Convert.ToString(editBolesnickaSoba.BrojSlobodnihKreveta);
            inputIDInventara.Text = Convert.ToString(editBolesnickaSoba.Inventar.IdInventara);
        }

        private void close_win(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Potvrdi_btn(object sender, RoutedEventArgs e)
        {

            if (editBolesnickaSoba == null)
            {
                // pravimo novu
                Model.BolesnickaSoba novaBolesnickaSoba = new Model.BolesnickaSoba(
                                    Convert.ToInt32(inputBrKreveta.Text),
                                    Convert.ToInt32(inputBrSlobKreveta.Text),
                                    Convert.ToInt32(inputIDprostorije.Text),
                                    Convert.ToInt32(inputSprat.Text),
                                    Convert.ToDouble(inputPovrsina.Text),
                                    Convert.ToInt32(inputIDInventara.Text));

                Model.Bolnica.GetInstance.AddBolesnickeSobe(novaBolesnickaSoba);
            }
            else
            {
                // editujemo postojecu

                editBolesnickaSoba.Id = Convert.ToInt32(inputIDprostorije.Text);
                editBolesnickaSoba.Sprat = Convert.ToInt32(inputSprat.Text);
                editBolesnickaSoba.Povrsina = Convert.ToDouble(inputPovrsina.Text);
                editBolesnickaSoba.BrojSlobodnihKreveta = Convert.ToInt32(inputBrSlobKreveta.Text);
                editBolesnickaSoba.BrojKreveta = Convert.ToInt32(inputBrKreveta.Text);
                editBolesnickaSoba.Inventar.IdInventara = Convert.ToInt32(inputIDInventara.Text);
            }

            this.Close();
        }

    }
}
