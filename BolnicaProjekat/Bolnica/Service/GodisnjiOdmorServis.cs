using Bolnica.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DTO;
using System.Collections.ObjectModel;
using Repozitorijum;

namespace Service
{
    class GodisnjiOdmorServis
    {
        public GodisnjiOdmorServis()
        {

        }

        public GodisnjiOdmorDTO DodajGodisnjiOdmor(GodisnjiOdmorDTO odmor)
        {
            odmor.Id = GodisnjiOdmorRepozitorijum.GetInstance.GetNewId();
            GodisnjiOdmorRepozitorijum.GetInstance.DodajOdmor(konvertujUmodel(odmor));
            return odmor;
        }

        public GodisnjiOdmor konvertujUmodel(GodisnjiOdmorDTO dto)
        {
            return new GodisnjiOdmor(dto.Id, dto.LekarId, dto.Period);
        }

        public GodisnjiOdmorDTO konvertujUDTO(GodisnjiOdmor odmor)
        {
            GodisnjiOdmorDTO dto = new GodisnjiOdmorDTO();
            dto.Id = odmor.Id;
            dto.LekarId = odmor.LekarId;
            dto.Period = odmor.Period;
            return dto;
        }

        public ObservableCollection<GodisnjiOdmorDTO> getOdmoriLekara(int idLekara)
        {
            ObservableCollection<GodisnjiOdmor> sviOdmori = GodisnjiOdmorRepozitorijum.GetInstance.GetAll();
            ObservableCollection<GodisnjiOdmorDTO> odmoriDTO = new ObservableCollection<GodisnjiOdmorDTO>();
            foreach (GodisnjiOdmor odmor in sviOdmori)
            {
                if(odmor.LekarId == idLekara)
                {
                    odmoriDTO.Add(konvertujUDTO(odmor));
                }
            }
            return odmoriDTO;
        }

        public void IzmeniRadnoVremeLekara(int id, RadnoVreme vreme)
        {
            LekarRepozitorijum.GetInstance.IzmeniRadnoVremeLekara(id, vreme);
        }

        public void obrisiGodisnjiOdmor(int id)
        {
            GodisnjiOdmorRepozitorijum.GetInstance.obrisiGodisnjiOdmor(id);
        }

        public RadnoVreme getRadnoVremeLekara(int id)
        {
            return LekarRepozitorijum.GetInstance.getRadnoVremeLekara(id);
        }
    }
}
