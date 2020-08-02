using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleCuotaPage : ContentPage
    {
        public DetalleCuotaPage(Cuota cuota)
        {
            InitializeComponent();

            NumeroCuota.Text = cuota.Nro.ToString();
            InteresCuota.Text = cuota.InteresFormateado;
            AmortizacionCuota.Text = cuota.AmortizacionFormateada;
            TotalCuota.Text = cuota.totalApagar;
        }
    }
}