using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PenScan.Data;
using PenScan.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(PenScan.Droid.Connection.SQLiteAsyncConnection))]
namespace PenScan.Droid.Connection
{
    class SQLiteAsyncConnection : IDatabase
    {
        public SQLite.SQLiteAsyncConnection GetConnection()
        {
            var filename = "penscan.db";
            var documentspath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentspath, filename);
            var connection = new SQLite.SQLiteAsyncConnection(path);
            return connection;
        }
    }
}