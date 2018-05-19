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
            // Jaffa: InitializeComponentの前にページ開始を通知 (Required)
            Jaffa.UI.Page.Start(this);

            this.InitializeComponent();

            // Jaffa: ログはいつでも出力できます(キャッシュに入ります)
            Logging.Write("SubPage1 Start");

            // 画面のログをクリア
            logText.Text = "";

            // Jaffa: ログを画面に転送するためのイベントを設定
            Logging.LogWritingEvent += Logging_LogWritingEvent;

            // Jaffa: ログ出力開始（キャッシュされていたログはこのタイミングで出力されます）
            Logging.LogWriteWaiting = false;

            // 言語リスト読み込み
            if (listLanguages.Items.Count == 0) listLanguages_Reload();
        }

        private void Logging_LogWritingEvent(Logging.LogWritingEventArgs e)
        {
            // ログを行ごとに転送
            foreach (string log in e.Messages)
            {
                try
                {
            //        logText.Inlines.Add(e.DateTime.ToString("HHmmssfff|") + log);
            //        logText.Inlines.Add(new LineBreak());

                    logText.Text += e.DateTime.ToString("HHmmssfff|") + log + "\r\n";

                }
                catch { }
            }

            // 画面の保持は300行まで
            //while (logText.Inlines.Count > 300)
            {
            //    logText.Inlines.Remove(logText.Inlines.FirstInline);
            }

            // 末尾にスクロール
            LogTextScroll.ScrollToVerticalOffset(LogTextScroll.Height);
        }

        private void listLanguages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listLanguagesReloading == true || listLanguages.SelectedIndex < 0) return;
            Logging.Write("Event: listLanguages_SelectionChanged");

            // Jaffa: カルチャを切り替え
            Jaffa.International.ChangeCultureFromDisplayLanguageName(listLanguages.Items[listLanguages.SelectedIndex].ToString());
        }

        /// <summary>
        /// 言語リストを読み込み、現在の設定を選択します。
        /// </summary>
        private void listLanguages_Reload()
        {
            listLanguagesReloading = true;
            listLanguages.ItemsSource = Jaffa.International.GetAvailableLanguageList();
            listLanguages.SelectedItem = Jaffa.International.GetDisplayLanguageName(Jaffa.International.CurrentCultureSetting);
            Logging.Write("Selected Languages: " + listLanguages.SelectedValue);
            listLanguagesReloading = false;
        }
        private bool listLanguagesReloading = false;

        public void SaveContents(ref List<object> save)
        {
            save.Clear();
            save.Add(logText.Text);
        }

        public void RestoreContents(List<object> save)
        {
            logText.Text = save[0] as string;
        }

        private string savlogtext = "";
    }
}
