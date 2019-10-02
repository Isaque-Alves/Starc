using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace STARC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaPrincipal : ContentPage
    {
        public PaginaPrincipal()
        {
            InitializeComponent();
        }

        async void Clicked_ImageAsync(object sender, EventArgs a)
        {
            Button b = (sender as Button);
            b.Effects.Clear();

            if(b.ImageSource.ToString() == "File: LampadaLigada.png")
            {
                b.ImageSource = "LampadaDesligada.png";
            }else if (b.ImageSource.ToString() == "File: LampadaDesligada.png")
            {
                b.ImageSource = "LampadaLigada.png";
            }

            bool desabilitar = await DisplayAlert("Conflito", "O componente atual está em um grupo, deseja desativa-lo do grupo?", "Desabilitar", "Cancelar");

               
             
        }
    }
}