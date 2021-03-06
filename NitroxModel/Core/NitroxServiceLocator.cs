﻿using System;
using Autofac;
using Autofac.Builder;

namespace NitroxModel.Core
{
    public static class NitroxServiceLocator
    {
        public static IContainer DependencyContainer { get; private set; }

        public static T LocateService<T>()
            where T : class
        {
            if (DependencyContainer == null)
            {
                throw new InvalidOperationException(
                    "Cannot locate services until a AutoFac Container has been installed.");
            }

            return DependencyContainer.Resolve<T>();
        }

        public static object LocateService(Type serviceType)
        {
            if (DependencyContainer == null)
            {
                throw new InvalidOperationException(
                    "Cannot locate services until a AutoFac Container has been installed.");
            }

            return DependencyContainer.Resolve(serviceType);
        }

        public static void InitializeDependencyContainer(IAutoFacRegistrar dependencyRegistrar)
        {
            ContainerBuilder builder = new ContainerBuilder();
            dependencyRegistrar.RegisterDependencies(builder);
            DependencyContainer = builder.Build(ContainerBuildOptions.IgnoreStartableComponents);
        }
    }
}
