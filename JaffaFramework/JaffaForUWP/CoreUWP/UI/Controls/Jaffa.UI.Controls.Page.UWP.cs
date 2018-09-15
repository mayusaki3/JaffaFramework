using Jaffa.Diagnostics;
using System;
using System.Threading.Tasks;

namespace Jaffa.UI.Controls
{
    /// <summary>
    /// Jaffaフレームワーク・UWP版ページサポート
    /// </summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public static class Page : Object
    {
        #region インナークラス

        #region リロード表示用ページクラス (ReloadMask) [private]

        /// <summary>
        /// コアライブラリ用ヘルパークラス
        /// </summary>
        private class PageMask : Windows.UI.Xaml.Controls.Page
        {
            #region コンストラクタ―/デストラクター

            /// <summary>
            /// コンストラクタ―
            /// </summary>
            public PageMask()
            { }

            #endregion
        }

        #endregion

        #endregion

        #region イベント

        #region ページインスタンス生成イベント (Creating)

        /// <summary>
        /// ページインスタンスが生成されることを通知します。
        /// </summary>
        public static event EventHandler<EventArgs> Creating;

        #endregion

        #endregion

        #region メソッド

        #region ページ開始 (Start)

        /// <summary>
        /// Jaffaフレームワークにページ開始を通知します。
        /// InitializeComponentの前に実行する必要があります。
        /// </summary>
        /// <param name="win">Jaffaフレームワークを利用するページのインスタンスを指定します。</param>
        public static void Start(Windows.UI.Xaml.Controls.Page page)
        {
            // ページ生成完了通知イベント
            Creating?.Invoke(page, new EventArgs());

            // カルチャに合わせてリソースを切り替え
            if (Jaffa.Application.WaitingChangeCulture == true)
            {
                Jaffa.Application.Current.Resources = Internal.Core.MakeChangedResources(Jaffa.Application.Current.Resources, Jaffa.International.GetAvailableLanguageCodeList(), Jaffa.International.CurrentCulture);
                Jaffa.Application.WaitingChangeCulture = false;
            }
            page.Resources = Internal.Core.MakeChangedResources(page.Resources, Jaffa.International.GetAvailableLanguageCodeList(), Jaffa.International.CurrentCulture);
        }

        #endregion

        #region ページリロード (Reload)

        /// <summary>
        /// ページをリロードします。
        /// </summary>
        /// <param name="frame">フレームのインスタンス</param>
        /// <param name="page">ページのインスタンス</param>
        /// <param name="preprocess">リロードの前処理 (async)</param>
        /// <param name="postprocess">リロードの後処理 (async)</param>
        /// <returns></returns>
        public static void Reload(Windows.UI.Xaml.Controls.Frame frame, Windows.UI.Xaml.Controls.Page page, Preprocess preprocess = null, Postprocess postprocess = null)
        {
            Logging.SysLogWriteWaiting = true;

            // 前処理
            if (preprocess != null) preprocess(frame, page);

            // コンポーネント再構築
            Windows.UI.Xaml.Application.LoadComponent(page, page.BaseUri, Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);

            // 後処理
            if (postprocess != null) postprocess(frame, page);

            Logging.SysLogWriteWaiting = false;
        }

        #endregion

        #endregion

        #region ファンクション

        #region リロードの前処理 (Preprocess)

        /// <summary>
        /// リロードの前処理を行います。
        /// </summary>
        /// <param name="frame">フレームのインスタンス</param>
        /// <param name="page">ページのインスタンス</param>
        public delegate void Preprocess(Windows.UI.Xaml.Controls.Frame frame, Windows.UI.Xaml.Controls.Page page);

        #endregion

        #region リロードの後処理 (Postprocess)

        /// <summary>
        /// リロードの後処理を行います。
        /// </summary>
        /// <param name="frame">フレームのインスタンス</param>
        /// <param name="page">ページのインスタンス</param>
        public delegate void Postprocess(Windows.UI.Xaml.Controls.Frame frame, Windows.UI.Xaml.Controls.Page page);

        #endregion

        #endregion
    }
}
