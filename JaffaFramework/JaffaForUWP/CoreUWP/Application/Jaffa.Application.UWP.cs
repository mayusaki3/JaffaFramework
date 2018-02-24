using System;
using System.Collections.Generic;

namespace Jaffa
{
    /// <summary>
    /// Jaffaフレームワーク・UWP版アプリケーションサポート
    /// </summary>
    public static partial class Application : Object
    {
        #region イベント

        #region ページインスタンス生成イベント (Page_CreatePageEvent) [Private]

        private static void Page_CreatePageEvent(object sender, EventArgs e)
        {
            Windows.UI.Xaml.Controls.Page page = sender as Windows.UI.Xaml.Controls.Page;

            // Pageインスタンスを記憶
            instPages.Add(page);

            // Unloadイベントを設定
            page.Unloaded += Page_Unloaded;
        }

        private static List<Windows.UI.Xaml.Controls.Page> instPages = new List<Windows.UI.Xaml.Controls.Page>();

        #endregion

        #region ページインスタンス破棄イベント (Page_Unloaded) [Private]

        private static void Page_Unloaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // Pageインスタンスを除外
            instPages.Remove(sender as Windows.UI.Xaml.Controls.Page);
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

        #region アプリケーションを参照 ([R] Current)

        /// <summary>
        /// アプリケーションを参照します。
        /// </summary>
        public static Windows.UI.Xaml.Application Current
        {
            get
            {
                return Windows.UI.Xaml.Application.Current;
            }
        }

        #endregion

        #region リソースローダーを参照 ([R] Resource)

        static private Windows.ApplicationModel.Resources.ResourceLoader resLoader = null;

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

        #region アプリケーションでインスタンス化されたページを取得 ([R} Pages)

        /// <summary>
        /// アプリケーションでインスタンス化されたページを取得します。
        /// </summary>
        public static Windows.UI.Xaml.Controls.Page[] Pages
        {
            get
            {
                return instPages.ToArray();
            }
        }

        #endregion

        #endregion
    }
}
