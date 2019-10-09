using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
            NavigationPage.SetHasNavigationBar(this, false);

            User = this.FindByName<Entry>("Usuario");
            Password = this.FindByName<Entry>("Senha");
        }

        async void Cliked_Login(object sender, EventArgs e)
        {
            if(User.Text == "adm" && Password.Text == "123")
            {
                await Navigation.PushAsync(new PaginaPrincipal(), true);
            }
            else
            {
                await Navigation.PushAsync(new ErrorPage(), true);
            }
            
        }
    }
}
