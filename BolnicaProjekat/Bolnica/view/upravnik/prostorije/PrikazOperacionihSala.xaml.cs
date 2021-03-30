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

namespace Bolnica.view.upravnik.prostorije
{
    /// <summary>
    /// Interaction logic for PrikazOperacionihSala.xaml
    /// </summary>
    public partial class PrikazOperacionihSala : Page
    {

        public ObservableCollection<Model.OperacionaSala> KolekcijaOperacionihSala { get; set; }

        public PrikazOperacionihSala()
        {
            KolekcijaOperacionihSala = Model.Bolnica.GetInstance.GetOperacioneSale();
            InitializeComponent();
            this.DataGridPrikazOperacionihSala.ItemsSource = KolekcijaOperacionihSala;
        }

        public Model.OperacionaSala GetSelectedOperacionaSala()
        {

            return (DataGridPrikazOperacionihSala.SelectedItem as Model.OperacionaSala);
        }

    }
}
