using Bolnica.utils;
using Kontroler;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for PageOcenaAplikacije.xaml
    /// </summary>
    public partial class PageOcenaAplikacije : Page
    {
        public PageOcenaAplikacije()
        {
            InitializeComponent();
            btnPomoc.Visibility = App.vidljivostPomoci;
        }

        private void DodajKomentar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidirajUnos())
            {
                FeedbackKontroler kontroler = new FeedbackKontroler();
                kontroler.DodajFeedbackSekretara(App.IdUlogovanogKorisnika, tbKomentar.Text);
                MessageBox.Show("Uspešno ste dodali komentar.");
            }
            else
            {
                MessageBox.Show("Niste napisali komentar.");
            }
        }

        private bool ValidirajUnos()
        {
            if(String.IsNullOrWhiteSpace(tbKomentar.Text))
            {
                return false;
            }

            return true;
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp("Ime");

            }
        }
    }
}
