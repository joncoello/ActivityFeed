using ActivityFeed.Domain.Repositories;
using Bcl.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ActivityFeed.Domain.Handlers {
    public class MessageHandlerFactory {
        private IActivityFeedRepository _activityFeedRepository;
        public MessageHandlerFactory(IActivityFeedRepository activityFeedRepository) {
            _activityFeedRepository = activityFeedRepository;
        }

        public IHandler GetHandler(MessageBase message) {
            IHandler instance;
            try {
                var typeList = GetHandlerTypes(message.GetType());
                var consumer = typeList.FirstOrDefault(
                                x => x.BaseType.GenericTypeArguments.Any(
                                    t => t == message.GetType()));
                instance = Activator.CreateInstance(
                    consumer,
                    new object[] { _activityFeedRepository }) as IHandler;
            }
            catch (ArgumentNullException e) {
                throw new ArgumentNullException
                    (string.Format("No handler found for type {0}",
                     message.GetType()), e);
            }
            catch (ArgumentException e) {
                throw new ArgumentException
                    (string.Format("Invalid argument passed to create message handler",
                     message.GetType()), e);
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
                catch (Exception) {
                    continue;
                }
            }

            return listOfTypes;
        }
    }
}
