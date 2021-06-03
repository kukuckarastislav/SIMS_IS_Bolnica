using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;
using Repozitorijum;
using Model;
using System.Threading;

namespace Threads
{
    class MedicationConsumption : ISubject
    {
        private List<IObserver> _observers;
        private PodsjetnikRepozitorijum _repository;
        public int Reminderid { get; set; }

        public MedicationConsumption()
        {
            _repository = PodsjetnikRepozitorijum.GetInstance;
            _observers = new List<IObserver>();
        }
        public void Notify()
        {
            foreach (IObserver o in _observers)
                o.Update(this);
        }

        public void Register(IObserver o)
        {
            _observers.Add(o);
        }

        public void Unregister(IObserver o)
        {
            _observers.Remove(o);
        }

        public void ThreadPodsjetnik()
        {
            List<Podsjetnik> lista = _repository.GetAll();
            while (true)
            {
                foreach (Podsjetnik p in lista)
                {
                    if (!p.Vidljiv && DateTime.Compare(p.VrijemePojavljivanja, DateTime.Now) <= 0)
                    {
                        Reminderid = p.Id;
                        Notify();
                    }
                }

                Thread.Sleep(60 * 1000);      // na svkaih 60 sekundi   
            }

        }


    }
}
