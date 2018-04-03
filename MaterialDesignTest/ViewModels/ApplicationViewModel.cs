using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VPackage.Network;

namespace DmxController.ViewModels
{
    public class ApplicationViewModel : ViewModel, IPageViewModel
    {

        #region Fields

        private ICommand changePageCommand;
        private IPageViewModel currentPageViewModel;
        private List<IPageViewModel> pageViewModels;

        #endregion

        #region Propreties / Commands

        public ICommand ChangePageCommand
        {
            get
            {
                return changePageCommand;
            }
        }

        public string Name
        {
            get
            {
                return "Application";
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return currentPageViewModel;
            }

            set
            {
                if (currentPageViewModel != value)
                {
                    currentPageViewModel = value;
                    NotifyProperty();
                }
            }
        }

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (pageViewModels == null) pageViewModels = new List<IPageViewModel>();
                return pageViewModels;
            }

        }


        public IModuleViewModel SidePanel
        {
            get
            {
                return null;
            }

            set
            {

            }
        }

        #endregion

        #region Methods

        private void ChangePageViewModel(IPageViewModel viewModel)
        {

            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm == viewModel);
        }

        protected override void NotifyProperty([CallerMemberName] string str = "")
        {
            base.NotifyProperty(str);
        }

        #endregion

        public ApplicationViewModel()
        {
            PageViewModels.Add(new HomeViewModel());
            PageViewModels.Add(new ColorViewModel());

            CurrentPageViewModel = PageViewModels[0];

            changePageCommand = new RelayCommand<IPageViewModel>(
                    p => ChangePageViewModel((IPageViewModel)p),
                    p => p is IPageViewModel
            );
        }
    }
}
