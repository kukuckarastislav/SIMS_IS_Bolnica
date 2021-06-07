using Model;
using Servis;
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
using Bolnica.Model;
using DTO;

namespace Bolnica.view.lekar.pacijenti
{
    public partial class TerapijaPacijenta : Page
    {
        public Pacijent IzabraniPacijent { get; set; }
        public LekarDTO LekarDTO { get; set; }
        public ObservableCollection<DTORecept> ListaRecepti { get; set; }
        public ObservableCollection<string> KolekcijaAlergeni;
        public MedicinskiKarton MedicinskiKarton { get; set; }
        public List<string> Alergeni;
        private view.lekar.pacijenti.PrikazMedicinskiKarton refPrikazMedicinskiKarton;
        public TerapijaPacijenta(LekarDTO LekarDTO, Pacijent IzabraniPacijent)
        {
            InitializeComponent();
            this.LekarDTO = LekarDTO;
            this.IzabraniPacijent = IzabraniPacijent;
            ListaRecepti = ReceptServis.GetPacijentovihReceptaDTO(IzabraniPacijent.Id);
            Alergeni = Repozitorijum.PacijentRepozitorijum.GetInstance.GetById(IzabraniPacijent.Id).MedicinskiKarton.Alergeni;

           //    Recepti = KontrolerRecept.GetPacijentovihRecepta(IzabraniPacijent.Id);

            /* Recept(int id, 
             *        int idLekarDTOa, 
             *        int idPacijenta, 
             *        int idLeka, 
             *        DateTime datumPropisivanja, 
             *        DateTime datumIsteka,
             *        bool oslobodjenOdParticipacije, 
             *        string opisKoriscenja)
             */
            this.DataGridRecepti.ItemsSource = ListaRecepti;
            this.DataGridPrikazAlergena.ItemsSource = Alergeni;
        }

        private void AzurirajPrikazAlergena()
        {
            DataGridPrikazAlergena.ItemsSource = KolekcijaAlergeni;
        }





        private void PrikazMedicinskiKartonButton(object sender, RoutedEventArgs e)
        {
            if (IzabraniPacijent != null)
            {
                refPrikazMedicinskiKarton = new view.lekar.pacijenti.PrikazMedicinskiKarton(LekarDTO, IzabraniPacijent);
                NavigationService.Navigate(refPrikazMedicinskiKarton);
            }
        }
    }
}
