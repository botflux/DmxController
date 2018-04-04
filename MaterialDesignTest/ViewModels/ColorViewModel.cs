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

namespace DmxController.ViewModels
{
    public class ColorViewModel : ViewModel, IPageViewModel
    {
        private Color mainColor;

        private byte r;
        private byte g;
        private byte b;

        private List<IModuleViewModel> modules;

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
                    NotifyProperty();
                    NotifyProperty("RedBalance");
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
                }
            }
        }

        public string Name
        {
            get
            {
                return "Color";
            }
        }

        public List<IModuleViewModel> RightModules
        {
            get
            {
                if (modules == null) modules = new List<IModuleViewModel>();
                return modules;
            }
        }

        public List<IModuleViewModel> LeftModules
        {
            get
            {
                return new List<IModuleViewModel>();
            }
        }

        protected override void NotifyProperty([CallerMemberName] string str = "")
        {
            base.NotifyProperty(str);
            MainColor = Color.FromRgb(R, G, B);
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
