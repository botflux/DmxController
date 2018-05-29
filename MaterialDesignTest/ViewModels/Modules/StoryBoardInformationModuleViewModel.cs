using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.ViewModels.Modules
{
    class StoryBoardInformationModuleViewModel : ViewModel, IModuleViewModel
    {
        private IPageViewModel parent;

        public string ModuleName
        {
            get
            {
                return "Informations";
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
