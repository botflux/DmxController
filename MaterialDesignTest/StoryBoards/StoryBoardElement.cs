using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmxController.StoryBoards
{
    public class StoryBoardElement
    {
        private Color elementColor;
        private double time;

        public Color ElementColor
        {
            get
            {
                return elementColor;
            }

            set
            {
                elementColor = value;
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
                time = value;
            }
        }
    }
}
