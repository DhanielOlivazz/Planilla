using Firebase.Database;
using PlanillaAppMovil.Models;
using Firebase.Database.Query;
using Firebase.Storage;
namespace PlanillaAppMovil.Views;

public partial class NuevoEmpleadoPage : ContentPage
{
    FirebaseClient client = new FirebaseClient("https://planillaprueba-a7560-default-rtdb.firebaseio.com/");
    private string UrlFoto { get; set; }
    public List<Cargo> Cargos { get; set; }
    public NuevoEmpleadoPage()
	{
		InitializeComponent();
        cargarCargos();
        BindingContext = this;
    }
    public async Task cargarCargos()
    {
        var cargos = client.Child("Cargos").OnceAsync<Cargo>();
        Cargos = cargos.Result.Select(x => x.Object).ToList();
    }
    private async void guardarButton_Clicked(object sender, EventArgs e)
    {
        
        Cargo cargoUser = cargoPicker.SelectedItem as Cargo;
        await client.Child("Empleados").PostAsync(new Empleado()
        {
            nombreCompleto = nombreEntry.Text,
            FechaInicio = fechaInicioPicker.Date,
            salario = Convert.ToDouble(salarioEntry.Text),
            cargo = cargoUser,
            UrlFoto = UrlFoto
        });
        await Shell.Current.GoToAsync("..");

    }

    private async void seleccionarButton_Clicked(object sender, EventArgs e)
    {
        var foto = await MediaPicker.PickPhotoAsync();
        if(foto != null)
        {
            var stream = await foto.OpenReadAsync();
            UrlFoto = await new FirebaseStorage("planillaprueba-a7560.appspot.com")
                    .Child("Fotos")
                    .Child(DateTime.Now.ToString("ddMMyyyyhhmm")+foto.FileName)
                    .PutAsync(stream);
            fotoImage.Source = UrlFoto;
        }
    }
}