using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model;

namespace Bolnica.view.pacijent
{
    /// <summary>
    /// Interaction logic for NotifikacijePacijent.xaml
    /// </summary>
    public partial class NotifikacijePacijent : Window
    {
        ObservableCollection<Notifikacija> Notifikacije { get; set; }
        ObservableCollection<Notifikacija> Reminders { get; set; }
        public NotifikacijePacijent()
        {
            Notifikacije = Repozitorijum.NotifikacijaRepozitorijum.GetInstance.GetByPatientId(1);
            Reminders = new ObservableCollection<Notifikacija>();
            //prvo cemo prikazati samo normalne notifikacije a remindere u njihovu listu

            bool zavrsio = false;
            while(!zavrsio)
            {
                zavrsio = true;
                foreach (Notifikacija n in Notifikacije)
                {
                    if (n.Id < 0)
                    {
                        Notifikacije.Remove(n);
                        Reminders.Add(n);
                        break;
                    }
                }
            }

            //Notifikacije koje su se vec trebale pojaviti dodaj u listu sa sve datum kad su se trebale pojaviti a za ostale dodaj cekanje da se pojave
            
            foreach (Notifikacija n in Reminders)
            {
                string opis = n.Opis;
                char regex = '*';
                string[] dijelovi = opis.Split(regex);
                DateTime pojavljivanjeNotifikacije = DateTime.ParseExact(dijelovi[0], "yyyy-MM-dd HH:mm tt", null);
                DateTime now = DateTime.Now;
               // MessageBox.Show(pojavljivanjeNotifikacije.ToString()+ "uporedjujemo sa "+now.ToString());

                if (DateTime.Compare(pojavljivanjeNotifikacije,now) <= 0) //znaci vec je trebala da se pojavi,ovaj slucaj radi
                {
                    Notifikacije.Add(n);
                }              
                else if(DateTime.Compare(pojavljivanjeNotifikacije,now) > 0)
                {
                    TimeSpan ts = pojavljivanjeNotifikacije.Subtract(now); 
                    UseDelay(n, ts);
                }              

            }
            
            InitializeComponent();
            this.listaNotifikacija.ItemsSource = Notifikacije;
        }

        async Task UseDelay(Notifikacija n, TimeSpan ts)
        {
            await Task.Delay(ts);
           // MessageBox.Show("Nova notifikacija");
            Notifikacije.Add(n);
            this.listaNotifikacija.ItemsSource = Notifikacije;
        }
    }
}
