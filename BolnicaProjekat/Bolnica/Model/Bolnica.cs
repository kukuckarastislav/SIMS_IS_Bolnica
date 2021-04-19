/***********************************************************************
 * Module:  Bolnica.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Bolnica
 ***********************************************************************/

using System;
using System.Collections;

namespace Model
{
   public class Bolnica
   {
        private static Bolnica instance = null;
        public static Bolnica GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Bolnica();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }

        public Bolnica()
        { }

        public int Id { get; set; }
        public string MestoBolnice { get; set; }
        public string NazivBolnice { get; set; }
        // public ArrayList Lekari { get; set; }
        // public ArrayList Upravnici { get; set; }
        //  public ArrayList Sekretari { get; set; }
        //  public ArrayList Pacijenti { get; set; }
        // public ArrayList Prostorije { get; set; }
        // public ArrayList OperacioneSale { get; set; }
        // public ArrayList BolesnickeSobe { get; set; }
        //  public ArrayList SobeZaPregled { get; set; }
        public System.Collections.ObjectModel.ObservableCollection<Model.Pacijent> pacijenti;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ObjectModel.ObservableCollection<Model.Pacijent> GetPacijenti()
        {
            if (pacijenti == null)
                pacijenti = new System.Collections.ObjectModel.ObservableCollection<Model.Pacijent>();
            return pacijenti;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetPacijenti(System.Collections.ObjectModel.ObservableCollection<Model.Pacijent> newPacijenti)
        {
            RemoveAllPacijenti();
            foreach (Pacijent oPacijent in newPacijenti)
                AddPacijenti(oPacijent);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddPacijenti(Pacijent newPacijent)
        {
            if (newPacijent == null)
                return;
            if (this.pacijenti == null)
                this.pacijenti = new System.Collections.ObjectModel.ObservableCollection<Model.Pacijent>();
            if (!this.pacijenti.Contains(newPacijent))
                this.pacijenti.Add(newPacijent);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemovePacijenti(Pacijent oldPacijent)
        {
            if (oldPacijent == null)
                return;
            if (this.pacijenti != null)
                if (this.pacijenti.Contains(oldPacijent))
                    this.pacijenti.Remove(oldPacijent);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllPacijenti()
        {
            if (pacijenti != null)
                pacijenti.Clear();
        }

        public bool EditPacijent(Pacijent oldPacijent)
        {
            if (oldPacijent == null)
                return false;
            if (this.pacijenti != null)
            {
                foreach (Pacijent p in pacijenti)
                {
                    if (p.Jmbg.Equals(oldPacijent.Jmbg))
                    {
                        p.Ime = oldPacijent.Ime;
                        p.Prezime = oldPacijent.Prezime;
                        p.KorisnickoIme = oldPacijent.KorisnickoIme;
                        p.Sifra = oldPacijent.Sifra;
                        p.Telefon = oldPacijent.Telefon;
                        p.DatumRodjenja = oldPacijent.DatumRodjenja;
                        p.Drzavljanstvo = oldPacijent.Drzavljanstvo;
                        p.AdresaStanovanja = oldPacijent.AdresaStanovanja;
                        p.Jmbg = oldPacijent.Jmbg;
                        p.Email = oldPacijent.Email;
                        return true;
                    }
                }
            }
            return false;

        }

        public Pacijent GetPacijent(string jmbg)
        {

            if (this.pacijenti != null)
            {
                foreach (Pacijent p in pacijenti)
                {
                    if (p.Jmbg.Equals(jmbg))
                    {

                        return p;
                    }
                }
            }
            return null;

        }
        /*
        public SobaZaPreglede GetSobaZaPregledeByID(int id)
        {

            if (this.sobeZaPreglede != null)
            {
                foreach (SobaZaPreglede s in sobeZaPreglede)
                {
                    if (s.Id == id)
                    {

                        return s;
                    }
                }
            }
            return null;

        }
        */
        public Lekar getLekarByI(int id)
        {

            if (this.lekari != null)
            {
                foreach (Lekar s in lekari)
                {
                    if (s.Id== id)
                    {
                        return s;
                    }
                }
            }

            return null;

        }







        public System.Collections.ArrayList sekretari;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetSekretari()
        {
            if (sekretari == null)
                sekretari = new System.Collections.ArrayList();
            return sekretari;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetSekretari(System.Collections.ArrayList newSekretari)
        {
            RemoveAllSekretari();
            foreach (Sekretar oSekretar in newSekretari)
                AddSekretari(oSekretar);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddSekretari(Sekretar newSekretar)
        {
            if (newSekretar == null)
                return;
            if (this.sekretari == null)
                this.sekretari = new System.Collections.ArrayList();
            if (!this.sekretari.Contains(newSekretar))
                this.sekretari.Add(newSekretar);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveSekretari(Sekretar oldSekretar)
        {
            if (oldSekretar == null)
                return;
            if (this.sekretari != null)
                if (this.sekretari.Contains(oldSekretar))
                    this.sekretari.Remove(oldSekretar);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllSekretari()
        {
            if (sekretari != null)
                sekretari.Clear();
        }
        public System.Collections.ArrayList upravnici;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetUpravnici()
        {
            if (upravnici == null)
                upravnici = new System.Collections.ArrayList();
            return upravnici;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetUpravnici(System.Collections.ArrayList newUpravnici)
        {
            RemoveAllUpravnici();
            foreach (Upravnik oUpravnik in newUpravnici)
                AddUpravnici(oUpravnik);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddUpravnici(Upravnik newUpravnik)
        {
            if (newUpravnik == null)
                return;
            if (this.upravnici == null)
                this.upravnici = new System.Collections.ArrayList();
            if (!this.upravnici.Contains(newUpravnik))
                this.upravnici.Add(newUpravnik);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveUpravnici(Upravnik oldUpravnik)
        {
            if (oldUpravnik == null)
                return;
            if (this.upravnici != null)
                if (this.upravnici.Contains(oldUpravnik))
                    this.upravnici.Remove(oldUpravnik);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllUpravnici()
        {
            if (upravnici != null)
                upravnici.Clear();
        }
        public System.Collections.ArrayList lekari;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetLekari()
        {
            if (lekari == null)
                lekari = new System.Collections.ArrayList();
            return lekari;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetLekari(System.Collections.ArrayList newLekari)
        {
            RemoveAllLekari();
            foreach (Lekar oLekar in newLekari)
                AddLekari(oLekar);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddLekari(Lekar newLekar)
        {
            if (newLekar == null)
                return;
            if (this.lekari == null)
                this.lekari = new System.Collections.ArrayList();
            if (!this.lekari.Contains(newLekar))
                this.lekari.Add(newLekar);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveLekari(Lekar oldLekar)
        {
            if (oldLekar == null)
                return;
            if (this.lekari != null)
                if (this.lekari.Contains(oldLekar))
                    this.lekari.Remove(oldLekar);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllLekari()
        {
            if (lekari != null)
                lekari.Clear();
        }
        public System.Collections.ObjectModel.ObservableCollection<Model.Prostorija> prostorije;

        public int GetBrojProstorija()
        {
            if (prostorije == null)
                prostorije = new System.Collections.ObjectModel.ObservableCollection<Model.Prostorija>();

            return prostorije.Count;
        }

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ObjectModel.ObservableCollection<Model.Prostorija> GetProstorije()
        {
            if (prostorije == null)
                prostorije = new System.Collections.ObjectModel.ObservableCollection<Model.Prostorija>();
            return prostorije;
        }

        public Prostorija GetProstorijaByID(int idProstorije)
        {
            if (prostorije == null)
                prostorije = new System.Collections.ObjectModel.ObservableCollection<Model.Prostorija>();

            foreach (Prostorija prostroija in prostorije)
            {
                if (prostroija.Id == idProstorije)
                {
                    return prostroija;
                }
            }
            return null;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetProstorije(System.Collections.ObjectModel.ObservableCollection<Model.Prostorija> newProstorije)
        {
            RemoveAllProstorije();
            foreach (Prostorija oProstorija in newProstorije)
                AddProstorije(oProstorija);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddProstorije(Prostorija newProstorija)
        {
            if (newProstorija == null)
                return;
            if (this.prostorije == null)
                this.prostorije = new System.Collections.ObjectModel.ObservableCollection<Model.Prostorija>();
            if (!this.prostorije.Contains(newProstorija))
                this.prostorije.Add(newProstorija);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveProstorije(Prostorija oldProstorija)
        {
            if (oldProstorija == null)
                return;
            if (this.prostorije != null)
                if (this.prostorije.Contains(oldProstorija))
                {
                    this.prostorije.Remove(oldProstorija);
                }
        }

        public void RemoveProstorijeByID(int idProstorije)
        {
            if (this.prostorije == null)
                prostorije = new System.Collections.ObjectModel.ObservableCollection<Model.Prostorija>();
            System.Windows.MessageBox.Show("OCES DA BRISES " + Convert.ToString(idProstorije));
            System.Windows.MessageBox.Show("PRE BRISANJA");
            foreach (Prostorija pro in prostorije)
            {
                System.Windows.MessageBox.Show(Convert.ToString(pro.Id));
            }
            foreach (Prostorija pro in prostorije)
            {
                if (pro.Id == idProstorije)
                {
                    System.Windows.MessageBox.Show("YESSSS");
                    this.prostorije.Remove(pro);
                    break;
                }
            }
            System.Windows.MessageBox.Show("POSLE BRISANJA");
            foreach (Prostorija pro in prostorije)
            {
                System.Windows.MessageBox.Show(Convert.ToString(pro.Id));
            }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllProstorije()
        {
            if (prostorije != null)
                prostorije.Clear();
        }

        /*
        public System.Collections.ObjectModel.ObservableCollection<Model.BolesnickaSoba> bolesnickeSobe;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ObjectModel.ObservableCollection<Model.BolesnickaSoba> GetBolesnickeSobe()
        {
            if (bolesnickeSobe == null)
                bolesnickeSobe = new System.Collections.ObjectModel.ObservableCollection<Model.BolesnickaSoba>();
            return bolesnickeSobe;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetBolesnickeSobe(System.Collections.ObjectModel.ObservableCollection<Model.BolesnickaSoba> newBolesnickeSobe)
        {
            RemoveAllBolesnickeSobe();
            foreach (BolesnickaSoba oBolesnickaSoba in newBolesnickeSobe)
                AddBolesnickeSobe(oBolesnickaSoba);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddBolesnickeSobe(BolesnickaSoba newBolesnickaSoba)
        {
            if (newBolesnickaSoba == null)
                return;
            if (this.bolesnickeSobe == null)
                this.bolesnickeSobe = new System.Collections.ObjectModel.ObservableCollection<Model.BolesnickaSoba>();
            if (!this.bolesnickeSobe.Contains(newBolesnickaSoba))
                this.bolesnickeSobe.Add(newBolesnickaSoba);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveBolesnickeSobe(BolesnickaSoba oldBolesnickaSoba)
        {
            if (oldBolesnickaSoba == null)
                return;
            if (this.bolesnickeSobe != null)
                if (this.bolesnickeSobe.Contains(oldBolesnickaSoba))
                    this.bolesnickeSobe.Remove(oldBolesnickaSoba);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllBolesnickeSobe()
        {
            if (bolesnickeSobe != null)
                bolesnickeSobe.Clear();
        }

        public System.Collections.ObjectModel.ObservableCollection<Model.SobaZaPreglede> sobeZaPreglede;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ObjectModel.ObservableCollection<Model.SobaZaPreglede> GetSobeZaPreglede()
        {
            if (sobeZaPreglede == null)
                sobeZaPreglede = new System.Collections.ObjectModel.ObservableCollection<Model.SobaZaPreglede>();
            return sobeZaPreglede;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetSobeZaPreglede(System.Collections.ObjectModel.ObservableCollection<Model.SobaZaPreglede> newSobeZaPreglede)
        {
            RemoveAllSobeZaPreglede();
            foreach (SobaZaPreglede oSobaZaPreglede in newSobeZaPreglede)
                AddSobeZaPreglede(oSobaZaPreglede);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddSobeZaPreglede(SobaZaPreglede newSobaZaPreglede)
        {
            if (newSobaZaPreglede == null)
                return;
            if (this.sobeZaPreglede == null)
                this.sobeZaPreglede = new System.Collections.ObjectModel.ObservableCollection<Model.SobaZaPreglede>();
            if (!this.sobeZaPreglede.Contains(newSobaZaPreglede))
                this.sobeZaPreglede.Add(newSobaZaPreglede);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveSobeZaPreglede(SobaZaPreglede oldSobaZaPreglede)
        {
            if (oldSobaZaPreglede == null)
                return;
            if (this.sobeZaPreglede != null)
                if (this.sobeZaPreglede.Contains(oldSobaZaPreglede))
                    this.sobeZaPreglede.Remove(oldSobaZaPreglede);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllSobeZaPreglede()
        {
            if (sobeZaPreglede != null)
                sobeZaPreglede.Clear();
        }

        public System.Collections.ObjectModel.ObservableCollection<Model.OperacionaSala> operacioneSale;


        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ObjectModel.ObservableCollection<Model.OperacionaSala> GetOperacioneSale()
        {
            if (operacioneSale == null)
                operacioneSale = new System.Collections.ObjectModel.ObservableCollection<Model.OperacionaSala>();
            return operacioneSale;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetOperacioneSale(System.Collections.ObjectModel.ObservableCollection<Model.OperacionaSala> newOperacioneSale)
        {
            RemoveAllOperacioneSale();
            foreach (OperacionaSala oOperacionaSala in newOperacioneSale)
                AddOperacioneSale(oOperacionaSala);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddOperacioneSale(OperacionaSala newOperacionaSala)
        {
            if (newOperacionaSala == null)
                return;
            if (this.operacioneSale == null)
                this.operacioneSale = new System.Collections.ObjectModel.ObservableCollection<Model.OperacionaSala>();
            if (!this.operacioneSale.Contains(newOperacionaSala))
                this.operacioneSale.Add(newOperacionaSala);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveOperacioneSale(OperacionaSala oldOperacionaSala)
        {
            if (oldOperacionaSala == null)
                return;
            if (this.operacioneSale != null)
                if (this.operacioneSale.Contains(oldOperacionaSala))
                    this.operacioneSale.Remove(oldOperacionaSala);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllOperacioneSale()
        {
            if (operacioneSale != null)
                operacioneSale.Clear();
        }


        */

    }
}