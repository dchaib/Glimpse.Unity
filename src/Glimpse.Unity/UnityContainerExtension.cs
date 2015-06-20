using System;
using Glimpse.Unity.Tabs;
using Microsoft.Practices.Unity;

namespace Glimpse.Unity
{
    public static class UnityContainerExtension
    {
        public static void ActivateGlimpse(this IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            UnityTab.ContainerInstance = container;
        }
    }
}
