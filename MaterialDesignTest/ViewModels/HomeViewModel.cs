using DmxController.ViewModels.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.ViewModels
{
    /// <summary>
    /// Représente le ViewModel utilisé pour la page d'acceuil de l'application
    /// </summary>
    public class HomeViewModel : ViewModel, IPageViewModel
    {
        /// <summary>
        /// Renvoie les modules nécessaire à HomeViewModel pour fonctionner.
        /// </summary>
        public List<IModuleViewModel> LeftModules
        {
            get
            {
                return new List<IModuleViewModel>();
            }
        }

        /// <summary>
        /// Renvoie le nom de ViewModel.
        /// </summary>
        public string Name
        {
            get
            {
                return "Home";
            }
        }

        /// <summary>
        /// Renvoie les modules nécessaire à HomeViewModel pour fonctionner.
        /// </summary>
        public List<IModuleViewModel> RightModules
        {
            get
            {
                return new List<IModuleViewModel>();
            }
           
        }
    }
}
