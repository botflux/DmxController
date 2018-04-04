using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.ViewModels.Modules
{
    public class ModuleList : ObservableCollection<IModuleViewModel>
    {
        public ModuleList(List<IModuleViewModel> list) : base(list)
        {
            
        }
    }
}
