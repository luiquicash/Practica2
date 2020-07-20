
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
            if (txtTaza.Text != null)
            {
                taza = Convert.ToDouble(txtTaza.Text);
                if (txtMonto.Text != null)
                {
                    monto = Convert.ToDouble(txtMonto.Text);
                    if (pkMeses.SelectedItem != null)
                    {
                        mesesPlazo = Convert.ToInt32(pkMeses.SelectedItem);
                        double t = taza / 1200;
                        double b = Math.Pow((1 + t), mesesPlazo);
                        lblResultado.Text = (Math.Round( t* monto * b / (b - 1),2)).ToString();
                    }
                    else
                    {
                        DisplayAlert("Error", "Favor selecionar la Cantidad de Meses Antes de Continuar", "OK");
}
                }
                else
                {
                    DisplayAlert("Error", "Favor introduzca el Monto Antes de Continuar", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "Favor introduzca la taza Antes de Continuar", "OK");
            }
        }
    }
}
