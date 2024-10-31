using Firebase.Database;
using PlanillaAppMovil.Models;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
namespace PlanillaAppMovil.Views;

public partial class MainPage : ContentPage
{
    FirebaseClient client = new FirebaseClient("https://planillaprueba-a7560-default-rtdb.firebaseio.com/");
    public ObservableCollection<Empleado> Lista { get; set; } = new ObservableCollection<Empleado>();
    public MainPage()
	{
		InitializeComponent();
        BindingContext = this;
        cargarLista();
	}
    public void cargarLista()
    {
        client.Child("Empleados").AsObservable<Empleado>().Subscribe((empleado) =>
        {
            if (empleado.Object != null)
            {
                Lista.Add(empleado.Object);
            }
        });
    }
    private async void NuevoButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("NuevoEmpleadoPage");
    }

    private void FiltroEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        string filtro = FiltroEntry.Text.ToLower();
        if (filtro.Length > 0) 
        { 
            listaCollection.ItemsSource = Lista.Where(x => x.nombreCompleto.ToLower().Contains(filtro));
        }
        else
        {
            listaCollection.ItemsSource = Lista;
        }
    }

    private async void listaCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Empleado empleado = e.CurrentSelection.FirstOrDefault() as Empleado;
        var parametro = new Dictionary<string, object>()
        {
            ["Detalle"] = empleado
        };
        await Shell.Current.GoToAsync(nameof(VerEmpleadoPage),parametro);
    }
}