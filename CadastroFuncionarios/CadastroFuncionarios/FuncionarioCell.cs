using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CadastroFuncionarios
{
    class FuncionarioCell : ViewCell
    {
        public FuncionarioCell()
        {
            var LbIdFuncionario = new Label
            {
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Start
            };
            LbIdFuncionario.SetBinding(Label.TextProperty, new Binding("IDFuncionario"));

            var LbNome = new Label
            {
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Start
            };
            LbNome.SetBinding(Label.TextProperty, new Binding("Nome"));

            var LbSobrenome = new Label
            {
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            LbSobrenome.SetBinding(Label.TextProperty, new Binding("SobreNome"));

            var LbSalario = new Label
            {
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            LbSalario.SetBinding(Label.TextProperty, new Binding("Salario"));


            var LbDataContrato = new Label
            {
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            LbDataContrato.SetBinding(Label.TextProperty, new Binding("DataContrato"));


            var switchAtivo = new Switch
            {
                HorizontalOptions = LayoutOptions.End,
                IsEnabled = false
            };
            switchAtivo.SetBinding(Switch.IsToggledProperty, new Binding("Ativo"));


            var panel1 = new StackLayout
            {
                Children = { LbIdFuncionario, LbNome, LbSobrenome },
                Orientation = StackOrientation.Horizontal
            };

            var panel2 = new StackLayout
            {
                Children = { LbSalario, LbDataContrato, switchAtivo },
                Orientation = StackOrientation.Horizontal
            };

            View = new StackLayout
            {
                Children = { panel1, panel2 },
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Fill
                
            };
        }
        
    }
}
