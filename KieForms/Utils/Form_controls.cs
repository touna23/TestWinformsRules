using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KieForms.Utils
{
    public class Form_controls
    {
        public Form_controls()
        {
        }

        //Enable or disable all Buttons
        public void EnableDisableButtonControls(bool val, Control container)
        {            
            try
            {
                foreach (Control c in container.Controls)
                {
                    Button b = c as Button;
                    if (b != null)
                    {
                        b.Enabled = false;
                    }
                }
            }
            catch (Exception myException)
            {
                throw (new Exception(myException.Message));
            }
        }

        //Enable or disable all Elements in container
        public void EnableDisableControls(bool val, Control container)
        {
            try
            {
                foreach (Control c in container.Controls)
                {
                    if (c is Panel || c is GroupBox)
                    {
                        EnableDisableButtonControls(val, c);
                    }
                    else
                    {
                        c.Enabled = val;
                    }
                }
            }
            catch (Exception myException)
            {
                throw (new Exception(myException.Message));
            }
        }

        //disable Horizontal Scroll
        public void DisableHorizontalScroll(Control container)
        {
            int verticalScrollWidth = SystemInformation.VerticalScrollBarWidth;
            container.Padding = new Padding(0, 0, verticalScrollWidth, 0);
        }
    }
}
