
using DmxController.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DmxController.ViewModels
{
    /// <summary>
    /// Représente le ViewModel de l'interface de paramatrage de l'application.
    /// </summary>
    public class SettingsViewModel : ViewModel, IPageViewModel, IConfigurable<Configuration>
    {
        /// <summary>
        /// La configuration utilisé dans l'application.
        /// </summary>
        private Configuration configuration;

        /// <summary>
        /// Commande servant à changer de ViewModel.
        /// </summary>
        private ICommand changePageCommand;
        /// <summary>
        /// Représente le ViewModel actuellement utilisé.
        /// </summary>
        private IPageViewModel currentPageViewModel;
        /// <summary>
        /// Représente l'ensemble des ViewModels utilisé dans ce ViewModel
        /// </summary>
        private List<IPageViewModel> pageViewModels;

        /// <summary>
        /// Commande servant à annuler cette fenêtre de dialogue.
        /// </summary>
        private ICommand cancelDialog;
        /// <summary>
        /// Commande servant à comfirmer cette fenêtre de dialogue.
        /// </summary>
        private ICommand confirmDialog;

        #region Command / Properties
        /// <summary>
        /// Représente les modules utilisés pour ce ViewModel.
        /// </summary>
        public List<IModuleViewModel> LeftModules
        {
            get
            {
                return new List<IModuleViewModel>();
            }
        }

        /// <summary>
        /// Représente les modules utilisés pour ce ViewModel.
        /// </summary>
        public List<IModuleViewModel> RightModules
        {
            get
            {
                return new List<IModuleViewModel>();
            }
        }

        /// <summary>
        /// Représente les ViewModels contenu dans ce ViewModel.
        /// </summary>
        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (pageViewModels == null) pageViewModels = new List<IPageViewModel>();
                return pageViewModels;
            }
        }

        /// <summary>
        /// Renvoie le nom de ce ViewModel.
        /// </summary>
        public string Name
        {
            get
            {
                return "Settings";
            }
        }

        /// <summary>
        /// Sert à changer de ViewModel.
        /// </summary>
        public ICommand ChangePageCommand
        {
            get
            {
                return changePageCommand;
            }
        }

        /// <summary>
        /// Renvoie ou renseigne le ViewModel actuellement utilisé.
        /// </summary>
        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return currentPageViewModel;
            }

            set
            {
                currentPageViewModel = value;
                NotifyProperty();
            }
        }

        /// <summary>
        /// Renvoie la commande servant à confirmer le dialogue.
        /// </summary>
        public ICommand ConfirmDialog
        {
            get
            {
                if (confirmDialog == null) confirmDialog = new RelayCommand<Window>((window) =>
                {
                    UtilityProvider.Current.ConfHandler.CurrentConfiguration = new Configuration()
                    {
                        CurrentNetworkConfiguration = (this.PageViewModels[0] as NetworkFormViewModel).Configuration,
                        CurrentTargetConfiguration = (this.PageViewModels[1] as TargetFormViewModel).Configuration
                    };
                    window.DialogResult = true;
                });

                return confirmDialog;
            }
        }

        /// <summary>
        /// Renvoie la commande servant à annuler le dialogue.
        /// </summary>
        public ICommand CancelDialog
        {
            get
            {
                if (cancelDialog == null) cancelDialog = new RelayCommand<Window>((window) =>
                {
                    window.DialogResult = false;
                });

                return cancelDialog;
            }
        }

        /// <summary>
        /// Renvoie la configuration actuelle.
        /// </summary>
        public Configuration Configuration
        {
            get
            {
                return configuration;
            }

            set
            {
                configuration = value;
            }
        }
        #endregion

        #region Methods
        protected override void NotifyProperty([CallerMemberName] string str = "")
        {
            base.NotifyProperty(str);
        }
        /// <summary>
        /// Change de ViewModel.
        /// </summary>
        /// <param name="viewModel">Nouveau ViewModel</param>
        private void ChangePageViewModel(IPageViewModel viewModel)
        {

            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm == viewModel);
        }
        

        #endregion
        public SettingsViewModel()
        {
            PageViewModels.Add(new NetworkFormViewModel()
            {
                Configuration = UtilityProvider.Current.ConfHandler.CurrentConfiguration.CurrentNetworkConfiguration
            });
            PageViewModels.Add(new TargetFormViewModel()
            {
                Configuration = UtilityProvider.Current.ConfHandler.CurrentConfiguration.CurrentTargetConfiguration
            });

            CurrentPageViewModel = PageViewModels[0];

            changePageCommand = new RelayCommand<IPageViewModel>(
                    p => ChangePageViewModel((IPageViewModel)p),
                    p => p is IPageViewModel
            );
        }
    }
}
