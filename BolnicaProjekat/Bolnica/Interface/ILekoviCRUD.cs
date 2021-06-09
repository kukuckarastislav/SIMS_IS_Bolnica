using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Interface
{
    interface ILekoviCRUD
    {
        void ObrisiLek(LekDTO lek);
        void DodajLek(LekDTO lek);
        void AzurirajLek(LekDTO lek);
        List<LekDTO> GetOdobreniLekovi();
        List<LekDTO> GetNeodobreniLekovi();
    }
}
