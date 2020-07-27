
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


        private void btncalcular_Clicked(object sender, EventArgs e)
        {
            double monto, taza = 0;
            int mesesPlazo = 0;
            taza = Convert.ToDouble(txtTaza.Text);
            monto = Convert.ToDouble(txtMonto.Text);
            mesesPlazo = Convert.ToInt32(pkMeses.SelectedItem);

            if (taza != null && taza > 1 || taza < 100)
            {
                if (monto != null && monto > 100)
                {
                    if (mesesPlazo != null && mesesPlazo > 1 || mesesPlazo < 13)
                    {
                        double t = taza / 1200;
                        double b = Math.Pow((1 + t), mesesPlazo);
                        lblResultado.Text = (Math.Round( t* monto * b / (b - 1),2)).ToString();
                    }
                    else
                    {
                        DisplayAlert("Error", "Favor selecionar la Cantidad Mayor a 1 o Menor a 12 en Meses Antes de Continuar", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Error", "Favor introduzca un Monto Mayor a 100$ Antes de Continuar", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "Favor introduzca una Taza Mayor a 1% o Menor a 100% Antes de Continuar", "OK");
            }
        }
    }
}
