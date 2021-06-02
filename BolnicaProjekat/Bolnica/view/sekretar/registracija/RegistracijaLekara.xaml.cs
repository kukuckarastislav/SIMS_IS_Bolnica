
using Kontroler;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DTO;
using Bolnica.viewmodel;

namespace Bolnica.view.sekretar.registracija
{
    /// <summary>
    /// Interaction logic for RegistracijaLekara.xaml
    /// </summary>
    public partial class RegistracijaLekara : Page
    {
        public RegistracijaLekara()
        {
            InitializeComponent();
            this.rbrMusko.IsChecked = true;
            this.inputDatum.SelectedDate = DateTime.Now;
        }

       
    }
}
