using System;
using SQLite;
using VirtoCommerce.Mobile.Interfaces;
using System.IO;
using VirtoCommerce.Mobile.iOS.Shared;

[assembly: Xamarin.Forms.Dependency(typeof(SqlLite))]
namespace VirtoCommerce.Mobile.iOS.Shared
{
    public class SqlLite : ISqlLiteConnection
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "VcfMobile.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            if (!Directory.Exists(documentsPath))
            {
                Directory.CreateDirectory(documentsPath);
            }
            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}