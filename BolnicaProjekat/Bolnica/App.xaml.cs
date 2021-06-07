using Bolnica.view.sekretar;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    
    public partial class App : Application
    {
        public static Korisnik ulogovaniKorisnik;
        public static int IdUlogovanogKorisnika;
        public static bool prikaziHelp = true;
        //public static Visibility vidljivostPomoci = Visibility.Hidden;
        public static Visibility vidljivostPomoci = Visibility.Visible;
        public static SekretarHome stranicaSekretara;

        private String someText = "default";
 
       public String SomeText
       {
           get { return this.someText; }
           set { this.someText = value; }
       }
    }
}
