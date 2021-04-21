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
using System.Windows.Shapes;

namespace Bolnica.view.upravnik.Inventari
{
    /// <summary>
    /// Interaction logic for OdabirTermina.xaml
    /// </summary>
    public partial class OdabirTermina : Window
    {
        private TipOpreme tipOpreme;
        private int idInventar1;
        private int idInventar2;
        private Magacin.PrikazStaticke refPrikazStaticke = null;
        private Magacin.PrikazDinamicke refPrikazDinamicke = null;
        private Prostorija pro;
        public OdabirTermina(Magacin.PrikazStaticke refPrikazStaticke,
                              Magacin.PrikazDinamicke refPrikazDinamicke,
                              TipOpreme tipOpreme,
                              int idInventar1,
                              int idInventar2,
                              Prostorija pro)
        {
            this.tipOpreme = tipOpreme;
            this.refPrikazStaticke = refPrikazStaticke;
            this.refPrikazDinamicke = refPrikazDinamicke;
            this.idInventar1 = idInventar1;
            this.idInventar2 = idInventar2;
            this.pro = pro; 
            InitializeComponent();
        }

        private void btn_preraspodela(object sender, RoutedEventArgs e)
        {
            var preraspodelaInventara = new PreraspodelaInventara(refPrikazStaticke, refPrikazDinamicke,
                                                        tipOpreme, 0, pro.IdInventar);
            preraspodelaInventara.Show();
        }

        private void btn_nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
