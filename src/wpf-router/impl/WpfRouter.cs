using RouterControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using wpfRouter;
using wpfRouter.compents;
using wpfRouter.extions;
using wpfRouter.model;

namespace wpfRouter.impl
{
    public class WpfRouter : IWpfRouter
    {
        private static IWpfRouter? _instance;
        public static IWpfRouter Instance
        {
            get
            {
                if (_instance == null) _instance = new WpfRouter();
                return _instance;
            }
        }
        private WpfRouter() { }
        private Dictionary<string, AbstComponent> hashRouter = new();
        public void AddRouter(string url, Page component)
        {
            throw new NotImplementedException();
        }

        public void InitRouter(params RouterItem[] routes)
        {
            if (routes == null)
            {
                throw new ArgumentNullException(nameof(routes));
            }
            void ProcessRouterItems(IEnumerable<RouterItem> items, string parentUrl)
            {
                foreach (var item in items)
                {
                    if (item.Url == null || item.Component == null)
                    {
                        continue;
                    }
                    string fullUrl = string.IsNullOrEmpty(parentUrl) ? item.Url : $"{parentUrl}/{item.Url}";
                    hashRouter.Add(fullUrl, item.Component);

                    if (item.Children != null)
                    {
                        ProcessRouterItems(item.Children, fullUrl);
                    }
                }
            }

            ProcessRouterItems(routes, "");
        }
        private Window GetChildrenPage(string patter, Dictionary<string, Window> routes)
        {
            var urlNodes = patter.Split("//");
            if (urlNodes.Length > 1)
            {
                return routes[urlNodes[1]];
            }
            return null;
        }
        private Window lastHistory;
        public void NavicatTo(string url)
        {
            string[] routeNode = url.Split("/");
            var pageMain = (hashRouter[$"/{routeNode[1]}"] as WindowComponent).Instance;
            if(lastHistory != null && lastHistory.GetType() == pageMain.GetType())
            {
                FreamNavicatTo(lastHistory, url);
            }
            pageMain.Loaded += (sender, e) =>
            {
                FreamNavicatTo(pageMain, url);
            };
            if (lastHistory == null || lastHistory.GetType() != pageMain.GetType())
            {
                lastHistory = pageMain;
                pageMain.Show();

            }
        }
        public void FreamNavicatTo(Window window,string url)
        {
            var controls = window.GetControls();
            foreach (var ctr in controls)
            {
                if (ctr as RouterControl.RouterView != null)
                {
                    var routeView = ctr as RouterControl.RouterView;

                    var frame = routeView?.FindName("wpf_router_view_fream") as Frame;
                    if (frame != null)
                    {
                        var page = (hashRouter[url] as PageComponents).Instance;
                        frame.Navigate(page);
                    }

                }

            }
        }
        private void PageMain_Loaded(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
