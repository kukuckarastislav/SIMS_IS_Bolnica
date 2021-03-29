using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.view.upravnik.prostorije
{
    /// <summary>
    /// Interaction logic for prostorije.xaml
    /// </summary>
    public partial class Prostorije : Page
    {

        //public List<Model.Prostorija> Prostorijee { get; set; }
        //public ArrayList Prostorijee { get; set; }
        public ObservableCollection<Model.Prostorija> Prostorijee { get; set; }
        public int colNum = 0;

        public Prostorije()
        {
            /*
            Prostorijee = new List<Model.Prostorija>(Model.Bolnica.GetInstance().GetBrojProstorija());
            foreach(Model.Prostorija p in Model.Bolnica.GetInstance().GetProstorije())
            {
                Prostorijee.Add(p);
            }
            */
            Prostorijee = new ObservableCollection<Model.Prostorija>();
            foreach (Model.Prostorija p in Model.Bolnica.GetInstance().GetProstorije())
            {
                Prostorijee.Add(p);
            }
            
            //Prostorijee = Model.Bolnica.GetInstance().GetProstorije();
            InitializeComponent();
            this.datagrid1.ItemsSource = Prostorijee;
        }

        /*
        private void generateColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            colNum++;
            if (colNum == 3)
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }
        */
    }
}
