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

namespace Bolnica.view.lekar
{
    /// <summary>
    /// Interaction logic for LekarHome.xaml
    /// </summary>
    public partial class LekarHome : Window
    {
        private view.lekar.pacijenti.PrikazPacijenata refPrikazPacijenataZaLekar;
        private view.lekar.LoginPage refLoginPage;
        public Lekar Lekar;
        public LekarHome(Lekar Lekar)
        {
            this.Lekar = Lekar;
            InitializeComponent();

            refLoginPage = new view.lekar.LoginPage(Lekar);
            RadnaPovrsinaLekar.Navigate(refLoginPage);
        }


    }
}
