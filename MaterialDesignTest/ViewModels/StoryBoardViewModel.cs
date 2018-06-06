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
using VPackage.Json;
using DmxController.Common.Json;
using VPackage.Network;
using DmxController.Common.Network;
using VPackage.Files;
using DmxController.Common.Files;
using Microsoft.Win32;
using System.IO;

namespace DmxController.ViewModels
{
    public class StoryBoardViewModel : ViewModel, IPageViewModel
    {
        #region Fields
        /// <summary>
        /// Représente les modules gauches nécessaire à ce ViewModel
        /// </summary>
        private List<IModuleViewModel> leftModules;
        /// <summary>
        /// Représente les modules droits nécessaire à ce ViewModel
        /// </summary>
        private List<IModuleViewModel> rightModules;
        /// <summary>
        /// Représente l'éléments en cours d'inspection dans l'interface
        /// </summary>
        private StoryBoardElement currentElement;
        /// <summary>
        /// Représente la commande servant à changer l'élément à inspecter
        /// </summary>
        private ICommand changeStoryBoardElementCommand;
        /// <summary>
        /// Représente la commande servant à ajouter un nouvel éléments dans la story board
        /// </summary>
        private ICommand addStoryBoardElementCommand;
        /// <summary>
        /// Représente la commande servant à supprimer l'éléments séléctionné de la story board
        /// </summary>
        private ICommand deleteStoryBoardElementCommand;
        /// <summary>
        /// Représente la commande servant à envoyer la story board au serveur
        /// </summary>
        private ICommand sendStoryBoardCommand;
        /// <summary>
        /// Réprésente la commande servant à sauvegarder la story board en cours
        /// </summary>
        private ICommand saveStoryBoardCommand;
        /// <summary>
        /// Représente la story board
        /// </summary>
        private ObservableCollection<StoryBoardElement> story;
        /// <summary>
        /// Le nom de la story board
        /// </summary>
        private string storyBoardName;
        /// <summary>
        /// Le chemin sous lequel la story board est sauvegarder
        /// </summary>
        private string storyBoardPath;
        /// <summary>
        /// Renseigne si l'utilisateur a fait des changements sur la storyboard qui n'ont pas été sauvegarder
        /// </summary>
        private bool hasChanges;
        /// <summary>
        /// Nombre d'élément dans la storyboard
        /// </summary>
        private int elementCount;
        #endregion

        #region Properties
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
                    ElementCount = story.Count;
                    story.CollectionChanged += Story_CollectionChanged;
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
                    NotifyProperty("CurrentElementIsNull");
                    NotifyProperty("CurrentElementIsNotNull");
                }
            }
        }

        public Visibility CurrentElementIsNull
        {
            get
            {
                return (currentElement == null)? Visibility.Visible : Visibility.Hidden;
            }
        }

        public Visibility CurrentElementIsNotNull
        {
            get
            {
                return (currentElement != null) ? Visibility.Visible : Visibility.Hidden;
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

        public ICommand SendStoryBoardCommand
        {
            get
            {
                return sendStoryBoardCommand;
            }
        }

        public ICommand SaveStoryBoardCommand
        {
            get
            {
                return saveStoryBoardCommand;
            }
        }

        public List<IModuleViewModel> LeftModules
        {
            get
            {
                if (leftModules == null) leftModules = new List<IModuleViewModel>();
                return leftModules;
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

                    NotifyProperty("DisplayName");
                }
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return saveStoryBoardCommand;
            }
        }

        public ICommand SaveUnderCommand
        {
            get
            {
                return saveStoryBoardCommand;
            }
        }

        public ICommand Send
        {
            get
            {
                return sendStoryBoardCommand;
            }
        }

        public ICommand OpenCommand
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string StoryBoardPath
        {
            get
            {
                return storyBoardPath;
            }

            set
            {
                if (storyBoardPath != value)
                {
                    storyBoardPath = value;
                    NotifyProperty();
                    NotifyProperty("DisplayName");
                }
            }
        }

        public string DisplayName
        {
            get
            {
                return (string.IsNullOrEmpty(storyBoardPath)) ? storyBoardName : storyBoardPath;
            }
        }

        public bool HasChanges
        {
            get
            {
                return hasChanges;
            }

            set
            {
                if (hasChanges != value)
                {
                    hasChanges = value;
                    NotifyProperty();
                }
            }
        }

        public int ElementCount
        {
            get
            {
                return elementCount;
            }

            set
            {
                if (elementCount != value)
                {
                    elementCount = value;
                    NotifyProperty();
                }
            }
        }

        #endregion

        #region Constructors
        public StoryBoardViewModel ()
        {
            RightModules.Add(new StoryBoardElementModuleViewModel() { Parent = this });
            RightModules.Add(new StoryBoardElementActionModuleViewModel() { Parent = this });
            LeftModules.Add(new StoryBoardInformationModuleViewModel() { Parent = this });

            Story = new ObservableCollection<StoryBoardElement>();

            changeStoryBoardElementCommand = new RelayCommand<StoryBoardElement>((e) =>
            {
                CurrentElement = e;
                if (CurrentElement == null)
                {
                    if (Story.Count > 0)
                    {
                        CurrentElement = Story[0];
                    }
                    else
                    {
                        CurrentElement = null;
                    }
                }
            });

            addStoryBoardElementCommand = new RelayCommand<object>(o => Story.Add(new StoryBoardElement()
            {
                R = 127,
                G = 127,
                B = 127,
                Time = 1
            }));

            deleteStoryBoardElementCommand = new RelayCommand<StoryBoardElement>((o) => 
            {
                Story.Remove(o);
            });

            sendStoryBoardCommand = new RelayCommand<object>((o) => 
            {
                string j = JsonHandler.ConstructStoryBoardPacket(story.ToArray(), (FilesHandler.Current.CurrentConfiguration.TargetType == TargetTypeEnum.Barre) ? "BARRELED" : "SPOTLED", FilesHandler.Current.CurrentConfiguration.LightAddress, StoryBoardName);
                //MessageBox.Show(j);
                NetworkHandler.Current.Manager.SendFragmented(j);
            });

            saveStoryBoardCommand = new RelayCommand<object>((o) => 
            {
                if (string.IsNullOrEmpty(storyBoardPath))
                {
                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.FileName = storyBoardName;
                    dialog.DefaultExt = ".sb";
                    dialog.Filter = "Story board file (.sb)|*.sb";

                    if (dialog.ShowDialog() == true)
                    {
                        StoryBoardPath = dialog.FileName;
                        StoryBoardName = Path.GetFileName(StoryBoardPath);
                        FilesHandler.Current.SaveStoryBoard(dialog.FileName, story.ToArray());
                        HasChanges = false;
                    }
                    
                }
                else
                {
                    FilesHandler.Current.SaveStoryBoard(StoryBoardPath, story.ToArray());
                    HasChanges = false;
                }
            });
        }

        #endregion

        #region Methods


        protected override void NotifyProperty([CallerMemberName] string str = "")
        {
            base.NotifyProperty(str);
        }

        public void Clear()
        {
            Story.Clear();
            StoryBoardName = string.Empty;
            CurrentElement = null;
            StoryBoardPath = string.Empty;
            ElementCount = 0;
        }

        private void Story_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            HasChanges = true;
            ElementCount = story.Count;
        }
        #endregion
    }
}
