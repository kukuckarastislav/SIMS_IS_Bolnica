using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Model;

namespace Bolnica.Template
{
    public abstract class KreatorIzvestaja
    {
        protected Termin perodIzvestaja;
        protected IzvestajDto finalniIzvestaj;
        
        public IzvestajDto KreirajIzvestaj()
        {
            IzracunajPodatkeZaPojedinacneDane();
            IzracunajPodatkeZaSveDane();
            StvoriIzvestajNaOsnovuPodataka();
            return finalniIzvestaj;
        }

        public abstract void IzracunajPodatkeZaPojedinacneDane();

        public abstract void IzracunajPodatkeZaSveDane();

        public abstract void StvoriIzvestajNaOsnovuPodataka();

    }
}
