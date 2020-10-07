using System;
using System.Collections.Generic;

namespace IP2Email.Helpers
{
    internal static class ConsoleHelper
    {
        internal static void EmailSend(string senderEmail, string recipientEmail)
        {
            Console.WriteLine($"The email from {senderEmail} for {recipientEmail} was sent successfully.");            
        }

        internal static void ShowIPs(string internetIP, List<string> localIPs)
        {            
            Console.WriteLine($"Internet IP . . . . : {internetIP}");
            localIPs.ForEach(ip => Console.WriteLine($"Local IP. . . . . . : {ip}"));                      
        }

        internal static void EmailSendException(Exception exception, string senderEmail, string recipientEmail)
        {
            Console.WriteLine($"Failed to send message from {senderEmail} for {recipientEmail}.");
            Console.WriteLine($"Exception description: {exception.Message}.");            
        }

        internal static string SetOption(string option)
        {
            Console.Write(option);
            return Console.ReadLine();
        }

        internal static void SetMailData()
        {
            Console.WriteLine("WARNING: DO NOT ENTER HERE YOUR CURRENT EMAIL'S LOGIN AND PASSWORD!");
            Console.WriteLine("IT'S NOT SAFE! CREATE NEW EMAIL ACCOUNT WITH A STRONG AND RANDOM PASSWORD.");
            Console.WriteLine();
            Console.WriteLine("To send messages about changing the IP address of your PC by email, specify the following parameters:");            
        }

        internal static void EmailSettingsSave(bool state)
        {            
            Console.WriteLine(state == true ? "Excellent! Now all settings successfully saved." : "Something went wrong! Couldn't save settings.");           
        }

        internal static void ShowAppBanner()
        {
            Console.WriteLine();
            Console.WriteLine("IP2Email v1.0 - A simple way to find out the internet ip address in cmd");
            Console.WriteLine("Copyright (c) 2019 oZ-Zo");
            Console.WriteLine("https://github.com/oz-zo/ip2email");
            Console.WriteLine();
        }

        internal static void NotSetMailData()
        {
            Console.WriteLine("A email cannot be sent without initial settings.");
            Console.WriteLine("Usage: \"ip2email.exe -Config\" to configure email settings.");            
        }
    }
}
