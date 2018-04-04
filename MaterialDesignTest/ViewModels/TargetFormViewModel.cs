using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.ViewModels
{
    class TargetFormViewModel : ViewModel, IPageViewModel
    {
        private TargetType currentTargetType;
        private int targetAddress;

        public TargetType CurrentTargetType
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
    }
}
