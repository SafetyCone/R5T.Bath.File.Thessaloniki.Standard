using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Bath.File.Default;
using R5T.Dacia;
using R5T.Lombardy.Standard;
using R5T.Thessaloniki.CDrive;


namespace R5T.Bath.File.Thessaloniki.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds a C-drive-based <see cref="IHumanOutputFileDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddCDriveHumanOutputFileDirectoryPathProvider(this IServiceCollection services)
        {
            services.AddTemporaryDirectoryBasedHumanOutputFileDirectoryPathProvider(services.AddTemporaryDirectoryPathProviderAction());

            return services;
        }

        /// <summary>
        /// Adds a C-drive-based <see cref="IHumanOutputFileDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceAction<IHumanOutputFileDirectoryPathProvider> AddCDriveHumanOutputFileDirectoryPathProviderAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction<IHumanOutputFileDirectoryPathProvider>.New(() => services.AddCDriveHumanOutputFileDirectoryPathProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds a C-drive-based <see cref="IHumanOutputFilePathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddCDriveHumanOutputFilePathProvider(this IServiceCollection services,
            IServiceAction<IHumanOutputFileNameProvider> addHumanOutputFileNameProvider)
        {
            services.AddDefaultHumanOutputFilePathProvider(
                services.AddCDriveHumanOutputFileDirectoryPathProviderAction(),
                addHumanOutputFileNameProvider,
                services.AddStringlyTypedPathOperatorAction())
                ;

            return services;
        }

        /// <summary>
        /// Adds a C-drive-based <see cref="IHumanOutputFilePathProvider"/> service.
        /// </summary>
        public static IServiceAction<IHumanOutputFilePathProvider> AddCDriveHumanOutputFilePathProviderAction(this IServiceCollection services,
            IServiceAction<IHumanOutputFileNameProvider> addHumanOutputFileNameProvider)
        {
            var serviceAction = ServiceAction<IHumanOutputFilePathProvider>.New(() => services.AddCDriveHumanOutputFilePathProvider(addHumanOutputFileNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds a C-drive-based <see cref="IHumanOutputFilePathProvider"/> service using the <see cref="DefaultHumanOutputFileNameProvider"/>.
        /// </summary>
        public static IServiceCollection AddCDriveHumanOutputFilePathProvider(this IServiceCollection services)
        {
            services.AddCDriveHumanOutputFilePathProvider(services.AddDefaultHumanOutputFileNameProviderAction());

            return services;
        }

        /// <summary>
        /// Adds a C-drive-based <see cref="IHumanOutputFilePathProvider"/> service using the <see cref="DefaultHumanOutputFileNameProvider"/>.
        /// </summary>
        public static IServiceAction<IHumanOutputFilePathProvider> AddCDriveHumanOutputFilePathProviderAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction<IHumanOutputFilePathProvider>.New(() => services.AddCDriveHumanOutputFilePathProvider());
            return serviceAction;
        }
    }
}
