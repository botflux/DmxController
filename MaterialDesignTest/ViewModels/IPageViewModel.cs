﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.ViewModels
{
    public interface IPageViewModel
    {
        IModuleViewModel SidePanel { get; set; }

        string Name { get; }
    }
}
