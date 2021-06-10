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

namespace Bolnica.view.upravnik.Podesavanje
{
    /// <summary>
    /// Interaction logic for FeedBackForma.xaml
    /// </summary>
    public partial class FeedBackForma : Window
    {
        public FeedBackForma()
        {
            InitializeComponent();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Posalji_Click(object sender, RoutedEventArgs e)
        {
            FeedbackKontroler kontroler = new FeedbackKontroler();
            kontroler.DodajFeedbackUpravnika(App.IdUlogovanogKorisnika, feedback.Text);
            this.Close();
        }
    }
}
