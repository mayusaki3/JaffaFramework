using Jaffa.Diagnostics;
using System;
using System.Text;

namespace Jaffa
{
    /// <summary>
    /// Jaffaフレームワーク・UWP版国際化対応サポート
    /// </summary>
    public static partial class International : Object
    {
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

            // アプリケーションのリソースを更新
            try
            {
                Application.Current.Resources = Jaffa.Internal.Core.ChangeResources(Application.Current.Resources, codes, currentCulture);
            }
            catch
            {
                // ページ開始時に更新するように設定
                Jaffa.Application.WaitingChangeCulture = true;
            }

            // 各ページのリソースを更新
            foreach (var page in Jaffa.Application.Pages)
            {
                page.Resources = Jaffa.Internal.Core.ChangeResources(page.Resources, codes, currentCulture);
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
