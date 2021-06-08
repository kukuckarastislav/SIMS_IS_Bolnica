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
using Kontroler;
using Model;

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for KartonPacijenta.xaml
    /// </summary>
    public partial class KartonPacijenta : Window
    {
        private Pacijent pacijent;
        public KartonPacijenta(Pacijent pacijent)
        {
            InitializeComponent();
            this.pacijent = pacijent;
            if(App.prikaziHelp == false)
            {
                btnPomoc.Visibility = Visibility.Hidden;
            }
            
       /*     if(pacijent.MedicinskiKarton.Alergeni == null)
            {
                pacijent.MedicinskiKarton.Alergeni = " ";
            }
            tbAlergeni.Text = pacijent.MedicinskiKarton.Alergeni;*/
        }

        private void SacuvaAlergene_Click(object sender, RoutedEventArgs e)
        {
            PacijentKontroler kontroler = new PacijentKontroler();
         //   pacijent.MedicinskiKarton.Alergeni = tbAlergeni.Text;
            kontroler.AzurirajPacijenta(pacijent);
            MessageBox.Show("Izmena je sacuvana.");
        }
    }
}
