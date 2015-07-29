using System;
using System.Collections.Generic;
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

        private static object GetUnityContainerData(IUnityContainer container)
        {
            if (container == null)
            {
                return null;
            }

            var registrations = container.Registrations.ToArray();

            return new UnityTabModel
            {
                Nameless = registrations.Where(r => string.IsNullOrEmpty(r.Name)).Select(r => new NamelessRegistration(r)),
                Named = registrations.Where(r => !string.IsNullOrEmpty(r.Name))
                    .GroupBy(r => r.RegisteredType)
                    .Select(g => new NamedRegistrationList(g))
            };
        }

        public bool KeysHeadings { get { return true; } }

        internal class UnityTabModel
        {
            public IEnumerable<NamelessRegistration> Nameless { get; set; }
            public IEnumerable<NamedRegistrationList> Named { get; set; }
        }

        internal class NamelessRegistration
        {
            public NamelessRegistration(ContainerRegistration r)
            {
                RegisteredType = r.RegisteredType;
                MappedToType = r.MappedToType;
                LifeTimeManagerType = r.LifetimeManagerType;
            }

            public Type RegisteredType { get; set; }
            public Type MappedToType { get; set; }
            public Type LifeTimeManagerType { get; set; }
        }

        internal class NamedRegistrationList
        {
            public NamedRegistrationList(IGrouping<Type, ContainerRegistration> registrations)
            {
                RegisteredType = registrations.Key;
                Registrations = registrations.Select(r => new NamedRegistration(r));
            }

            public Type RegisteredType { get; set; }
            public IEnumerable<NamedRegistration> Registrations { get; set; }
        }

        internal class NamedRegistration
        {
            public NamedRegistration(ContainerRegistration r)
            {
                Name = r.Name;
                MappedToType = r.MappedToType;
                LifeTimeManagerType = r.LifetimeManagerType;
            }

            public string Name { get; set; }
            public Type MappedToType { get; set; }
            public Type LifeTimeManagerType { get; set; }
        }
    }
}
