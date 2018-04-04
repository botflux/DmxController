using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DmxController
{
    [DataContract]
    public class Packet
    {
        [DataMember(Name = "couleur")]
        private Couleur color;

        public Couleur Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        [DataContract]
        public class Couleur
        {

            [DataMember(Name = "CIBLE")]
            private string target;
            [DataMember(Name = "ADDRCIBLE")]
            private string targetAdress;
            [DataMember(Name = "RED")]
            private string red;
            [DataMember(Name = "BLUE")]
            private string blue;
            [DataMember(Name = "GREEN")]
            private string green;
            [DataMember(Name = "INTENSITY")]
            private string intensity;

            public string Target
            {
                get
                {
                    return target;
                }

                set
                {
                    target = value;
                }
            }

            public string TargetAdress
            {
                get
                {
                    return targetAdress;
                }

                set
                {
                    targetAdress = value;
                }
            }

            public string Red
            {
                get
                {
                    return red;
                }

                set
                {
                    red = value;
                }
            }

            public string Blue
            {
                get
                {
                    return blue;
                }

                set
                {
                    blue = value;
                }
            }

            public string Green
            {
                get
                {
                    return green;
                }

                set
                {
                    green = value;
                }
            }

            public string Intensity
            {
                get
                {
                    return intensity;
                }

                set
                {
                    intensity = value;
                }
            }
        }

    }
}
