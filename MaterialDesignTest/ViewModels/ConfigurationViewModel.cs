using DmxController.Common.Configurations;
using DmxController.Common.Files;
using DmxController.Common.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DmxController.ViewModels
{
    public class ConfigurationViewModel : ViewModel
    {
        #region Fields
        /// <summary>
        /// Port d'envoie
        /// </summary>
        private int sendPort;
        /// <summary>
        /// Port de reception
        /// </summary>
        private int receivePort;
        /// <summary>
        /// Nom d'hôte distant
        /// </summary>
        private string hostname;
        /// <summary>
        /// Adresse de lumière à commander
        /// </summary>
        private int lightAddress;
        /// <summary>
        /// Valide le dialogue
        /// </summary>
        private ICommand validateDialogCommand;
        #endregion

        #region Properties / Commands
        public int SendPort
        {
            get
            {
                return sendPort;
            }

            set
            {
                if (sendPort != value)
                {
                    sendPort = value;
                    NotifyProperty();
                }
            }
        }

        public int ReceivePort
        {
            get
            {
                return receivePort;
            }

            set
            {
                if (receivePort != value)
                {
                    receivePort = value;
                    NotifyProperty();
                }
            }
        }

        public string Hostname
        {
            get
            {
                return hostname;
            }

            set
            {
                if (hostname != value)
                {

                    hostname = value;
                    NotifyProperty();
                }
            }
        }

        public int LightAddress
        {
            get
            {
                return lightAddress;
            }

            set
            {
                if (lightAddress != value)
                {

                    lightAddress = value;
                    NotifyProperty();
                }
            }
        }

        public ICommand ValidateDialogCommand {
            get { return validateDialogCommand; }
        }
        #endregion

        #region Constructors

        public ConfigurationViewModel ()
        {
            Configuration configuration = JsonHandler.ParseConfigurationPacket(JsonHandler.ConstructConfigurationPacket(FilesHandler.Current.CurrentConfiguration));
            Hostname = configuration.Hostname;
            LightAddress = configuration.LightAddress;
            ReceivePort = configuration.ReceivePort;
            SendPort = configuration.SendPort;

            validateDialogCommand = new RelayCommand<Window>((o) => 
            {
                DialogCloser.SetDialogResult(o, true);
            });
        }

        #endregion

        #region Methods
        public static Configuration GetConfiguration (ConfigurationViewModel vm)
        {
            return new Configuration()
            {
                Hostname = vm.Hostname,
                LightAddress = vm.LightAddress,
                ReceivePort = vm.ReceivePort,
                SendPort = vm.SendPort
            };
        }
        #endregion
    }
}
