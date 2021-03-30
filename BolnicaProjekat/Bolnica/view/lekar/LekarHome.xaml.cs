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
        private view.lekar.pacijenti.PrikazPacijenata refPrikazPacijenataZaLekar;

        public LekarHome()
        {
            InitializeComponent();

        }

        private void Pacijenti_Click(object sender, RoutedEventArgs e)
        {
            refPrikazPacijenataZaLekar = new view.lekar.pacijenti.PrikazPacijenata();
            RadnaPovrsinaLekar.Content = refPrikazPacijenataZaLekar;
            
        }

        private void MedicinskiKarton_Click(object sender, RoutedEventArgs e)
        {
            Model.Pacijent izabranPacijent= refPrikazPacijenataZaLekar.GetSelectedPacijentZaLekar();
            if(izabranPacijent!=null)
                RadnaPovrsinaLekar.Content = new view.lekar.pacijenti.PrikazMedicinskiKarton(izabranPacijent);

        }
    }
}
