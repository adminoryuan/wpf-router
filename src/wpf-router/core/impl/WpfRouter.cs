using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using wpf_router.core;
using wpfRouter.compents;
using wpfRouter.extions;
using wpfRouter.model;

namespace wpf_router.core.impl
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

        private Trie routeTrie = new Trie();
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
                    routeTrie.Insert(fullUrl, item.Component);
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

        private T GetComponent<T>(string url) where T:AbstComponent
        {
            var routerComponent = routeTrie.Search(url);
            if (routerComponent == null)
            {
                throw new Exception("路由不存在！");
            }
            var components = (routerComponent as T);
            if (components == null) throw new Exception("类型错误！");
            return components;
        }
        public void NavicatTo(string url)
        {
            string[] routeNode = url.Split("/");

            var windowMain = GetComponent<WindowComponent>($"/{routeNode[1]}").Instance;
            if (lastHistory != null && lastHistory.GetType() == windowMain.GetType())
            {
                PageNavicatTo(lastHistory, url);

            }
            else
            {
                windowMain.Loaded += (sender, e) =>
                {
                    PageNavicatTo(windowMain, url);
                };
            }
            
            if (lastHistory == null || lastHistory.GetType() != windowMain.GetType())
            {
                lastHistory = windowMain;
                windowMain.Show();
            }
        }
        public void PageNavicatTo(Window window, string url)
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
                        var page = GetComponent<PageComponents>(url).Instance;
                        frame.Navigate(page);
                    }
                }
            }
        }
      
    }
}
