using Jaffa;
using Jaffa.Diagnostics;
using System;
using System.Reflection;

namespace JaffaShell
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello w");

            LoggingSettings.Folder = @"C:\WORKPLACE\Jaffa\Log\";
            LoggingSettings.FileName = @"syslog[@].txt";
            LoggingSettings.LoggingMode = LoggingMode.Week;
            LoggingSettings.FrameworkMessage = true;

            Internal.Initialize();

            Logging.LogWriting += Logging_LogWriting;
            Logging.LogWriteWaiting = false;

            Logging.Write(International.GetDisplayLanguageName("Auto"));
            Logging.Write(International.GetDisplayLanguageName("ja-JP"));
            Logging.Write(International.GetDisplayLanguageName("en-US"));

            Logging.Write("[LangCodeList]");
            Logging.Write("--------------------");
            foreach (string s in International.GetAvailableLanguageCodeList())
            {
                Logging.Write(s);
            }
            Logging.Write("--------------------");

            Logging.Write("[LangNameList]");
            Logging.Write("--------------------");
            foreach (string s in International.GetAvailableLanguageNameList())
            {
                Logging.Write(s);
            }
            Logging.Write("--------------------");

            International.ChangeCultureFromDisplayLanguageName("English");

            Logging.Write("[LangNameList]");
            Logging.Write("--------------------");
            foreach (string s in International.GetAvailableLanguageNameList())
            {
                Logging.Write(s);
            }
            Logging.Write("--------------------");

            International.ChangeCultureFromDisplayLanguageName("日本語");

            try
            {
                Internal.SetResource("SHELL", "JaffaShell.Resources." + International.CurrentCulture + ".Resource", Assembly.GetExecutingAssembly());
                throw new Exception(Internal.MakeMessage("SHELL", "{TEST_MESSAGE}"));
            }
            catch(Exception e)
            {
                Logging.Write(Logging.ExceptionToList(e), LogType.Error);
            }

            Internal.Terminate();
        }

        private static void Logging_LogWriting(object sender, LogWritingEventArgs e)
        {
            foreach(string m in e.Messages)
            {
                Console.WriteLine(m);
            }
        }
    }
}
