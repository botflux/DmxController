using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPackage.Network;

namespace DmxController.Common.Network
{
    public class NetworkHandler
    {
        #region Singleton
        private static NetworkHandler current;

        public static NetworkHandler Current
        {
            get
            {
                if (current == null)
                    current = new NetworkHandler();
                return current;
            }
        }
        #endregion

        #region Properties
        public NetworkManager Manager
        {
            get
            {
                return manager;
            }
        }
        #endregion


        #region Fields
        private NetworkManager manager;
        #endregion

        private NetworkHandler ()
        {
            
        }

        public void Initialize (string hostname, int sendPort, int receivePort)
        {
            this.manager = new NetworkManager(hostname, sendPort, receivePort, receivePort);
        }

    }
}
