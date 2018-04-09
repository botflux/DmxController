using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.ViewModels
{
    /// <summary>
    /// Représente la classe de base des ViewModels de l'application
    /// </summary>
    public abstract class ViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Appelé lors ce qu'une proprieté change.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Sert à appeler l'évènement PropertyChanged.
        /// </summary>
        /// <param name="str">Nom de la propriété changée</param>
        protected virtual void NotifyProperty ([CallerMemberName] string str = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(str));
        }
    }
}
