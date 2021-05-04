using Model;
using System;
using System.Collections;
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

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for ZakazivanjeTermina.xaml
    /// </summary>
    public partial class ZakazivanjeTermina : Page
    {

        private ObservableCollection<Lekar> listaLekari;
        public ZakazivanjeTermina()
        {
            InitializeComponent();

            //listaLekari = Repozitorijum.LekarRepozitorijum.GetInstance.GetAll();
            //this.ComboBoxLekari.ItemsSource = listaLekari;
        }
    }
}
