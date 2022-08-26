using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace BusBoarding.Localization
{
    public static class BusBoardingLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(BusBoardingConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(BusBoardingLocalizationConfigurer).GetAssembly(),
                        "BusBoarding.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
