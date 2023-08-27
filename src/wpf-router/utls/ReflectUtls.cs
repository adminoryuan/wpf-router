using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfRouter.utls
{
    public class ReflectUtls
    {
        public static T GetInstance<T>(Type cls)
        {
            // 使用 Activator.CreateInstance 创建对象
            object instance = Activator.CreateInstance(cls);

            return (T)instance;
        }
    }
}
