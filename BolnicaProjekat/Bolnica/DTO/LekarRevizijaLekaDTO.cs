using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LekarRevizijaLekaDTO
    {
        public LekarRevizijaLekaDTO(int idLekara, string imePrezimeLekara, string specijalizacija, string statusRevizije)
        {
            IdLekara = idLekara;
            ImePrezimeLekara = imePrezimeLekara;
            Specijalizacija = specijalizacija;
            StatusRevizije = statusRevizije;
        }

        public LekarRevizijaLekaDTO(LekarRevizijaLekaDTO copyLekarDTO)
        {
            IdLekara = copyLekarDTO.IdLekara;
            ImePrezimeLekara = copyLekarDTO.ImePrezimeLekara;
            Specijalizacija = copyLekarDTO.Specijalizacija;
            StatusRevizije = copyLekarDTO.StatusRevizije;
        }

        public int IdLekara { get; set; }
        public string ImePrezimeLekara { get; set; }
        public string Specijalizacija { get; set; }
        public string StatusRevizije { get; set; }


    }
}
