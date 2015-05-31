using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace airdia
{
    class Image
    {
        public Image(PictureBox source, Boolean isStatic)
        {
            this.source = source;
            timeToShow = 0;
            source.Visible = false;
            this.isStatic = isStatic;
        }

        private PictureBox source;
        public Boolean isStatic { set; get; }
        public int timeToShow { set; get; }

        public void setVisible( Boolean visible)
        {
            source.Visible = visible;
        }
    }
}
