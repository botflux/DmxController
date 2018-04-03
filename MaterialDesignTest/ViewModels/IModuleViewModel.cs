using DmxController.ViewModels.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.ViewModels
{
    public interface IModuleViewModel
    {
        string ModuleName { get; }

        IPageViewModel Parent { get; set; }
    }
}
