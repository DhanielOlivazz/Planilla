using Microsoft.Extensions.Logging;
using Firebase.Database;
using Firebase.Database.Query;
using PlanillaAppMovil.Models;

namespace PlanillaAppMovil
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            Registrar();
            return builder.Build();
        }
        public static void Registrar()
        {
            FirebaseClient cliente = new FirebaseClient("https://planillaprueba-a7560-default-rtdb.firebaseio.com/");
            var cargos = cliente.Child("Cargos").OnceAsync<Cargo>();
            if(cargos.Result.Count == 0)
            {
                cliente.Child("Cargos").PostAsync(new Cargo { nombre = "Administrador" });
                cliente.Child("Cargos").PostAsync(new Cargo { nombre = "Supervisor" });
                cliente.Child("Cargos").PostAsync(new Cargo { nombre = "Dependiente" });
            }
        }
    }
}
