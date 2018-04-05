using DmxController.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPackage.Network;

namespace DmxController
{
    public class UtilityProvider
    {
        private static UtilityProvider current = null;

        public static UtilityProvider Current
        {
            get
            {
                if (current == null)
                    current = new UtilityProvider();
                return current;
            }
        }

        public NetworkManager NetManager
        {
            get
            {
                if (netManager == null)
                    throw new Exception("NetManager nul");

                return netManager;
            }
        }

        public ConfigurationHandler ConfHandler
        {
            get
            {
                if (confHandler == null)
                {
                    throw new Exception("Configuration handler is null");
                }

                return confHandler;
            }
        }

        private NetworkManager netManager;
        private ConfigurationHandler confHandler;
        
        public void ProvideNetworkManager (NetworkManager netManager)
        {
            this.netManager = netManager;
        }
        public void ProvideConfigrationHandler (ConfigurationHandler configurationHandler)
        {
            this.confHandler = configurationHandler;
        }
    }
}
