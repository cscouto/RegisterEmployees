using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Interop;

namespace CadastroFuncionarios
{
    public interface IDataBase
    {
        string DiretorioDB { get; }
        ISQLitePlatform Plataforma { get; }
    }
}
