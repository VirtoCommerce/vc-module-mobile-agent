using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Entities;
using VirtoCommerce.Mobile.Interfaces;
using Xamarin.Forms;

namespace VirtoCommerce.Mobile.Repositories
{
    public class SqlLiteThemeSettingsRepository : IThemeSettingsRepository
    {
        private readonly Func<SQLiteConnection> _connectionFactory;
        public SqlLiteThemeSettingsRepository()
        {
            _connectionFactory = new Func<SQLiteConnection>(() => { return DependencyService.Get<ISqlLiteConnection>().GetConnection(); });
            using (var connection = _connectionFactory())
            {
                connection.CreateTable<ThemeSettingsEntity>();
            }
        }
        public ThemeSettingsEntity GetSettings()
        {
            using (var connection = _connectionFactory())
            {
                return connection.Table<ThemeSettingsEntity>().FirstOrDefault();
            }
        }

        public bool SaveSettings(ThemeSettingsEntity settings)
        {
            using (var connection = _connectionFactory())
            {
                return (connection.Table<ThemeSettingsEntity>().FirstOrDefault(x => x.Id == settings.Id) != null ? connection.Update(settings) : connection.Insert(settings)) != -1;
            }
        }
    }
}
