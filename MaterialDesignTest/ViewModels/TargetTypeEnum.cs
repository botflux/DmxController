using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.ViewModels
{
    /// <summary>
    /// Représente les differents types de sources lumineuses.
    /// </summary>
    [DataContract]
    public enum TargetTypeEnum
    {
        [EnumMember]
        Lyre,
        [EnumMember]
        Projecteur
    }
}
