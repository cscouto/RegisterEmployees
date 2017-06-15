using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CadastroFuncionarios
{
    class DataAccess : IDisposable
    {
        private SQLiteConnection connection;

        public DataAccess()
        {
            var config = DependencyService.Get<IDataBase>();
            connection = new SQLiteConnection(config.Plataforma,
                Path.Combine(config.DiretorioDB, "Funcionarios.db3"));
            connection.CreateTable<Funcionario>();
        }

        public void InsertFuncionario(Funcionario funcionario)
        {
            connection.Insert(funcionario);
        }

        public void UpdateFuncionario(Funcionario funcionario)
        {
            connection.Update(funcionario);
        }

        public void DeleteFuncionario(Funcionario funcionario)
        {
            connection.Delete(funcionario);
        }

        public Funcionario GetFuncionario(int IDFuncionario)
        {
            return connection.Table<Funcionario>().FirstOrDefault(c => c.IDFuncionario == IDFuncionario);
        }

        public List<Funcionario> GetFuncionarios()
        {
            return connection.Table<Funcionario>().OrderBy(c => c.IDFuncionario).ToList();
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
