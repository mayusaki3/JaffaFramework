using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Jaffa
{
    /// <summary>
    /// Jaffaフレームワーク・UWP版アプリケーションサポート
    /// </summary>
    public static partial class Application
    {
        #region イベント

        #region ページインスタンス生成イベント (Page_CreatePageEvent) [Private]

        private static void Page_CreatePageEvent(object sender, EventArgs e)
        {
            Windows.UI.Xaml.Controls.Page page = sender as Windows.UI.Xaml.Controls.Page;

            System.Diagnostics.Debug.Write("[Page_CreatePageEvent] " + sender.GetType().ToString() + " ");
            System.Diagnostics.Debug.Write(instPages.Count.ToString() + " --> ");

            // Pageインスタンスを記憶
            instPages.Add(page);

            // Unloadイベントを設定
            page.Unloaded += Page_Unloaded;

            System.Diagnostics.Debug.WriteLine(instPages.Count.ToString());
            foreach (var p in instPages)
            {
                System.Diagnostics.Debug.WriteLine("- " + p.ToString());
            }
        }

        private static List<Windows.UI.Xaml.Controls.Page> instPages = new List<Windows.UI.Xaml.Controls.Page>();

        #endregion

        #region ページインスタンス破棄イベント (Page_Unloaded) [Private]

        private static void Page_Unloaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

            System.Diagnostics.Debug.Write("[Page_Unloaded] " + sender.GetType().ToString() + " ");
            System.Diagnostics.Debug.Write(instPages.Count.ToString() + " --> ");

            // Pageインスタンスを除外
            instPages.Remove(sender as Windows.UI.Xaml.Controls.Page);

            System.Diagnostics.Debug.WriteLine(instPages.Count.ToString());
            foreach(var p in instPages)
            {
                System.Diagnostics.Debug.WriteLine("- " + p.ToString());
            }
        }

        #endregion

        #endregion

        #region メソッド

        #region アプリケーション開始 (Start)

        /// <summary>
        /// Jaffaフレームワークにアプリケーション開始を通知します。
        /// </summary>
        public static void Start()
        {
            // リソースローダー初期化
            try
            {
                resLoader = new Windows.ApplicationModel.Resources.ResourceLoader();
            }
            catch { }

            // 起動時のカルチャー名を記憶
            Jaffa.International.GetResourceCultureName(Windows.System.UserProfile.GlobalizationPreferences.Languages[0]);

            // ページ追加通知を設定
            Jaffa.UI.Page.CreatePageEvent += Page_CreatePageEvent;

            // コアライブラリ初期化
            Jaffa.Internal.Core.Initialize();
        }

        #endregion

        #endregion

        #region プロパティ

        #region アプリケーションインスタンスを参照 ([R] Current)

        /// <summary>
        /// アプリケーションインスタンスを参照します。
        /// </summary>
        public static Windows.UI.Xaml.Application Current
        {
            get
            {
                return Windows.UI.Xaml.Application.Current;
            }
        }

        #endregion

        #region アプリケーションでインスタンス化されたページを参照 ([R} Pages)

        /// <summary>
        /// アプリケーションでインスタンス化されたページを参照します。
        /// </summary>
        public static Windows.UI.Xaml.Controls.Page[] Pages
        {
            get
            {
                return instPages.ToArray();
            }
        }

        #endregion

        #region リソースローダーを参照 ([R] Resource)

        private static Windows.ApplicationModel.Resources.ResourceLoader resLoader = null;

        /// <summary>
        /// リソースローダーを参照します。
        /// </summary>
        public static Windows.ApplicationModel.Resources.ResourceLoader Resource
        {
            get
            {
                return resLoader;
            }
        }

        #endregion

        #region アプリケーションカルチャー遅延更新 ([R/W] WaitingChangeCulture)

        private static bool waitingChangeCulture = false;

        /// <summary>
        /// アプリケーションカルチャーが遅延更新状態かを設定または参照します。
        /// </summary>
        public static bool WaitingChangeCulture
        {
            get
            {
                return waitingChangeCulture;
            }
            set
            {
                waitingChangeCulture = value;
            }
        }

        #endregion

        #endregion
    }
}
