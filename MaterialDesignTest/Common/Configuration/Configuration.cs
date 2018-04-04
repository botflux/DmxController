using DmxController.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.Common.Configuration
{
    [DataContract]
    public class Configuration
    {
        [DataMember]
        private IPAddress hostname;
        [DataMember]
        private int sendPort;
        [DataMember]
        private int receivePort;
        [DataMember]
        private TargetTypeEnum targetType;
        [DataMember]
        private int targetAddress;

        public int TargetAddress
        {
            get
            {
                return targetAddress;
            }

            set
            {
                targetAddress = value;
            }
        }

        public TargetTypeEnum TargetType
        {
            get
            {
                return targetType;
            }

            set
            {
                targetType = value;
            }
        }

        public int ReceivePort
        {
            get
            {
                return receivePort;
            }

            set
            {
                receivePort = value;
            }
        }

        public int SendPort
        {
            get
            {
                return sendPort;
            }

            set
            {
                sendPort = value;
            }
        }

        public IPAddress Hostname
        {
            get
            {
                return hostname;
            }

            set
            {
                hostname = value;
            }
        }
    }
}
