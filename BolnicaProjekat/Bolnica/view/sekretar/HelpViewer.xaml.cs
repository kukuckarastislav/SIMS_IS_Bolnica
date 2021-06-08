using System;
using System.Collections.Generic;
using System.IO;
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

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for HelpViewer.xaml
    /// </summary>
    public partial class HelpViewer : Window
    {
        public HelpViewer(string key)
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            string curDir = Directory.GetCurrentDirectory();
            curDir = curDir.Substring(0, curDir.Length - 9);
            curDir += "view\\sekretar";
            //MessageBox.Show(curDir);
            string path = String.Format("{0}/help/{1}.htm", curDir, key);
            if (!File.Exists(path))
            {
                key = "error";
            }
            Uri u = new Uri(String.Format("file:///{0}/help/{1}.htm", curDir, key));
            //MessageBox.Show(u.ToString());
            wbHelp.Navigate(u);
        }
    }
}
