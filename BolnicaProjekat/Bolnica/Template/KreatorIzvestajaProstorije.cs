using DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Template
{
    public class KreatorIzvestajaProstorije : KreatorIzvestaja
    {
        private List<ZdravstvenaUsluga> terminiZauzetostiProstorije;
        private List<double> udeoDnevneZauzetosti;
        private double ukupnaProcenaZauzetosti;
        private const int brMinutaUDanu = 1440;


        public KreatorIzvestajaProstorije(List<ZdravstvenaUsluga> terminiProstorije, Termin periodIzvestaja)
        {
            terminiZauzetostiProstorije = terminiProstorije;
            this.perodIzvestaja = periodIzvestaja;
            udeoDnevneZauzetosti = new List<double>();
        }
        public override void IzracunajPodatkeZaPojedinacneDane()
        {
            DateTime datum = new DateTime(perodIzvestaja.Pocetak.Year, perodIzvestaja.Pocetak.Month, perodIzvestaja.Pocetak.Day);
            while (datum <= perodIzvestaja.Kraj)
            {
                IzracunajPodatkeDana(datum);
                datum = datum.AddDays(1);
            }
        }

        public override void IzracunajPodatkeZaSveDane()
        {
            double ukupnoMinuta = 0;
            foreach (Double vrednost in udeoDnevneZauzetosti)
            {
                ukupnoMinuta += vrednost;
            }
            ukupnaProcenaZauzetosti = (ukupnoMinuta) / (udeoDnevneZauzetosti.Count * brMinutaUDanu);
        }

        public override void StvoriIzvestajNaOsnovuPodataka()
        {
            IzvestajDto izvestaj = new IzvestajDto();
            izvestaj.Procenat = Math.Round(ukupnaProcenaZauzetosti * 100, 2);
           
            int indMax = 0;
            double maxMinuta = udeoDnevneZauzetosti.ElementAt(0);
            for (int i = 0; i < udeoDnevneZauzetosti.Count(); i++)
            {
                if (maxMinuta < udeoDnevneZauzetosti.ElementAt(i))
                {
                    indMax = i;
                    maxMinuta = udeoDnevneZauzetosti.ElementAt(i);
                }
            }
            izvestaj.datum = this.perodIzvestaja.Pocetak.AddDays(indMax);


            this.finalniIzvestaj = izvestaj;
        }

        private void IzracunajPodatkeDana(DateTime datum)
        {
            double minutiZauzetosti = 0;
            foreach (ZdravstvenaUsluga usluga in terminiZauzetostiProstorije)
            {
                if(usluga.Termin.Pocetak.Date.Equals(datum.Date))
                {
                    minutiZauzetosti += ((TimeSpan)(usluga.Termin.Kraj - usluga.Termin.Pocetak)).TotalMinutes;
                }
            }

            udeoDnevneZauzetosti.Add(minutiZauzetosti);
        }
    }
}
