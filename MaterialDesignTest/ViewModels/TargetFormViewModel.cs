using DmxController.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.ViewModels
{
    class TargetFormViewModel : ViewModel, IPageViewModel, IConfigurable<TargetConfiguration>
    {
        private TargetTypeEnum currentTargetType;
        private int targetAddress;

        public TargetTypeEnum TargetType
        {
            get
            {
                return currentTargetType;
            }

            set
            {
                if (currentTargetType != value)
                {
                    currentTargetType = value;
                    NotifyProperty();
                }
            }
        }

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
                return "Target";
            }
        }

        public List<IModuleViewModel> RightModules
        {
            get
            {
                return new List<IModuleViewModel>();
            }
        }

        public int TargetAddress
        {
            get
            {
                return targetAddress;
            }

            set
            {
                if (targetAddress != value)
                {
                    targetAddress = value;
                    NotifyProperty();
                }
            }
        }

        public TargetConfiguration Configuration
        {
            get
            {
                return new TargetConfiguration()
                {
                    TargetAddress = this.TargetAddress,
                    TargetType = this.TargetType
                };
            }

            set
            {
                TargetAddress = value.TargetAddress;
                TargetType = value.TargetType;
            }
        }
    }
}
