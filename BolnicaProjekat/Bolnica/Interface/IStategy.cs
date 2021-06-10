using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Bolnica.Interface
{
    interface IStategy
    {
        void ZakazivanjeTermina(ZdravstvenaUslugaDTO usluga);
        void AzuriranjeTermina(ZdravstvenaUslugaDTO usluga);
        void BrisanjeTermina(ZdravstvenaUslugaDTO usluga);
       
    }
}
