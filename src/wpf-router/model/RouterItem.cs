using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using wpfRouter.compents;

namespace wpfRouter.model
{
    public class RouterItem
    {
        public string? Url { get; set; }

        public AbstComponent Component { get; set; }

        public RouterItem[]? Children { get; set; }

        public static RouterBuilder builder() => new RouterBuilder();
    }
}
