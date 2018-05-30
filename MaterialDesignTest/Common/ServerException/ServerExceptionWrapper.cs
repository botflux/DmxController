using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.Common.ServerException
{
    public class ServerExceptionWrapper
    {
        /// <summary>
        /// Code de l'exception
        /// </summary>
        private int code;
        /// <summary>
        /// Message de l'exception
        /// </summary>
        private string message;

        /// <summary>
        /// Renseigne ou renvoi le code d'erreur
        /// </summary>
        public int Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }

        /// <summary>
        /// Renseigne ou renvoi le message d'erreur
        /// </summary>
        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Code, Message);
        }
    }
}
