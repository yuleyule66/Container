﻿using AspectCore.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AspectCore.Container.DependencyInjection.Test
{
    public class ServiceCollectionExtensionsTests
    {
        [Fact]
        public void AddAspectConfiguration_Test()
        {
            var services = new ServiceCollection();
            services.AddAspectConfigure(c => { });
            var aspectCoreServiceProviderFactory = new AspectCoreServiceProviderFactory();
            var proxyServices = aspectCoreServiceProviderFactory.CreateBuilder(services);
            var descriptor = Assert.Single(proxyServices, d => d.ServiceType == typeof(IAspectConfigure));
            Assert.Null(descriptor.ImplementationType);
            Assert.NotNull(descriptor.ImplementationInstance);
        }
    }
}
