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

namespace Bolnica.view.upravnik.Podesavanje
{
    /// <summary>
    /// Interaction logic for PodesavanjePage.xaml
    /// </summary>
    public partial class PodesavanjePage : Page
    {

        private LokalDTO lok;

        public PodesavanjePage(LokalDTO lok)
        {
            InitializeComponent();
            this.lok = lok;
        }

        private void White_click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorMode = "Light";
            Properties.Settings.Default.Save();
        }

        private void Black_click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorMode = "Black";
            Properties.Settings.Default.Save();
        }

        private void SRB_click(object sender, RoutedEventArgs e)
        {
            lok.setSrb();
            txtJezik.Text = "Jezik";
            txtPodesavanje.Text = "Podesavanje";
            txtTema.Text = "Tema";
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("sr");
        }

        private void ENG_click(object sender, RoutedEventArgs e)
        {
            lok.setEng();
            txtJezik.Text = "Language";
            txtPodesavanje.Text = "Settings";
            txtTema.Text = "Them";
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
        }
    }
}
