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
using Model;

namespace Bolnica.view.pacijent
{
    /// <summary>
    /// Interaction logic for NoviPodsjetnik.xaml
    /// </summary>
    public partial class NoviPodsjetnik : Window
    {
        public Pacijent Pacijent { get; set; }
        private Controller.PodsjetnikKontroler Kontroler;
        public NoviPodsjetnik(Pacijent Pacijent,String text)
        {
            Kontroler = new Controller.PodsjetnikKontroler();
            this.Pacijent = Pacijent;
            InitializeComponent();
            sadrzaj.Text = text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = DateTime.Now;
            int pocetakSati = Convert.ToInt32(vrijeme_pocetak_sati.Text);
            int pocetakMinute = Convert.ToInt32(vrijeme_pocetak_minute.Text);
            string pocetakAP = vrijeme_pocetak_ap.Text;

            if (pocetakAP.Equals("PM"))
                pocetakSati += 12;

            DateTime pocetak = new DateTime(date.Year, date.Month, date.Day, pocetakSati, pocetakMinute, 00);
            Kontroler.DodajPodsjetnik(Pacijent.Id,pocetak,sadrzaj.Text);
        }
    }
}
