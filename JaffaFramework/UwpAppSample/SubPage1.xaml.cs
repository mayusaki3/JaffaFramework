using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Jaffa.Diagnostics;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace UwpAppSample
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class SubPage1 : Page
    {
        public SubPage1()
        {
            this.InitializeComponent();
            Jaffa.UI.Page.Start(this);

            Logging.Write("SubPage1 Start!");
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
