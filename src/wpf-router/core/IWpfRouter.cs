using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using wpfRouter.model;

namespace wpf_router.core
{
    public interface IWpfRouter
    {

        void InitRouter(params RouterItem[] routes);
        /// <summary>
        /// 添加路由
        /// </summary>
        /// <param name="url">路由地址</param>
        /// <param name="component">组件地址</param>
        void AddRouter(string url, Page component);

        /// <summary>
        /// 路由跳转
        /// </summary>
        /// <param name="url"></param>
        void NavicatTo(string url);

    }
}
