using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroFuncionarios
{
    public class Funcionario
    {
        [PrimaryKey, AutoIncrement]

        public int IDFuncionario { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataContrato { get; set; }
        public double Salario { get; set; }
        public bool Ativo { get; set; }

        public override string ToString()
        {
            return string.Format("{1} {2} {3} {4}", IDFuncionario, Nome, SobreNome, DataContrato, Salario, Ativo);
        }
    }
}
