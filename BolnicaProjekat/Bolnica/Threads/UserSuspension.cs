using System.Collections.Generic;
using Interface;
using Repozitorijum;
using Model;
using System;
using System.Threading;

namespace Threads
{
    class UserSuspension : ISubject
    {
        private List<IObserver> _observers;

        private KorisnickaAktivnostRepozitorijum _repository;
        private readonly TimeSpan SuspensionPeriod = new TimeSpan(14, 0, 0, 0, 0);
        public int Patientid { get; set; }

        public UserSuspension()
        {
            _observers = new List<IObserver>();
            _repository = KorisnickaAktivnostRepozitorijum.GetInstance;
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

        public void ThreadSuspension()
        {
            while (true)
            {
                foreach (Aktivnost p in _repository.GetAllSuspenzije())
                {
                    if (DateTime.Compare(p.Datum + SuspensionPeriod, DateTime.Now) <= 0)
                    {
                        Patientid = p.IdPacijenta;
                        Notify();
                    }
                }

                Thread.Sleep(60 * 1000);      // na svkaih 60 sekundi   
            }
        }
    }
}
