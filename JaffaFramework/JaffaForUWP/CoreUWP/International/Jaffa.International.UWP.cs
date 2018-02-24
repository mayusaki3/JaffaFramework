using System;
using System.Text;

namespace Jaffa
{
    /// <summary>
    /// Jaffaフレームワーク・ユニバーサル版国際化対応サポート
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
                    resLoader = new Windows.ApplicationModel.Resources.ResourceLoader("CoreUWP/Resources");
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
