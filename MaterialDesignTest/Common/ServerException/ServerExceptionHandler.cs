using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.Common.ServerException
{
    public static class ServerExceptionHandler
    {
        public static ServerExceptionWrapper GetExceptionFromCode (int code)
        {
            ServerExceptionWrapper wrapper = new ServerExceptionWrapper() { Code = code };

            switch (code)
            {
                case -1:
                    wrapper.Message = "Des paquets ont été perdus lors de la réception.";
                    break;
                case -2:
                    wrapper.Message = "Le serveur n'a pas compris le formalisme.";
                    break;
                case -3:
                    wrapper.Message = "La demande n'a pas été comprise";
                    break;
                case -4:
                    wrapper.Message = "Aucune story board n'est jouée";
                    break;
                default:
                    wrapper.Message = "Erreur inconnue";
                    break;
            }

            return wrapper;
        }
    }
}
