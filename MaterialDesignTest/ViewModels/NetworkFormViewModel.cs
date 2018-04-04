
using DmxController.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.ViewModels
{
    class NetworkFormViewModel : ViewModel, IPageViewModel, IConfigurable<NetworkConfiguration> 
    {
        private string hostname;
        private int sendPort;
        private int receivePort;

        public List<IModuleViewModel> LeftModules
        {
            get
            {
                return new List<IModuleViewModel>();
            }
        }

        public string Name
        {
            get
            {
                return "Network";
            }
        }

        public List<IModuleViewModel> RightModules
        {
            get
            {
                return new List<IModuleViewModel>();
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

        public NetworkConfiguration Configuration
        {
            get
            {
                return new NetworkConfiguration()
                {
                    Hostname = this.Hostname,
                    ReceivePort = this.ReceivePort,
                    SendPort = this.SendPort
                };
            }

            set
            {
                this.Hostname = value.Hostname;
                this.ReceivePort = value.ReceivePort;
                this.SendPort = value.SendPort;
            }
        }

        protected override void NotifyProperty([CallerMemberName] string str = "")
        {
            base.NotifyProperty(str);
        }
        
    }
}
