using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfRouter.compents
{
    public abstract class AbstComponent
    {
        protected Type componentsType;
        public AbstComponent(Type componentType)
        {
            componentsType = componentType;
        }
    }
}
