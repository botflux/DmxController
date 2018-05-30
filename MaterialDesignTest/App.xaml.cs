using DmxController.Common.Configurations;
using DmxController.Common.Files;
using DmxController.Common.Json;
using DmxController.Common.Network;
using DmxController.Common.ServerException;
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
            NetworkHandler.Current.Initialize(configuration.Hostname, configuration.SendPort, configuration.ReceivePort);
            NetworkHandler.Current.Manager.UseFragmentation = false;
            NetworkHandler.Current.Manager.Mtu = 1000;
            NetworkHandler.Current.Manager.OnMessageReceived += (message) =>
            {
                int code;
                if (int.TryParse(message, out code))
                {
                    if (code != 0)
                    {
                        ServerExceptionWrapper w = ServerExceptionHandler.GetExceptionFromCode(code);
                        MessageBox.Show(w.ToString());
                    } 
                    else
                    {
                        MessageBox.Show("Le message a correctement été reçu");
                    }
                }
                else
                {
                    MessageBox.Show(message);
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
