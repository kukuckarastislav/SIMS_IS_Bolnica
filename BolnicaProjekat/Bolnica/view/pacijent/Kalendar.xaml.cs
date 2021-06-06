using System;
using System.Collections.Generic;
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
using DTO;
using Controller;

namespace Bolnica.view.pacijent
{
    /// <summary>
    /// Interaction logic for Kalendar.xaml
    /// </summary>
    public partial class Kalendar : Window
    {
        ZdravstvenaUslugaKontroler Kontroler;
        PacijentDTO Pacijent;
        public Kalendar(PacijentDTO Pacijent)
        {
            this.Pacijent = Pacijent;
            Kontroler = new ZdravstvenaUslugaKontroler();
            InitializeComponent();
            List<string> months = new List<String> { "January", "Febuary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            cboMonth.ItemsSource = months;

            for (int i = -50; i < 50; i++)
                cboYear.Items.Add(DateTime.Today.AddYears(i).Year);

            cboMonth.SelectedItem = months.FirstOrDefault(w => w == DateTime.Today.ToString());
            cboYear.SelectedItem = DateTime.Today.Year;

            cboMonth.SelectionChanged += (o, e) => RefreshCalendar();
            cboYear.SelectionChanged += (o, e) => RefreshCalendar();

        }

        private void RefreshCalendar()
        {
            if (cboMonth.SelectedItem == null) return;
            if (cboYear.SelectedItem == null) return;

            int year = (int)cboYear.SelectedItem;
            int month = cboMonth.SelectedIndex + 1;

            DateTime targetDate = new DateTime(year, month, 1);

            List<DateTime> patiensAppointments = new List<DateTime>();
            foreach (ZdravstvenaUslugaDTO z in Kontroler.GetTerminiPacijenta(Pacijent.Id))
                patiensAppointments.Add(z.Termin.Pocetak);
            Calendar.SetPatiensAppointments(patiensAppointments);
            Calendar.BuildCalendar(targetDate);


        }

        private void Calendar_DayChanged(object sender, MyCalendar.Calendar.DayChangedEventArgs e)
        {

        }

        private void Calendar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
