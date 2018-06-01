
using DmxController.Common.Configurations;
using DmxController.Common.Files;
using DmxController.Common.Json;
using DmxController.Common.Network;
using DmxController.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
        private ICommand openCommand;

        private ICommand changeConfigurationCommand;
        private ICommand askStoryboardCommand;
        

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

        public ICommand OpenCommand
        {
            get
            {
                if (openCommand == null)
                {
                    openCommand = new RelayCommand<object>((o) => 
                    {
                        OpenFileDialog dialog = new OpenFileDialog();
                        dialog.FileName = "";
                        dialog.DefaultExt = ".sb";
                        dialog.Filter = "Story board file (.sb)|*.sb";
                        if(dialog.ShowDialog() == true)
                        {
                            JsonHandler.StoryBaordSave save = FilesHandler.Current.OpenStoryBoard(dialog.FileName);
                            ChangePageViewModel(PageViewModels[2]);
                            (PageViewModels[2] as StoryBoardViewModel).Story = new System.Collections.ObjectModel.ObservableCollection<StoryBoards.StoryBoardElement>(save.Elements);
                            (PageViewModels[2] as StoryBoardViewModel).StoryBoardName = Path.GetFileName(dialog.FileName);
                            (PageViewModels[2] as StoryBoardViewModel).StoryBoardPath = dialog.FileName;
                        }
                    });
                }

                return openCommand;
            }
        }

        public ICommand ChangeConfigurationCommand
        {
            get
            {
                return changeConfigurationCommand;
            }
        }

        public ICommand AskStoryboardCommand
        {
            get
            {
                if (askStoryboardCommand == null) askStoryboardCommand = new RelayCommand<object>((o) => 
                {
                    string command = JsonHandler.ConstructStoryboardNameRequest();
                    NetworkHandler.Current.Manager.SendFragmented(command);
                });

                return askStoryboardCommand;
            }
            
        }

        #endregion

        #region Methods
        private void ChangePageViewModel(IPageViewModel viewModel)
        {

            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);


            CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm == viewModel);
            CurrentPageViewModel.Clear();
        }

        protected override void NotifyProperty([CallerMemberName] string str = "")
        {
            base.NotifyProperty(str);
        }

        public void Clear()
        {
            throw new NotImplementedException();
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

            changeConfigurationCommand = new RelayCommand<object>((o) =>
            {
                ConfigurationView configurationView = new ConfigurationView();
                bool? res = configurationView.ShowDialog();
                if (res == true)
                {
                    AppConfiguration configuration = ConfigurationViewModel.GetConfiguration((ConfigurationViewModel)configurationView.DataContext);
                    FilesHandler.Current.SaveConfiguration(configuration);
                }
            });
        }
    }
}
