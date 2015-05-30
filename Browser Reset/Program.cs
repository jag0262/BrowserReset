// Browser Reset Ver. 1.00
// Created By Justin Greco 
// 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Browser_Reset
{
    class Program
    {

        public static void firefoxReset(string username)
        {
            // Check if the FireFox Preferences File Exists and Removes it
            string profile = findFirefoxProfile(username);
            string filepath = System.String.Format(@"C:\Users\{0}\AppData\Roaming\Mozilla\Firefox\{1}\prefs.js", username, profile);
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
                Console.WriteLine("Operation Complete!" + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("No FireFox Profile Exist" + Environment.NewLine);
            }
        }

        public static void firefoxExtensionRemoval(string username)
        {
            //Checks if the Firefox Extension Directory Exists and Removes it
            string profile = findFirefoxProfile(username);
            string filepath = System.String.Format(@"C:\Users\{0}\AppData\Roaming\Mozilla\Firefox\{1}\extensions", username, profile);
            if (Directory.Exists(filepath))
            {
                Directory.Delete(filepath, true);
                Console.WriteLine("Operation Complete!" + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("No FireFox Profile Exist" + Environment.NewLine);
            }
        }

        public static void chromeReset(string username)
        {
            // Checks if the Chrome Profile Directory Exists and Removes it
            string filepath = System.String.Format(@"C:\Users\{0}\AppData\Local\Google\Chrome\User Data\Default", username);
            string textlines;
            string text;
            if (Directory.Exists(filepath))
            {
                Directory.Delete(filepath, true);
                Console.WriteLine("Operation Complete!" + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("No Google Chrome Profile Exists" + Environment.NewLine);
            }
        }

        public static void chromeExtensionRemoval(string username)
        {
            // Checks if the Chrome Extension Directory Exists and Removes it
            string filepath = System.String.Format(@"C:\Users\{0}\AppData\Local\Google\Chrome\User Data\Default\Extensions", username);
            if (Directory.Exists(filepath))
            {
                Directory.Delete(filepath, true);
                Console.WriteLine("Operation Complete!" + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("No Google Chrome Profile Exists" + Environment.NewLine);
            }
        }

        public static string findFirefoxProfile(string username)
        {
            // Reads Text File that has name of Firefox Profile amd returns the Profile Name
            string filepath = System.String.Format(@"C:\Users\{0}\AppData\Roaming\Mozilla\Firefox\profiles.ini", username);
            string textlines;
            string text;
            string profile = ("none");
            StreamReader textfile = File.OpenText(filepath);
            while ((textlines = textfile.ReadLine()) != null)
            {
                if (textlines.Contains(".default"))
                {
                    text = textlines;
                    profile = text.Remove(0, 5); 
                }
                 
            }

            return profile;
        }

        public static void resetIE()
        {
            //Runs Command Line Code to Bring up the Internet Explorer Reset Page
            string cmdtext = "/C RunDll32.exe InetCpl.cpl,ResetIEtoDefaults";
            System.Diagnostics.Process.Start("CMD.exe", cmdtext);
            Console.WriteLine("Operation Complete!");
        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(90, 32);
            int ans = 0;

            // While loop looks for user to choose "6. Exit", which breaks the loop and quits the program
            while (ans != 6)
            {
                string username = Environment.UserName;
                Console.WriteLine("###################" + Environment.NewLine + "#                 #" + Environment.NewLine 
                    + "# Browser Restore #" + Environment.NewLine + "# Ver. 1.00       #" + Environment.NewLine + 
                    "#                 #" + Environment.NewLine + "###################" 
                    + Environment.NewLine + Environment.NewLine );

                Console.WriteLine("WARNING:" + Environment.NewLine);

                Console.WriteLine("This program resets your browsers back to their original states," + Environment.NewLine + "and will remove user data." +
                    Environment.NewLine + Environment.NewLine + "This can include but not limited to saved passwords, form data, and history." 
                    + Environment.NewLine + "Please use at your own risk." + Environment.NewLine);
                    
                Console.WriteLine("Please Select an Option Below and Hit Enter:" + Environment.NewLine + Environment.NewLine );

                Console.WriteLine("1. Restore FireFox Settings" + Environment.NewLine + Environment.NewLine + "2. Restore FireFox Extensions"
                    + Environment.NewLine + Environment.NewLine + "3. Restore Chrome Settings" + Environment.NewLine + Environment.NewLine + "4. Restore Chrome Extensions"
                    + Environment.NewLine + Environment.NewLine + "5. Restore Internet Explorer" + Environment.NewLine + Environment.NewLine + "6. Exit");
                
                var answer = Console.ReadLine();
                Console.Clear();
                // Takes user input and parses it into an int, which it uses to switch the case and run the correct function
                 if (int.TryParse(answer, out ans))
                 {
                     switch (ans)
                     {
                         case 1:
                             firefoxReset(username);
                             Console.WriteLine("Press Any Key");
                             Console.ReadKey();
                             Console.Clear();
                             break;
                         case 2:
                             firefoxExtensionRemoval(username);
                             Console.WriteLine("Press Any Key");
                             Console.ReadKey();
                             Console.Clear();
                             break;
                         case 3:
                             chromeReset(username);
                             Console.WriteLine("Press Any Key");
                             Console.ReadKey();
                             Console.Clear();
                             break;
                         case 4:
                             chromeExtensionRemoval(username);
                             Console.WriteLine("Press Any Key");
                             Console.ReadKey();
                             Console.Clear();
                             break;
                         case 5:
                             resetIE();
                             Console.WriteLine("Press Any Key");
                             Console.ReadKey();
                             Console.Clear();
                             break;
                         case 6:

                             break;

                     }
                 }
            }
        }
    }
}
