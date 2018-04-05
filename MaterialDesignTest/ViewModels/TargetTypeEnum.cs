using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.ViewModels
{
    [DataContract]
    public enum TargetTypeEnum
    {
        [EnumMember]
        Lyre,
        [EnumMember]
        Projecteur
    }
}
