﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.Common.Configuration
{
    [DataContract]
    public class Configuration
    {
        [DataMember]
        private NetworkConfiguration currentNetworkConfiguration;
        [DataMember]
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

        public Configuration () { }

        public Configuration (Configuration configuration)
        {
            currentNetworkConfiguration = new NetworkConfiguration(configuration.currentNetworkConfiguration);
            currentTargetConfiguration = new TargetConfiguration(configuration.currentTargetConfiguration);
        }
    }
}
