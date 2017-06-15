using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(CadastroFuncionarios.Droid.Config))]

namespace CadastroFuncionarios.Droid
{
    class Config : IDataBase
    {
        private string diretorioDB;
        private ISQLitePlatform plataforma;

        public string DiretorioDB
        {
            get
            {
                if (string.IsNullOrEmpty(diretorioDB))
                {
                    diretorioDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return diretorioDB;
            }

        }

        public ISQLitePlatform Plataforma
        {
            get
            {
                if (plataforma == null)
                {
                   plataforma =  new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return plataforma;
            }
        }
    }
}