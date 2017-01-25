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
        public static AutomationElement FindByAutomationId(ControlType controltype, string automationId)
        {
            AutomationElement rootElement = AutomationElement.RootElement;
            AutomationElement element = rootElement.FindFirst(TreeScope.Descendants, new AndCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty, controltype),
                new PropertyCondition(AutomationElement.AutomationIdProperty, automationId)));

            if (element != null)
            {
                return element;
            }
            else
            {
                throw new Exception("Element is null!");
            }

        }

        public static AutomationElement FindByClassName(ControlType controltype, string classname)
        {
            AutomationElement rootElement = AutomationElement.RootElement;
            AutomationElement element = rootElement.FindFirst(TreeScope.Descendants, new AndCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty, controltype),
                new PropertyCondition(AutomationElement.ClassNameProperty, classname)));

            if (element != null)
            {
                return element;
            }
            else
            {
                throw new Exception("Element is null!");
            }
        }
       // public static AutomationElementCollection FindAll()
        //{ }
    }
}

    
