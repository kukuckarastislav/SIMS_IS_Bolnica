using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TerminProstorije
    {
        public int Id {get; set;}
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
        public int IdProstorije1 { get; set; }
        public int IdProstorije2 { get; set; }      // potrebno kod premestanje opreme prostorija -> prostorija
        public int IdZdravstveneUsluge { get; set; }  // ta bi bili povezani sa zdravstvenom uslugom
        public TipTerminaProstorije tipTerminaProstorije { get; set; }
        public bool PreraspodelaIzvrsena { get; set; }      // true - izvrsili smo preraspodelu, false - jos nismo prebacili staticku opremu iz invetara u inventar
        public List<TransferOpreme> ListaTransferOpreme { get; set; }   // ovo se koristi kad je tipTerminaProstorije premestanje 
        public TransformacijaProstorijeParametri TransformacijaProstorijeParam { get; set; }

        public TerminProstorije(int id, DateTime pocetak, DateTime kraj, int idProstorije1, int idProstorije2, 
            int idZdravstveneUsluge, TipTerminaProstorije tipTerminaProstorije, 
            bool preraspodelaIzvrsena, List<TransferOpreme> listaTransferOpreme,
            TransformacijaProstorijeParametri transformacijaProstorijeParam)
        {
            Id = id;
            Pocetak = pocetak;
            Kraj = kraj;
            IdProstorije1 = idProstorije1;
            IdProstorije2 = idProstorije2;
            IdZdravstveneUsluge = idZdravstveneUsluge;
            this.tipTerminaProstorije = tipTerminaProstorije;
            PreraspodelaIzvrsena = preraspodelaIzvrsena;
            ListaTransferOpreme = listaTransferOpreme;
            TransformacijaProstorijeParam = transformacijaProstorijeParam;
        }

        public bool isPreraspodela()
        {
            return (tipTerminaProstorije == TipTerminaProstorije.PreraspodelaInventaraPiM ||
                    tipTerminaProstorije == TipTerminaProstorije.PreraspodelaInventaraPiP);
        }
    }
}
