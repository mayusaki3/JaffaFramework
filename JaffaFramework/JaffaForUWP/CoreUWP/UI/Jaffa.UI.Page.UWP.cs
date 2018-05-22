using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Jaffa.UI
{
    /// <summary>
    /// Jaffaフレームワーク・UWP版ページサポート
    /// </summary>
//    [System.Diagnostics.DebuggerNonUserCode]
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
        /// <param name="sender">生成された Windows.UI.Xaml.Controls.Page オブジェクトです。</param>
        /// <param name="e">既定のイベントデータです。</param>
        public delegate void CreatingHandler(object sender, EventArgs e);
        
        /// <summary>
        /// ページインスタンスが生成されることを通知します。
        /// </summary>
        public static event CreatingHandler Creating;

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

        public delegate Task<bool> Preprocess();
        public delegate Task<bool> Postprocess();

        /// <summary>
        /// ページをリロードします。
        /// </summary>
        /// <param name="frame">フレームのインスタンス</param>
        /// <param name="page">ページのインスタンス</param>
        public static async void Reload(Windows.UI.Xaml.Controls.Frame frame, Windows.UI.Xaml.Controls.Page page)
        {
            Reload(frame, page, null, null, null);
        }

        /// <summary>
        /// ページをリロードします。
        /// </summary>
        /// <param name="frame">フレームのインスタンス</param>
        /// <param name="page">ページのインスタンス</param>
        /// <param name="transitionPage">リロード中に表示するページ</param>
        public static async void Reload(Windows.UI.Xaml.Controls.Frame frame, Windows.UI.Xaml.Controls.Page page, Type transitionPage)
        {
            Reload(frame, page, transitionPage, null, null);
        }

        /// <summary>
        /// ページをリロードします。
        /// </summary>
        /// <param name="frame">フレームのインスタンス</param>
        /// <param name="page">ページのインスタンス</param>
        /// <param name="transitionPage">リロード中に表示するページ</param>
        /// <param name="preprocess">リロードの前処理</param>
        public static async void Reload(Windows.UI.Xaml.Controls.Frame frame, Windows.UI.Xaml.Controls.Page page, Type transitionPage, Preprocess preprocess)
        {
            Reload(frame, page, transitionPage, preprocess, null);
        }

        /// <summary>
        /// ページをリロードします。
        /// </summary>
        /// <param name="frame">フレームのインスタンス</param>
        /// <param name="page">ページのインスタンス</param>
        /// <param name="transitionPage">リロード中に表示するページ</param>
        /// <param name="postprocess">リロードの後処理</param>
        public static async void Reload(Windows.UI.Xaml.Controls.Frame frame, Windows.UI.Xaml.Controls.Page page, Type transitionPage, Postprocess postprocess)
        {
            Reload(frame, page, transitionPage, null, postprocess);
        }

        /// <summary>
        /// ページをリロードします。
        /// </summary>
        /// <param name="frame">フレームのインスタンス</param>
        /// <param name="page">ページのインスタンス</param>
        /// <param name="transitionPage">リロード中に表示するページ</param>
        /// <param name="preprocess">リロードの前処理</param>
        /// <param name="postprocess">リロードの後処理</param>
        public static async void Reload(Windows.UI.Xaml.Controls.Frame frame, Windows.UI.Xaml.Controls.Page page, Type transitionPage, Preprocess preprocess, Postprocess postprocess)
        {
            // リロード中表示
            UIElement savContent = null;
            if(transitionPage != null)
            {
                savContent = Window.Current.Content;
                Window.Current.Content = Activator.CreateInstance(transitionPage) as UIElement;
                await Task.Delay(100);
            }

            // 前処理
            if (preprocess != null) await preprocess();

            // コンポーネント再構築
            Windows.UI.Xaml.Application.LoadComponent(page, page.BaseUri, Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
            await Task.Delay(100);

            // 後処理
            if (postprocess != null) await postprocess();

            // リロード中表示を消去
            if (savContent != null)
            {
                Window.Current.Content = savContent;
                await Task.Delay(1000);
            }
        }

        #endregion

        #endregion
    }
}
