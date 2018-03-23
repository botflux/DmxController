using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Runtime.CompilerServices;

namespace DmxController
{
    public class ColorViewModel : INotifyPropertyChanged
    {
        private Color mainColor;

        private byte r;
        private byte g;
        private byte b;

        public Color MainColor
        {
            get
            {
                return mainColor;
            }

            set
            {
                mainColor = value;
            }
        }

        public Color RedBalance
        {
            get
            {
                return Color.FromRgb(r, 0, 0);
            }
        }

        public Color GreenBalance
        {
            get
            {
                return Color.FromRgb(0, g, 0);
            }
        }


        public Color BlueBalance
        {
            get
            {
                return Color.FromRgb(0, 0, b);
            }
        }

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
                    NotifyPropertyChanged();
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("RedBalance"));
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("MainColor"));
                }
            }
        }

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
                    NotifyPropertyChanged();
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("GreenBalance"));
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("MainColor"));
                }
            }
        }

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
                    NotifyPropertyChanged();
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("BlueBalance"));
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("MainColor"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged ([CallerMemberName] string str = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(str));

            MainColor = Color.FromRgb(R, G, B);
        }

        public ColorViewModel ()
        {
            R = 127;
            G = 127;
            B = 127;
        }
    }
}
