using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using wpfRouter.utls;

namespace wpfRouter.compents
{
    /// <summary>
    /// 页面组件
    /// </summary>
    public class PageComponents : AbstComponent
    {
        public Page Instance { get { return ReflectUtls.GetInstance<Page>(componentsType); } }
        public PageComponents(Type componentType) : base(componentType)
        {

        }
    }
}
