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

namespace Bolnica.view.lekar.pacijenti
{
    /// <summary>
    /// Interaction logic for TerapijaPacijenta.xaml
    /// </summary>
    public partial class TerapijaPacijenta : Page
    {
        public Pacijent IzabraniPacijent { get; set; }
        public Lekar Lekar { get; set; }
        public ObservableCollection<Recept> Recepti { get; set; }
        public TerapijaPacijenta(Lekar Lekar, Pacijent IzabraniPacijent)
        {
            InitializeComponent();
            this.Lekar = Lekar;
            this.IzabraniPacijent = IzabraniPacijent;




           //    Recepti = KontrolerRecept.GetPacijentovihRecepta(IzabraniPacijent.Id);

            /* Recept(int id, 
             *        int idLekara, 
             *        int idPacijenta, 
             *        int idLeka, 
             *        DateTime datumPropisivanja, 
             *        DateTime datumIsteka,
             *        bool oslobodjenOdParticipacije, 
             *        string opisKoriscenja)
             */
            this.DataGridRecepti.ItemsSource = Recepti;
        }
    }
}
