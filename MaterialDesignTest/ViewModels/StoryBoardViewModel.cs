using DmxController.StoryBoards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DmxController.ViewModels
{
    public class StoryBoardViewModel : ViewModel, IPageViewModel
    {
        #region Interface
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
                return "StoryBoard";
            }
        }

        public List<IModuleViewModel> RightModules
        {
            get
            {
                return new List<IModuleViewModel>();
            }
        }
        #endregion

        private ObservableCollection<StoryBoardElement> story;


        public ObservableCollection<StoryBoardElement> Story
        {
            get
            {
                return story;
            }

            set
            {
                if (story != value)
                {
                    story = value;
                    NotifyProperty();
                }
            }
        }

        public StoryBoardViewModel ()
        {
            Story = new ObservableCollection<StoryBoardElement>()
            {
                new StoryBoardElement() {ElementColor = Color.FromRgb(255,0,0), Time = 1.0 },
                new StoryBoardElement() {ElementColor = Color.FromRgb(127,0,127), Time = 2.25 },
                new StoryBoardElement() {ElementColor = Color.FromRgb(0,120,0), Time = .75 }
            };
        }
    }
}
