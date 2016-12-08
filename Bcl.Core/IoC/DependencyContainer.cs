using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcl.Core.IoC
{
    public class DependencyContainer : IDependencyContainer
    {
        private readonly UnityContainer _container;

        public DependencyContainer()
        {
            _container = new UnityContainer();
        }
        
        public void RegisterType<TFrom, TTo>() where TTo : TFrom
        {
            _container.RegisterType<TFrom, TTo>();
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public T Resolve<T>(Type type)
        {
            return (T)_container.Resolve(type);
        }
    }
}
