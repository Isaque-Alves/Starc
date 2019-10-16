using Newtonsoft.Json;
using STARC.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace STARC
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public Entry User;
        private Entry Password;

        public MainPage()
        { 
            InitializeComponent();

            /*BtnEnter.Clicked += async delegate 
            {
                using (var http = new HttpClient())
                {
                    HttpResponseMessage result = await http.GetAsync("http://viacep.com.br/ws/01001000/json/?usuario=alskdjflakjsdf&senha=ou34o2iu34"); /*http://starc.azurewebsites.net/Componente/Lista */
            /*Componente c = JsonConvert.DeserializeObject<Componente>(await result.Content.ReadAsStringAsync());
        }
    };*/

            NavigationPage.SetHasNavigationBar(this, false);

            User = this.FindByName<Entry>("Usuario");
            Password = this.FindByName<Entry>("Senha");
            ContentPage c = this.FindByName<ContentPage>("ContentPage");


        }

        async void Cliked_Login(object sender, EventArgs e)
        {
            this.FindByName<ContentPage>("ContentPage").BackgroundColor = Color.FromHex("646464");
            this.FindByName<Button>("BtnEnter").TextColor = Color.FromHex("646464");

            string url = "http://starc.azurewebsites.net/Usuario/LoginMobile?email="+User.Text+"&senha="+Password.Text;
            HttpResponseMessage result = await App.http.GetAsync(url);
            string resposta = await result.Content.ReadAsStringAsync();
            if(resposta == "OK")
            {
                Database database = new Database();

                Usuario u = new Usuario();
                u.Nome = User.Text;
                u.Senha = Password.Text;
                database.Conexao().DeleteAll<Usuario>();
                database.Conexao().Insert(u);
                
                await Navigation.PushAsync(new PaginaPrincipal(), true);
            }
            else
            {
                await DisplayAlert("ERRO", "Usuario e/ou senha não encontrados!", "Cancelar");
            }

            this.FindByName<ContentPage>("ContentPage").BackgroundColor = Color.FromHex("FFFFFF");
            this.FindByName<Button>("BtnEnter").TextColor = Color.FromHex("FFFFFF");
        }
    }
}
