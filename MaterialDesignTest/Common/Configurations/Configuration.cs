using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.Common.Configurations
{
    public class Configuration
    {
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
