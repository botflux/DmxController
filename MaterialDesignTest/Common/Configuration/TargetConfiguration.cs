using DmxController.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.Common.Configuration
{
    public class TargetConfiguration
    {
        private int targetAddress;
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
    }
}
