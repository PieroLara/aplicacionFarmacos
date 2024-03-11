using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Plugin.LocalNotification;
using aplicacionFarmacos.controlador;

namespace aplicacionFarmacos
{
    public partial class MainPage : ContentPage
    {

        private readonly IFarmacoResService _FarmacoService; 
        int count = 0;
        public MainPage(IFarmacoResService service)
        {
            InitializeComponent();
            _FarmacoService = service;

        }
        
        private async void OnCounterClicked(object sender, EventArgs e)
        {
            Loading.IsVisible = true;
            var data = await _FarmacoService.Obtener();
            ItemListView.ItemsSource = data;
            Loading.IsVisible = false;
            
        }
        private String carganombre()
        {

            return "Invitado";
        }
        private void CargandoNombresString(object sender, EventArgs e)
        {
            lblBienvenida.Text = $"¡Bienvenido {carganombre()}, a la aplicación de gestión de fármacos!";
        }
        private void lanzaNotificaciones(object sender, EventArgs e) {

            var request = new NotificationRequest
            {
                NotificationId = 1,
                Title = "Recuerda tomar las pastillas",
                Description = "Hay pastillas que tomarse",
            };
        
        }


    }

}
