using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace UIAutomation.Find
{
    class ControlFinder
    {
        public static AutomationElement FindByAutomationId(string automationId)
        {
            AutomationElement rootElement = AutomationElement.RootElement;
            Condition cond = new PropertyCondition(
            AutomationElement.AutomationIdProperty, automationId, PropertyConditionFlags.IgnoreCase);
            AutomationElement element = rootElement.FindFirst(TreeScope.Descendants, cond);
            if (element != null)
            {
                return element;
            }
            else
            {
                throw new Exception("Element not found!");
            }

        }

        public static AutomationElement FindByClassName(string classname)
        {
            AutomationElement rootElement = AutomationElement.RootElement;
            Condition cond = new PropertyCondition(
            AutomationElement.ClassNameProperty, classname, PropertyConditionFlags.IgnoreCase);
            AutomationElement element = rootElement.FindFirst(TreeScope.Descendants, cond);
            if (element != null)
            {
                return element;
            }
            else
            {
                throw new Exception("Element is null!");
            }

        }
    }
}

    
