using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Router;
using wpfRouter;
using wpfRouter.compents;
using wpfRouter.impl;
using wpfRouter.model;

namespace router_testing
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IWpfRouter router = WpfRouter.Instance;

        protected override void OnStartup(StartupEventArgs e)
        {
            var routers = RouterItem.builder()
                    .WithUrl("/home")
                    .WithComponent(new WindowComponent(typeof(MainWindow)))
                    .WithChildren(
                        RouterItem.builder()
                            .WithUrl("page1")
                            .WithComponent(new PageComponents(typeof(Page1)))
                            .Build(),
                        RouterItem.builder()
                            .WithUrl("page2")
                            .WithComponent(new PageComponents(typeof(Page3)))
            .Build()
                    ).Build();
            router.InitRouter(routers);
            router.NavicatTo("/home/page2");
        }
    }
}
