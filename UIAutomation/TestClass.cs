using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;

namespace UIAtomation
{
    [TestFixture]
    public class Tests
    {
        private static class Param
        {
            public const string ProcessPath = "C:\\Flights Application\\FlightsGUI.exe";
            public const string target_name = "FlightsGUI";
        }
        [SetUp]
        public void BeforeEachTest()
        {
            Process.Start(Param.ProcessPath);
            Thread.Sleep(1000);
        }

        [TearDown]
        public void AfterTest()
        {
            ///Process[] local_procs = Process.GetProcesses();
            Process[] processlist = Process.GetProcessesByName(Param.target_name);
            try
            {
                foreach(Process theprocess in processlist){
                theprocess.Kill();
                    }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Process " + Param.target_name + " not found!");
            }
        }
    [Test]
        public void Login()
        {
            var mainWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children, new AndCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window),
                new PropertyCondition(AutomationElement.ClassNameProperty, "NavigationWindow")));
            var allButtons = mainWindow.FindAll(TreeScope.Children, new PropertyCondition(
                AutomationElement.ControlTypeProperty, ControlType.Button));

            var LoginField = mainWindow.FindFirst(TreeScope.Children, new AndCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit),
                new PropertyCondition(AutomationElement.ClassNameProperty, "TextBox")));
            var typelogin = LoginField.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;

            var PasswordField = mainWindow.FindFirst(TreeScope.Children, new AndCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit),
                new PropertyCondition(AutomationElement.ClassNameProperty, "PasswordBox")));
            var typepassword = PasswordField.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;

            
    
            typelogin.SetValue("john");
            typepassword.SetValue("hp");
            var OkButton = mainWindow.FindFirst(TreeScope.Children, new AndCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
                new PropertyCondition(AutomationElement.AutomationIdProperty, "okButton")));
            var OkButtonClick = OkButton.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            OkButtonClick.Invoke();
            Thread.Sleep(2000);

        }
    }
}
