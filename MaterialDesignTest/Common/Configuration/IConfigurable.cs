using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.Common.Configuration
{
    public interface IConfigurable<T>
    {
        T Configuration { get; set; }
    }
}
