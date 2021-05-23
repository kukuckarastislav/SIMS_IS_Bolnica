using Bolnica.DTO;
using Kontroler;
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

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for PageLekari.xaml
    /// </summary>
    public partial class PageLekari : Page
    {
        private ObservableCollection<LekarDTO> PrikazaniLekari;
        public PageLekari()
        {
            InitializeComponent();

            LekarKontroler kontroler = new LekarKontroler();
            PrikazaniLekari = kontroler.getAllDto();
            MessageBox.Show("ima " + PrikazaniLekari.Count);
            this.DataGridPrikazLekara.ItemsSource = PrikazaniLekari;
        }
    }
}
