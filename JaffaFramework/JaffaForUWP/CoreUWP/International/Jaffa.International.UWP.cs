using Jaffa.Diagnostics;
using System;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Jaffa
{
    /// <summary>
    /// Jaffaフレームワーク・UWP版国際化対応サポート
    /// </summary>
    public static partial class International : Object
    {
        #region インナークラス

        #region カルチャを切り替え時のページデータ処理要求 (PageDataProcessingRequests)

        /// <summary>
        /// カルチャを切り替え時のページデータ処理要求
        /// </summary>
        public enum PageDataProcessingRequests : byte
        {
            /// <summary>
            /// データ退避
            /// </summary>
            Save,
            /// <summary>
            /// データ復元
            /// </summary>
            Restore
        }

        #endregion

        #region カルチャを切り替え時のページデータ処理イベント引数クラス (PageDataProcessingEventArgs)

        /// <summary>
        /// カルチャを切り替え時のページデータ処理イベント引数クラス
        /// </summary>
        public class PageDataProcessingEventArgs : Object
        {
            #region コンストラクター

            /// <summary>
            /// カルチャを切り替え時のページデータ処理イベント引数を初期化します。
            /// </summary>
            /// <param name="request">カルチャを切り替え時のページデータ処理要求</param>
            public PageDataProcessingEventArgs(PageDataProcessingRequests request)
            {
                this.request = request;
            }

            #endregion

            #region プロパティ

            #region ページデータ処理要求 ([R] Request)

            private PageDataProcessingRequests request;

            /// <summary>
            /// ページデータ処理要求を参照します。
            /// </summary>
            public PageDataProcessingRequests Request
            {
                get
                {
                    return request;
                }
            }

            #endregion

            #endregion
        }

        #endregion

        #endregion

        #region イベント

        #region カルチャを切り替え時のページデータ処理通知イベント (PageDataProcessingEvent)

        public delegate void PageDataProcessingEventHandler(object sender, PageDataProcessingEventArgs e);
        /// <summary>
        /// カルチャを切り替え時のページデータの退避及び復元タイミングを通知します。
        /// </summary>
        public static event PageDataProcessingEventHandler PageDataProcessingEvent;

        #endregion

        #region カルチャを切り替え時のページデータ処理通知イベント呼び出し ([private] OnPageDataProcessing)

        /// <summary>
        /// カルチャを切り替え時のページデータ処理通知イベントを呼び出します。
        /// </summary>
        private static void OnPageDataProcessing(PageDataProcessingRequests request)
        {
            // ページデータ処理を通知
            PageDataProcessingEvent?.Invoke(Application.Pages, new PageDataProcessingEventArgs(request));
        }

        #endregion

        #endregion

        #region メソッド

        #region 現在のカルチャーに対応するKey値で指定された文字列リソースを取得 (GetCurrentCultureResourceString) [Private]

        /// <summary>
        /// 現在のカルチャーに対応するKey値で指定された文字列リソースを取得します。
        /// </summary>
        /// <param name="key">Key値</param>
        static private string GetCurrentCultureResourceString(string key)
        {
            key = key.Replace("{", "").Replace("}", "");
            string rt = "";
            try
            {
                rt = Application.Current.Resources[key] as string;
            }
            catch { }
            return rt;
        }

        #endregion

        #region 現在のカルチャーをすべてのページに反映 (ChangeCulture) [Private]

        /// <summary>
        /// 現在のカルチャーをすべてのページに反映します。ページキャッシュはクリアされます。
        /// </summary>
        static private void ChangeCulture()
        {
            // カルチャーコードリスト取得
            var codes = Jaffa.International.GetAvailableLanguageCodeList();

            // 言語設定を更新
            Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = currentCulture;

            // Coreリソース切り替えのため解放
            resLoader = null;

            bool isChanged = false;

            // アプリケーションのリソースを更新
            try
            {
                Application.Current.Resources = Jaffa.Internal.Core.ChangeResources(Application.Current.Resources, codes, currentCulture);
                isChanged = true;
            }
            catch
            { }

            // 各ページのリソースを更新
            foreach (var page in Jaffa.Application.Pages)
            {
                page.Resources = Jaffa.Internal.Core.ChangeResources(page.Resources, codes, currentCulture);
                isChanged = true;
            }

            if (isChanged)
            {
                // リソースを更新した場合はページをリロード
                Jaffa.Application.PageReload();
            }

            // カルチャー変更通知イベント
            OnCultureChanged();
        }

        #endregion

        #region 文字列内のリソース指定を現在のカルチャーで変換 (ConvertCurrentCultureResourceString) [Private]

        /// <summary>
        /// 文字列内のリソース指定を現在のカルチャーで変換します。
        /// </summary>
        /// <param name="text">テキスト</param>
        /// <remarks>
        /// テキスト内の {resource-name} を現在のカルチャーに対応するリソースから変換します。
        /// </remarks>
        static private string ConvertCurrentCultureResourceString(string text)
        {
            if (resLoader == null) {
                // リソースローダー初期化
                try
                {
//#pragma warning disable 0618
                    resLoader = new Windows.ApplicationModel.Resources.ResourceLoader("JaffaForUWP/Resources");
//#pragma warning restore 0618
                }
                catch (Exception es)
                {
                    Logging.Write(Logging.LogTypes.Error, Logging.ExceptionToList(es));
                    return text;
                }
            }
            string[] tl = text.Split(new char[] { '{' });
            StringBuilder rt = new StringBuilder();
            foreach(string t in tl)
            {
                int s = t.IndexOf('}');
                if (s < 0)
                {
                    if (rt.Length > 0) rt.Append('{');
                    rt.Append(t);
                }
                else
                {
                    try
                    {
                        rt.Append(resLoader.GetString(t.Substring(0, s)));
                    }
                    catch { }
                    
                    rt.Append(t.Substring(s+1));
                }
            }
            return rt.ToString();
        }

        static private Windows.ApplicationModel.Resources.ResourceLoader resLoader = null;

        #endregion

        #endregion
    }
}
