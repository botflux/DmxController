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
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows;
using VPackage.Json;

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
                //NetworkHandler.Current.Manager.SendEndPoint.Address = IPAddress.Parse(FilesHandler.Current.CurrentConfiguration.Hostname);
                //NetworkHandler.Current.Manager.SendEndPoint.Port = FilesHandler.Current.CurrentConfiguration.SendPort;
                //NetworkHandler.Current.Manager.SendEndPoint = new IPEndPoint(IPAddress.Parse(FilesHandler.Current.CurrentConfiguration.Hostname), FilesHandler.Current.CurrentConfiguration.SendPort);

                MessageBox.Show("Redémarrez l'application pour que les changements de la configuration soient pris en compte.");
            };
            AppConfiguration configuration = FilesHandler.Current.OpenConfiguration();
            NetworkHandler.Current.Initialize(configuration.Hostname, configuration.SendPort, 0);
            NetworkHandler.Current.Manager.UseFragmentation = false;
            NetworkHandler.Current.Manager.Mtu = 380;
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
                    try
                    {
                        message = message.Trim('\0');
                        StoryboardNameWrapper w = JSONSerializer.Deserialize<StoryboardNameWrapper>(message);
                        MessageBox.Show("La storyboard nommé " + w.Name + " est en cours.");
                    }
                    catch (Exception ex){
                        MessageBox.Show(message);
                    }
                }
            };
            NetworkHandler.Current.Manager.StartListening();
        }

        [DataContract]
        class StoryboardNameWrapper
        {
            [DataMember (Name = "nomStory")]
            private string name;

            public string Name
            {
                get
                {
                    return name;
                }

                set
                {
                    name = value;
                }
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            NetworkHandler.Current.Manager.StopListening();
        }
    }
}
