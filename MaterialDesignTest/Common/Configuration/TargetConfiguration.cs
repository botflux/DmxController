using DmxController.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.Common.Configuration
{
    [DataContract]
    public class TargetConfiguration
    {
        [DataMember]
        private int targetAddress;
        [DataMember]
        private TargetTypeEnum targetType;

        public int TargetAddress
        {
            get
            {
                return targetAddress;
            }

            set
            {
                targetAddress = value;
            }
        }

        public TargetTypeEnum TargetType
        {
            get
            {
                return targetType;
            }

            set
            {
                targetType = value;
            }
        }

        public TargetConfiguration () { }
        public TargetConfiguration (TargetConfiguration targetConfiguration)
        {
            TargetAddress = targetConfiguration.TargetAddress;
            TargetType = targetConfiguration.TargetType;
        }
    }
}
