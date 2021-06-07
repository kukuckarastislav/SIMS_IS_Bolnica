using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DTO;
using Kontroler;

namespace Bolnica.view.pacijent
{
    /// <summary>
    /// Interaction logic for Izvjestaj.xaml
    /// </summary>
    public partial class Izvjestaj : Window
    {
        public Izvjestaj(PacijentDTO Pacijent)
        {
            InitializeComponent();
            PodsjetnikKontroler kontroler = new PodsjetnikKontroler();

            List<StavkaIzvjestajaDTO> Ponedeljak = kontroler.GetStavkeIzvjestajaZaDan(Pacijent.Id,DayOfWeek.Monday.ToString());
            List<StavkaIzvjestajaDTO> Utorak = kontroler.GetStavkeIzvjestajaZaDan(Pacijent.Id, DayOfWeek.Tuesday.ToString());
            List<StavkaIzvjestajaDTO> Srijeda = kontroler.GetStavkeIzvjestajaZaDan(Pacijent.Id, DayOfWeek.Wednesday.ToString());
            List<StavkaIzvjestajaDTO> Cetvrtak = kontroler.GetStavkeIzvjestajaZaDan(Pacijent.Id, DayOfWeek.Thursday.ToString());
            List<StavkaIzvjestajaDTO> Petak = kontroler.GetStavkeIzvjestajaZaDan(Pacijent.Id, DayOfWeek.Friday.ToString());
            List<StavkaIzvjestajaDTO> Subota = kontroler.GetStavkeIzvjestajaZaDan(Pacijent.Id, DayOfWeek.Saturday.ToString());
            List<StavkaIzvjestajaDTO> Nedelja = kontroler.GetStavkeIzvjestajaZaDan(Pacijent.Id, DayOfWeek.Sunday.ToString());

            Servis.PodsjetnikServis servis = new Servis.PodsjetnikServis();

            foreach (StavkaIzvjestajaDTO s in Ponedeljak)
                ponedeljak.Text += s.NazivLijeka + Environment.NewLine + "(" + s.VrijemeUzimanja.ToString("hh:mm tt") + ")" + Environment.NewLine + Environment.NewLine;
            foreach (StavkaIzvjestajaDTO s in Utorak)
                utorak.Text += s.NazivLijeka + Environment.NewLine + "(" + s.VrijemeUzimanja.ToString("hh:mm tt") + ")" + Environment.NewLine + Environment.NewLine;
            foreach (StavkaIzvjestajaDTO s in Srijeda)
                srijeda.Text +=s.NazivLijeka + Environment.NewLine + "(" + s.VrijemeUzimanja.ToString("hh:mm tt") + ")" + Environment.NewLine + Environment.NewLine;
            foreach (StavkaIzvjestajaDTO s in Cetvrtak)
                cetvrtak.Text += s.NazivLijeka + Environment.NewLine + "(" + s.VrijemeUzimanja.ToString("hh:mm tt") + ")" + Environment.NewLine + Environment.NewLine;
            foreach (StavkaIzvjestajaDTO s in Petak)
                petak.Text += s.NazivLijeka + Environment.NewLine + "(" + s.VrijemeUzimanja.ToString("hh:mm tt") + ")" + Environment.NewLine + Environment.NewLine;
            foreach (StavkaIzvjestajaDTO s in Subota)
                subota.Text += s.NazivLijeka + Environment.NewLine + "(" + s.VrijemeUzimanja.ToString("hh:mm tt") + ")" + Environment.NewLine + Environment.NewLine;
            foreach (StavkaIzvjestajaDTO s in Nedelja)
                nedelja.Text += s.NazivLijeka + Environment.NewLine + "(" + s.VrijemeUzimanja.ToString("hh:mm tt") + ")" + Environment.NewLine + Environment.NewLine;

        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;

                Print.Visibility = Visibility.Hidden;

                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "Invoice");

                }

                Print.Visibility = Visibility.Visible;
  
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}
