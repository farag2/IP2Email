using IP2Email.Actions;
using IP2Email.Classes;
using IP2Email.Helpers;
using IP2Email.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ip2email
{
    internal class IP2Email
    {
        internal AppExitCodes ExitCode = AppExitCodes.Success;
        internal string InternetIP { get; private set; }
        internal List<string> LocalIP { get; private set; }
        internal AppConfig Configuration { get; private set; }

        public IP2Email()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(1033);
            InternetIP = GetInternetIP();
            LocalIP = GetLocalIP();
            Configuration = new AppConfig();
        }

        public IP2Email(string[] args) : this()
        {
            ArgsActionWrapper(ParseArgs(args));            
        }

        private void ArgsActionWrapper(IArgsAction action)
        {
            action.Do(InternetIP, LocalIP, ref ExitCode, Configuration);
        }

        private IArgsAction ParseArgs(string[] args)
        {
            if (args.Length == 0)
                return new ShowAllIPs();

            else if (args[0].ToUpper() == ArgsHelper.CONFIG)
                return new ConfigApp();

            else if (args[0].ToUpper() == ArgsHelper.SEND)
                return new SendMail();

            else
            {
                return new ShowHelp();
            }            
        }

        private List<string> GetLocalIP()
        {
            try
            {
                List<string> result = new List<string>();

                List<UnicastIPAddressInformationCollection> ipInfo = NetworkInterface.GetAllNetworkInterfaces()
                                                                                     .Select(ipinfo => ipinfo.GetIPProperties().UnicastAddresses)
                                                                                     .ToList();

                ipInfo.SelectMany(ipinfo => ipinfo.Select(ip => ip.Address))
                       .Where(ip => ip.AddressFamily == AddressFamily.InterNetwork)
                       .OrderByDescending(ip => ip.Address)                       
                       .ToList()
                       .ForEach(ip => result.Add(ip.ToString()));

                return result;
            }

            catch (Exception)
            {
                ExitCode = AppExitCodes.LocalIpException;
                return new List<string> { TextHelper.FailedGetLocalIP };
            }
        }

        private string GetInternetIP()
        {
            try
            {
                using (StreamReader stream = new StreamReader(HttpHelper.GetWebRequest(TextHelper.InternetIpSite)
                                                                        .GetResponse()
                                                                        .GetResponseStream(), Encoding.UTF8))
                {
                    return stream.ReadToEnd();
                }
            }
            catch (Exception)
            {
                ExitCode = AppExitCodes.InternetIpException;
                return TextHelper.FailedGetInternetIP;
            }
        }
    }
}