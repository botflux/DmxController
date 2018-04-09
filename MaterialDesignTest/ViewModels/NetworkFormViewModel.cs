
using DmxController.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.ViewModels
{
    /// <summary>
    /// Renseigne le ViewModel utilisé pour la partie configuration du réseau
    /// </summary>
    class NetworkFormViewModel : ViewModel, IPageViewModel, IConfigurable<NetworkConfiguration> 
    {
        /// <summary>
        /// Renseigne le nom d'hôte
        /// </summary>
        private string hostname;
        /// <summary>
        /// Renseigne le port d'envoie
        /// </summary>
        private int sendPort;
        /// <summary>
        /// Renseigne le port de reception
        /// </summary>
        private int receivePort;

        /// <summary>
        /// Renvoie les modules utilisés pour ce ViewModel
        /// </summary>
        public List<IModuleViewModel> LeftModules
        {
            get
            {
                return new List<IModuleViewModel>();
            }
        }

        /// <summary>
        /// Renvoie le nom de ce ViewModel
        /// </summary>
        public string Name
        {
            get
            {
                return "Network";
            }
        }

        /// <summary>
        /// Renvoie les modules utilisés dans ce ViewModel
        /// </summary>
        public List<IModuleViewModel> RightModules
        {
            get
            {
                return new List<IModuleViewModel>();
            }
        }

        /// <summary>
        /// Renvoie ou renseigne le nom d'hôte
        /// </summary>
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

        /// <summary>
        /// Renvoie ou renseigne le port d'envoie
        /// </summary>
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

        /// <summary>
        /// Renvoie ou renseigne le port de reception
        /// </summary>
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

        /// <summary>
        /// Renvoie ou renseigne la configuration actuelle
        /// </summary>
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
