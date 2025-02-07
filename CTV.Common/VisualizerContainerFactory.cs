﻿using CTV.Common.Layouters;
using CTV.Common.Layouters.Spirals;
using CTV.Common.Preprocessors;
using CTV.Common.WordsParsers;
using Microsoft.Extensions.DependencyInjection;

namespace CTV.Common
{
    public static class VisualizerContainerFactory
    {
        public static ServiceProvider CreateInstance()
        {
            var container = new ServiceCollection();
            AddDependencies(container);
            return container.BuildServiceProvider();
        }

        private static void AddDependencies(IServiceCollection container)
        {
            container.AddScoped<Visualizer>();
            container.AddScoped<IFileStreamFactory, FileStreamFactory>();
            container.AddScoped<IWordsParser, RussianWordsParser>();
            container.AddScoped<ToLowerPreprocessor>();
            container.AddScoped<IHunspeller, NHunspeller>();
            container.AddScoped<IHunspellerFilesProvider, RussianHunspellerFilesProvider>();
            container.AddScoped<RemovingBoringWordsPreprocessor>();
            container.AddScoped<IWordsPreprocessor, CombinedPreprocessor>(
                provider => new CombinedPreprocessor(
                    new IWordsPreprocessor[]
                    {
                        provider.GetService<ToLowerPreprocessor>(),
                        provider.GetService<RemovingBoringWordsPreprocessor>()
                    }));
            container.AddScoped<ILayouter, CircularCloudLayouter>();
            container.AddScoped<ISpiral, ExpandingSquareSpiral>();
            container.AddScoped<IWordSizer, FrequencyBasedWordSizer>();
        }
    }
}