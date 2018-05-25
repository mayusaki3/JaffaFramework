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
            // Jaffa: InitializeComponentの前にウィンドウ開始を通知 (Required)
            Jaffa.UI.Window.Start(this);

            InitializeComponent();

            // Jaffa: ログはいつでも出力できます(キャッシュに入ります)
            Logging.Write("MainWindow Start!");

            // 画面のログをクリア
            logText.Text = "";

            // Jaffa: ログを画面に転送するためのイベントを設定
            Logging.LogWriting += Logging_LogWriting;

            // Jaffa: ログ出力開始（キャッシュされていたログはこのタイミングで出力されます）
            Logging.LogWriteWaiting = false;

            // 国際化対応のサンプル

            // Jaffa: ダイナミックリソース以外をカルチャ切替するためのイベントを設定
            Jaffa.International.CultureChanged += Jaffa_CultureChanged;

            // Jaffa: 初期表示前にカルチャを切り替える
            Jaffa.International.ChangeCultureFromDisplayLanguageName("English");

            // 言語リスト読み込み
            if (listLanguages.Items.Count == 0) listLanguages_Reload();
        }

        private void Logging_LogWriting(Logging.LogWritingEventArgs e)
        {
            // ログを行ごとに転送
            foreach (string log in e.Messages)
            {
                try
                {
                    logText.Inlines.Add(e.DateTime.ToString("HHmmssfff|") + log);
                    logText.Inlines.Add(new LineBreak());

                }
                catch { }
            }

            // 画面の保持は300行まで
            while (logText.Inlines.Count > 300)
            {
                logText.Inlines.Remove(logText.Inlines.FirstInline);
            }

            // 末尾にスクロール
            //LogTextScroll.ScrollToEnd();
        }

        private void listLanguages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listLanguagesReloading == true || listLanguages.SelectedIndex < 0) return;
            Logging.Write("Event: listLanguages_SelectionChanged");

            // Jaffa: カルチャを切り替え
            Jaffa.International.ChangeCultureFromDisplayLanguageName(listLanguages.Items[listLanguages.SelectedIndex].ToString());
        }

        private void Jaffa_CultureChanged(object sender, EventArgs e)
        {
            Logging.Write("Event: Jaffa_CultureChanged - " + Jaffa.International.CurrentCulture);

            Jaffa.Internal.DateTime.DifferenceNow = new TimeSpan();

            // 言語リスト再読み込み
            listLanguages_Reload();
        }

        /// <summary>
        /// 言語リストを読み込み、現在の設定を選択します。
        /// </summary>
        private void listLanguages_Reload()
        {
            listLanguagesReloading = true;
            listLanguages.ItemsSource = Jaffa.International.GetAvailableLanguageNameList();
            listLanguages.SelectedItem = Jaffa.International.GetDisplayLanguageName(Jaffa.International.CurrentCultureSetting);
            Logging.Write("Selected Languages: " + listLanguages.SelectedValue);
            listLanguagesReloading = false;
        }
        private bool listLanguagesReloading = false;

        private void MenuEnd_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
