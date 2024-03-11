using System.Security.Cryptography.X509Certificates;

namespace aplicacionFarmacos
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public MainPage()
        {
            InitializeComponent();
            MenuPrincipal();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        private String carganombre()
        {

            return "Piero";
        }
        private void CargandoNombresString(object sender, EventArgs e)
        {
            lblBienvenida.Text = $"¡Bienvenido {carganombre()}, a la aplicación de gestión de fármacos!";
        }
    }

}
