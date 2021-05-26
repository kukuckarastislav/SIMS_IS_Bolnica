using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DTO;
using Model;

namespace Servis
{
    class InventariSerivs
    {

        public Repozitorijum.InventariRepozitorijum InventarRepozitorijumRef { get; set; }
        private ProstorijeServis prostorijeServisObjaket;

        public InventariSerivs()
        {
            InventarRepozitorijumRef = Repozitorijum.InventariRepozitorijum.GetInstance;
            prostorijeServisObjaket = new ProstorijeServis();
        }

        public List<Inventar> GetAllInventar()
        {
            return InventarRepozitorijumRef.GetAll();
        }

        public Inventar GetInventarById(int id)
        {
            List<Inventar> li = GetAllInventar();
            foreach (Inventar inv in li)
            {
                if (inv.Id == id)
                {
                    return inv;
                }
            }
            return null;
        }

        public ObservableCollection<Oprema> GetTipOpremeByIdInventaraObservable(int id, TipOpreme tipOpreme)
        {
            Inventar inv = GetInventarById(id);         // ako ne nadje inventar baca null pa tu puca program
            if (inv == null)
            {
                MessageBox.Show("Nije pronadjen trazeni invetnar/magacin");
                return new ObservableCollection<Oprema>();
            }
            List<Oprema> oprema = inv.GetOpremaByTip(tipOpreme);

            ObservableCollection<Oprema> obsOP = new ObservableCollection<Oprema>();
            foreach (Oprema op in oprema)
            {
                obsOP.Add(op);
            }

            return obsOP;
        }


        public Oprema DodajOpremuUInventarById(int idInventara,
                                            TipOpreme tipOpreme,
                                            string naziv,
                                            string sifra,
                                            int kolicina,
                                            double cena,
                                            string opis)
        {
            Inventar inv = GetInventarById(idInventara);
            if (inv == null)
            {
                MessageBox.Show("Ne postoji inventar sa tim ID");
                return null;
            }
            Oprema oprema = new Oprema(-1, sifra, naziv, tipOpreme, opis, kolicina, cena, inv.Id);
            inv.LOprema.Add(oprema);
            InventarRepozitorijumRef.AzurirajInventar(inv);
            return oprema;
        }



        public Oprema IzmeniOpremuUInventarById(int idInventara,
                                                Oprema editOprema,
                                                string naziv,
                                                string sifra,
                                                int kolicina,
                                                double cena,
                                                string opis)
        {
            Inventar inv = GetInventarById(idInventara);
            if (inv == null)
            {
                MessageBox.Show("Ne postoji inventar sa tim ID");
                return null;
            }
            editOprema.Naziv = naziv;
            editOprema.Sifra = sifra;
            editOprema.Cena = cena;
            editOprema.Kolicina = kolicina;
            editOprema.Opis = opis;

            InventarRepozitorijumRef.AzurirajInventar(inv);
            return editOprema;
        }

        

        /*
         * parametar skroz nam sluzi ako zelimo obrisati neku opremu na nivou celog sistema
         * */
        public Oprema ObrisiOpremuInvetara(int idInventara, Oprema oprema, bool skroz)
        {
            Inventar inv = GetInventarById(idInventara);
            if (inv == null)
            {
                MessageBox.Show("Ne postoji inventar sa tim ID");
                return null;
            }

            if (!skroz)
            {
                inv.ObrisiOpremuBySifra(oprema.Sifra);
                InventarRepozitorijumRef.AzurirajInventar(inv);
            }
            else
            {
                // brisanje na nivou celog sistema
                foreach (Inventar inventar in GetAllInventar())
                {
                    inventar.ObrisiOpremuBySifra(oprema.Sifra);
                }
                InventarRepozitorijumRef.AzurirajInventar();
            }



            return oprema;
        }


        public Oprema preraspodelaOpreme(int idPocetnogInventara, int idKrajnjegInventara, Oprema oprema, int kolicina)
        {
            Inventar pocetniInventar = GetInventarById(idPocetnogInventara);
            Inventar krajnjiInventar = GetInventarById(idKrajnjegInventara);

            if(pocetniInventar == null || krajnjiInventar == null)
            {
                return null;
            }

            pocetniInventar.oduzmiOpremu(oprema, kolicina);
            krajnjiInventar.dodajOpremu(oprema, kolicina);
            InventarRepozitorijumRef.AzurirajInventar();
            return oprema;
        }

        public bool preraspodelaOpreme(int idPocetnogInventara, int idKrajnjegInventara, string sifraOprema, int kolicina)
        {
            Inventar pocetniInventar = GetInventarById(idPocetnogInventara);
            Inventar krajnjiInventar = GetInventarById(idKrajnjegInventara);

            if (pocetniInventar == null || krajnjiInventar == null)
                return false;

            Oprema oprema = pocetniInventar.oduzmiOpremu(sifraOprema, kolicina);
            if (oprema == null) return false;
            krajnjiInventar.dodajOpremu(oprema, kolicina);
            InventarRepozitorijumRef.AzurirajInventar();
            return true;
        }

        public bool preraspodelaOpreme(TransferOpreme transferOpreme)
        {
            return preraspodelaOpreme(transferOpreme.IdInventar1, transferOpreme.IdInventar2, transferOpreme.SifraOpreme, transferOpreme.KolicinaOpreme);
        }

        public ObservableCollection<OpremaDTO> GetOpremaByNaprednaPretraga(ParametriNaprednePretrageDTO parametriPretrage)
        {
            ObservableCollection<OpremaDTO> opremeDTO = new ObservableCollection<OpremaDTO>(); 
            if (parametriPretrage == null)
            {
                MessageBox.Show("Alo poslao si null vracam praznu listu "); 
                return opremeDTO;
            }

            List<Inventar> inventari = GetAllInventar();

            foreach(Inventar inventar in inventari)
            {
                Prostorija prostorija = null;
                bool prostorijaZadovoljava = false;
                if (inventar.IdProstorije == -1)
                {
                    // magacin
                    prostorijaZadovoljava = parametriPretrage.CheckMagacin;
                }
                else
                {
                    // prostorija
                    prostorija = prostorijeServisObjaket.GetProstorijaById(inventar.IdProstorije);
                    if (prostorija.TipProstorije == TipProstorije.Bolnicka && parametriPretrage.CheckBolnicka)
                    {
                        prostorijaZadovoljava = true;
                    }
                    else if (prostorija.TipProstorije == TipProstorije.OpracionaSala && parametriPretrage.CheckOpracionaSala)
                    {
                        prostorijaZadovoljava = true;
                    }
                    else if (prostorija.TipProstorije == TipProstorije.SobaZaPreglede && parametriPretrage.CheckSobaZaPreglede)
                    {
                        prostorijaZadovoljava = true;
                    }
                    else if (prostorija.TipProstorije == TipProstorije.BolesnickaSoba && parametriPretrage.CheckBolesnickaSoba)
                    {
                        prostorijaZadovoljava = true;
                    }
                }
                
                
                

                if (prostorijaZadovoljava)
                {
                    foreach(Oprema op in inventar.LOprema)
                    {
                        bool odgovaraTipOpreme = false;
                        if (op.Tip == TipOpreme.Staticka && parametriPretrage.CheckStaticka) odgovaraTipOpreme = true;
                        else if (op.Tip == TipOpreme.Dinamicka && parametriPretrage.CheckDinamicka) odgovaraTipOpreme = true;

                        if (odgovaraTipOpreme && 
                            op.Naziv.Contains(parametriPretrage.PretragaNaziv) &&
                            op.Sifra.Contains(parametriPretrage.PretragaSifra) &&
                            (op.Kolicina >= parametriPretrage.KolicinaOd && op.Kolicina <= parametriPretrage.KolicinaDo) &&
                            (op.Cena >= parametriPretrage.CenaOd && op.Cena <= parametriPretrage.CenaDo))
                        {
                            if (prostorija == null)
                            {
                                opremeDTO.Add(new OpremaDTO(op, "Magacin"));
                            }
                            else
                            {
                                opremeDTO.Add(new OpremaDTO(op, prostorija.BrojSprat));
                            }
                            
                        }
                    }
                }

            }


            return opremeDTO;
        }


        public bool PrebaciSvuOpremu(int idPocetnogInventara, int idKrajnjegInventara)
        {
            Inventar pocetniInventar = GetInventarById(idPocetnogInventara);
            Inventar krajnjiInventar = GetInventarById(idKrajnjegInventara);

            foreach(Oprema oprema in pocetniInventar.LOprema)
            {
                krajnjiInventar.dodajOpremu(oprema, oprema.Kolicina);
            }

            pocetniInventar.LOprema = new List<Oprema>();

            InventarRepozitorijumRef.AzurirajInventar();
            return true;
        }

        public bool ObrisiInventarById(int IdInventar)
        {
            Inventar inventar = GetInventarById(IdInventar);
            InventarRepozitorijumRef.ObrisiInventar(inventar);
            return true;
        }

    }
}
