using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DTO
{
    public class TerminProstorijeDTO
    {
        // ovu klasu koristim za data grid kod prikaz prostorija pa tamo onaj termini
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
        public string TipTermina { get; set; }
        public TerminProstorije terminProstorijeRef { get; set; }

        public TerminProstorijeDTO(TerminProstorije terminProstorijeRef)
        {
            this.terminProstorijeRef = terminProstorijeRef;
            Pocetak = terminProstorijeRef.Pocetak;
            Kraj = terminProstorijeRef.Kraj;
            TipTermina = DajNazivTipaTermina(terminProstorijeRef.tipTerminaProstorije);   
        }

        public TerminProstorijeDTO(DateTime pocetak, DateTime kraj, string tipTermina)
        {
            Pocetak = pocetak;
            Kraj = kraj;
            TipTermina = tipTermina;
            this.terminProstorijeRef = terminProstorijeRef;
        }

        private string DajNazivTipaTermina(TipTerminaProstorije tipTerminaProstorije)
        {
            if (tipTerminaProstorije == TipTerminaProstorije.ZdravstvenaUsluga) return "Zdravstvena usluga";
            if (tipTerminaProstorije == TipTerminaProstorije.Renoviranje) return "Renoviranje";
            if (tipTerminaProstorije == TipTerminaProstorije.PreraspodelaInventaraPiM) return "Preraspodela Magacin";
            if (tipTerminaProstorije == TipTerminaProstorije.PreraspodelaInventaraPiP) return "Preraspodela Prostorija";
            if (tipTerminaProstorije == TipTerminaProstorije.TransformacijaRazdvajanje) return "Razdvajanje";
            if (tipTerminaProstorije == TipTerminaProstorije.TransformacijaSpajanje) return "Spajanje";
            // if (tipTerminaProstorije == TipTerminaProstorije.Zabrana) return "Zabrana";

            return "TIP TERMINA";
        }
    }
}
