using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using System.Threading;
using System.Windows.Forms;
using PatternEnum;

namespace Baseclass
{
    /// <summary>
    /// Public to Customized UIOperation with AutomationElement parameter
    /// </summary>
    public class ClassicBase
    {
        private static int TIMEOUT = 500; //1000;
        /// <summary>
        /// Get the classic properties for automation element
        /// </summary>
        public class Properties
        {
            /// <summary>
            /// Indicates whether the control is in enabled status.
            /// </summary>
            /// <returns>Boolean - True or False</returns>
            /// <remarks>Support Control Type: All</remarks>
            public static bool IsEnabled(AutomationElement element)
            {
                var isEnabled = false;

                if (element == null)
                    throw new Exception("Element is null!");

                try
                {
                    isEnabled = element.Current.IsEnabled;
                }
                catch { }

                return isEnabled;
            }

            /// <summary>
            /// Indicates whether the control is password control.
            /// </summary>
            /// <returns>Boolean - True or False</returns>
            /// <remarks>Support Control Type: All</remarks>
            public static bool IsPassword(AutomationElement element)
            {
                var isPassword = false;

                if (element == null)
                    throw new Exception("Element is null!");

                try
                {
                    isPassword = element.Current.IsPassword;
                }
                catch { }

                return isPassword;
            }

            /// <summary>
            /// Indicates whether the control is out of screen.
            /// </summary>        
            /// <returns>Boolean - True or False</returns>    
            /// <remarks>Support Control Type: All</remarks>
            public static bool IsOffScreen(AutomationElement element)
            {
                var isOffScreen = false;

                if (element == null)
                    throw new Exception("Element is null!");

                try
                {
                    isOffScreen = element.Current.IsOffscreen;
                }
                catch { }

                return isOffScreen;
            }

            /// <summary>
            /// Check whether the control is required control in current form.
            /// </summary>        
            /// <returns>Boolean - True or False</returns>    
            /// <remarks>Support Control Type: All</remarks>
            public static bool IsRequiredforForm(AutomationElement element)
            {
                var isRequiredforForm = false;

                if (element == null)
                    throw new Exception("Element is null!");

                try
                {
                    isRequiredforForm = element.Current.IsRequiredForForm;
                }
                catch { }

                return isRequiredforForm;
            }

            /// <summary>
            /// Indicates whether the entered or selected value is valid for the form rule associated.
            /// </summary>        
            /// <returns>Boolean - True or False</returns>    
            /// <remarks>Support Control Type: All</remarks>
            /// !!! ??? IsDataValidForForm did not found
            //public static bool IsDataValidForForm(AutomationElement element)
            //{
            //    var isDataValidForForm = false;

            //    if (element == null)
            //        throw new Exception("Element is null!");

            //    try
            //    {
            //        isDataValidForForm = element.Current.IsDataValidForForm;
            //    }
            //    catch { }

            //    return isDataValidForForm;
            //}

            /// <summary>
            /// Indicates whether the keyboard is focusable for the control.
            /// </summary>        
            /// <returns>True or False</returns>
            /// <remarks>Support Control Type: All</remarks>
            public static bool IsKeyboardFocusable(AutomationElement element)
            {
                var isKeyboardFocusable = false;

                if (element == null)
                    throw new Exception("Element is null!");

                try
                {
                    isKeyboardFocusable = element.Current.IsKeyboardFocusable;
                }
                catch { }

                return isKeyboardFocusable;
            }

            /// <summary>
            /// Return Name property value for the control.
            /// </summary>        
            /// <returns>String - Control Name</returns>
            /// <remarks>Support Control Type: All</remarks>
            public static string GetName(AutomationElement element)
            {
                string name = null;

                if (element == null)
                    throw new Exception("Element is null!");

                try
                {
                    name = element.Current.Name;
                }
                catch { }

                return name;
            }

            /// <summary>
            /// Return the runtime id for the control.
            /// </summary>        
            /// <returns>String - Runtime ID</returns>
            /// <remarks>Support Control Type: All</remarks>
            public static string GetRuntimeId(AutomationElement element)
            {
                string runtimeid = null;

                if (element == null)
                    throw new Exception("Element is null!");

                try
                {
                    foreach (int id in element.GetRuntimeId())
                    {
                        if (string.IsNullOrEmpty(runtimeid))
                            runtimeid += string.Format("{0}", id);
                        else
                            runtimeid += string.Format(",{0}", id);
                    }
                }
                catch { }

                return runtimeid;
            }

            /// <summary>
            /// Return the runtime id for the control.
            /// </summary>
            /// <returns>String - Runtime ID</returns>
            /// <remarks>Support Control Type: All</remarks>
            public static string GetFrameworkId(AutomationElement element)
            {
                string frameworkid = null;

                if (element == null)
                    throw new Exception("Element is null!");

                try
                {
                    frameworkid = element.Current.FrameworkId;
                }
                catch { }

                return frameworkid;
            }

            /// <summary>
            /// Return the access key for the control.
            /// </summary>
            /// <returns>String - Access Key</returns>
            /// <remarks>Support Control Type: All</remarks>
            public static string GetAccessKey(AutomationElement element)
            {
                string accesskey = null;

                if (element == null)
                    throw new Exception("Element is null!");

                try
                {
                    accesskey = element.Current.AccessKey;
                }
                catch { }

                return accesskey;
            }

            /// <summary>
            /// Return the help text for the control.
            /// </summary>        
            /// <returns>String - Help Text</returns>
            /// <remarks>Support Control Type: All</remarks>
            public static string GetHelpText(AutomationElement element)
            {
                string helptext = null;

                if (element == null)
                    throw new Exception("Element is null!");

                try
                {
                    helptext = element.Current.HelpText;
                }
                catch { }

                return helptext;
            }

            /// <summary>
            /// Return the BoundingRectangle (width/height/x, y position) for the control.
            /// </summary>        
            /// <returns>System.Windows.Rect - BoundingRectangle</returns>
            /// <remarks>Support Control Type: All</remarks>
            /*public static System.Windows.Rect GetBoundingRectangle(AutomationElement element)
            {
                var bounding = new System.Windows.Rect();

                if (element == null)
                    throw new Exception("Element is null!");

                try
                {
                    bounding = element.Current.BoundingRectangle;
                }
                catch { }

                return bounding;
            }
        }*/

            /// <summary>
            /// Methods for ExpandCollapsePattern
            /// </summary>
            public class ExpandCollapse
            {
                /// <summary>
                /// Expand the control.
                /// </summary>        
                /// <returns>void</returns>
                /// <remarks>Support Control Type: MenuItem | TreeItem | ListItem</remarks>
                public static void Expand(AutomationElement element)
                {
                    if (IsSupportPattern(element, ExpandCollapsePattern.Pattern))
                    {
                        var expandcollapsePattern = (ExpandCollapsePattern)element.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                        if (expandcollapsePattern.Current.ExpandCollapseState != ExpandCollapseState.Expanded &&
                            expandcollapsePattern.Current.ExpandCollapseState != ExpandCollapseState.LeafNode)
                        {
                            expandcollapsePattern.Expand();
                            Thread.Sleep(TIMEOUT);
                        }
                    }
                }

                /// <summary>
                /// Collapse the control.
                /// </summary>        
                /// <returns>void</returns>
                /// <remarks>Support Control Type: MenuItem | TreeItem | ListItem</remarks>
                public static void Collapse(AutomationElement element)
                {
                    if (IsSupportPattern(element, ExpandCollapsePattern.Pattern))
                    {
                        var expandcollapsePattern = (ExpandCollapsePattern)element.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                        if (expandcollapsePattern.Current.ExpandCollapseState != ExpandCollapseState.Collapsed &&
                            expandcollapsePattern.Current.ExpandCollapseState != ExpandCollapseState.LeafNode)
                        {
                            expandcollapsePattern.Collapse();
                            Thread.Sleep(TIMEOUT);
                        }
                    }
                }

                /// <summary>
                /// Get state (isexpand or iscollapse) on the control.
                /// </summary>        
                /// <returns>String - ExpandCollapseState</returns>
                /// <remarks>Support Control Type: MenuItem | TreeItem | ListItem</remarks>
                public static string GetExpandCollapseState(AutomationElement element)
                {
                    string state = null;

                    if (IsSupportPattern(element, ExpandCollapsePattern.Pattern))
                    {
                        var expandcollapsePattern = (ExpandCollapsePattern)element.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                        state = expandcollapsePattern.Current.ExpandCollapseState.ToString();
                    }

                    return state;
                }
            }

            /// <summary>
            /// Methods for InvokePattern
            /// </summary>
            public class Invoke
            {
                /// <summary>
                /// Invoke the control (Click).
                /// </summary>        
                /// <returns>void</returns>
                /// <remarks>Support Control Type: Button | MenuItem | TreeItem | ListItem | etc.</remarks>
                public static void Click(AutomationElement element)
                {
                    if (IsSupportPattern(element, InvokePattern.Pattern))
                    {
                        var invokePattern = (InvokePattern)element.GetCurrentPattern(InvokePattern.Pattern);
                        invokePattern.Invoke();
                    }
                }
            }

            /// <summary>
            /// Methods for TogglePattern
            /// </summary>
            public class Toggle
            {
                /// <summary>
                /// Toggle the control (Check / UnCheck).
                /// </summary>        
                /// <param name="state">toggle on / off</param>
                /// <returns>void</returns>
                /// <remarks>Support Control Type: CheckBox | Button</remarks>
                public static void Check(AutomationElement element, PatternEnum.PatternEnum.ToggleState state)
                {
                    if (IsSupportPattern(element, TogglePattern.Pattern))
                    {
                        var togglePattern = (TogglePattern)element.GetCurrentPattern(TogglePattern.Pattern);
                        if (state == PatternEnum.PatternEnum.ToggleState.ToggleOn && togglePattern.Current.ToggleState != ToggleState.On)
                            togglePattern.Toggle();
                        else if (state == PatternEnum.PatternEnum.ToggleState.ToggleOff && togglePattern.Current.ToggleState != ToggleState.Off)
                            togglePattern.Toggle();

                        //Thread.Sleep(1000);
                    }
                }

                /// <summary>
                /// Get Toggle status of the control.
                /// </summary>        
                /// <returns>Toggled | Non-Toggled | NA</returns>
                /// <remarks>Support Control Type: CheckBox | Button</remarks>
                public static bool? GetToggleStatus(AutomationElement element)
                {
                    if (IsSupportPattern(element, TogglePattern.Pattern))
                    {
                        var itemPattern = (TogglePattern)element.GetCurrentPattern(TogglePattern.Pattern);

                        if (itemPattern.Current.ToggleState == ToggleState.On)
                            return true;
                        if (itemPattern.Current.ToggleState == ToggleState.Off)
                            return false;
                        return null;
                    }

                    return null;
                }

            }

            /// <summary>
            /// Methods for SelectionItemPattern
            /// </summary>
            public class SelectionItem
            {
                /// <summary>
                /// Select the control
                /// </summary>        
                /// <returns>void</returns>
                /// <remarks>Support Control Type: MenuItem | TreeItem | ListItem</remarks>
                public static void SelectItem(AutomationElement element)
                {
                    if (IsSupportPattern(element, SelectionItemPattern.Pattern))
                    {
                        var selectPattern = (SelectionItemPattern)element.GetCurrentPattern(SelectionItemPattern.Pattern);
                        selectPattern.Select();

                        //Thread.Sleep(TIMEOUT);
                    }
                }

                /// <summary>
                /// Select current control when the parent control supports multiple selection
                /// </summary>        
                /// <returns>void</returns>
                /// <remarks>Support Control Type: ComboBox | TreeItem | ListItem</remarks>
                public static void AddItemToSelection(AutomationElement element)
                {
                    if (IsSupportPattern(element, SelectionItemPattern.Pattern))
                    {
                        var selectPattern = (SelectionItemPattern)element.GetCurrentPattern(SelectionItemPattern.Pattern);
                        selectPattern.AddToSelection();

                        Thread.Sleep(TIMEOUT);
                    }
                }

                /// <summary>
                /// Unselect current control when the parent control supports multiple selection
                /// </summary>        
                /// <returns>void</returns>
                /// <remarks>Support Control Type: TreeItem | ListItem</remarks>
                public static void RemoveItemFromSelection(AutomationElement element)
                {
                    if (IsSupportPattern(element, SelectionItemPattern.Pattern))
                    {
                        var selectPattern = (SelectionItemPattern)element.GetCurrentPattern(SelectionItemPattern.Pattern);
                        selectPattern.RemoveFromSelection();

                        Thread.Sleep(TIMEOUT);
                    }
                }

                /// <summary>
                /// Indicates current control is selected
                /// </summary>        
                /// <returns>void</returns>
                /// <remarks>Support Control Type: MenuItem | TreeItem | ListItem</remarks>
                public static bool IsItemSelected(AutomationElement element)
                {
                    bool isSelected = false;

                    if (IsSupportPattern(element, SelectionItemPattern.Pattern))
                    {
                        var selectPattern = (SelectionItemPattern)element.GetCurrentPattern(SelectionItemPattern.Pattern);
                        isSelected = selectPattern.Current.IsSelected;
                    }

                    return isSelected;
                }

                /// <summary>
                /// Get container of the selection
                /// </summary>        
                /// <returns>AutomationElement - contrainer</returns>
                /// <remarks>Support Control Type: MenuItem | TreeItem | ListItem</remarks>
                public static AutomationElement GetSelectionContainer(AutomationElement element)
                {
                    AutomationElement container;

                    object obj;
                    if (element.TryGetCurrentPattern(SelectionItemPattern.Pattern, out obj))
                    {
                        var selectPattern = (SelectionItemPattern)element.GetCurrentPattern(SelectionItemPattern.Pattern);
                        container = selectPattern.Current.SelectionContainer;
                    }
                    else
                        throw new Exception("Current element does not support SelectionItemPattern");

                    return container;
                }
            }

            /// <summary>
            /// Methods for ValuePattern
            /// </summary>
            public class Value
            {
                /// <summary>
                /// Set value on the control
                /// </summary>        
                /// <param name="value">String - value</param>
                /// <returns>AutomationElement - Parent control</returns>
                /// <remarks>Support Control Type: Edit</remarks>
                public static void SetValue(AutomationElement element, string value)
                {
                    var valuePattern = (ValuePattern)element.GetCurrentPattern(ValuePattern.Pattern);
                    valuePattern.SetValue(value);
                }

                public static bool IsReadOnly(AutomationElement element)
                {
                    var valuePattern = (ValuePattern)element.GetCurrentPattern(ValuePattern.Pattern);
                    return valuePattern.Current.IsReadOnly;
                }

                /// <summary>
                /// Get value on current control
                /// </summary>        
                /// <returns>String - value in the control</returns>
                /// <remarks>Support Control Type: Edit | TextBox</remarks>
                public static string GetValue(AutomationElement element)
                {
                    var valuePattern = (ValuePattern)element.GetCurrentPattern(ValuePattern.Pattern);
                    return valuePattern.Current.Value;
                }
            }

            /// <summary>
            /// Methods for SelectionPattern
            /// </summary>
            public class Selection
            {
                /// <summary>
                /// Indicates whether require some selection for the control
                /// </summary>        
                /// <returns>Bool - True or False</returns>
                /// <remarks>Support Control Type: List | Tree | Menu</remarks>
                public static bool IsSelectionRequired(AutomationElement element)
                {
                    var isrequired = false;

                    if (IsSupportPattern(element, SelectionPattern.Pattern))
                    {
                        var pattern = (SelectionPattern)element.GetCurrentPattern(SelectionPattern.Pattern);
                        isrequired = pattern.Current.IsSelectionRequired;
                    }

                    return isrequired;
                }

                /// <summary>
                /// Indicates whether support multiple selection for the control
                /// </summary>        
                /// <returns>Bool - True or False</returns>
                /// <remarks>Support Control Type: List | Tree | Menu</remarks>
                public static bool IsSelectionCanSelectMultiple(AutomationElement element)
                {
                    var ismultiple = false;

                    if (IsSupportPattern(element, SelectionPattern.Pattern))
                    {
                        var pattern = (SelectionPattern)element.GetCurrentPattern(SelectionPattern.Pattern);
                        ismultiple = pattern.Current.CanSelectMultiple;
                    }

                    return ismultiple;
                }

                /// <summary>
                /// Get all child selection name of the control
                /// </summary>        
                /// <returns>String[] - selection names</returns>
                /// <remarks>Support Control Type: List | Tree | Menu</remarks>
                public static string[] GetSelectionItems(AutomationElement element)
                {
                    string[] selectedItemsName = null;

                    if (IsSupportPattern(element, SelectionPattern.Pattern))
                    {
                        var pattern = (SelectionPattern)element.GetCurrentPattern(SelectionPattern.Pattern);
                        var selectedItems = pattern.Current.GetSelection();
                        selectedItemsName = new string[selectedItems.Count()];
                        const int i = 0;
                        foreach (var selectedItem in selectedItems)
                        {
                            selectedItemsName[i] = selectedItem.Current.Name;
                        }
                    }

                    return selectedItemsName;
                }
            }

            /// <summary>
            /// Methods for DockPattern
            /// </summary>
            public class Dock
            {
                /// <summary>
                /// Set Dock control position
                /// </summary>        
                /// <param name="dockPosition">dock Position: Fill | Bottom | Top | Left | Right | None</param>
                /// <returns>void</returns>
                /// <remarks>Support Control Type: Dock</remarks>
                public static void SetDockPosition(AutomationElement element, PatternEnum.PatternEnum.DockPosition dockPosition)
                {
                    if (IsSupportPattern(element, DockPattern.Pattern))
                    {
                        var dockPattern = (DockPattern)element.GetCurrentPattern(DockPattern.Pattern);
                        dockPattern.SetDockPosition(ParsePosition(dockPosition));

                        Thread.Sleep(TIMEOUT);
                    }
                }

                /// <summary>
                /// Get Dock control position
                /// </summary>        
                /// <returns>String - dock Position: Fill | Bottom | Top | Left | Right | None</returns>
                /// <remarks>Support Control Type: Dock</remarks>
                public static string GetDockPosition(AutomationElement element)
                {
                    var position = "None";

                    if (IsSupportPattern(element, DockPattern.Pattern))
                    {
                        var dockPattern = (DockPattern)element.GetCurrentPattern(DockPattern.Pattern);
                        position = dockPattern.Current.DockPosition.ToString();

                        Thread.Sleep(TIMEOUT);
                    }

                    return position;
                }
            }

            /// <summary>
            /// Methods for WindowPattern
            /// </summary>
            public class Window
            {
                /// <summary>
                /// Close Window control
                /// </summary>        
                /// <returns>void</returns>
                /// <remarks>Support Control Type: Window</remarks>
                public static void CloseWindow(AutomationElement element)
                {
                    if (IsSupportPattern(element, WindowPattern.Pattern))
                    {
                        var winPattern = (WindowPattern)element.GetCurrentPattern(WindowPattern.Pattern);
                        winPattern.Close();

                        Thread.Sleep(TIMEOUT);
                    }
                }

                /// <summary>
                /// Set visual state of the window control
                /// </summary>        
                /// <param name="windowState">State: Minimized | Maximize | Normal</param>
                /// <returns>void</returns>
                /// <remarks>Support Control Type: Window</remarks>
                public static void SetWindowVisualState(AutomationElement element, PatternEnum.PatternEnum.WindowVisualState windowState)
                {
                    if (IsSupportPattern(element, WindowPattern.Pattern))
                    {
                        var winPattern = (WindowPattern)element.GetCurrentPattern(WindowPattern.Pattern);
                        winPattern.SetWindowVisualState(ParseWindowVisualState(windowState));
                    }
                }

                /// <summary>
                /// Indicates whether the window control is timeout for waiting input
                /// </summary>        
                /// <param name="seconds">Seconds for the timeout</param>
                /// <returns>Boolean - True or False</returns>
                /// <remarks>Support Control Type: Window</remarks>
                public static bool IsWindowWaitForInputIdleTimeout(AutomationElement element, int seconds)
                {
                    var isTimeout = false;

                    if (IsSupportPattern(element, WindowPattern.Pattern))
                    {
                        var winPattern = (WindowPattern)element.GetCurrentPattern(WindowPattern.Pattern);
                        isTimeout = winPattern.WaitForInputIdle(seconds * TIMEOUT);
                    }

                    return isTimeout;
                }

                /// <summary>
                /// Get visual state of the window control
                /// </summary>        
                /// <returns>String - State: Minimized | Maximize | Normal</returns>
                /// <remarks>Support Control Type: Window</remarks>
                public static string GetWindowVisualState(AutomationElement element)
                {
                    string visualstate = null;

                    if (IsSupportPattern(element, WindowPattern.Pattern))
                    {
                        var winPattern = (WindowPattern)element.GetCurrentPattern(WindowPattern.Pattern);
                        visualstate = winPattern.Current.WindowVisualState.ToString();
                    }

                    return visualstate;
                }

                /// <summary>
                /// Get interaction state of the window control
                /// </summary>        
                /// <returns>String - State: BlockedByModalWindow | Closing | NotResponding | ReadyForUserInteraction | Running</returns>
                /// <remarks>Support Control Type: Window</remarks>
                public static string GetWindowInteractionState(AutomationElement element)
                {
                    string ineractionstate = null;

                    if (IsSupportPattern(element, WindowPattern.Pattern))
                    {
                        var winPattern = (WindowPattern)element.GetCurrentPattern(WindowPattern.Pattern);
                        ineractionstate = winPattern.Current.WindowInteractionState.ToString();
                    }

                    return ineractionstate;
                }

                /// <summary>
                /// Indicates whether the control is topmost
                /// </summary>        
                /// <returns>Boolean - True or false</returns>
                /// <remarks>Support Control Type: Window</remarks>
                public static bool IsWindowTopmost(AutomationElement element)
                {
                    var istopmost = false;

                    if (IsSupportPattern(element, WindowPattern.Pattern))
                    {
                        var winPattern = (WindowPattern)element.GetCurrentPattern(WindowPattern.Pattern);
                        istopmost = winPattern.Current.IsTopmost;
                    }

                    return istopmost;
                }

                /// <summary>
                /// Indicates whether the control is maximize
                /// </summary>        
                /// <returns>Boolean - True or false</returns>
                /// <remarks>Support Control Type: Window</remarks>
                public static bool IsWindowCanMaximize(AutomationElement element)
                {
                    var canmax = false;

                    if (IsSupportPattern(element, WindowPattern.Pattern))
                    {
                        var winPattern = (WindowPattern)element.GetCurrentPattern(WindowPattern.Pattern);
                        canmax = winPattern.Current.CanMaximize;
                    }

                    return canmax;
                }

                /// <summary>
                /// Indicates whether the control is minimize
                /// </summary>
                /// <returns>Boolean - True or false</returns>
                /// <remarks>Support Control Type: Window</remarks>
                public static bool IsWindowCanMinimize(AutomationElement element)
                {
                    var canmin = false;

                    if (IsSupportPattern(element, WindowPattern.Pattern))
                    {
                        var winPattern = (WindowPattern)element.GetCurrentPattern(WindowPattern.Pattern);
                        canmin = winPattern.Current.CanMinimize;
                    }

                    return canmin;
                }

                /// <summary>
                /// Indicates whether the control is modal window
                /// </summary>        
                /// <returns>Boolean - True or false</returns>
                /// <remarks>Support Control Type: Window</remarks>
                public static bool IsWindowModal(AutomationElement element)
                {
                    var isModal = false;

                    if (IsSupportPattern(element, WindowPattern.Pattern))
                    {
                        var winPattern = (WindowPattern)element.GetCurrentPattern(WindowPattern.Pattern);
                        isModal = winPattern.Current.IsModal;
                    }

                    return isModal;
                }
            }

            /// <summary>
            /// Methods for ScrollPattern
            /// </summary>
            public class Scroll
            {

                /// <summary>
                /// Scroll the control by percentage
                /// </summary>
                /// <param name="scrollHorizontalPercentage"> Horizontal percentage, double type</param>
                /// <param name="scrollVerticalPercentage">Vertical percentage, double type</param>
                /// <returns>void</returns>
                /// <remarks>Support Control Type: ScrollBar</remarks>
                public static void ScrollByPercentage(AutomationElement element, double scrollHorizontalPercentage, double scrollVerticalPercentage)
                {
                    if (IsSupportPattern(element, ScrollPattern.Pattern))
                    {
                        var scrollPattern = (ScrollPattern)element.GetCurrentPattern(ScrollPattern.Pattern);
                        scrollPattern.SetScrollPercent(scrollHorizontalPercentage, scrollVerticalPercentage);
                    }
                }

                /// <summary>
                /// Indicates whether the controll support horizontally scroll
                /// </summary>        
                /// <param name="scrollAxis">PatternEnum.PatternEnum.ScrollAxis: Horizontal or Veritical</param>
                /// <returns>Boolean - True or false</returns>
                /// <remarks>Support Control Type: ScrollBar</remarks>
                public static bool IsScrollable(AutomationElement element, PatternEnum.PatternEnum.ScrollAxis scrollAxis)
                {
                    var isScrollable = false;

                    if (IsSupportPattern(element, ScrollPattern.Pattern))
                    {
                        var scrollPattern = (ScrollPattern)element.GetCurrentPattern(ScrollPattern.Pattern);
                        isScrollable = scrollAxis == PatternEnum.PatternEnum.ScrollAxis.Horizontal ? scrollPattern.Current.HorizontallyScrollable : scrollPattern.Current.VerticallyScrollable;
                    }

                    return isScrollable;
                }

                /// <summary>
                /// Get Scroll view size
                /// </summary>        
                /// <param name="scrollAxis">PatternEnum.PatternEnum.ScrollAxis: Horizontal or Veritical</param>
                /// <returns>Double - size of scroll view</returns>
                /// <remarks>Support Control Type: ScrollBar</remarks>
                public static double GetScrollViewSize(AutomationElement element, PatternEnum.PatternEnum.ScrollAxis scrollAxis)
                {
                    double viewSize = 0;

                    if (IsSupportPattern(element, ScrollPattern.Pattern))
                    {
                        var scrollPattern = (ScrollPattern)element.GetCurrentPattern(ScrollPattern.Pattern);
                        viewSize = scrollAxis == PatternEnum.PatternEnum.ScrollAxis.Horizontal ? scrollPattern.Current.HorizontalViewSize : scrollPattern.Current.VerticalViewSize;
                    }

                    return viewSize;
                }

                /// <summary>
                /// Get Scroll percentage
                /// </summary>
                /// <param name="scrollAxis">PatternEnum.PatternEnum.ScrollAxis: Horizontal or Veritical</param>
                /// <returns>Double - scroll percentage</returns>
                /// <remarks>Support Control Type: ScrollBar</remarks>
                public static double GetScrollPercentage(AutomationElement element, PatternEnum.PatternEnum.ScrollAxis scrollAxis)
                {
                    double scrollPercent = 0;

                    if (IsSupportPattern(element, ScrollPattern.Pattern))
                    {
                        var scrollPattern = (ScrollPattern)element.GetCurrentPattern(ScrollPattern.Pattern);
                        scrollPercent = scrollAxis == PatternEnum.PatternEnum.ScrollAxis.Horizontal ? scrollPattern.Current.HorizontalScrollPercent : scrollPattern.Current.VerticalScrollPercent;
                    }

                    return scrollPercent;
                }
            }

            /// <summary>
            /// Methods for ScrollItemPattern
            /// </summary>
            public class ScrollItem
            {
                /// <summary>
                /// Scroll specified control to current view 
                /// </summary>
                /// <returns>void</returns>
                /// <remarks>Support Control Type: ScrollItem</remarks>
                public static void ScrollItemIntoView(AutomationElement element)
                {
                    if (IsSupportPattern(element, ScrollItemPattern.Pattern))
                    {
                        var scrollItemPattern = (ScrollItemPattern)element.GetCurrentPattern(ScrollItemPattern.Pattern);
                        scrollItemPattern.ScrollIntoView();
                    }
                }
            }

            /// <summary>
            /// Methods for TransformPattern
            /// </summary>
            public class Transform
            {
                /// <summary>
                /// Move control to specified position
                /// </summary>

                /// <param name="x">X axis of position</param>
                /// <param name="y">Y axis of position</param>
                /// <returns>void</returns>
                /// <remarks>Support Control Type: Moveable control</remarks>
                public static void Move(AutomationElement element, double x, double y)
                {
                    if (IsSupportPattern(element, TransformPattern.Pattern))
                    {
                        var transformPattern = (TransformPattern)element.GetCurrentPattern(TransformPattern.Pattern);
                        transformPattern.Move(x, y);
                    }
                }

                /// <summary>
                /// Resize control to specified position
                /// </summary>

                /// <param name="x">X axis of position</param>
                /// <param name="y">Y axis of position</param>
                /// <returns>void</returns>
                /// <remarks>Support Control Type: Resizeable control</remarks>
                public static void Resize(AutomationElement element, double x, double y)
                {
                    if (IsSupportPattern(element, TransformPattern.Pattern))
                    {
                        var transformPattern = (TransformPattern)element.GetCurrentPattern(TransformPattern.Pattern);
                        transformPattern.Resize(x, y);
                    }
                }

                /// <summary>
                /// Rotate control to specified position
                /// </summary>

                /// <param name="degrees">degrees of the rotation</param>
                /// <returns>void</returns>
                /// <remarks>Support Control Type: Rotatable control</remarks>
                public static void Rotate(AutomationElement element, double degrees)
                {
                    if (IsSupportPattern(element, TransformPattern.Pattern))
                    {
                        var transformPattern = (TransformPattern)element.GetCurrentPattern(TransformPattern.Pattern);
                        transformPattern.Rotate(degrees);
                    }
                }

                /// <summary>
                /// Indicates if the control can be moved
                /// </summary>        
                /// <returns>Boolean - True or false</returns>
                /// <remarks>Support Control Type: All</remarks>
                public static bool CanMove(AutomationElement element)
                {
                    var canMove = false;

                    if (IsSupportPattern(element, TransformPattern.Pattern))
                    {
                        var transformPattern = (TransformPattern)element.GetCurrentPattern(TransformPattern.Pattern);
                        canMove = transformPattern.Current.CanMove;
                    }

                    return canMove;
                }

                /// <summary>
                /// Indicates if the control can be resized
                /// </summary>        
                /// <returns>Boolean - True or false</returns>
                /// <remarks>Support Control Type: All</remarks>
                public static bool CanResize(AutomationElement element)
                {
                    var canResize = false;

                    if (IsSupportPattern(element, TransformPattern.Pattern))
                    {
                        var transformPattern = (TransformPattern)element.GetCurrentPattern(TransformPattern.Pattern);
                        canResize = transformPattern.Current.CanResize;
                    }

                    return canResize;
                }

                /// <summary>
                /// Indicates if the control can be rotated
                /// </summary>        
                /// <returns>Boolean - True or false</returns>
                /// <remarks>Support Control Type: All</remarks>
                public static bool CanRotate(AutomationElement element)
                {
                    var canRotate = false;

                    if (IsSupportPattern(element, TransformPattern.Pattern))
                    {
                        var transformPattern = (TransformPattern)element.GetCurrentPattern(TransformPattern.Pattern);
                        canRotate = transformPattern.Current.CanRotate;
                    }

                    return canRotate;
                }
            }

            /// <summary>
            /// Methods for GridPattern
            /// </summary>
            public class Grid
            {
                /// <summary>
                /// Get item in grid
                /// </summary>
                /// <param name="row">row index of grid item</param>
                /// <param name="column">column index of grid item</param>
                /// <returns>AutomationElement - Item</returns>
                /// <remarks>Support Control Type: Grid</remarks>
                public static AutomationElement GetGridItem(AutomationElement element, int row, int column)
                {
                    AutomationElement gridItem = null;

                    var gridPattern = (GridPattern)element.GetCurrentPattern(GridPattern.Pattern);
                    gridItem = gridPattern.GetItem(row, column);
                    return gridItem;
                }

                /// <summary>
                /// Get count of item in grid
                /// </summary>
                /// <param name="gridAxis">Indicates whether calculate in row or column</param>
                /// <returns>Int - item count</returns>
                /// <remarks>Support Control Type: Grid</remarks>
                public static int GetGridItemCount(AutomationElement element, PatternEnum.PatternEnum.Axis gridAxis)
                {
                    var count = 0;
                    if (IsSupportPattern(element, GridPattern.Pattern))
                    {
                        var gridPattern = (GridPattern)element.GetCurrentPattern(GridPattern.Pattern);
                        count = gridAxis == PatternEnum.PatternEnum.Axis.Row ? gridPattern.Current.RowCount : gridPattern.Current.ColumnCount;
                    }

                    return count;
                }
            }

            /// <summary>
            /// Methods for GridItemPattern
            /// </summary>
            public class GridItem
            {
                /// <summary>
                /// Get container of grid item
                /// </summary>
                /// <param name="row">row index of grid item</param>
                /// <param name="column">column index of grid item</param>
                /// <returns>AutomationElement - Container</returns>
                /// <remarks>Support Control Type: GridItem</remarks>
                public static AutomationElement GetContainingGrid(AutomationElement element, int row, int column)
                {
                    AutomationElement grid = null;
                    if (IsSupportPattern(element, GridItemPattern.Pattern))
                    {
                        var gridItemPattern = (GridItemPattern)element.GetCurrentPattern(GridItemPattern.Pattern);
                        grid = gridItemPattern.Current.ContainingGrid;
                    }

                    return grid;
                }

                /// <summary>
                /// Get item index on row/column in grid
                /// </summary>
                /// <param name="gridAxis">Indicates whether calculate in row or column</param>
                /// <returns>Int - item count</returns>
                /// <remarks>Support Control Type: GridItem</remarks>
                public static int GetGridRowColumnIndex(AutomationElement element, PatternEnum.PatternEnum.Axis gridAxis)
                {
                    var number = 0;
                    if (IsSupportPattern(element, GridItemPattern.Pattern))
                    {
                        var gridItemPattern = (GridItemPattern)element.GetCurrentPattern(GridItemPattern.Pattern);
                        number = gridAxis == PatternEnum.PatternEnum.Axis.Row ? gridItemPattern.Current.Row : gridItemPattern.Current.Column;
                    }

                    return number;
                }

                /// <summary>
                /// Get row/column span in grid
                /// </summary>
                /// <param name="gridAxis">Indicates whether calculate in row or column</param>
                /// <returns>Int - item count</returns>
                /// <remarks>Support Control Type: GridItem</remarks>
                public static int GetGridRowColumnSpan(AutomationElement element, PatternEnum.PatternEnum.Axis gridAxis)
                {
                    var span = 0;
                    if (IsSupportPattern(element, GridItemPattern.Pattern))
                    {
                        var gridItemPattern = (GridItemPattern)element.GetCurrentPattern(GridItemPattern.Pattern);
                        span = gridAxis == PatternEnum.PatternEnum.Axis.Row ? gridItemPattern.Current.RowSpan : gridItemPattern.Current.ColumnSpan;
                    }

                    return span;
                }
            }

            /// <summary>
            /// Methods for TablePattern
            /// </summary>
            public class Table
            {
                /// <summary>
                /// Get item in table
                /// </summary>
                /// <param name="row">row index of table item</param>
                /// <param name="column">column index of table item</param>
                /// <returns>AutomationElement - Item</returns>
                /// <remarks>Support Control Type: Table</remarks>
                public static AutomationElement GetTableItem(AutomationElement element, int row, int column)
                {
                    AutomationElement tableItem = null;
                    if (IsSupportPattern(element, TablePattern.Pattern))
                    {
                        var tablePattern = (TablePattern)element.GetCurrentPattern(TablePattern.Pattern);
                        tableItem = tablePattern.GetItem(row, column);
                    }

                    return tableItem;
                }

                /// <summary>
                /// Get count of item in table
                /// </summary>
                /// <param name="gridAxis">Indicates whether calculate in row or column</param>
                /// <returns>Int - item count</returns>
                /// <remarks>Support Control Type: Table</remarks>
                public static int GetTableItemCount(AutomationElement element, PatternEnum.PatternEnum.Axis gridAxis)
                {
                    var count = 0;
                    if (IsSupportPattern(element, TablePattern.Pattern))
                    {
                        var tablePattern = (TablePattern)element.GetCurrentPattern(TablePattern.Pattern);
                        count = gridAxis == PatternEnum.PatternEnum.Axis.Row ? tablePattern.Current.RowCount : tablePattern.Current.ColumnCount;
                    }

                    return count;
                }

                /// <summary>
                /// Get headers name of row/column from table
                /// </summary>
                /// <param name="gridAxis">Indicates whether calculate in row or column</param>
                /// <returns>String[] - header names</returns>
                /// <remarks>Support Control Type: Table</remarks>
                public static string[] GetTableHeadersName(AutomationElement element, PatternEnum.PatternEnum.Axis gridAxis)
                {
                    AutomationElement[] headers = GetTableHeaders(element, gridAxis);
                    if (headers != null)
                        return null;

                    if (headers.Length == 0)
                        return null;

                    string[] headerNames = new string[headers.Length];

                    int i = 0;
                    foreach (AutomationElement ae in headers)
                    {
                        headerNames[i] = ae.Current.Name;
                        i++;
                    }

                    return headerNames;
                }


                /// <summary>
                /// Get headers of row/column from table
                /// </summary>
                /// <param name="gridAxis">Indicates whether calculate in row or column</param>
                /// <returns>AutomationElement[] - headers</returns>
                /// <remarks>Support Control Type: Table</remarks>
                public static AutomationElement[] GetTableHeaders(AutomationElement element, PatternEnum.PatternEnum.Axis gridAxis)
                {
                    AutomationElement[] headers = null;

                    if (IsSupportPattern(element, TablePattern.Pattern))
                    {
                        var tablePattern = (TablePattern)element.GetCurrentPattern(TablePattern.Pattern);
                        headers = gridAxis == PatternEnum.PatternEnum.Axis.Row ? tablePattern.Current.GetRowHeaders() : tablePattern.Current.GetColumnHeaders();
                    }

                    return headers;
                }

                /// <summary>
                /// Get major of row/column from table
                /// </summary>
                /// <param name="gridAxis">Indicates whether calculate in row or column</param>
                /// <returns>String - Major name</returns>
                /// <remarks>Support Control Type: Table</remarks>
                public static string GetTableRowColumnMajor(AutomationElement element)
                {
                    string major = null;

                    if (IsSupportPattern(element, TablePattern.Pattern))
                    {
                        var tablePattern = (TablePattern)element.GetCurrentPattern(TablePattern.Pattern);
                        major = tablePattern.Current.RowOrColumnMajor.ToString();
                    }

                    return major;
                }
            }

            /// <summary>
            /// Methods for TableItemPattern
            /// </summary>
            public class TableItem
            {
                /// <summary>
                /// Get container of table item
                /// </summary>
                /// <param name="row">row index of table item</param>
                /// <param name="column">column index of table item</param>
                /// <returns>AutomationElement - Container</returns>
                /// <remarks>Support Control Type: TableItem</remarks>
                public static AutomationElement GetContainingTableGrid(AutomationElement element, int row, int column)
                {
                    AutomationElement tableGrid = null;
                    if (IsSupportPattern(element, TableItemPattern.Pattern))
                    {
                        var tableItemPattern = (TableItemPattern)element.GetCurrentPattern(TableItemPattern.Pattern);
                        tableGrid = tableItemPattern.Current.ContainingGrid;
                    }

                    return tableGrid;
                }

                /// <summary>
                /// Get index of row/column from table item
                /// </summary>
                /// <param name="gridAxis">Indicates whether calculate in row or column</param>
                /// <returns>Int - item count</returns>
                /// <remarks>Support Control Type: TableItem</remarks>
                public static int GetTableItemRowColumnIndex(AutomationElement element, PatternEnum.PatternEnum.Axis gridAxis)
                {
                    var number = 0;
                    if (IsSupportPattern(element, TableItemPattern.Pattern))
                    {
                        var tableItemPattern = (TableItemPattern)element.GetCurrentPattern(TableItemPattern.Pattern);
                        number = gridAxis == PatternEnum.PatternEnum.Axis.Row ? tableItemPattern.Current.Row : tableItemPattern.Current.Column;
                    }

                    return number;
                }

                /// <summary>
                /// Get row/column span in table item
                /// </summary>
                /// <param name="gridAxis">Indicates whether calculate in row or column</param>
                /// <returns>Int - item count</returns>
                /// <remarks>Support Control Type: GridItem</remarks>
                public static int GetTableItemRowColumnSpan(AutomationElement element, PatternEnum.PatternEnum.Axis gridAxis)
                {
                    var span = 0;
                    if (IsSupportPattern(element, TableItemPattern.Pattern))
                    {
                        var tableItemPattern = (TableItemPattern)element.GetCurrentPattern(TableItemPattern.Pattern);
                        span = gridAxis == PatternEnum.PatternEnum.Axis.Row ? tableItemPattern.Current.RowSpan : tableItemPattern.Current.ColumnSpan;
                    }

                    return span;
                }

                /// <summary>
                /// Get headers name of row/column from table item
                /// </summary>
                /// <param name="gridAxis">Indicates whether calculate in row or column</param>
                /// <returns>String[] - header names</returns>
                /// <remarks>Support Control Type: TableItem</remarks>
                public static string[] GetTableItemHeadersName(AutomationElement element, PatternEnum.PatternEnum.Axis gridAxis)
                {
                    AutomationElement[] headers = TableItem.GetTableItemHeaders(element, gridAxis);
                    if (headers != null)
                        return null;

                    if (headers.Length == 0)
                        return null;

                    string[] headerNames = new string[headers.Length];

                    int i = 0;
                    foreach (AutomationElement ae in headers)
                    {
                        headerNames[i] = ae.Current.Name;
                        i++;
                    }

                    return headerNames;
                }

                /// <summary>
                /// Get headers of row/column from table item
                /// </summary>
                /// <param name="gridAxis">Indicates whether calculate in row or column</param>
                /// <returns>AutomationElement[] - headers</returns>
                /// <remarks>Support Control Type: TableItem</remarks>
                public static AutomationElement[] GetTableItemHeaders(AutomationElement element, PatternEnum.PatternEnum.Axis gridAxis)
                {
                    AutomationElement[] headers = null;
                    if (IsSupportPattern(element, TableItemPattern.Pattern))
                    {
                        var tableItemPattern = (TableItemPattern)element.GetCurrentPattern(TableItemPattern.Pattern);
                        headers = gridAxis == PatternEnum.PatternEnum.Axis.Row ? tableItemPattern.Current.GetRowHeaderItems() : tableItemPattern.Current.GetColumnHeaderItems();
                    }

                    return headers;
                }
            }

            /// <summary>
            /// Methods for RangeValuePattern
            /// </summary>
            public class RangeValue
            {
                /// <summary>
                /// Set Range value
                /// </summary>
                /// <param name="value">Double - value for range</param>
                /// <returns>void</returns>
                /// <remarks>Support Control Type: TBD</remarks>
                public static void SetRangeValue(AutomationElement element, double value)
                {
                    var rangeValuePattern = (RangeValuePattern)element.GetCurrentPattern(RangeValuePattern.Pattern);
                    rangeValuePattern.SetValue(value);
                }

                /// <summary>
                /// Indicates whether range value is readonly
                /// </summary>
                /// <returns>void</returns>
                /// <remarks>Support Control Type: TBD</remarks>
                public static bool IsRangeValueReadOnly(AutomationElement element)
                {
                    var isReadOnly = false;

                    if (IsSupportPattern(element, RangeValuePattern.Pattern))
                    {
                        var rangeValuePattern = (RangeValuePattern)element.GetCurrentPattern(RangeValuePattern.Pattern);
                        isReadOnly = rangeValuePattern.Current.IsReadOnly;
                    }

                    return isReadOnly;
                }

                /// <summary>
                /// Get Range value
                /// </summary>
                /// <param name="rvi">Type: value, largechange, smallchange, max, min</param>
                /// <returns>double</returns>
                /// <remarks>Support Control Type: TBD</remarks>
                public static double GetRangeValue(AutomationElement element, PatternEnum.PatternEnum.RangeValueInformation rvi)
                {
                    double value = 0;
                    if (IsSupportPattern(element, RangeValuePattern.Pattern))
                    {
                        var rangeValuePattern = (RangeValuePattern)element.GetCurrentPattern(RangeValuePattern.Pattern);
                        switch (rvi)
                        {
                            case PatternEnum.PatternEnum.RangeValueInformation.Value:
                                value = rangeValuePattern.Current.Value;
                                break;
                            case PatternEnum.PatternEnum.RangeValueInformation.LargeChange:
                                value = rangeValuePattern.Current.LargeChange;
                                break;
                            case PatternEnum.PatternEnum.RangeValueInformation.SmallChange:
                                value = rangeValuePattern.Current.SmallChange;
                                break;
                            case PatternEnum.PatternEnum.RangeValueInformation.Max:
                                value = rangeValuePattern.Current.Maximum;
                                break;
                            case PatternEnum.PatternEnum.RangeValueInformation.Min:
                                value = rangeValuePattern.Current.Minimum;
                                break;
                        }
                    }

                    return value;
                }
            }

            /// <summary>
            /// Methods for MultipleViewPattern
            /// </summary>
            public class MultipleView
            {
                /// <summary>
                /// Set specified view as current view
                /// </summary>
                /// <param name="viewId">Specified View ID</param>
                /// <returns>void</returns>
                /// <remarks>Support Control Type: MultipleView</remarks>
                public static void SetCurrentView(AutomationElement element, int viewId)
                {
                    if (IsSupportPattern(element, MultipleViewPattern.Pattern))
                    {
                        var multipleViewPattern = (MultipleViewPattern)element.GetCurrentPattern(MultipleViewPattern.Pattern);
                        multipleViewPattern.SetCurrentView(viewId);
                    }
                }

                /// <summary>
                /// Get specified view name
                /// </summary>
                /// <param name="viewId">Specified View ID</param>
                /// <returns>String - view name</returns>
                /// <remarks>Support Control Type: MultipleView</remarks>
                public static string GetViewName(AutomationElement element, int viewId)
                {
                    string viewname = null;

                    if (IsSupportPattern(element, MultipleViewPattern.Pattern))
                    {
                        var multipleViewPattern = (MultipleViewPattern)element.GetCurrentPattern(MultipleViewPattern.Pattern);
                        viewname = multipleViewPattern.GetViewName(viewId);
                    }

                    return viewname;
                }

                /// <summary>
                /// Get specified view id
                /// </summary>
                /// <param name="viewId">Specified View ID</param>
                /// <returns>Int - view id</returns>
                /// <remarks>Support Control Type: MultipleView</remarks>
                public static int GetCurrentViewId(AutomationElement element)
                {
                    var currentviewId = 0;

                    if (IsSupportPattern(element, MultipleViewPattern.Pattern))
                    {
                        var multipleViewPattern = (MultipleViewPattern)element.GetCurrentPattern(MultipleViewPattern.Pattern);
                        currentviewId = multipleViewPattern.Current.CurrentView;
                    }

                    return currentviewId;
                }

                /// <summary>
                /// Get all view ids
                /// </summary>
                /// <returns>Int[] - view ids</returns>
                /// <remarks>Support Control Type: MultipleView</remarks>
                public static int[] GetSupportedViewsId(AutomationElement element)
                {
                    int[] supportedViewsId = null;

                    if (IsSupportPattern(element, MultipleViewPattern.Pattern))
                    {
                        var multipleViewPattern = (MultipleViewPattern)element.GetCurrentPattern(MultipleViewPattern.Pattern);
                        supportedViewsId = multipleViewPattern.Current.GetSupportedViews();
                    }

                    return supportedViewsId;
                }
            }

            /// <summary>
            /// Methods for TextPattern
            /// </summary>
            public class Text
            {
                /// <summary>
                /// Get selected text
                /// </summary>
                /// <returns>String - selected text</returns>
                /// <remarks>Support Control Type: Text</remarks>
                public static string GetSupportedTextSelection(AutomationElement element)
                {
                    string supportedTextSelection = null;

                    if (IsSupportPattern(element, TextPattern.Pattern))
                    {
                        var textPattern = (TextPattern)element.GetCurrentPattern(TextPattern.Pattern);
                        supportedTextSelection = textPattern.SupportedTextSelection.ToString();
                    }

                    return supportedTextSelection;
                }
            }


            #region private functions
            /// <summary>
            /// Check pattern is supported for the automation element
            /// </summary>
            /// <param name="element">Automation element</param>
            /// <param name="pattern">pattern type</param>
            /// <returns>true or false</returns>
            private static bool IsSupportPattern(AutomationElement element, AutomationPattern pattern)
            {
                object obj;

                if (element.TryGetCurrentPattern(pattern, out obj))
                    return true;
                else
                    return false;
                //throw new Exception(string.Format("Current element does not support {0}", pattern.ProgrammaticName));
            }

            private static DockPosition ParsePosition(PatternEnum.PatternEnum.DockPosition position)
            {
                DockPosition dp;

                switch (position)
                {
                    case PatternEnum.PatternEnum.DockPosition.Top:
                        dp = DockPosition.Top;
                        break;
                    case PatternEnum.PatternEnum.DockPosition.Bottom:
                        dp = DockPosition.Bottom;
                        break;
                    case PatternEnum.PatternEnum.DockPosition.Left:
                        dp = DockPosition.Left;
                        break;
                    case PatternEnum.PatternEnum.DockPosition.Right:
                        dp = DockPosition.Right;
                        break;
                    case PatternEnum.PatternEnum.DockPosition.Fill:
                        dp = DockPosition.Fill;
                        break;
                    default:
                        dp = DockPosition.None;
                        break;
                }

                return dp;
            }

            private static WindowVisualState ParseWindowVisualState(PatternEnum.PatternEnum.WindowVisualState state)
            {
                WindowVisualState wvs;

                switch (state)
                {
                    case PatternEnum.PatternEnum.WindowVisualState.Minimized:
                        wvs = WindowVisualState.Minimized;
                        break;
                    case PatternEnum.PatternEnum.WindowVisualState.Maximized:
                        wvs = WindowVisualState.Maximized;
                        break;
                    default:
                        wvs = WindowVisualState.Normal;
                        break;
                }

                return wvs;
            }

        }
    }
}
#endregion