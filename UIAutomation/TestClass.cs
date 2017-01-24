using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baseclass;
using NUnit.Framework;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using UIAutomation.Find;

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
                foreach (Process theprocess in processlist)
                {
                    theprocess.Kill();
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Process " + Param.target_name + " not found!");
            }
        }
        [Test]
        [TestCase("john", "ph")]
        [TestCase("nhon", "hp")]
        [TestCase("john", "hp")]
        public void Login(string loginvalue, string passwordvalue)

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
            typelogin.SetValue(loginvalue);
            typepassword.SetValue(passwordvalue);
            string variable = "okButton";
            var OkButton = mainWindow.FindFirst(TreeScope.Children, new AndCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
                new PropertyCondition(AutomationElement.AutomationIdProperty, variable)));
            ClassicBase.Properties.Invoke.Click(OkButton);
            Thread.Sleep(1000);
            if (loginvalue != "john" || passwordvalue != "hp")
            {
                var error = mainWindow.FindFirst(TreeScope.Children, new AndCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window),
                new PropertyCondition(AutomationElement.ClassNameProperty, "#32770")));
                Assert.IsTrue(ClassicBase.Properties.IsEnabled(error));
                string failed = ClassicBase.Properties.GetName(error);
                Assert.AreEqual("Login Failed", failed);
            }
            else
            {
                var johnsmith = mainWindow.FindFirst(TreeScope.Children, new AndCondition(
                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Text),
                    new PropertyCondition(AutomationElement.AutomationIdProperty, "usernameTitle")));
                Assert.AreEqual("John Smith", ClassicBase.Properties.GetName(johnsmith));
            }
            Thread.Sleep(2000);

        }
        [Test]
        public void Test123()
        {
            Login("john", "hp");
            var tab = ControlFinder.FindByClassName(ControlType.Tab, "TabControl");
            ClassicBase.Properties.SelectionItem.SelectItem(tab);
            Assert.AreEqual("123", tab);
        }
    }
}
