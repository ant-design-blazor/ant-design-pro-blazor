using System;
using System.Collections.Concurrent;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AntDesign.Pro.Localization.Json
{
    internal class JsonStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly ConcurrentDictionary<string, JsonStringLocalizer> _localizerCache =
            new ConcurrentDictionary<string, JsonStringLocalizer>();

        private readonly ILoggerFactory _loggerFactory;
        private readonly JsonLocalizationOptions _localizationOptions;

        public JsonStringLocalizerFactory(IOptions<JsonLocalizationOptions> localizationOptions, ILoggerFactory loggerFactory)
        {
            _localizationOptions = localizationOptions.Value;
            _loggerFactory = loggerFactory;
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            if (resourceSource == null)
            {
                throw new ArgumentNullException(nameof(resourceSource));
            }

            var resourceName = resourceSource.FullName;
            return CreateJsonStringLocalizer(resourceName);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            if (baseName == null)
            {
                throw new ArgumentNullException(nameof(baseName));
            }

            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            var resourceName = TrimPrefix(baseName, location + ".");
            return CreateJsonStringLocalizer(resourceName);
        }

        private JsonStringLocalizer CreateJsonStringLocalizer(string resourceName)
        {
            var logger = _loggerFactory.CreateLogger<JsonStringLocalizer>();
            return _localizerCache.GetOrAdd(resourceName, resName => new JsonStringLocalizer(
                _localizationOptions,
                resName,
                logger));
        }

        private static string TrimPrefix(string name, string prefix)
        {
            if (name.StartsWith(prefix, StringComparison.Ordinal))
            {
                return name.Substring(prefix.Length);
            }

            return name;
        }
    }
}
