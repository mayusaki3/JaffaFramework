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

            // Jaffa: ログはいつでも出力できます(キャッシュに入ります)
            Logging.Write("SubPage1 Start");

            // Jaffa: ページ開始を通知
            Jaffa.UI.Page.Start(this);

            // 画面のログをクリア
            logText.Text = "";

            // Jaffa: ログを画面に転送するためのイベントを設定
            Logging.LogWritingEvent += Logging_LogWritingEvent;

            // Jaffa: ログ出力開始（キャッシュされていたログはこのタイミングで出力されます）
            Logging.LogWriteWaiting = false;

            // 国際化対応のサンプル

            // Jaffa: カルチャ切替時のページデータ処理のためのイベントを設定
            Jaffa.International.PageDataProcessingEvent += Jaffa_PageDataProcessingEvent;

            // Jaffa: カルチャ切替するためのイベントを設定
            Jaffa.International.CultureChangedEvent += Jaffa_CultureChangedEvent;

            // 言語リスト読み込み
            listLanguages_Reload();
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
            Logging.Write("Event: listLanguages_SelectionChanged");
            if (listLanguages.SelectedIndex < 0) return;

            // ログを退避
            savelog = logText.Text;

            // Jaffa: カルチャを切り替え
            Jaffa.International.ChangeCultureFromDisplayLanguageName(listLanguages.Items[listLanguages.SelectedIndex].ToString());
        }
        private string savelog = "";

        private void Jaffa_PageDataProcessingEvent(object sender, Jaffa.International.PageDataProcessingEventArgs e)
        {
            // ページリロード時にデータを維持するための処理
            if (e.Request == Jaffa.International.PageDataProcessingRequests.Save)
            {
                // ログを退避
                logSaves = logText.Text;
            }
            if (e.Request == Jaffa.International.PageDataProcessingRequests.Restore)
            {
                // ログを復元
                logText.Text = logSaves;
                logSaves = "";
            }
        }
        private string logSaves = "";

        private void Jaffa_CultureChangedEvent(object sender, EventArgs e)
        {
            logText.Text = savelog;
            Logging.Write("Event: Jaffa_CultureChangedEvent - " + Jaffa.International.CurrentCulture);
        }

        /// <summary>
        /// 言語リストを読み込み、現在の設定を選択します。
        /// </summary>
        private void listLanguages_Reload()
        {
            listLanguages.ItemsSource = Jaffa.International.GetAvailableLanguageList();
            listLanguages.SelectedItem = Jaffa.International.GetDisplayLanguageName(Jaffa.International.CurrentCultureSetting);
            Logging.Write("Selected Languages: " + listLanguages.SelectedValue);
        }
    }
}
