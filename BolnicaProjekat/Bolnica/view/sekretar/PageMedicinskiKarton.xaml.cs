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

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for PageMedicinskiKarton.xaml
    /// </summary>
    public partial class PageMedicinskiKarton : Page
    {
        public PageMedicinskiKarton(PacijentDTO pacijent)
        {
            InitializeComponent();
        }
    }
}
