using System.Linq;
using Glimpse.Core.Extensibility;
using Microsoft.Practices.Unity;

namespace Glimpse.Unity.Tabs
{
    public class UnityTab : TabBase
    {
        internal static IUnityContainer RegisteredContainer { private get; set; }

        public override string Name
        {
            get { return "Unity"; }
        }

        public override object GetData(ITabContext context)
        {
            return GetUnityContainerData(RegisteredContainer);
        }

        private object GetUnityContainerData(IUnityContainer container)
        {
            if (container == null)
            {
                return null;
            }

            var registrations = container.Registrations.Select(x => new
            {
                Name = x.Name,
                RegisteredType = x.RegisteredType,
                MappedToType = x.MappedToType,
                LifetimeManagerType = x.LifetimeManagerType,
                LifetimeManager = x.LifetimeManager
            });

            return registrations;
        }
    }
}
