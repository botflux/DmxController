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
        /// Nom d'hôte distant
        /// </summary>
        private string hostname;
        /// <summary>
        /// Adresse de lumière à commander
        /// </summary>
        private int lightAddress;
        /// <summary>
        /// Type de cible
        /// </summary>
        private TargetTypeEnum targetType;
        /// <summary>
        /// Valide le dialogue
        /// </summary>
        private ICommand validateDialogCommand;
        /// <summary>
        /// Annule le dialogue
        /// </summary>
        private ICommand cancelDialogCommand;
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

        public ICommand CancelDialogCommand
        {
            get
            {
                return cancelDialogCommand;
            }
        }

        public TargetTypeEnum TargetType
        {
            get
            {
                return targetType;
            }

            set
            {
                if (targetType != value)
                {
                    targetType = value;
                    NotifyProperty();
                }
            }
        }
        #endregion

        #region Constructors

        public ConfigurationViewModel ()
        {
            AppConfiguration configuration = JsonHandler.ParseConfigurationPacket(JsonHandler.ConstructConfigurationPacket(FilesHandler.Current.CurrentConfiguration));
            Hostname = configuration.Hostname;
            LightAddress = configuration.LightAddress;
            SendPort = configuration.SendPort;
            TargetType = configuration.TargetType;

            validateDialogCommand = new RelayCommand<Window>((o) => 
            {
                DialogCloser.SetDialogResult(o, true);
            });

            cancelDialogCommand = new RelayCommand<Window>((o) =>
           {
               DialogCloser.SetDialogResult(o, false);
           });
        }

        #endregion

        #region Methods
        public static AppConfiguration GetConfiguration (ConfigurationViewModel vm)
        {
            return new AppConfiguration(vm);
        }
        #endregion
    }
}
