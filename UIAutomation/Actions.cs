using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using UIAutomation;
using UIAutomation.Find;

namespace UIAutomation
{
class Actions
    {
        public static void SetValue(string automationId, string value)
        {
            var element = ControlFinder.FindByAutomationId(automationId);
            if (element != null)
            {
                ValuePattern pattern;
                try
                {
                    pattern = element.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Pattern not supported.");
                    return;
                }
                pattern.SetValue(value);

            }
        }
        public static void Click(string automationId)
        {
            var element = ControlFinder.FindByAutomationId(automationId);
            InvokePattern pattern;
            try
            {
                pattern = element.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Pattern not supported.");
                return;
            }
            pattern.Invoke();
        }
        public static void ComboboxSelectItem(string automationId, string item)
        {
            var element = ControlFinder.FindByAutomationId(automationId);
            AutomationElementCollection comboboxItem = element.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem));

            ExpandCollapsePattern pattern;
            try
            {
                pattern = element.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
                pattern.Expand();
                pattern.Collapse();
                AutomationElement listItem = element.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, item));
                SelectionItemPattern selectionItemPattern = listItem.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                selectionItemPattern.Select();
                
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Pattern not supported.");
                return;
            }
        }
        public static void TableItemSelect(string automationId, int indexToSelect)
        {
            var element = ControlFinder.FindByAutomationId(automationId);
            AutomationElementCollection tableItems = element.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.DataItem));
            SelectionItemPattern selectPattern;
            try
            {
                AutomationElement itemToSelect = tableItems[indexToSelect];
                selectPattern = (SelectionItemPattern)itemToSelect.GetCurrentPattern(SelectionItemPattern.Pattern);
                selectPattern.Select();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Pattern not supported.");
                return;
            }

        }
        public static void SelectItem(string automationId)
        {
            var element = ControlFinder.FindByAutomationId(automationId);
            SelectionItemPattern pattern;
            try
            {
                pattern = element.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Pattern not supported.");
                return;
            }
            pattern.Select();
            }
        public static string GetSelection(string automationId)
        {
            AutomationElement element = ControlFinder.FindByAutomationId(automationId);

            SelectionPattern pattern;
            pattern = element.GetCurrentPattern(SelectionPattern.Pattern) as SelectionPattern;
            AutomationElement[] selected = pattern.Current.GetSelection();
            string selection = selected[0].Current.Name;
            return selection;
            }

        public static string GetName(string automationId)
        {
            string name = null;
            var element = ControlFinder.FindByAutomationId(automationId);
            if (element == null)
                throw new Exception("Element is null!");

            try
            {
                name = element.Current.Name;
            }
            catch { }

            return name;
        }
    }
}
class SpecialActions
{
    public static void FindFlights()
    {
        var FindFlight = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, new AndCondition(
            new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
            new PropertyCondition(AutomationElement.NameProperty, "FIND FLIGHTS")));
        InvokePattern pattern;
        try
        {
            pattern = FindFlight.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Pattern not supported.");
            return;
        }
        pattern.Invoke();
    }
    public static void DeleteOrder()
    {
        var deleteButton = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, new AndCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
                new PropertyCondition(AutomationElement.HelpTextProperty, "Delete Order")));
        InvokePattern pattern;
        try
        {
            pattern = deleteButton.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Pattern not supported.");
            return;
        }
        pattern.Invoke();
    }
    public static string GetOrderNumber()
    {
        string name = null;
        var OrderNumber = ControlFinder.FindByAutomationId("orderCompleted");
        try
        {
            name = OrderNumber.Current.Name;
        }
        catch { }
        String[] words = name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string word = words[1];
        return word;
    }
    public static void SelectElementItem(AutomationElement element)
    {
        try {
            var selectPattern = (SelectionItemPattern)element.GetCurrentPattern(SelectionItemPattern.Pattern);
            selectPattern.Select();
        }
        catch { }
        }
    public static void SelectSearchOrderTab()
    {
        var mainwindow = ControlFinder.FindByClassName("NavigationWindow");
        var tabs = mainwindow.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem));
        var search_order = tabs.Cast<AutomationElement>().ToList().First(tab => tab.Current.Name.Equals("SEARCH ORDER"));
        SpecialActions.SelectElementItem(search_order);
    }
    public static string GetTicketPrice()
    {
        AutomationElement element = ControlFinder.FindByAutomationId("pricePerTicket");
        string price = element.Current.Name;
        return price;
    }
    public static string GetTotalPrice()
    {
        AutomationElement element = ControlFinder.FindByAutomationId("totalPrice");
        string totalprice = element.Current.Name;
        return totalprice;
    }
    public static void BookFlight(string Tocity,string FromCity,string FlightDate,string FlightClass, string TicketQuantity, string Passenger)
    {
        string FromCityCombo = "fromCity";
        string ToCityCombo = "toCity";
        string Date = "PART_TextBox";
        string Class = "Class";
        string Tickets = "numOfTickets";
        string DataGrid = "flightsDataGrid";
        string SelectFlight = "selectFlightBtn";
        string PassengerName = "passengerName";
        string OrderButton = "orderBtn";

        Actions.ComboboxSelectItem(FromCityCombo, Tocity);
        Actions.ComboboxSelectItem(ToCityCombo, FromCity);
        Actions.SetValue(Date, FlightDate);
        Actions.ComboboxSelectItem(Class, FlightClass);
        Actions.ComboboxSelectItem(Tickets, TicketQuantity);
        SpecialActions.FindFlights();
        Actions.TableItemSelect(DataGrid, 1);
        Actions.Click(SelectFlight);
        Actions.SetValue(PassengerName, Passenger);
        Actions.Click(OrderButton);
        Thread.Sleep(2000);
    }
}
