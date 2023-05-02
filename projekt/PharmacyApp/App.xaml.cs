using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using PharmacyApp.EFCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PharmacyApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly MainWindow mainWindow;

        public App()
        {
            Startup += OnStartup;
            mainWindow = new MainWindow();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            mainWindow.ShowDialog();
        }
    }
}
