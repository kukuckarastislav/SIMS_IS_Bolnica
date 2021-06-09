using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PodesavanjaDTO
    {
        public int Id { get; set; }
        public bool JelBioUlogovan { get; set; }
        public PodesavanjaDTO(int id, bool jelBioUlogovan)
        {
            Id = id;
            JelBioUlogovan = jelBioUlogovan;
        }
    }
}
