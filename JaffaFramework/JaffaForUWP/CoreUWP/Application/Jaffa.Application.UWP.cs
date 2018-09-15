using System;
using System.Collections.Generic;

namespace Jaffa
{
    /// <summary>
    /// Jaffaフレームワーク・UWP版アプリケーションサポート
    /// </summary>
    public static partial class Application
    {
        #region イベント

        #region ページインスタンスアンロードイベント (PageUnloaded)

         /// <summary>
        /// ページインスタンスがアンロードされたことを通知します。
        /// </summary>
        public static event EventHandler<EventArgs> PageUnloaded;

        #endregion

        #region ページインスタンス生成イベント (Page_Creating) [Private]

        private static void Page_Creating(object sender, EventArgs e)
        {
            Windows.UI.Xaml.Controls.Page page = sender as Windows.UI.Xaml.Controls.Page;

            // Pageインスタンスを記憶
            instPages.Add(page);

            // Unloadイベントを設定
            page.Unloaded += Page_Unloaded;
        }

        #endregion

        #region ページインスタンス破棄イベント (Page_Unloaded) [Private]

        private static void Page_Unloaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // Pageインスタンスを除外
            instPages.Remove(sender as Windows.UI.Xaml.Controls.Page);

            // ページ破棄を通知
            PageUnloaded?.Invoke(sender, new EventArgs());
        }

        #endregion

        #endregion

        #region メソッド

        #region アプリケーション開始 (Start)

        /// <summary>
        /// Jaffaフレームワークにアプリケーション開始を通知します。
        /// InitializeComponentの前に実行する必要があります。
        /// </summary>
        /// <param name="app">Jaffaフレームワークを利用するアプリケーションのインスタンスを指定します。</param>
        public static void Start(Windows.UI.Xaml.Application app)
        {
            // リソースローダー初期化
            try
            {
                resLoader = new Windows.ApplicationModel.Resources.ResourceLoader();
            }
            catch { }

            // 起動時のカルチャー名を記憶
            Jaffa.International.GetResourceCultureName(System.Globalization.CultureInfo.CurrentCulture.Name);

            // ページ追加通知を設定
            Jaffa.UI.Controls.Page.Creating += Page_Creating;

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

        private static List<Windows.UI.Xaml.Controls.Page> instPages = new List<Windows.UI.Xaml.Controls.Page>();

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
