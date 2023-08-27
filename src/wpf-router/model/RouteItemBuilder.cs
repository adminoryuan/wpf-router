using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfRouter.compents;

namespace wpfRouter.model
{
    public class RouterBuilder
    {
        private RouterItem _routerItem = new RouterItem();

        public RouterBuilder WithUrl(string url)
        {
            _routerItem.Url = url;
            return this;
        }

        public RouterBuilder WithComponent(AbstComponent component)
        {
            _routerItem.Component = component;
            return this;
        }

        public RouterBuilder WithChildren(params RouterItem[] children)
        {
            _routerItem.Children = children;
            return this;
        }

        public RouterItem Build()
        {
            return _routerItem;
        }

    }
}
