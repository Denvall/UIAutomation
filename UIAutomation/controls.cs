using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace UIAutomation
{
    public class ControlBase
    {
        protected AutomationElement control;

        public ControlBase(AutomationElement control)
        {
            this.control = control;

        }
    }
}
