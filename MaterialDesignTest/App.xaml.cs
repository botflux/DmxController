using DmxController.Common.Configurations;
using DmxController.Common.Files;
using DmxController.Common.Json;
using DmxController.Common.Network;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DmxController
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        private string storyBoardPath;
        private string settingsPath;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            storyBoardPath = AppDomain.CurrentDomain.BaseDirectory + @"storyboards";
            settingsPath = AppDomain.CurrentDomain.BaseDirectory + @"settings\settings.json";

            FilesHandler.Current.Initialize(storyBoardPath, settingsPath);
            FilesHandler.Current.ConfigurationChanged += () => 
            {
                MessageBox.Show("Redémarrez l'application pour que les changements de la configuration soient pris en compte.");
            };
            Configuration configuration = FilesHandler.Current.OpenConfiguration();
            //NetworkHandler.Current.Initialize(configuration.Hostname, configuration.SendPort, configuration.ReceivePort);
            //NetworkHandler.Current.Initialize("10.129.22.26", 5000, 15000);
            NetworkHandler.Current.Initialize(configuration.Hostname, configuration.SendPort, configuration.ReceivePort);
            //NetworkHandler.Current.Manager.Mtu = 10;
            NetworkHandler.Current.Manager.OnMessageReceived += (message) =>
            {
                try
                {
                    MessageBox.Show(string.Format("Message reçu: {0}", message));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };
            NetworkHandler.Current.Manager.StartListening();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            NetworkHandler.Current.Manager.StopListening();
        }
    }
}
