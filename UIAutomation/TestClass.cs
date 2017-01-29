using System;
using System.Linq;
using NUnit.Framework;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using UIAutomation.Find;
using UIAutomation;

namespace UIAtomation
{
    [TestFixture]
    public class Tests
    {
        public string ProcessPath = "C:\\Flights Application\\FlightsGUI.exe";
        public string target_name = "FlightsGUI";

        [SetUp]
        public void BeforeEachTest()
        {
            Process.Start(ProcessPath);
            Thread.Sleep(1000);
        }

        [TearDown]
        public void AfterTest()
        {
            Process[] processlist = Process.GetProcessesByName(target_name);
            try
            {
                foreach (Process theprocess in processlist)
                {
                    theprocess.Kill();
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Process " + target_name + " not found!");
            }
        }
        [Test]
        [TestCase("john", "ph")]
        [TestCase("nhon", "hp")]
        [TestCase("john", "hp")]
        public void Login(string LoginValue, string PasswordValue)
        {
            string LoginField = "agentName";
            string PasswordField = "password";
            string OkButton = "okButton";

            Actions.SetValue(LoginField, LoginValue);
            Actions.SetValue(PasswordField, PasswordValue);
            Actions.Click(OkButton);
            if (LoginValue != "john" || PasswordValue != "hp")
            {
                var error = ControlFinder.FindByClassName("#32770");
                
                Assert.IsTrue(error.Current.IsEnabled);
                string failed = error.Current.Name;
                Assert.AreEqual("Login Failed", failed);
            }
            else
            {
                Thread.Sleep(1000);
                var johnsmith = ControlFinder.FindByAutomationId("usernameTitle");
                
                Assert.AreEqual("John Smith", johnsmith.Current.Name);
            }
            Thread.Sleep(2000);

        }

        [Test]
        public void OrderNumber()
        {
           Login("john", "hp");
            Thread.Sleep(1000);
            SpecialActions.SelectSearchOrderTab();

            var radio_button = ControlFinder.FindByAutomationId("byNumberRadio");
            var order_number = ControlFinder.FindByAutomationId("byNumberWatermark");
            bool order_number_selected = order_number.Current.IsEnabled;
            var selected = radio_button.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            bool is_radio_selected = selected.Current.IsSelected;

            Assert.AreEqual(is_radio_selected, order_number_selected);
            Thread.Sleep(1000);
            Actions.SelectItem("byNumberRadio");

           var type = order_number.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
           var search = ControlFinder.FindByAutomationId("searchBtn");

           Assert.AreEqual(false, search.Current.IsEnabled);
           type.SetValue("123456");
           Assert.AreEqual(true, search.Current.IsEnabled);
           Thread.Sleep(1000);
            Actions.Click("searchBtn");
           var error_message = ControlFinder.FindByAutomationId("65535");
           var error_text = error_message.Current.Name;
           Assert.AreEqual("Order number does not exist.", error_text);
        }
        [Test]
        public void OrderE2E()
        {
            string NewSearchButton = "newSearchBtn";

            Login("john", "hp");
            Thread.Sleep(1000);
            SpecialActions.BookFlight("Paris","London","24.02.2017","Economy","5","hpjohn");
            string order = SpecialActions.GetOrderNumber();
            string PriceExpected  = SpecialActions.GetTicketPrice();
            string TotalExpected = SpecialActions.GetTotalPrice();
            AfterTest();
            BeforeEachTest();
            Login("john", "hp");
            ///Actions.Click(NewSearchButton);
            SpecialActions.SelectSearchOrderTab();
            Actions.SelectItem("byNumberRadio");
            Actions.SetValue("byNumberWatermark",order);
            Actions.Click("searchBtn");
            string TicketNumber =  Actions.GetSelection("numOfTicketsCombo");
            string ClassSelected = Actions.GetSelection("flightClassCombo");
            string PriceActual = SpecialActions.GetTicketPrice();
            string TotalActual = SpecialActions.GetTotalPrice();
            Assert.AreEqual(PriceExpected, PriceActual);
            Assert.AreEqual(TotalExpected, TotalActual);
            Assert.AreEqual(ClassSelected, "Economy");
            Assert.AreEqual(TicketNumber, "5");
            SpecialActions.DeleteOrder();


        }
    }
}
