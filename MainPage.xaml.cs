using System;
using Microsoft.Maui.Controls;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Plugin.LocalNotification;
using aplicacionFarmacos.controlador;
using aplicacionFarmacos.modelo;


namespace aplicacionFarmacos
{
    public partial class MainPage : ContentPage
    {

        private readonly IFarmacoResService _FarmacoService; 
        private DateTime nuevaFecha;
        private DateTime horaElegida;
        private string nombreMedicamento;
        private string Usuario;
       
        public MainPage(IFarmacoResService service)
        {
            InitializeComponent();
            _FarmacoService = service;
            

        }
        
        private async void InsertarNuevoMedicamento(object sender, EventArgs e)
        {
            Loading.IsVisible = true;
            var data = await _FarmacoService.Obtener();
            CapaListadoMedicamento.ItemsSource = data;
            Loading.IsVisible = false;
            
        }
     
        private void CargandoNombresString(object sender, EventArgs e)
        {
            lblBienvenida.Text = $"¡Bienvenido {MainPage.CargaNombreVariable()}, a la aplicación de gestión de fármacos!";
        }
        private static string CargaNombreVariable()
        {

            return "Invitado";
        }
        private void LanzaNotificaciones(object sender, EventArgs e) {

            TimeSpan tiempoActual = EligeHora.Time;
            DateTime diaActual = DateTime.Today;

            horaElegida = diaActual.Add(tiempoActual);
            
            CapaHora.IsVisible = false;
            CapaNuevoMedicamento.IsVisible = true;

            var request = new NotificationRequest
            {
                NotificationId = 1,
                Title = $"{MainPage.CargaNombreVariable()}, recuerda tomar la pastilla {MainPage.CargaNombreVariable()}",
                Description = "Hay pastillas que tomarse",
                Schedule = new NotificationRequestSchedule {

                    NotifyTime = horaElegida,
                    NotifyRepeatInterval = TimeSpan.FromDays(100)


                }
            };
            LocalNotificationCenter.Current.Show(request);
            
            DisplayAlert("Nueva Notificacion registrada","Se repetirá todos los dias a esa misma hora","OK");
          
        }
        private void SeleccionaMedicamento(object sender, ItemTappedEventArgs e)
        {
            var farmacoElegido = e.Item as FarmacoResponse;
            nombreMedicamento = farmacoElegido.nombre;
            CapaNuevoMedicamento.IsVisible = false;
            CapaFecha.IsVisible = true;
        }
        private void SeleccionaFecha(object sender, DateChangedEventArgs e)
        {
            nuevaFecha= e.NewDate;
            CapaFecha.IsVisible=false;
            CapaHora.IsVisible = true;
        }
        private void eliminaNotificacion(object sender, EventArgs e)
        {
            LocalNotificationCenter.Current.ClearAll();
        }
        /*
         * NO funciona :C
         * problemas de MAUI :c
         * https://github.com/dotnet/maui/issues/12899
         * private void SeleccionaHora(object sender, EventArgs e)
        {
            TimeSpan horaElegida = EligeHora.Time;
            CapaHora.IsVisible = false;
            CapaListadoMedicamento.IsVisible = true;
        }
        */
        private void guardaFichero(Recordatorio recordatorioAGuardar)
        {

        }
        private void leeFichero()
        {

        }

    }

}
