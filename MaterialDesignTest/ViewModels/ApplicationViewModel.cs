
using DmxController.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VPackage.Json;
using VPackage.Network;

namespace DmxController.ViewModels
{
    public class ApplicationViewModel : ViewModel, IPageViewModel
    {

        #region Fields

        private ViewState applicationViewState;

        private ICommand closeApplication;
        private ICommand handleLeftPanel;
        private ICommand handleRightPanel;

        private ICommand newStoryBoardCommand;



        private ICommand changePageCommand;
        private IPageViewModel currentPageViewModel;
        private List<IPageViewModel> pageViewModels;

        #endregion

        #region Propreties / Commands
        public ICommand CloseApplication
        {
            get
            {
                if (closeApplication == null) closeApplication =
                        new RelayCommand<ApplicationViewModel>((applicationViewModel) =>
                {
                    Application.Current.Shutdown();
                });

                return closeApplication;
            }
        }

        public ICommand ChangePageCommand
        {
            get
            {
                return changePageCommand;
            }
        }

        public ICommand HandleLeftPanel
        {
            get
            {
                if (handleLeftPanel == null) handleLeftPanel = new RelayCommand<ViewState>((state) =>
                {
                    state.LeftPanelState = !state.LeftPanelState;

                    if (state.LeftPanelState)
                    {
                        MainWindow.ShowLeftPanel.Begin();
                    }
                    else
                    {
                        MainWindow.HideLeftPanel.Begin();
                    }
                });

                return handleLeftPanel;
            }
        }

        public ICommand HandleRightPanel
        {
            get
            {
                if (handleRightPanel == null) handleRightPanel = new RelayCommand<ViewState>((state) =>
                {
                    state.RightPanelState = !state.RightPanelState;

                    if (state.RightPanelState)
                    {
                        MainWindow.ShowRightPanel.Begin();
                    }
                    else
                    {
                        MainWindow.HideRightPanel.Begin();
                    }
                });

                return handleRightPanel;
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

        public List<IModuleViewModel> RightModules
        {
            get
            {
                return new List<IModuleViewModel>();
            }
        }

        public List<IModuleViewModel> LeftModules
        {
            get
            {
                return new List<IModuleViewModel>();
            }
        }

        public ViewState ApplicationViewState
        {
            get
            {
                return applicationViewState;
            }

            set
            {
                applicationViewState = value;
            }
        }

        public ICommand NewStoryBoardCommand
        {
            get
            {
                return newStoryBoardCommand;
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand<object>((o) => 
                {
                    throw new NotImplementedException();
                });
            }
        }

        public ICommand SaveUnderCommand
        {
            get
            {
                return new RelayCommand<object>((o) =>
                {
                    throw new NotImplementedException();
                });
            }
        }

        public ICommand Send
        {
            get
            {
                return new RelayCommand<object>((o) =>
                {
                    throw new NotImplementedException();
                });
            }
        }

        public ICommand SendTo
        {
            get
            {
                return new RelayCommand<object>((o) =>
                {
                    throw new NotImplementedException();
                });
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
            PageViewModels.Add(new StoryBoardViewModel());

            CurrentPageViewModel = PageViewModels[0];
            ApplicationViewState = new ViewState();

            changePageCommand = new RelayCommand<IPageViewModel>(
                    p => ChangePageViewModel((IPageViewModel)p),
                    p => p is IPageViewModel
            );

            newStoryBoardCommand = new RelayCommand<object>((o) =>
            {
                NewStoryBoardView v = new NewStoryBoardView();
                if (v.ShowDialog() == true)
                {
                    ChangePageViewModel(PageViewModels[2]);
                    StoryBoardViewModel vm = (PageViewModels[2] as StoryBoardViewModel);
                    vm.StoryBoardName = (v.DataContext as NewStoryBoardViewModel).StoryBoardName;
                }
            });
        }
    }
}
