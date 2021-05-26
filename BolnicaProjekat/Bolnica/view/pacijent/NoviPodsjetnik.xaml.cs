using System;
using System.Windows;
using System.Windows.Controls;
using Model;
using DTO;
using Kontroler;

namespace Bolnica.view.pacijent
{
    public partial class NoviPodsjetnik : Window
    {
        public PacijentDTO Pacijent { get; set; }
        private PodsjetnikKontroler Kontroler;
        private DateTime Od;
        private DateTime Do;
        public NoviPodsjetnik(PacijentDTO Pacijent,String text)
        {
            Kontroler = new PodsjetnikKontroler();
            this.Pacijent = Pacijent;
            InitializeComponent();
            sadrzaj.Text = text;
            Od = DateTime.Now;
            Do = Od + new TimeSpan(1, 0, 0, 0, 0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = DateTime.Now;
            int Sati = Convert.ToInt32(sati.Text);
            int Minute = Convert.ToInt32(minute.Text);
            string AP = ap.Text;

            if (AP.Equals("PM"))
                Sati += 12;

            DateTime vrijeme = new DateTime(date.Year, date.Month, date.Day, Sati, Minute, 00);
            PodsjetnikParametriDTO parametri = new PodsjetnikParametriDTO(Pacijent.Id,vrijeme,sadrzaj.Text,Od,Do);
            Kontroler.DodajPodsjetnik(parametri);
            this.Close();
        }

        private void od_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Od=odDatum.SelectedDate.Value;
        }

        private void do_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Do=doDatum.SelectedDate.Value;
        }
    }
}
