using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.Common.Configurations
{
    [DataContract]
    public class Configuration
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
        
        public Configuration ()
        {
            Hostname = "127.0.0.1";
            SendPort = 5000;
            ReceivePort = 15000;
            LightAddress = 1;
        }

        public Configuration (Configuration configuration)
        {
            Hostname = configuration.Hostname;
            LightAddress = configuration.LightAddress;
            ReceivePort = configuration.ReceivePort;
            SendPort = configuration.SendPort;
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

       
    }
}
