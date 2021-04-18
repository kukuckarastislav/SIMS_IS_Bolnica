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
    /// Interaction logic for DodajProstorijuForma.xaml
    /// </summary>
    public partial class DodajProstorijuForma : Window
    {

        public DodajProstorijuForma()
        {
            InitializeComponent();
        }

        private Model.Prostorija editProstorija;
        public DodajProstorijuForma(Model.Prostorija editProstorija)
        {
            InitializeComponent();
            this.editProstorija = editProstorija;

            inputIDprostorije.Text = Convert.ToString(editProstorija.Id);
            inputSprat.Text = Convert.ToString(editProstorija.Sprat);
            inputPovrsina.Text = Convert.ToString(editProstorija.Povrsina);
           // inputIDInventara.Text = Convert.ToString(editProstorija.Inventar.IdInventara);
        }

        private void close_win(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Potvrdi_btn(object sender, RoutedEventArgs e)
        {

            if(editProstorija == null) 
            {
                // pravimo novu
              //  Model.Prostorija novaProstorija = new Model.Prostorija(
              //                      Convert.ToInt32(inputIDprostorije.Text),
             //                       Convert.ToInt32(inputSprat.Text),
             //                       Convert.ToDouble(inputPovrsina.Text),
             //                       Convert.ToInt32(inputIDInventara.Text));

             //   Model.Bolnica.GetInstance.AddProstorije(novaProstorija);
            }
            else
            {
                // editujemo postojecu

                editProstorija.Id = Convert.ToInt32(inputIDprostorije.Text);
                editProstorija.Sprat = Convert.ToInt32(inputSprat.Text);
                editProstorija.Povrsina = Convert.ToDouble(inputPovrsina.Text);
               // editProstorija.Inventar.IdInventara = Convert.ToInt32(inputIDInventara.Text);
            }
            
            this.Close();
        }
    }
}
