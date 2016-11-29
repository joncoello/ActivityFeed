using Bcl.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityFeed.DomainModel.Handlers {
    public class MessageHandlerFactory {

        public IHandler GetHandler(MessageBase message) {
            IHandler instance;
            try {
                var typeList = GetHandlerTypes(message.GetType());
                var consumer = typeList.FirstOrDefault(
                                x => x.BaseType.GenericTypeArguments.Any(
                                    t => t == message.GetType()));
                instance = Activator.CreateInstance(consumer) as IHandler;
            }
            catch (Exception e) {
                instance = null;
            }

            return instance;
        }

        private IEnumerable<Type> GetHandlerTypes(Type type) {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var listOfTypes = new List<Type>();
            foreach (var assembly in assemblies) {
                try {
                    var types = assembly.GetExportedTypes()
                        .Where(x => x.BaseType != null && x.BaseType.GetInterfaces()
                        .Any(a => a == typeof(IHandler)));

                    listOfTypes.AddRange(types);
                }
                catch (Exception e) {
                    continue;
                }
            }

            return listOfTypes;
        }
    }
}
