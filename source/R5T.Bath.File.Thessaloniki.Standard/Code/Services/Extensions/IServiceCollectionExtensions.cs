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
        public static IServiceCollection AddHumanOutputFileDirectoyPathProvider_TemporaryDirectoryBased(this IServiceCollection services)
        {
            services
                .AddSingleton<IHumanOutputFileDirectoryPathProvider, TemporaryDirectoryBasedHumanOutputFileDirectoryPathProvider>()
                .AddCTempTemporaryDirectoryPathProvider()
                ;

            return services;
        }

        public static IServiceCollection AddHumanOutputFilePathProvider_TemporaryDirectoryBased<THumanOutputFileNameProvider, TStringlyTypedPathOperator>(this IServiceCollection services)
            where THumanOutputFileNameProvider: class, IHumanOutputFileNameProvider
            where TStringlyTypedPathOperator: class, IStringlyTypedPathOperator
        {
            services
                .AddSingleton<IHumanOutputFilePathProvider, DefaultHumanOutputFilePathProvider>()
                .AddHumanOutputFileDirectoyPathProvider_TemporaryDirectoryBased()
                .TryAddSingletonFluent<IHumanOutputFileNameProvider, THumanOutputFileNameProvider>()
                .TryAddSingletonFluent<IStringlyTypedPathOperator, TStringlyTypedPathOperator>()
                ;

            return services;
        }

        /// <summary>
        /// Uses the <see cref="DefaultHumanOutputFileNameProvider"/> service.
        /// </summary>
        public static IServiceCollection AddHumanOutputFilePathProvider_TemporaryDirectoryBased<TStringlyTypedPathOperator>(this IServiceCollection services)
            where TStringlyTypedPathOperator : class, IStringlyTypedPathOperator
        {
            services.AddHumanOutputFilePathProvider_TemporaryDirectoryBased<DefaultHumanOutputFileNameProvider, TStringlyTypedPathOperator>();

            return services;
        }
    }
}
