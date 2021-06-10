using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Interface
{
    public interface IBaza
    {
        List<Prostorija> UcitajPodatke();
        void SacuvajPodatke(List<Prostorija> prostorije);

    }
}
