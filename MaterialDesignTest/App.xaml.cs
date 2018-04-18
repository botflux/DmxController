﻿using DmxController.Common.Files;
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


            NetworkHandler.Current.Initialize("10.129.22.26", 5000, 15000);
            NetworkHandler.Current.Manager.OnMessageReceived += (message) =>
            {
                MessageBox.Show(string.Format("Message reçu: {0}", message));
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
