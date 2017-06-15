using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CadastroFuncionarios
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btNovo.Clicked += btNovoClicked;

            lvDados.ItemSelected += LvDados_ItemSelected;

            //Define o template com a class FuncionarioCell
            lvDados.ItemTemplate = new DataTemplate(typeof(FuncionarioCell));
              
            //Acessa os dados atraves do DataAccess e preenche a lista
            using (var dados = new DataAccess())
            {
                lvDados.ItemsSource = dados.GetFuncionarios();
            }
        }

        //Define o click do item na lista
        public void LvDados_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new EditPage((Funcionario)e.SelectedItem));
        }

        //Sava informacoes no banco e atualiza listview
        private async void btNovoClicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(nomeEntry.Text))
            {
                await DisplayAlert("Error", "Preencha o Nome", "OK");
                nomeEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(sobrenomeEntry.Text))
            {
                await DisplayAlert("Error", "Preencha o Sobrenome", "OK");
                sobrenomeEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(SalarioEntry.Text))
            {
                await DisplayAlert("Error", "Preencha o Salario", "OK");
                SalarioEntry.Focus();
                return;
            }
            try {
                Double var = Convert.ToDouble(SalarioEntry.Text);
            }catch(Exception exception)
            {
                await DisplayAlert("Error", "Preencha um valor Valido", "OK");
                SalarioEntry.Focus();
                return;
            }
            Funcionario funcionario = new Funcionario()
            {
                Ativo = ativoSwitch.IsToggled,
                SobreNome = sobrenomeEntry.Text,
                DataContrato = (DateTime)dtpDataContrato.Date,
                Nome = nomeEntry.Text,
                Salario = Convert.ToDouble(SalarioEntry.Text)
            };
            

            using (var dados = new DataAccess())
            {
                dados.InsertFuncionario(funcionario);
                lvDados.ItemsSource = dados.GetFuncionarios();
            }
            sobrenomeEntry.Text = string.Empty;
            dtpDataContrato.Date = DateTime.Now;
            nomeEntry.Text = string.Empty;
            SalarioEntry.Text = string.Empty;
            await DisplayAlert("Mensagem", "Funcionario Cadastrado", "OK");
        }
    }
}
