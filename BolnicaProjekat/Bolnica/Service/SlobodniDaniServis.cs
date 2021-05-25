using Bolnica.DTO;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class SlobodniDaniServis
    {
        public SlobodniDaniServis()
        {

        }

        public void DodajSlobodanDan(int idLekara,DateTime dan)
        {
            SlobodniDaniDTO dani = GetDaniLekara(idLekara);
            if (!jelImaDane(idLekara))
                SlobodniDaniRepozitorijum.GetInstance.DodajOdmor(new SlobodniDani(SlobodniDaniRepozitorijum.GetInstance.GetNewId(), idLekara, new List<DateTime>()));
            SlobodniDaniRepozitorijum.GetInstance.DodajDanLekaru(idLekara, dan);
        }

        public SlobodniDani KonvertujUmodel(SlobodniDaniDTO dto)
        {
            return new SlobodniDani(dto.Id, dto.LekarId, dto.Dani);
        }

        public SlobodniDaniDTO KonvertujUDTO(SlobodniDani dani)
        {
            SlobodniDaniDTO dto = new SlobodniDaniDTO();
            dto.Id = dani.Id;
            dto.LekarId = dani.LekarId;
            dto.Dani = dani.Dani;
            return dto;
        }

        public SlobodniDaniDTO GetDaniLekara(int idLekara)
        {
            ObservableCollection<SlobodniDani> sviDani = SlobodniDaniRepozitorijum.GetInstance.GetAll();
            foreach (SlobodniDani dan in sviDani)
            {
                if (dan.LekarId == idLekara)
                {
                    return KonvertujUDTO(dan);
                }
            }
            return new SlobodniDaniDTO();
        }

        public bool jelImaDane(int idLekara)
        {
            ObservableCollection<SlobodniDani> sviDani = SlobodniDaniRepozitorijum.GetInstance.GetAll();
            foreach (SlobodniDani dan in sviDani)
            {
                if (dan.LekarId == idLekara)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
