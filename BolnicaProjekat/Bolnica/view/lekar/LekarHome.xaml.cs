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

namespace Bolnica.view.lekar
{
    /// <summary>
    /// Interaction logic for LekarHome.xaml
    /// </summary>
    public partial class LekarHome : Window
    {
        public LekarHome()
        {
            InitializeComponent();

            Model.RadnoVreme radnoVreme = new Model.RadnoVreme(8.00, 14.00);
            //   Model.Pol.Musko, "perica@gmail", "0658499", new DateTime(2000, 1, 7), "4932423", "Srpsko", "Novi Sad");
            Model.Lekar lekar = new Model.Lekar(1, true, Model.Odeljenje.OpstaHirurgija, radnoVreme, Model.RadniStatus.Aktivan,
                                    "laslouri99", "sifra123","Laslo","Uri", Model.Pol.Musko, "laslou@gmail.com", "066-666-666", 
                                    new DateTime(1999,7,16), "1111111", "Srpsko", "Novi Sad");
        }

        private void Pacijenti_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsinaLekar.Content = new view.lekar.pacijenti.PrikazPacijenata();
        }
    }
}
