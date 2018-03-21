using DmxController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaterialDesignTest
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UIStates uiStates = new UIStates(true, true);

        private ColorViewModel myColorViewModel = new ColorViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        #region Commands
        private ICommand closeMainTab = new RelayCommand<MainWindow>((window) =>
        {
            window.grid_changeColor.Visibility = Visibility.Hidden;
            window.grid_welcome.Visibility = Visibility.Visible;
        });

        private ICommand closeApplication = new RelayCommand<MainWindow>((window) =>
        {
            Application.Current.Shutdown();
        });

        private ICommand colorMenu = new RelayCommand<MainWindow>((window) =>
        {
            window.grid_welcome.Visibility = Visibility.Hidden;
            window.grid_changeColor.Visibility = Visibility.Visible;
        });

        private ICommand handleLeftPanel = new RelayCommand<MainWindow>((window) =>
        {
            window.uiStates.IsLeftPanelShown = !window.uiStates.IsLeftPanelShown;

            if (window.uiStates.IsLeftPanelShown)
            {
                (window.FindResource("OpenLeftPanel") as Storyboard).Begin();
            }
            else
            {
                (window.FindResource("CloseLeftPanel") as Storyboard).Begin();
            }
        });

        private ICommand handleRightPanel = new RelayCommand<MainWindow>((window) =>
        {
            window.uiStates.IsRightPanelShown = !window.uiStates.IsRightPanelShown;

            if (window.uiStates.IsRightPanelShown)
            {
                (window.FindResource("OpenRightPanel") as Storyboard).Begin();
            }
            else
            {
                (window.FindResource("CloseRightPanel") as Storyboard).Begin();
            }
        });
#endregion

        #region Commands
        public ICommand ColorMenu
        {
            get
            {
                return colorMenu;
            }
        }

        public ICommand HandleLeftPanel
        {
            get
            {
                return handleLeftPanel;
            }
        }

        public ICommand HandleRightPanel
        {
            get
            {
                return handleRightPanel;
            }
        }

        public ICommand CloseMainTab
        {
            get
            {
                return closeMainTab;
            }
        }

        public ICommand CloseApplication
        {
            get
            {
                return closeApplication;
            }
        }
        #endregion

        public ColorViewModel MyColorViewModel
        {
            get
            {
                return myColorViewModel;
            }

            set
            {
                myColorViewModel = value;
            }
        }
        

        private struct UIStates
        {
            private bool isLeftPanelShown;
            private bool isRightPanelShown;

            public bool IsLeftPanelShown
            {
                get
                {
                    return isLeftPanelShown;
                }

                set
                {
                    isLeftPanelShown = value;
                }
            }

            public bool IsRightPanelShown
            {
                get
                {
                    return isRightPanelShown;
                }

                set
                {
                    isRightPanelShown = value;
                }
            }

            public UIStates (bool isRightPanelShown, bool isLeftPanelShown)
            {
                this.isLeftPanelShown = isLeftPanelShown;
                this.isRightPanelShown = isRightPanelShown;
            }
        }
    }
}
