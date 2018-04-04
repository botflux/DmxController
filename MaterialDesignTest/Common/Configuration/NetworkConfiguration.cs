using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.Common.Configuration
{
    public class NetworkConfiguration
    {
        private string hostname;
        private int receivePort;
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
    }
}
