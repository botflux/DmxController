using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.Views
{
    public class ViewState
    {
        private bool leftPanelState;
        private bool rightPanelState;

        public ViewState (bool leftPanelState = true, bool rightPanelState = true)
        {
            this.leftPanelState = leftPanelState;
            this.rightPanelState = rightPanelState;
        }

        public bool LeftPanelState
        {
            get
            {
                return leftPanelState;
            }

            set
            {
                leftPanelState = value;
            }
        }

        public bool RightPanelState
        {
            get
            {
                return rightPanelState;
            }

            set
            {
                rightPanelState = value;
            }
        }
    }
}
