using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.Common.Configuration
{
    public class Configuration
    {
        private NetworkConfiguration currentNetworkConfiguration;
        private TargetConfiguration currentTargetConfiguration;

        public NetworkConfiguration CurrentNetworkConfiguration
        {
            get
            {
                return currentNetworkConfiguration;
            }

            set
            {
                currentNetworkConfiguration = value;
            }
        }

        public TargetConfiguration CurrentTargetConfiguration
        {
            get
            {
                return currentTargetConfiguration;
            }

            set
            {
                currentTargetConfiguration = value;
            }
        }
    }
}
