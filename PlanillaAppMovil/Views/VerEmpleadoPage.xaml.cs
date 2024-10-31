using PlanillaAppMovil.Models;
namespace PlanillaAppMovil.Views;
[QueryProperty(nameof(Detalle),"Detalle")]
public partial class VerEmpleadoPage : ContentPage
{
	Empleado detalle;
	public Empleado Detalle
    {
        get => detalle;
		set
		{
			detalle = value;
			OnPropertyChanged();
        }
    }

    public VerEmpleadoPage()
	{
		InitializeComponent();
        BindingContext = this;
    }
}