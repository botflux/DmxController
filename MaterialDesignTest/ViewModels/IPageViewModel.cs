using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.ViewModels
{
    public interface IPageViewModel
    {
        List<IModuleViewModel> LeftModules { get; }
        List<IModuleViewModel> RightModules { get; }

        string Name { get; }
    }
}
