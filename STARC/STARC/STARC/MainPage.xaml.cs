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
    public partial class MainPage : ContentPage
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
        }

        async void Cliked_Login(object sender, EventArgs e)
        {
            //if(User.Text == "adm" && Password.Text == "123")
            //{
                await Navigation.PushAsync(new PaginaPrincipal(), true);
            /*}
            else
            {
                await Navigation.PushAsync(new ErrorPage(), true);
            }*/
            
        }
    }
}
