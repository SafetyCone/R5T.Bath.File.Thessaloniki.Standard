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
        public static ServiceAction<IHumanOutputFileDirectoryPathProvider> AddCDriveHumanOutputFileDirectoryPathProviderAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<IHumanOutputFileDirectoryPathProvider>(() => services.AddCDriveHumanOutputFileDirectoryPathProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds a C-drive-based <see cref="IHumanOutputFilePathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddCDriveHumanOutputFilePathProvider(this IServiceCollection services,
            ServiceAction<IHumanOutputFileNameProvider> addHumanOutputFileNameProvider)
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
        public static ServiceAction<IHumanOutputFilePathProvider> AddCDriveHumanOutputFilePathProviderAction(this IServiceCollection services,
            ServiceAction<IHumanOutputFileNameProvider> addHumanOutputFileNameProvider)
        {
            var serviceAction = new ServiceAction<IHumanOutputFilePathProvider>(() => services.AddCDriveHumanOutputFilePathProvider(addHumanOutputFileNameProvider));
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
        public static ServiceAction<IHumanOutputFilePathProvider> AddCDriveHumanOutputFilePathProviderAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<IHumanOutputFilePathProvider>(() => services.AddCDriveHumanOutputFilePathProvider());
            return serviceAction;
        }
    }
}
