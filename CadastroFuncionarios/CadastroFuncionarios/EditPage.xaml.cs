using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CadastroFuncionarios
{
    public partial class EditPage : ContentPage
    {
        private Funcionario funcionario;

        public EditPage(Funcionario funcionario)
        {
            InitializeComponent();
            this.funcionario = funcionario;

            btApagar.Clicked += btApagarClicked;
            btAtualizar.Clicked += btAtualizarClicked;

            //carrega com informacoes do funcionario na listview
            nomeEntry.Text = funcionario.Nome;
            sobrenomeEntry.Text = funcionario.SobreNome;
            SalarioEntry.Text = funcionario.Salario.ToString();
            dtpDataContrato.Date = funcionario.DataContrato;
            ativoSwitch.IsToggled = funcionario.Ativo;

        }

        public async void btAtualizarClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nomeEntry.Text))
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
            Funcionario funcionario = new Funcionario()
            {
                IDFuncionario = this.funcionario.IDFuncionario,
                Ativo = ativoSwitch.IsToggled,
                SobreNome = sobrenomeEntry.Text,
                DataContrato = dtpDataContrato.Date,
                Nome = nomeEntry.Text,
                Salario = Convert.ToDouble(SalarioEntry.Text)
            };

            using (var dados = new DataAccess())
            {
                dados.UpdateFuncionario(funcionario);
            }

            await DisplayAlert("Confirmacao", "Funcionario Atualizado Corretamente", "OK");
            await Navigation.PushAsync(new MainPage());
        }

        public async void btApagarClicked(object sender, EventArgs e)
        {
            var confirm = await DisplayAlert("Confirmacao", "Deseja apagar o funcionario?", "Sim", "Nao");
            if (!confirm) return;

            using (var dados = new DataAccess())
            {
                dados.DeleteFuncionario(funcionario);
            }

            await DisplayAlert("Confirmacao", "Funcionario Apagado Corretamente", "OK");
            await Navigation.PushAsync(new MainPage());
        }
    }
}
