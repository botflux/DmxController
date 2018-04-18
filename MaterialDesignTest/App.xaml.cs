﻿using DmxController.Common.Configuration;
using DmxController.Common.Files;
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
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            FilesHandler.Current.Initialize(AppDomain.CurrentDomain.BaseDirectory + @"storyboards", AppDomain.CurrentDomain.BaseDirectory + @"settings\settings.json");


            //UtilityProvider.Current.ProvideConfigrationHandler(new ConfigurationHandler(AppDomain.CurrentDomain.BaseDirectory + "\\settings\\settings.json"));

            //UtilityProvider.Current.ConfHandler.SearchConfiguration();


            NetworkHandler.Current.Initialize("10.129.22.26", 5000, 15000);
            NetworkHandler.Current.Manager.OnMessageReceived += (message) =>
            {
                MessageBox.Show(string.Format("Message reçu: {0}", message));
            };
            NetworkHandler.Current.Manager.StartListening();

            /*
            UtilityProvider.Current.ProvideNetworkManager(new VPackage.Network.NetworkManager("10.129.22.26", 5000, 15000, 15000));
            UtilityProvider.Current.NetManager.OnMessageReceived += (message) =>
            {
                MessageBox.Show("Message recu: " + message);
            };
            UtilityProvider.Current.NetManager.StartListening();*/
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            NetworkHandler.Current.Manager.StopListening();

            /*
            UtilityProvider.Current.NetManager.StopListening();
            UtilityProvider.Current.ConfHandler.WriteConfiguration();*/
        }
    }
}
