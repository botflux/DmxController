using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.Common.Configuration
{
    [DataContract]
    public class NetworkConfiguration
    {
        [DataMember]
        private string hostname;
        [DataMember]
        private int receivePort;
        [DataMember]
        private int sendPort;

        public string Hostname
        {
            get
            {
                return hostname;
            }

            set
            {
                hostname = value;
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
                receivePort = value;
            }
        }

        public int SendPort
        {
            get
            {
                return sendPort;
            }

            set
            {
                sendPort = value;
            }
        }

        public NetworkConfiguration() { }
        public NetworkConfiguration (NetworkConfiguration networkConfiguration)
        {
            Hostname = networkConfiguration.Hostname;
            SendPort = networkConfiguration.SendPort;
            ReceivePort = networkConfiguration.ReceivePort;
        }
    }
}
