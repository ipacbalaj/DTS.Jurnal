using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSA.Module.PersonalData.SettingsColumns.SettingsTile;
using DTS.Jurnal.V3.Database.Module.Entities.Local;

namespace DSA.Module.PersonalData
{
    public static class ExtensionMethods
    {
        public static SettingItem ToSettingItem(this SettingsTileViewModel settingsTile)
        {
            return new SettingItem()
            {
                Name = settingsTile.Name,
                Id = settingsTile.Id,
                Cost = settingsTile.Cost.HasValue?settingsTile.Cost.Value:0
            };
        }

        public static List<SettingItem> ToSettingItems(this ObservableCollection<SettingsTileViewModel> from)
        {
            return from.Select(item => item.ToSettingItem()).ToList();
        }
    }
}
