using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcl.Core.IoC
{
    public class DependencyContainerFactory
    {
        public IDependencyContainer Create() {
            return new DependencyContainer();
        }

    }
}
