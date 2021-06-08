using Kontroler;
using Model;
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
using DTO;

namespace Bolnica.view.lekar
{
    /// <summary>
    /// Interaction logic for FeedBack.xaml
    /// </summary>
    public partial class FeedBack : Page
    {
        private view.lekar.GlavniMeni refGlavniMeni;
        private LekarDTO LekarDTO;
        public FeedBack(LekarDTO LekarDTO)
        {
            this.LekarDTO = LekarDTO;
            InitializeComponent();
        }

        private void GlavniMeniButton(object sender, RoutedEventArgs e)
        {
            if (this.LekarDTO != null)
            {
                refGlavniMeni = new view.lekar.GlavniMeni(LekarDTO);
                NavigationService.Navigate(refGlavniMeni);
            }
        }

        private void btnPosaljiFeedBack_Click(object sender, RoutedEventArgs e)
        {
            FeedbackKontroler kontroler = new FeedbackKontroler();
            kontroler.DodajFeedbackLekara(LekarDTO.Id, txtFeedBack.Text);
        }
    }
}
