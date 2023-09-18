namespace Keyloggers
{
    partial class Form1 : Form
    {
        private Timer myTimer;

        public Form1()
        {
            InitializeComponent();

            // Skapa en timer med en tidsintervall på 1000 millisekunder (1 sekund).
            myTimer = new Timer();
            myTimer.Interval = 1000;

            // Lägg till en händelsehanterare för timerens Tick-händelse.
            myTimer.Tick += new EventHandler(MyTimer_Tick);

            // Starta timern när formuläret laddas.
            myTimer.Start();
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            // Denna funktion kommer att köras automatiskt varje sekund när timern tickar.
            // Du kan lägga till din önskade funktionalitet här.
            
            // Exempel: Visa ett meddelande varje sekund.
            MessageBox.Show("Programmet kör automatiskt!");
        }

        // Här kan du lägga till fler metoder och egenskaper efter behov.

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
