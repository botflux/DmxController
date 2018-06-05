using DmxController.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.Common.Configurations
{
    [DataContract]
    public class AppConfiguration
    {
        /// <summary>
        /// Port d'envoie
        /// </summary>
        [DataMember]
        private int sendPort;
        /// <summary>
        /// Port de reception
        /// </summary>
        [DataMember]
        private int receivePort;
        /// <summary>
        /// Nom d'hôte distant
        /// </summary>
        [DataMember]
        private string hostname;
        /// <summary>
        /// Adresse de lumière à commander
        /// </summary>
        [DataMember]
        private int lightAddress;
        /// <summary>
        /// Le type de cible
        /// </summary>
        [DataMember]
        private TargetTypeEnum targetType;

        public AppConfiguration ()
        {
            Hostname = "127.0.0.1";
            SendPort = 5000;
            ReceivePort = 15000;
            LightAddress = 1;
            TargetType = TargetTypeEnum.Spot;
        }

        public AppConfiguration (AppConfiguration configuration)
        {
            Hostname = configuration.Hostname;
            LightAddress = configuration.LightAddress;
            ReceivePort = configuration.ReceivePort;
            SendPort = configuration.SendPort;
            TargetType = configuration.TargetType;
        }

        public AppConfiguration (ConfigurationViewModel configurationViewModel)
        {
            Hostname = configurationViewModel.Hostname;
            ReceivePort = configurationViewModel.ReceivePort;
            SendPort = configurationViewModel.SendPort;
            TargetType = configurationViewModel.TargetType;
            LightAddress = configurationViewModel.LightAddress;
        }

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
                }
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
                targetType = value;
            }
        }
    }
}
