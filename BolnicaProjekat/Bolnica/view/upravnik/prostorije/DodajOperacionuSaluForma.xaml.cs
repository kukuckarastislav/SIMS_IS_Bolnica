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
    /// Interaction logic for DodajOperacionuSaluForma.xaml
    /// </summary>
    public partial class DodajOperacionuSaluForma : Window
    {
        public DodajOperacionuSaluForma()
        {
            InitializeComponent();
        }

        private Model.OperacionaSala editOperacionaSala;
        public DodajOperacionuSaluForma(Model.OperacionaSala editOperacionaSala)
        {
            InitializeComponent();
            this.editOperacionaSala = editOperacionaSala;

            inputIDprostorije.Text = Convert.ToString(editOperacionaSala.Id);
            inputSprat.Text = Convert.ToString(editOperacionaSala.Sprat);
            inputPovrsina.Text = Convert.ToString(editOperacionaSala.Povrsina);
            inputIDInventara.Text = Convert.ToString(editOperacionaSala.Inventar.IdInventara);
        }

        private void close_win(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Potvrdi_btn(object sender, RoutedEventArgs e)
        {

            if (editOperacionaSala == null)
            {
                // pravimo novu
                Model.OperacionaSala novaoPeracionaSala = new Model.OperacionaSala(
                                    Convert.ToInt32(inputIDprostorije.Text),
                                    Convert.ToInt32(inputSprat.Text),
                                    Convert.ToDouble(inputPovrsina.Text),
                                    Convert.ToInt32(inputIDInventara.Text));

                Model.Bolnica.GetInstance.AddOperacioneSale(novaoPeracionaSala);
            }
            else
            {
                // editujemo postojecu

                editOperacionaSala.Id = Convert.ToInt32(inputIDprostorije.Text);
                editOperacionaSala.Sprat = Convert.ToInt32(inputSprat.Text);
                editOperacionaSala.Povrsina = Convert.ToDouble(inputPovrsina.Text);
                editOperacionaSala.Inventar.IdInventara = Convert.ToInt32(inputIDInventara.Text);
            }

            this.Close();
        }
    }
}
