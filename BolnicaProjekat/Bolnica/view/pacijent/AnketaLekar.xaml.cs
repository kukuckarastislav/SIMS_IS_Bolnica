using System;
using System.Windows;
using DTO;

namespace Bolnica.view.pacijent
{
    /// <summary>
    /// Interaction logic for AnketaLekar.xaml
    /// </summary>
    public partial class AnketaLekar : Window
    {
        private string text;
        private ZdravstvenaUslugaDTO Pregled;

        public AnketaLekar(ZdravstvenaUslugaDTO pregled)
        {
            InitializeComponent();
            Pregled = pregled;
            lekar.Text = Repozitorijum.LekarRepozitorijum.GetInstance.GetById(pregled.IdLekara).Ime + " " + Repozitorijum.LekarRepozitorijum.GetInstance.GetById(pregled.IdLekara).Prezime;

        }

        private void posalji_anketu(object sender, RoutedEventArgs e)
        {
            Controller.AnketaKontroler kontroler = new Controller.AnketaKontroler();
            text = sadrzaj.Text;
            int ocjena = Convert.ToInt32(ocjene.Text);
            kontroler.DodajOcenuLekara(Pregled,1, text,ocjena);
            this.Close();
        }
    }
}
