using System;

namespace IP2Email.Helpers
{
    internal static class TextHelper
    {
        //todo: Dont forget to change TextHelper.SecurityKey !!!
        
        internal static readonly string InternetIpSite = "https://ifconfig.me/ip";        
        internal static readonly string FailedGetLocalIP = "Failed to obtain local IP address";
        internal static readonly string FailedGetInternetIP = "Failed to obtain internet IP address";
        internal static readonly string RegistryKeySoftware = "Software";
        internal static readonly string RegistryKeyAuthor = "oZZo";
        internal static readonly string RegistryAppName = "IP2Email";        
        internal static readonly string SecurityKey = "0123456789abcdef";
        internal static readonly string SenderDisplayName = "IP2Email";
        internal static readonly string EmailSubject = $"PC \"{Environment.MachineName.ToUpper()}\" ip addresses";
        internal static readonly string EmailBody = $"PC \"{Environment.MachineName.ToUpper()}\" has ip addresses";
    }
}
