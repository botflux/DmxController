using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPackage.Network;

namespace DmxController
{
    public class ApplicationViewModel
    {
        public ApplicationViewModel ()
        {
            UtilityProvider.Current.ProvideNetworkManager(new NetworkManager("10.129.22.26", 5000, 15000, 15000));
        }
    }
}
