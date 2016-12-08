using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcl.Core.IoC
{
    public interface IDependencyContainer
    {
        void RegisterType<TFrom, TTo>() where TTo : TFrom;
        T Resolve<T>();
        T Resolve<T>(Type type);

    }
}
