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
    /// Interaction logic for AnketaLekar.xaml
    /// </summary>
    public partial class AnketaLekar : Window
    {
        public string text { get; set; }
        public ZdravstvenaUsluga pregled { get; set; }

        public AnketaLekar(ZdravstvenaUsluga pregled)
        {
            this.pregled = pregled;
            //lekar.Text = Repozitorijum.LekarRepozitorijum.GetInstance.GetById(pregled.IdLekara).Ime + " " + Repozitorijum.LekarRepozitorijum.GetInstance.GetById(pregled.IdLekara).Prezime;
            InitializeComponent();
        }

        private void posalji_anketu(object sender, RoutedEventArgs e)
        {
            Controller.AnketaKontroler kontroler = new Controller.AnketaKontroler();
            text = sadrzaj.Text;
            kontroler.DodajOcenuLekara(pregled,1, text);
            this.Close();
        }
    }
}
