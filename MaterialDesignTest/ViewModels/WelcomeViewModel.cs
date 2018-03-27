using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.ViewModels
{
    public class WelcomeViewModel : ViewModel
    {
        protected override void NotifyPropertyChanged([CallerMemberName] string str = "")
        {
            base.NotifyPropertyChanged(str);
        }
    }
}
