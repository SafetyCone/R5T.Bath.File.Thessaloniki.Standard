using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Bath.File.Default;
using R5T.Dacia.Extensions;
using R5T.Lombardy;
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

        public static IServiceCollection AddTemporaryDirectoryBasedHumanOutputFilePathProvider<THumanOutputFileNameProvider, TStringlyTypedPathOperator>(this IServiceCollection services)
            where THumanOutputFileNameProvider: class, IHumanOutputFileNameProvider
            where TStringlyTypedPathOperator: class, IStringlyTypedPathOperator
        {
            services
                .AddSingleton<IHumanOutputFilePathProvider, DefaultHumanOutputFilePathProvider>()
                .AddTemporaryDirectoryBasedHumanOutputFileDirectoryPathProvider()
                .TryAddSingletonFluent<IHumanOutputFileNameProvider, THumanOutputFileNameProvider>()
                .TryAddSingletonFluent<IStringlyTypedPathOperator, TStringlyTypedPathOperator>()
                ;

            return services;
        }

        public static IServiceCollection AddTemporaryDirectoryBasedHumanOutputFilePathProvider<TStringlyTypedPathOperator>(this IServiceCollection services)
            where TStringlyTypedPathOperator : class, IStringlyTypedPathOperator
        {
            services.AddTemporaryDirectoryBasedHumanOutputFilePathProvider<DefaultHumanOutputFileNameProvider, TStringlyTypedPathOperator>();

            return services;
        }
    }
}
