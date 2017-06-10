using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using DTS.Jurnal.V3.Shell.Bootstrapper;
using DTS.Jurnal.V3.Shell.Properties;

namespace DTS.Jurnal.V3.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);
            var hostBootstrapper = new DSAClientBootstrapper();
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ro");
            SetAppConfig();
            hostBootstrapper.Run();
        }

        private void SetAppConfig()
        {
            var settings = ConfigurationManager.ConnectionStrings["dsaEntities"];
            var fi = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            fi.SetValue(settings, false);            
            var efConfigString =
                ConfigurationManager.ConnectionStrings["dsaEntities"].ConnectionString.Replace("AppData",
                Settings.Default.Databasepath);            
            if (efConfigString != null)
            {
                ConfigurationManager.ConnectionStrings["dsaEntities"].ConnectionString = efConfigString;
            }
        }
    }
}
