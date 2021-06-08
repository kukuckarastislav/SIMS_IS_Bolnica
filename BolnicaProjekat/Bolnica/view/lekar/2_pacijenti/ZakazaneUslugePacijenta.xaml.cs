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

namespace Bolnica.view.lekar.pacijenti
{

    public partial class ZakazaneUslugePacijenta : Page
    {
        public Pacijent IzabraniPacijent { get; set; }
        public LekarDTO LekarDTO;
        private view.lekar.pacijenti.PrikazMedicinskiKarton refPrikazMedicinskiKarton;

        public ZakazaneUslugePacijenta(LekarDTO LekarDTO, Pacijent IzabraniPacijent)
        {
            this.LekarDTO = LekarDTO;
            this.IzabraniPacijent = IzabraniPacijent;
           

            InitializeComponent();

            headerIme.Text = IzabraniPacijent.Ime;
            headerPrezime.Text = IzabraniPacijent.Prezime;
            headerJMBG.Text = IzabraniPacijent.Jmbg;
        }

        private void PrikazMedicinskiKartonButton(object sender, RoutedEventArgs e)
        {
            if (IzabraniPacijent != null)
            {
                refPrikazMedicinskiKarton = new view.lekar.pacijenti.PrikazMedicinskiKarton(LekarDTO,IzabraniPacijent);
                NavigationService.Navigate(refPrikazMedicinskiKarton);
            }
        }
    }
}
