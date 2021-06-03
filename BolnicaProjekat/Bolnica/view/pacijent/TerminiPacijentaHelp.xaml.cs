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
    /// Interaction logic for TerminiPacijentaHelp.xaml
    /// </summary>
    public partial class TerminiPacijentaHelp : Window
    {
        public TerminiPacijentaHelp()
        {
            InitializeComponent();

            String text = "U ovom prozoru su prikazani svi termini pacijenta, obavljeni i neobavljeni. Pod terminima se podrazumjevaju" + Environment.NewLine +
                         " U meniju Prikaz moguce je izabrati tacno koji termini nas zanimaju. Dvoklikom na termin moguce ga je otkazati" + Environment.NewLine +
                         " ( u slucaju neobavljenih ), prikazati detaljnije informacije o njima klikom na dugme Prikazi. " + Environment.NewLine +
                         "U tom slucaju pojavljuje se novi prozor sa detaljnijim informacijama o terminu gdje je moguce ostaviti komentar  " + Environment.NewLine +
                         "o razlogu zakazivanja i pomjeriti zakazani termin ( takodje samo u slucaju neobavljenih pregleda dok je  u slucaju" + Environment.NewLine +
                         " drugih termina ta funkcionalnost onemogucena )." + Environment.NewLine +
                         " Zbog organizacije radnog kalendara otkazivanje pregleda u zadnjem momentu je onemoguceno  i ta granica je" + Environment.NewLine +
                         " postavljena na 24 sata prije pocetka. ";

            help.Text = text;
        }
    }
}






