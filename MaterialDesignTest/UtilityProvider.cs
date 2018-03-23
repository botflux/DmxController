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

            set
            {
                netManager = value;
            }
        }

        private NetworkManager netManager;
        
        public void ProvideNetworkManager (NetworkManager netManager)
        {
            this.NetManager = netManager;
        }
    }
}
