﻿
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
    public class SettingsViewModel : ViewModel, IPageViewModel, IConfigurable<Configuration>
    {
        private Configuration configuration;

        private ICommand changePageCommand;
        private IPageViewModel currentPageViewModel;
        private List<IPageViewModel> pageViewModels;

        private ICommand cancelDialog;
        private ICommand confirmDialog;

        #region Command / Properties
        public List<IModuleViewModel> LeftModules
        {
            get
            {
                return new List<IModuleViewModel>();
            }
        }

        public List<IModuleViewModel> RightModules
        {
            get
            {
                return new List<IModuleViewModel>();
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
        public string Name
        {
            get
            {
                return "Settings";
            }
        }

        public ICommand ChangePageCommand
        {
            get
            {
                return changePageCommand;
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
                currentPageViewModel = value;
                NotifyProperty();
            }
        }

        public ICommand ConfirmDialog
        {
            get
            {
                if (confirmDialog == null) confirmDialog = new RelayCommand<Window>((window) =>
                {
                    window.DialogResult = true;
                });

                return confirmDialog;
            }
        }

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
        private void ChangePageViewModel(IPageViewModel viewModel)
        {

            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm == viewModel);
        }
        

        #endregion

        public SettingsViewModel()
        {
            PageViewModels.Add(new NetworkFormViewModel());
            PageViewModels.Add(new TargetFormViewModel());

            CurrentPageViewModel = PageViewModels[0];

            changePageCommand = new RelayCommand<IPageViewModel>(
                    p => ChangePageViewModel((IPageViewModel)p),
                    p => p is IPageViewModel
            );
        }
    }
}
