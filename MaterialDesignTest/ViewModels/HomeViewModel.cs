using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.ViewModels
{
    public class HomeViewModel : ViewModel, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Home";
            }
        }
    }
}
