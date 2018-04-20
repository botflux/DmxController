using DmxController.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DmxController.ViewModels
{
    public class NewStoryBoardViewModel : ViewModel, IPageViewModel
    {

        #region Fields
        private string storyBoardName;
        private ICommand validDialogCommand;
        #endregion

        #region Properties
        public List<IModuleViewModel> LeftModules
        {
            get
            {
                return new List<IModuleViewModel>();
            }
        }

        public string Name
        {
            get
            {
                return "NewStoryBoard";
            }
        }

        public List<IModuleViewModel> RightModules
        {
            get
            {
                return new List<IModuleViewModel>();
            }
        }

        public string StoryBoardName
        {
            get
            {
                return storyBoardName;
            }

            set
            {
                if (storyBoardName != value)
                {
                    storyBoardName = value;
                    NotifyProperty();
                }
            }
        }

        public ICommand ValidDialogCommand
        {
            get
            {
                return validDialogCommand;
            }
        }
        #endregion

        public NewStoryBoardViewModel ()
        {
            validDialogCommand = new RelayCommand<Window>((v) => 
            {
                DialogCloser.SetDialogResult(v, true);
            });
        }
    }
}
