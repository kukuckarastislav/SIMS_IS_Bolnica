using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using DTO;
using Model;
using System.Collections.ObjectModel;
using Bolnica.DTO;

namespace Controller
{
    class SlobodniDaniKontroler
    {
        private SlobodniDaniServis servisSlobodnihDana;
        public SlobodniDaniKontroler()
        {
            servisSlobodnihDana = new SlobodniDaniServis();
        }

        public SlobodniDaniDTO GetDaniLekara(int idLekara)
        {
            return servisSlobodnihDana.GetDaniLekara(idLekara);
        }

        public void DodajSlobodniDan(int idLekara, DateTime dan)
        {
            servisSlobodnihDana.DodajSlobodanDan(idLekara,dan);
        }

        public void ObrisiSlobodanDan(int idLekara, DateTime dan)
        {
            servisSlobodnihDana.ObrisiSlobodanDan(idLekara, dan);
        }

    }
}
