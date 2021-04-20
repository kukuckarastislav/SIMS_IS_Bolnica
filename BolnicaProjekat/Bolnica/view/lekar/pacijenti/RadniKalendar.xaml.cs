using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Bolnica.view.lekar.pacijenti
{
    /// <summary>
    /// Interaction logic for RadniKalendar.xaml
    /// </summary>
    public partial class RadniKalendar : Page
    {
        public ObservableCollection<ZdravstvenaUsluga> ZdrastveneUslugeLekara { get; set; }
        public ZdravstvenaUsluga odabranaUsluga;
        public Lekar Lekar;


        public RadniKalendar(Lekar lekar)
        {
            InitializeComponent();

        }
    }
}
