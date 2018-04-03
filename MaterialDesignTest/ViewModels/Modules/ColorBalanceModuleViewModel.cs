using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.ViewModels.Modules
{
    public class ColorBalanceModuleViewModel : IModuleViewModel
    {
        private IPageViewModel parent;

        public string ModuleName
        {
            get
            {
                return "ColorBalance";
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
