using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace DmxController.StoryBoards
{
    public class StoryBoardElement : INotifyPropertyChanged
    {
        private byte r;
        private byte g;
        private byte b;
        private double time;

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyProperty ([CallerMemberName] string str = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(str));
        }

        public Color RedBalance
        {
            get
            {
                return Color.FromRgb(r, 0, 0);
            }
        }

        public Color BlueBalance
        {
            get
            {
                return Color.FromRgb(0, 0, b);
            }
        }

        public Color GreenBalance
        {
            get
            {
                return Color.FromRgb(0, g, 0);
            }
        }

        public Color ElementColor
        {
            get
            {
                return Color.FromRgb(r, g, b);
            }
        }

        public double Time
        {
            get
            {
                return time;
            }

            set
            {
                if (time != value)
                {


                    time = value;
                    NotifyProperty();
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
                    NotifyProperty();
                    NotifyProperty("BlueBalance");
                    NotifyProperty("ElementColor");
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
                    NotifyProperty();
                    NotifyProperty("GreenBalance");
                    NotifyProperty("ElementColor");
                }

            }
        }

        public byte R
        {
            get
            {
                return r;
            }

            set
            {   if (value != r)
                {
                    r = value;
                    NotifyProperty();
                    NotifyProperty("RedBalance");
                    NotifyProperty("ElementColor");
                }
            }
        }
    }
}
