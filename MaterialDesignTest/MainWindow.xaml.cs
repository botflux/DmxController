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

namespace DmxController
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Storyboard showLeftPanel;
        private static Storyboard hideLeftPanel;
        private static Storyboard showRightPanel;
        private static Storyboard hideRightPanel;

        public static Storyboard ShowLeftPanel
        {
            get
            {
                return showLeftPanel;
            }
        }

        public static Storyboard HideLeftPanel
        {
            get
            {
                return hideLeftPanel;
            }
        }

        public static Storyboard ShowRightPanel
        {
            get
            {
                return showRightPanel;
            }
        }

        public static Storyboard HideRightPanel
        {
            get
            {
                return hideRightPanel;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            showLeftPanel = this.FindResource("ShowLeftPanel") as Storyboard;
            hideLeftPanel = this.FindResource("HideLeftPanel") as Storyboard;
            showRightPanel = this.FindResource("ShowRightPanel") as Storyboard;
            hideRightPanel = this.FindResource("HideRightPanel") as Storyboard;
        }
    }
}
