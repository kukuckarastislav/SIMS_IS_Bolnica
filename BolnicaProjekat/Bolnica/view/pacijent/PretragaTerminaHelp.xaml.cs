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

namespace Bolnica.view.pacijent
{
    /// <summary>
    /// Interaction logic for PretragaTerminaHelp.xaml
    /// </summary>
    public partial class PretragaTerminaHelp : Window
    {
        public PretragaTerminaHelp()
        {
            InitializeComponent();

            String text = "Unutar ovog prozora se vrsi zakazivanje pregleda. To radite na sljedeci nacin:" + Environment.NewLine +
               "-Birate dan kada zelite da zakazete pregled." + Environment.NewLine +
               "- Birate zeljeni vremenski period u tom danu. "+ Environment.NewLine +
               "- Birate odgovorajuceg lekara." + Environment.NewLine +
               "U idealnom slucaju, nakon pritiska na dugme pretraga bice vam prikazani svi termini koji" + Environment.NewLine +
               " odgovaraju vasim zahtjevima." + Environment.NewLine +
               " Ako ne postoje termini koji zadovoljavaju oba kriterijuma, bice prikazani oni koji im priblizno odgovaraju. " + Environment.NewLine +
               "Ako ste odabrali da prioritet pretrage bude lekar bice prikazani neki termini za tog lekara koji ne upadaju" + Environment.NewLine +
               " u zeljeni vremenski period. Ako ste, pak odabrali da prioritet bude vrijeme, bice prikazani termini nekih" + Environment.NewLine +
               " drugih lekara koji odgovaraju tom vremenu.";

            help.Text = text;
        }
    }
}
