using System;
using System.Windows;


namespace Bolnica.view.pacijent
{
    /// <summary>
    /// Interaction logic for PacijentHomeHelp.xaml
    /// </summary>
    public partial class PacijentHomeHelp : Window
    {
        public PacijentHomeHelp()
        {
            InitializeComponent();
            String text = "Sa pocetnog prozora pacijenta pokrecu se sve ostale funkcinalnosti." + Environment.NewLine+
                           "Moguce funkcionalnosti su vezane za termine pacijenta (zakazivanje "+ Environment.NewLine +
                           " pregleda i pregled vec zakazanih termina), za citanje notifikacija" + Environment.NewLine + 
                           "(odnose se na uzimanje lijekova ili obavjestenje da nam je zakazan  " + Environment.NewLine + 
                           "termin od strane lekara ili sekretara), ocjenjivanje lekara(samo onih " + Environment.NewLine + 
                           "sa kojima ste imali interakciju) kao i citanje ocjena i komentara " + Environment.NewLine + 
                           "drugih pacijenata kako biste lakse odlucili kod kog lekara zelite da " + Environment.NewLine + 
                           "zakazete pregled.Svim funkcionalnostima je moguce pristupiti sa linije " + Environment.NewLine + 
                           "menija ili pritiskom na neko od izlozenih dugmadi.U meniju se nalaze i " + Environment.NewLine + 
                           "neke dodatne funkcionalnosti kao sto su odjavljivanje, promjena lozinke " + Environment.NewLine + 
                           "i nekih licnih informacija u meniju Nalog.Pored ovih funkcionalnosti " + Environment.NewLine +
                           "pacijent ima uvid u istoriju svoje bolesti, aktuelnu terapiju i ima " + Environment.NewLine +
                           "mogucnost kreiranja manuelnih podsjetnika iz prozora podsjetnik ili " + Environment.NewLine +
                           "ili prilikom ostavljanja komentara u istoriji bolesti. Vecini ovih " + Environment.NewLine + 
                           "funkcionalnosti je moguce pristupiti i preko tastature koriscenjem " + Environment.NewLine + 
                           "istaknutih precica.";

            help.Text = text;
        }
    }
}
