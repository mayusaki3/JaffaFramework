using Jaffa.Diagnostics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
            Jaffa.International.CultureChanged += Jaffa_CultureChanged;

            // Jaffa: 初期表示前にカルチャを切り替える
            Jaffa.International.ChangeCultureFromDisplayLanguageName("English");

            // ページアンロード時の開放状況表示用に設定
            Jaffa.Application.PageUnloaded += Application_PageUnloaded;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += Timer_Tick;
        }

        private async void Jaffa_CultureChanged(object sender, EventArgs e)
        {
            Logging.Write("Event: Jaffa_CultureChanged - " + Jaffa.International.CurrentCulture);

            // Pivotでは、ページは一度表示しないとUnloadされない
            int savidx = pivot.SelectedIndex;
            pivot.Opacity = 0;
            for (int i = 0; i < pivot.Items.Count; i++)
            {
                pivot.SelectedIndex = i;
                await Task.Delay(50);
            }
            pivot.SelectedIndex = savidx;
            await Task.Delay(50);
            pivot.Opacity = 100;

            List<object> save = new List<object>();

            // ページのリロード
            Jaffa.UI.Page.Reload(Window.Current.Content as Frame, this, (f, p) => {
                // 画面のデータを退避
                subPage1.SaveContents(ref save);


            }, (f, p) => {
                // 画面のデータを復元
                subPage1.RestoreContents(save);
            });
        }

        private void Application_PageUnloaded(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Start();
        }
        private DispatcherTimer timer = null;
        private void Timer_Tick(object sender, object e)
        {
            timer.Stop();
            Logging.Write("Loaded Page list: ");
            foreach (var p in Jaffa.Application.Pages)
            {
                Logging.Write("- " + p.ToString());
            }
        }
    }
}
