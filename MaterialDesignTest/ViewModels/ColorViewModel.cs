using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using VPackage.Json;
using DmxController.ViewModels.Modules;
using System.Windows;
using DmxController.Common.Json;
using DmxController.Common.Network;

namespace DmxController.ViewModels
{
    /// <summary>
    /// Représente le ViewModel utilisé pour l'interface de gestion des couleurs
    /// </summary>
    public class ColorViewModel : ViewModel, IPageViewModel
    {
        #region Fields
        /// <summary>
        /// La couleur renseigné par l'utilisateur.
        /// </summary>
        private Color mainColor;

        /// <summary>
        /// Le niveau de rouge renseigné par l'utilisateur.
        /// </summary>
        private byte r;
        /// <summary>
        /// Le niveau de vert renseigné par l'utilisateur.
        /// </summary>
        private byte g;
        /// <summary>
        /// Le niveau de bleu renseigné par l'utilisateur.
        /// </summary>
        private byte b;

        /// <summary>
        /// Les modules de droites nécessaire au fonctionnement de ColorViewModel.
        /// </summary>
        private List<IModuleViewModel> rightModules;

        /// <summary>
        /// La commande qui sert à envoyer la couleur au serveur.
        /// </summary>
        private ICommand sendColor;

        #endregion

        #region Properties / Commands

        /// <summary>
        /// Renvoie ou renseigne la valeur de la couleur.
        /// </summary>
        public Color MainColor
        {
            get
            {
                return mainColor;
            }

            set
            {
                if (mainColor != value)
                {
                    mainColor = value;
                    NotifyProperty();
                }
            }
        }

        /// <summary>
        /// Renvoie la composante rouge renseignée par l'utilisateur sous forme de Color.
        /// </summary>
        public Color RedBalance
        {
            get
            {
                return Color.FromRgb(r, 0, 0);
            }
        }

        /// <summary>
        /// Renvoie la composante verte renseignée par l'utilisateur sous forme de Color.
        /// </summary>
        public Color GreenBalance
        {
            get
            {
                return Color.FromRgb(0, g, 0);
            }
        }

        /// <summary>
        /// Renvoie la composante bleu renseignée par l'utilisateur sous forme de Color.
        /// </summary>
        public Color BlueBalance
        {
            get
            {
                return Color.FromRgb(0, 0, b);
            }
        }

        /// <summary>
        /// Renvoie ou renseigne la composante rouge de la couleur.
        /// </summary>
        public byte R
        {
            get
            {
                return r;
            }

            set
            {
                if (r != value)
                {
                    r = value;
                    NotifyProperty();
                    NotifyProperty("RedBalance");
                }
            }
        }

        /// <summary>
        /// Renvoie ou renseigne la composante verte de la couleur.
        /// </summary>
        public byte G
        {
            get
            {
                return g;
            }

            set
            {
                if (g != value)
                {
                    g = value;
                    NotifyProperty();
                    NotifyProperty("GreenBalance");
                }
            }
        }

        /// <summary>
        /// Renvoie ou renseigne la composante bleu de la couleur.
        /// </summary>
        public byte B
        {
            get
            {
                return b;
            }

            set
            {
                if (b != value)
                {
                    b = value;
                    NotifyProperty();
                    NotifyProperty("BlueBalance");
                }
            }
        }
        

        /// <summary>
        /// Renvoie les modules de droites utilisés par ce ViewModel.
        /// </summary>
        public List<IModuleViewModel> RightModules
        {
            get
            {
                if (rightModules == null) rightModules = new List<IModuleViewModel>();
                return rightModules;
            }
        }

        /// <summary>
        /// Renvoie les modules de gauches utilisés par ce ViewModel.
        /// </summary>
        public List<IModuleViewModel> LeftModules
        {
            get
            {
                return new List<IModuleViewModel>();
            }
        }

        /// <summary>
        /// Renvoie la commande utilisé pour envoyer la couleur au serveur.
        /// </summary>
        public ICommand Send
        {
            get
            {
                if (sendColor == null) sendColor = new RelayCommand<object>((o) =>
                {
                    string frame = JsonHandler.ConstructColorPacket(R, G, B, 255, "PROJO", 1);

                    MessageBox.Show(string.Format("{0}: {1}", frame.Length, frame));

                    //UtilityProvider.Current.NetManager.Send(frame);
                    NetworkHandler.Current.Manager.Send(frame);
                });

                return sendColor;
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand<object>((o) => { MessageBox.Show("Rien à sauvegarder"); });
            }
        }

        public ICommand SaveUnderCommand
        {
            get
            {
                return new RelayCommand<object>((o) => { MessageBox.Show("Rien à sauvegarder"); });
            }
        }

        public ICommand SendTo
        {
            get
            {
                return Send;
            }
        }

        public ICommand OpenCommand
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        /// <summary>
        /// Renseigne la vue d'un changement dans le modèle
        /// </summary>
        /// <param name="str"></param>
        protected override void NotifyProperty([CallerMemberName] string str = "")
        {
            base.NotifyProperty(str);
            MainColor = Color.FromRgb(R, G, B);
        }

        public void Clear()
        {
            R = 127;
            G = 127;
            B = 127;
        }

        public ColorViewModel ()
        {
            RightModules.Add(new ColorBalanceModuleViewModel() { Parent = this });
            RightModules.Add(new ActionColorModuleViewModel() { Parent = this });

            R = 127;
            G = 127;
            B = 127;
        }
    }
}
