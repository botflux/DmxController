using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.ViewModels
{
    public class ConfigurationViewModel : ViewModel
    {
        private int sendPort;
        private int receivePort;
        private string hostname;
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
    }
}
