using DmxController.ViewModels.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DmxController.ViewModels
{
    /// <summary>
    /// Représente le ViewModel utilisé pour la page d'acceuil de l'application
    /// </summary>
    public class HomeViewModel : ViewModel, IPageViewModel
    {

        #region Properties / Commands
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

        public ICommand OpenCommand
        {
            get
            {
                throw new NotImplementedException();
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

        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand<object>((o) => { MessageBox.Show("Rien à sauvagarder"); });
            }
        }

        public ICommand SaveUnderCommand
        {
            get
            {
                return new RelayCommand<object>((o) => { MessageBox.Show("Rien à sauvagarder"); });
            }
        }

        public ICommand Send
        {
            get
            {
                return new RelayCommand<object>((o) => { MessageBox.Show("Rien à envoyer"); });
            }
        }

        public ICommand SendTo
        {
            get
            {
                return new RelayCommand<object>((o) => { MessageBox.Show("Rien à envoyer"); });
            }
        }

        public void Clear()
        {

        }
        #endregion
    }
}
