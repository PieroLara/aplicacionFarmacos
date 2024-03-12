using Plugin.LocalNotification;
using aplicacionFarmacos.controlador;
using aplicacionFarmacos.modelo;
using aplicacionFarmacos.controlador.Ficheros;


namespace aplicacionFarmacos
{
    public partial class MainPage : ContentPage
    {

        private readonly IFarmacoResService _FarmacoService; 
        private DateTime nuevaFecha;
        private DateTime horaElegida;
        private FarmacoResponse farmacoseleccionado;
        private string nombreMedicamento;
        private string Usuario;
        private Recordatorio ObjetoLecturadeFichero;
        public MainPage(IFarmacoResService service)
        {
            InitializeComponent();
            _FarmacoService = service;
            ObjetoLecturadeFichero = new GestionaRecordatorios().DeserializarRecordatorio();


            if ((ObjetoLecturadeFichero = new GestionaRecordatorios().DeserializarRecordatorio() ) !=null)
            {
                DisplayAlert("Ayudenme","me muero","OK");
                Usuario = ObjetoLecturadeFichero.nombre;
                BotonBorrado.IsVisible = true;
            }
            

        }
        
        private async void InsertarNuevoMedicamento(object sender, EventArgs e)
        {
            Loading.IsVisible = true;
            var data = await _FarmacoService.Obtener();
            CapaListadoMedicamento.ItemsSource = data;
            Loading.IsVisible = false;
            CapaListadoMedicamento.IsVisible = true;
            BtnNuevoMedicamento.IsVisible = false;
        }
     
        private void CargandoNombresString(object sender, EventArgs e)
        {
            lblBienvenida.Text = $"¡Bienvenido {MainPage.CargaNombreVariable(Usuario)}, a la aplicación de gestión de fármacos!";
        }
        private static string CargaNombreVariable(string Usuario)
        {

            return Usuario!=null ? Usuario:"Invitado";
        }
       
        private void SeleccionaMedicamento(object sender, ItemTappedEventArgs e)
        {
            farmacoseleccionado = (FarmacoResponse)e.Item;
            nombreMedicamento = farmacoseleccionado.nombre;
            BtnNuevoMedicamento.IsVisible = true;
            CapaNuevoMedicamento.IsVisible = false;
            CapaFecha.IsVisible = true;
            
        }
        private void SeleccionaFecha(object sender, DateChangedEventArgs e)
        {
            nuevaFecha= e.NewDate;
            CapaFecha.IsVisible=false;
            CapaHora.IsVisible = true;
        }
        private void LanzaNotificaciones(object sender, EventArgs e)
        {

            TimeSpan tiempoActual = EligeHora.Time;
            DateTime diaActual = DateTime.Today;

            horaElegida = diaActual.Add(tiempoActual);

            CapaHora.IsVisible = false;


            var request = new NotificationRequest
            {
                NotificationId = 1,
                Title = $"{MainPage.CargaNombreVariable(Usuario)}, recuerda tomar la pastilla {nombreMedicamento}",
                Description = "Hay pastillas que tomarse",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = horaElegida,
                    NotifyRepeatInterval = TimeSpan.FromDays( ((nuevaFecha- DateTime.Today).Days>0? (nuevaFecha - DateTime.Today).Days : 0))
                }
            };
            LocalNotificationCenter.Current.Show(request);

            DisplayAlert("Nueva Notificacion registrada", "Se repetirá todos los dias a esa misma hora", "OK");
            CapaListadoMedicamento.IsVisible=false;
            CapaNuevoMedicamento.IsVisible = true;
            new GestionaRecordatorios().SerializarRecordatorio(new Recordatorio(farmacoseleccionado,horaElegida, CargaNombreVariable(Usuario)));

        }
        private void EliminaNotificacion(object sender, EventArgs e)
        {
            LocalNotificationCenter.Current.ClearAll();
        }
        private void AbreRegistraUsuario(object sender, EventArgs e)
        {
            CapaRegistroUsuario.IsVisible = true;
            btnNuevoUsuario.IsVisible = false;
        }
        private void RegistraUsuario (object sender, EventArgs e)
        {
            string textoIngresado = EditorTextoUsuario.Text;
            Usuario=textoIngresado;
            CapaRegistroUsuario.IsVisible = false;
            btnNuevoUsuario.IsVisible = true;
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
    }
}
