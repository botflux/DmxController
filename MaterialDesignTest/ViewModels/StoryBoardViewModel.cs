﻿using DmxController.StoryBoards;
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

        public string StoryBoardName
        {
            get
            {
                return storyBoardName;
            }

            set
            {
                storyBoardName = value;
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand<object>((o) => { MessageBox.Show("Rien à sauvagarder"); });
            }
        }

        public ICommand SaveUnderCommand
        {
            get
            {
                return new RelayCommand<object>((o) => { MessageBox.Show("Rien à sauvagarder"); });
            }
        }

        public ICommand Send
        {
            get
            {
                return new RelayCommand<object>((o) => { MessageBox.Show("Rien à sauvagarder"); });
            }
        }

        public ICommand SendTo
        {
            get
            {
                return new RelayCommand<object>((o) => { MessageBox.Show("Rien à sauvagarder"); });
            }
        }


        #endregion

        #region Constructors
        public StoryBoardViewModel ()
        {
            RightModules.Add(new StoryBoardElementModuleViewModel() { Parent = this });
            RightModules.Add(new StoryBoardElementActionModuleViewModel() { Parent = this });

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
                        CurrentElement = new StoryBoardElement() { R = 100, G = 100, B = 100, Time = 1 };
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
                //UtilityProvider.Current.NetManager.Send(PacketHandler.ConstructStoryBoardPacket(story.ToArray(), "PROJO", 1, "Story board 1"));
                NetworkHandler.Current.Manager.Send(JsonHandler.ConstructStoryBoardPacket(story.ToArray(), "PROJO", 1, "Story board 1"));
            });

            saveStoryBoardCommand = new RelayCommand<object>((o) => 
            {
                FilesHandler.Current.SaveStoryBoard(storyBoardName, story.ToArray());
            });
        }

        #endregion

        #region Methods
        protected override void NotifyProperty([CallerMemberName] string str = "")
        {
            base.NotifyProperty(str);
        }
        #endregion
    }
}
