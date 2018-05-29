using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.ViewModels.Modules
{
    public class ActionColorModuleViewModel : IModuleViewModel
    {
        private IPageViewModel parent;

        public string ModuleName
        {
            get
            {
                return "Color action";
            }
        }

        public IPageViewModel Parent
        {
            get
            {
                return parent;
            }

            set
            {
                parent = value;
            }
        }
    }
}
