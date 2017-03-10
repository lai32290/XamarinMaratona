using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FormAssistControl.Droid.Storage.Implementations;
using FormAssistControl.Storage.Interfaces;
using SQLite;
using Environment = System.Environment;

namespace FormAssistControl.Droid.Storage.Implementations
{
    class SQLiteDroid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            SQLitePCL.Batteries.Init();
            var sqliteFilename = "TodoSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var path = Path.Combine(documentsPath, sqliteFilename);

            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}