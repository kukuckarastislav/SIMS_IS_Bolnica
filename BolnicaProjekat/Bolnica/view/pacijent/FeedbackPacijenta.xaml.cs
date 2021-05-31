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
using Kontroler;
using DTO;

namespace Bolnica.view.pacijent
{
    /// <summary>
    /// Interaction logic for FeedbackPacijenta.xaml
    /// </summary>
    public partial class FeedbackPacijenta : Window
    {
        private String Text;
        private PacijentDTO Pacijent;
        public FeedbackPacijenta(PacijentDTO Pacijent)
        {
            InitializeComponent();
            this.Pacijent = Pacijent;
        }

        private void potvrdi_Click(object sender, RoutedEventArgs e)
        {
            FeedbackKontroler kontroler = new FeedbackKontroler();
            kontroler.DodajFeedbackPacijenta(Pacijent.Id,feedback.Text);
            this.Close();
        }
    }
}
