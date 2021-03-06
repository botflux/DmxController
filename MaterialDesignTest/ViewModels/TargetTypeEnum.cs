﻿using System;
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
    [DataContract(Name = "TargetType")]
    public enum TargetTypeEnum
    {
        [EnumMember(Value = "Lyre")]
        Spot, 
        [EnumMember(Value = "Projecteur")]
        Barre
    }
}
