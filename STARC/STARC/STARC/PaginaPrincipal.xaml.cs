using Newtonsoft.Json;
using STARC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            BuscaComponente();
            InitializeComponent();
        }

        async void BuscaComponente()
        {
            var http = new HttpClient();

            try
            {
                Database database = new Database();

                HttpResponseMessage result = await http.GetAsync("http://starc.azurewebsites.net/Componente/Lista"); /* http://viacep.com.br/ws/01001000/json/?usuario=alskdjflakjsdf&senha=ou34o2iu34 */

                String json = await result.Content.ReadAsStringAsync();
                List<Componente> componentes = JsonConvert.DeserializeObject<List<Componente>>(json);
                foreach(Componente c in componentes)
                {
                    /*Componente teste = new Componente();
                    teste.Nome = c.Nome;
                    teste.Status = c.Status;*/

                    database.Conexao().Insert(c);
                }

                //database.Conexao().Insert(componentes[0]);

                this.FindByName<ListView>("ListContatos").ItemsSource = database.Conexao().Table<Componente>().ToList();
            }
            catch (Exception e)
            {

            }

            
        }

        async void SwitchCell_Clicked(object sender, EventArgs a)
        {
            SwitchCell s = (sender as SwitchCell);

            string id = s.ClassId;

            var http = new HttpClient();
            try
            {
                string url = "http://starc.azurewebsites.net/Componente/AlteraStatusMobile/" + id;
                HttpResponseMessage result = await http.GetAsync(url);
            }catch(Exception e)
            {
                await DisplayAlert("Erro", "Não foi possivel conectar ao servidor para alterar o status da sua lâmpada", "Cancelar");
            }
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