using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using DmxController.ViewModels;
using System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace DmxController.StoryBoards
{
    public class StoryBoardElement : INotifyPropertyChanged
    {
        private const double MIN_TIME_VALUE = 0.1;
        private const double MAX_TIME_VALUE = 3600;

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
                    if (value < MIN_TIME_VALUE) time = MIN_TIME_VALUE;
                    else if (value > MAX_TIME_VALUE) time = MAX_TIME_VALUE;
                    else time = value;
                    NotifyProperty();
                }
            }
        }

        [IntegerValidator(MinValue = 0, MaxValue = 255)]
        public int B
        {
            get
            {
                return b;
            }

            set
            {
                if (b != value)
                {


                    b = (byte)value;
                    NotifyProperty();
                    NotifyProperty("BlueBalance");
                    NotifyProperty("ElementColor");
                }
            }
        }

        [IntegerValidator(MinValue = 0, MaxValue = 255)]
        public int G
        {
            get
            {
                return g;
            }

            set
            {
                if (g != value)
                {

                    g = (byte)value;
                    NotifyProperty();
                    NotifyProperty("GreenBalance");
                    NotifyProperty("ElementColor");
                }

            }
        }

        [IntegerValidator(MinValue = 0, MaxValue = 255)]
        public int R
        {
            get
            {
                return r;
            }

            set
            {   if (value != r)
                {
                    r = (byte)value;
                    NotifyProperty();
                    NotifyProperty("RedBalance");
                    NotifyProperty("ElementColor");
                }
            }
        }
    }
}
