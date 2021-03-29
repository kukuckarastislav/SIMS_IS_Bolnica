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
using System.Windows.Shapes;

namespace Bolnica.view.pacijent
{
    /// <summary>
    /// Interaction logic for pregledi.xaml
    /// </summary>
    public partial class RaspoloziviPregledi : Window
    {

        public ObservableCollection<Model.Pregled> Pregledi { get; set; }

        public RaspoloziviPregledi()
        {
            InitializeComponent();
            Pregledi = Model.Bolnica.GetInstance.Pregledi;
            this.listaPregleda.
                ItemsSource = Pregledi;
        }
    }
}
