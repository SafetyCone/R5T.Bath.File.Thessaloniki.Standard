using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Bath.File.Default;
using R5T.Thessaloniki.Standard;


namespace R5T.Bath.File.Thessaloniki.Standard
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTemporaryDirectoryBasedHumanOutputFileDirectoryPathProvider(this IServiceCollection services)
        {
            services
                .AddSingleton<IHumanOutputFileDirectoryPathProvider, TemporaryDirectoryBasedHumanOutputFileDirectoryPathProvider>()
                .AddCTempTemporaryDirectoryPathProvider()
                ;

            return services;
        }
    }
}
