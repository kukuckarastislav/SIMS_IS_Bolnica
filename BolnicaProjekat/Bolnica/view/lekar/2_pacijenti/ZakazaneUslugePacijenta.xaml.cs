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
        public PacijentDTO PacijentDTO { get; set; }
        public LekarDTO LekarDTO;
        private view.lekar.pacijenti.PrikazMedicinskiKarton refPrikazMedicinskiKarton;

        public ZakazaneUslugePacijenta(LekarDTO LekarDTO, PacijentDTO PacijentDTO)
        {
            this.LekarDTO = LekarDTO;
            this.PacijentDTO = PacijentDTO;
           

            InitializeComponent();

            headerIme.Text = PacijentDTO.Ime;
            headerPrezime.Text = PacijentDTO.Prezime;
            headerJMBG.Text = PacijentDTO.Jmbg;
        }

        private void PrikazMedicinskiKartonButton(object sender, RoutedEventArgs e)
        {
            if (PacijentDTO != null)
            {
                refPrikazMedicinskiKarton = new view.lekar.pacijenti.PrikazMedicinskiKarton(LekarDTO,PacijentDTO);
                NavigationService.Navigate(refPrikazMedicinskiKarton);
            }
        }
    }
}
