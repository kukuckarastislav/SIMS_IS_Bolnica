using System;
using System.Collections.Generic;
using System.Windows;
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


            foreach (StavkaIzvjestajaDTO s in Ponedeljak)
                ponedeljak.Text += s.NazivLijeka + Environment.NewLine + "(" + s.VrijemeUzimanja.ToString("hh:mm tt") + ")";
            foreach (StavkaIzvjestajaDTO s in Utorak)
                utorak.Text += s.NazivLijeka + Environment.NewLine + "(" + s.VrijemeUzimanja.ToString("hh:mm tt") + ")";
            foreach (StavkaIzvjestajaDTO s in Srijeda)
                srijeda.Text +=s.NazivLijeka + Environment.NewLine + "(" + s.VrijemeUzimanja.ToString("hh:mm tt") + ")";
            foreach (StavkaIzvjestajaDTO s in Cetvrtak)
                cetvrtak.Text += s.NazivLijeka + Environment.NewLine + "(" + s.VrijemeUzimanja.ToString("hh:mm tt") + ")";
            foreach (StavkaIzvjestajaDTO s in Petak)
                petak.Text += s.NazivLijeka + Environment.NewLine + "(" + s.VrijemeUzimanja.ToString("hh:mm tt") + ")";
            foreach (StavkaIzvjestajaDTO s in Subota)
                subota.Text += s.NazivLijeka + Environment.NewLine + "(" + s.VrijemeUzimanja.ToString("hh:mm tt") + ")";
            foreach (StavkaIzvjestajaDTO s in Nedelja)
                nedelja.Text += s.NazivLijeka + Environment.NewLine + "(" + s.VrijemeUzimanja.ToString("hh:mm tt") + ")";

        }
    }
}
