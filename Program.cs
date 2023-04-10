using System;
using System.Security.Principal;

public class Program
{
    public static void Main()
    {
        Console.Title = "WindowsKeyGetter | Made by https://github.com/GabryB03/";

        if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
        {
            Console.WriteLine("[+] This program must be run with Administrator privileges.");
            goto exit;
        }

        try
        {
            string key = WindowsKeyGrabber.GetWindowsProductKeyFromRegistry();
        
            if (key == null || key == "" || key.Length != 29 || !key.Contains("-"))
            {
                Console.WriteLine("[+] No Windows key has been found.");
            }
            else
            {
                Console.WriteLine("[+] Your Windows key is the following: " + key);
            }
        }
        catch
        {
            Console.WriteLine("[+] No Windows key has been found.");
        }

        exit: Console.WriteLine("[+] Press ENTER to exit from the program.");
        Console.ReadLine();
    }
}