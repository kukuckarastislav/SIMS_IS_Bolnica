using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DTO;
using Kontroler;

namespace Bolnica.view.pacijent
{
    public partial class TrenutnaTerapija : Window
    {

        private ObservableCollection<ReceptDTO> Lista;
        private ReceptDTO OdabraniRecept;
        private ReceptKontroler kontroler;
        public TrenutnaTerapija(PacijentDTO Pacijent)
        {
            kontroler = new ReceptKontroler();
            Lista = new ObservableCollection<ReceptDTO>();
            List<ReceptDTO> receptiLista = kontroler.getReceptiPacijentaDTO(Pacijent.Id);
            foreach (ReceptDTO dto in receptiLista) Lista.Add(dto);

            InitializeComponent();
            this.listaRecepti.ItemsSource = Lista;
        }

        private void prikaz_recept_Click(object sender, RoutedEventArgs e)
        {
            var varr = new PrikazRecepta(OdabraniRecept);
            varr.ShowDialog();
        }

        private void listaRecepti_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            OdabraniRecept = listaRecepti.SelectedItem as ReceptDTO;
        }
    }
}
