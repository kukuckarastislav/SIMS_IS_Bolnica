using Bolnica.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repozitorijum;

namespace Bolnica.Service
{
    class LekoviRevizijaServis : ILekoviRevizija
    {
        public RevizijaLeka GetRevizijaLekaByIdLekara(int idLekara, int idLeka)
        {
            Lek lek = LekoviRepozitorijum.GetInstance.GetLekById(idLeka);
            return lek.GetRevizijaLekaByIdLekara(idLekara);

        }

        public bool JeOdobrenLek(int idLeka)
        {
            Lek lek = LekoviRepozitorijum.GetInstance.GetLekById(idLeka);
            return lek.JeOdobren();
        }

        public bool PostojiLekarURevizijiLeka(int idLekara, int idLeka)
        {
            Lek lek = LekoviRepozitorijum.GetInstance.GetLekById(idLeka);
            return lek.PostojiLekarURevizijiByID(idLekara);
        }
    }
}
