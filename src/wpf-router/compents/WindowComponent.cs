using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using wpfRouter.utls;

namespace wpfRouter.compents
{
    /// <summary>
    /// 窗口组件
    /// </summary>
    public class WindowComponent : AbstComponent
    {
        public Window Instance { get { return ReflectUtls.GetInstance<Window>(componentsType); } }

        public WindowComponent(Type componentType) : base(componentType)
        {
        }
    }

}
