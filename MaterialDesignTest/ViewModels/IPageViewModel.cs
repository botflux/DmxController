using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.ViewModels
{
    /// <summary>
    /// Interface de base des ViewModels de l'application.
    /// </summary>
    public interface IPageViewModel
    {
        /// <summary>
        /// Renvoie les modules de gauches nécessaire au ViewModel pour fonctionner.
        /// </summary>
        List<IModuleViewModel> LeftModules { get; }
        /// <summary>
        /// Renvoie les modules de droites nécessaire au ViewModel pour fonctionner.
        /// </summary>
        List<IModuleViewModel> RightModules { get; }

        /// <summary>
        /// Renvoie le nom du ViewModel.
        /// </summary>
        string Name { get; }
    }
}
