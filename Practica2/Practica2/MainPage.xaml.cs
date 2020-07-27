
using System;
using System.ComponentModel;
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
            double resultado= (Math.Round(t * monto * b / (b - 1), 2));
            return resultado;
        }

        private void btncalcular_Clicked(object sender, EventArgs e)
        {
            double taza = Convert.ToDouble(txtTaza.Text);
            double monto = Convert.ToDouble(txtMonto.Text);
            int mesesPlazo = Convert.ToInt32(pkMeses.SelectedItem);

            if (monto > 100)
            {
                if (mesesPlazo > 1 && mesesPlazo < 13)
                {
                    if (taza > 0 && taza < 100)
                    {
                        lblResultado.Text = calcular(monto: monto, taza: taza, mesesPlazo: mesesPlazo).ToString();
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
    }
}
