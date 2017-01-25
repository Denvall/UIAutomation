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
                mainWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children, new AndCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window),
                new PropertyCondition(AutomationElement.ClassNameProperty, "NavigationWindow")));
                var johnsmith = mainWindow.FindFirst(TreeScope.Children, new AndCondition(
                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Text),
                    new PropertyCondition(AutomationElement.AutomationIdProperty, "usernameTitle")));
                Assert.AreEqual("John Smith", ClassicBase.Properties.GetName(johnsmith));
            }
            Thread.Sleep(2000);

        }

        [Test]
        public void OrderNumber()
        {
           Login("john", "hp");
            Thread.Sleep(1000);
            var mainwindow = ControlFinder.FindByClassName(ControlType.Window, "NavigationWindow");
            var tabs = mainwindow.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem));

            var search_order = tabs.Cast<AutomationElement>().ToList().First(tab => tab.Current.Name.Equals("SEARCH ORDER"));

            ClassicBase.Properties.SelectionItem.SelectItem(search_order);

            var radio_button = ControlFinder.FindByAutomationId(ControlType.RadioButton, "byNumberRadio");
            var order_number = ControlFinder.FindByAutomationId(ControlType.Edit, "byNumberWatermark");
            bool order_number_selected = order_number.Current.IsEnabled;
            
            var selected = radio_button.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            bool is_radio_selected = selected.Current.IsSelected;
            Assert.AreEqual(is_radio_selected, order_number_selected);
            Thread.Sleep(1000);

           ClassicBase.Properties.SelectionItem.SelectItem(radio_button);
           var type = order_number.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
           var search = ControlFinder.FindByAutomationId(ControlType.Button, "searchBtn");
           Assert.AreEqual(false, search.Current.IsEnabled);
           type.SetValue("123456");
           Assert.AreEqual(true, search.Current.IsEnabled);
           Thread.Sleep(1000);
           ClassicBase.Properties.Invoke.Click(search);
           var error_message = ControlFinder.FindByAutomationId(ControlType.Text, "65535");
           var error_text = ClassicBase.Properties.GetName(error_message);
           Assert.AreEqual("Order number does not exist.", error_text);
        }
    }
}
