using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace wpfRouter.extions
{
    public static class WindowExtions
    {
        public static IList<Control> GetControls(this DependencyObject parent)
        {
            var result = new List<Control>();

            for (int x = 0; x < VisualTreeHelper.GetChildrenCount(parent); x++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, x);

                if (child is Control childControl)
                {
                    result.Add(childControl);
                }
                else
                {
                    result.AddRange(child.GetControls());
                }
            }

            return result;
        }
    }
}
