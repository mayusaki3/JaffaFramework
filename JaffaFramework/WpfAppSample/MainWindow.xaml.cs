using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Jaffa.Diagnostics;

namespace WpfAppSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Logging.Write("MainWindow Start!");
            Logging.LogWritingEvent += Logging_LogWritingEvent;
            logText.Text = "";
            Logging.LogWriteWaiting = false;

            listLangages.ItemsSource = Jaffa.International.GetAvailableLanguageList();
            listLangages.SelectedItem = Jaffa.International.GetDisplayLanguageName(Jaffa.International.CurrentCultureSetting);
        }

        private void Logging_LogWritingEvent(Logging.LogWritingEventArgs e)
        {
            foreach (string log in e.Messages)
            {
                try
                {
                    logText.Text += e.DateTime.ToString("HHmmssfff|") + log + "\r\n";
                }
                catch { }
            }
        }
    }
}
