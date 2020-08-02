
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Practica2
{

    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private double calcular( double monto, double taza, int mesesPlazo)
        {
            double t = taza / 1200;
            double b = Math.Pow((1 + t), mesesPlazo);
            double resultado = t * monto * b / (b - 1);
            return resultado;
        }

        public double montoTotaldelPrestamo(int mesesPlazo, double cuotas)
        {
            double total = 0;
            for (int i = 0; i < mesesPlazo; i++)
            {
                total += cuotas;
            }
            return total;
        }

        private void btncalcular_Clicked(object sender, EventArgs e)
        {
            double taza = Convert.ToDouble(txtTaza.Text);
            double monto = Convert.ToDouble(txtMonto.Text);
            int mesesPlazo = Convert.ToInt32(pkMeses.SelectedItem);
            double cuotacalculada = 0;

            if (monto > 100)
            {
                if (mesesPlazo > 1 && mesesPlazo < 13)
                {
                    if (taza > 0 && taza < 100)
                    {
                        cuotacalculada = calcular(monto, taza, mesesPlazo);

                        // Llenar la lista de cuotas
                        List<Cuota> cuotas = new List<Cuota>();
                        for (int i = 0; i < mesesPlazo; i++)
                        {
                            cuotas.Add(new Cuota(i + 1, monto, mesesPlazo, taza));
                        }

                        // Asignar cuotas a la tabla (ListView)
                        TablaAmortizacion.ItemsSource = cuotas;
                        lbltotal.Text = montoTotaldelPrestamo(mesesPlazo, cuotacalculada).ToString("C2");
                    }
                    else
                        {
                            DisplayAlert("Error", "Favor Introduzca una Taza Mayor a 1% o Menor a 100% Antes de Continuar", "OK");
                        }
                }
                else
                    {
                        DisplayAlert("Error", "Favor Selecionar la Cantidad Mayor a 1 o Menor a 12 en Meses Antes de Continuar", "OK");
                    }
              }
             else
                 {
                   DisplayAlert("Error", "Favor Introduzca un Monto Mayor a 100$ Antes de Continuar", "OK");
                 }
        }

        async void TablaAmortizacion_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var cuotaSeleccionada = e.SelectedItem as Cuota;
            if (cuotaSeleccionada == null)
            {
                return;
            }

            await DisplayAlert("Detalles de Cuota \n", " Numero de Cuota : " + cuotaSeleccionada.Nro +
                "\n Interes por Cuota : " + cuotaSeleccionada.InteresFormateado +
                "\n Amortizacion Por Cuota : " + cuotaSeleccionada.AmortizacionFormateada +
                "\n Total a Pagar : " + cuotaSeleccionada.totalApagar, "OK");

            
            await Navigation.PushAsync(new DetalleCuotaPage(cuotaSeleccionada));
        }
    }
}
