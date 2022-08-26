using BusBoarding.Debugging;

namespace BusBoarding
{
    public class BusBoardingConsts
    {
        public const string LocalizationSourceName = "BusBoarding";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "a09ed10917074659ada58b38392aacd0";
    }
}
