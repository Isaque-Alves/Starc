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

            
            try
            {
                Database database = new Database();

                HttpResponseMessage result = await App.http.GetAsync("http://starc.azurewebsites.net/Componente/Lista"); /* http://viacep.com.br/ws/01001000/json/?usuario=alskdjflakjsdf&senha=ou34o2iu34 */

                String json = await result.Content.ReadAsStringAsync();
                List<Componente> componentes = JsonConvert.DeserializeObject<List<Componente>>(json);
                if(componentes.Count != 0)
                {
                    foreach(Componente c in componentes)
                    {
                        /*Componente teste = new Componente();
                        teste.Nome = c.Nome;
                        teste.Status = c.Status;*/

                        database.Conexao().Insert(c);
                    }

                    this.FindByName<ListView>("ListContatos").ItemsSource = database.Conexao().Table<Componente>().ToList();
                }
                else
                {
                    await DisplayAlert("Mensagem", "Você não possui nenhum componente cadastrado", "Fechar");
                }
                
            }
            catch (Exception e)
            {
                await DisplayAlert("ERRO", e.Message, "Cancelar");
            }

        }

        async void SwitchCell_Clicked(object sender, EventArgs a)
        {
            SwitchCell s = (sender as SwitchCell);

            string id = s.ClassId;
            try
            {
                string url = "http://starc.azurewebsites.net/Componente/AlteraStatusMobile/" + id;
                HttpResponseMessage result = await App.http.GetAsync(url);
            }catch(Exception e)
            {
                await DisplayAlert("Erro", "Não foi possivel conectar ao servidor para alterar o status da sua lâmpada", "Cancelar");
            }
        }

    }
}