using Jaffa.Diagnostics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace UwpAppSample
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            // Jaffa: InitializeComponentの前にページ開始を通知 (Required)
            Jaffa.UI.Page.Start(this);

            this.InitializeComponent();

            // Jaffa: ログはいつでも出力できます(キャッシュに入ります)
            Logging.Write("MainPage Start");

            // 国際化対応のサンプル

            // Jaffa: カルチャ切替時のページデータ処理のためのイベントを設定
            Jaffa.International.CultureChangedEvent += Jaffa_CultureChangedEvent;

            // Jaffa: 初期表示前にカルチャを切り替える
            Jaffa.International.ChangeCultureFromDisplayLanguageName("English");
        }

        private void Jaffa_CultureChangedEvent(object sender, EventArgs e)
        {
            Logging.Write("Event: Jaffa_CultureChangedEvent - " + Jaffa.International.CurrentCulture);

            List<object> save = new List<object>();
            subPage1.SaveContents(ref save);

            this._contentLoaded = false;
            this.InitializeComponent();

            subPage1.RestoreContents(save);

            Logging.Write("Page Count = " + Jaffa.Application.Pages.Length.ToString());
            foreach(var page in Jaffa.Application.Pages)
            {
                Logging.Write(page.ToString());
            }

        }
    }
}
