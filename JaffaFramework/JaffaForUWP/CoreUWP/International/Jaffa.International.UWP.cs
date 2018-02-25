using System;
using System.Text;

namespace Jaffa
{
    /// <summary>
    /// Jaffaフレームワーク・UWP版国際化対応サポート
    /// </summary>
    public static partial class International : Object
    {
        #region イベント
        #endregion

        #region メソッド

        #region 現在のカルチャーに対応するKey値で指定された文字列リソースを取得 (GetCurrentCultureResourceString) [Private]

        /// <summary>
        /// 現在のカルチャーに対応するKey値で指定された文字列リソースを取得します。
        /// </summary>
        /// <param name="key">Key値</param>
        static private string GetCurrentCultureResourceString(string key)
        {
            key = key.Replace("{DynamicResource ", "").Replace("}", "");
            string rt = Jaffa.Application.Resource.GetString(key);
            return rt;
        }

        #endregion

        #region 現在のカルチャーをすべてのページに反映 (ChangeCulture) [Private]

        /// <summary>
        /// 現在のカルチャーをすべてのページに反映します。ページキャッシュはクリアされます。
        /// </summary>
        static private void ChangeCulture()
        {
            // 言語設定を更新
            Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = currentCulture;

            // Coreリソース切り替えのため解放
            resLoader = null;

            if (changePageTimer == null) {
                changePageTimer = new Windows.UI.Xaml.DispatcherTimer();
                changePageTimer.Tick += ChangePageTimer_Tick;
                changePageTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            }

            // ページに反映 - 一回では再表示でカルチャーが変更されないことがあるため、時間を空けて二回実行
            ChangePages(true);
            changePageTimer.Start();
        }

        private static void ChangePageTimer_Tick(object sender, object e)
        {
            changePageTimer.Stop();
            ChangePages(false);
        }

        static private Windows.UI.Xaml.DispatcherTimer changePageTimer = null;

        /// <summary>
        /// 現在のカルチャーをすべてのページに反映します。ページキャッシュはクリアされます。
        /// </summary>
        /// <param name="raiseEvent">イベントを発生される場合はtrueを設定</param>
        static private void ChangePages(bool raiseEvent)
        {
            // キャッシュされているページを破棄
            foreach (var page in Jaffa.Application.Pages)
            {
                int csize = page.Frame.CacheSize;
                page.Frame.CacheSize = 0;
                page.Frame.CacheSize = csize;
            }

            // ナビゲーション情報を使ってページ再表示
            string snav = Jaffa.Application.Pages[0].Frame.GetNavigationState();
            Jaffa.Application.Pages[0].Frame.SetNavigationState(snav);

            if(raiseEvent)
            {
                // カルチャー変更通知イベント
                OnChangeCulture();
            }
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
#pragma warning disable 0618
                    resLoader = new Windows.ApplicationModel.Resources.ResourceLoader("JaffaForUWP/Resources");
#pragma warning restore 0618
                }
                catch (Exception es)
                {
                    return "ResourceLoader Initialize failed. " + es.Message;
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

        #region プロパティ
        #endregion
    }
}
