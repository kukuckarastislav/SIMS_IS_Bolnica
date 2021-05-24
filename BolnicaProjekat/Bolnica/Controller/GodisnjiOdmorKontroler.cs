using DTO;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    class GodisnjiOdmorKontroler
    {
        private GodisnjiOdmorServis servisOdmora;
        public GodisnjiOdmorKontroler()
        {
            servisOdmora = new GodisnjiOdmorServis();
        }

        public ObservableCollection<GodisnjiOdmorDTO> GetOdmoriLekara(int idLekara)
        {
            return servisOdmora.getOdmoriLekara(idLekara);
        }

        public GodisnjiOdmorDTO DodajGodisnjiOdmor(int idLekara, GodisnjiOdmorDTO odmor)
        {
            odmor.LekarId = idLekara;
            return servisOdmora.DodajGodisnjiOdmor(odmor);
        }

        public void ObrisiGodisnjiOdmor(int id)
        {
            servisOdmora.obrisiGodisnjiOdmor(id);
        }

        public RadnoVreme GetRadnoVremeLekara(int id)
        {
            return servisOdmora.getRadnoVremeLekara(id);
        }

        public void IzmeniRadnoVremeLekara(int id, RadnoVreme vreme)
        {
            servisOdmora.IzmeniRadnoVremeLekara(id, vreme);
        }
    }
}
