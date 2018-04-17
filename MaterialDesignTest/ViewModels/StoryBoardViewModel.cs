using DmxController.StoryBoards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Runtime.CompilerServices;
using DmxController.ViewModels.Modules;

namespace DmxController.ViewModels
{
    public class StoryBoardViewModel : ViewModel, IPageViewModel
    {
        private List<IModuleViewModel> leftModules;
        private List<IModuleViewModel> rightModules;

        #region Interface
        public List<IModuleViewModel> LeftModules
        {
            get
            {
                if (leftModules == null) leftModules = new List<IModuleViewModel>();
                return leftModules;
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
                if (rightModules == null) rightModules = new List<IModuleViewModel>();
                return rightModules;
            }
        }
        #endregion
        private StoryBoardElement currentElement;
        private ICommand changeStoryBoardElementCommand;
        private ICommand addStoryBoardElementCommand;
        private ICommand deleteStoryBoardElementCommand;

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

        public StoryBoardElement CurrentElement
        {
            get
            {
                return currentElement;
            }

            set
            {
                if (currentElement != value)
                {
                    currentElement = value;
                    NotifyProperty();
                    NotifyProperty("Story");
                }
            }
        }

        public ICommand ChangeStoryBoardElementCommand
        {
            get
            {
                return changeStoryBoardElementCommand;
            }
        }

        public ICommand AddStoryBoardElementCommand
        {
            get
            {
                return addStoryBoardElementCommand;
            }
        }

        public ICommand DeleteStoryBoardElementCommand
        {
            get
            {
                return deleteStoryBoardElementCommand;
            }
        }

        public StoryBoardViewModel ()
        {
            RightModules.Add(new StoryBoardElementModuleViewModel() { Parent = this });
            RightModules.Add(new StoryBoardElementActionModuleViewModel() { Parent = this });

            Story = new ObservableCollection<StoryBoardElement>()
            {
                new StoryBoardElement() {R = 100, G = 211, B = 25, Time = 1.0 },
                new StoryBoardElement() {R = 200, G = 23, B = 32, Time = 0.25 },
            };

            changeStoryBoardElementCommand = new RelayCommand<StoryBoardElement>(
                p => ChangeStoryBoardElementIndex(p));
            addStoryBoardElementCommand = new RelayCommand<object>(o => Story.Add(new StoryBoardElement()
            {
                R = 127,
                G = 127,
                B = 127,
                Time = 1
            }));
            deleteStoryBoardElementCommand = new RelayCommand<StoryBoardElement>(o => Story.Remove(o));
        }

        private void ChangeStoryBoardElementIndex (StoryBoardElement element)
        {

            CurrentElement = element;
            if (CurrentElement == null)
            {
                if (Story.Count > 0)
                    CurrentElement = Story[0];
                else
                    CurrentElement = new StoryBoardElement() { R = 100, B = 100, G = 100, Time = 1 };
            }
        }

        protected override void NotifyProperty([CallerMemberName] string str = "")
        {
            base.NotifyProperty(str);
        }
    }
}
