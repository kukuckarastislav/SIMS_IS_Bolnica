using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Interface
{
    interface ILekoviRevizija
    {
        bool PostojiLekarURevizijiLeka(int idLekara,int idLeka);
        bool JeOdobrenLek(int idLeka);
        RevizijaLeka GetRevizijaLekaByIdLekara(int idLekara, int idLeka);
    }
}
