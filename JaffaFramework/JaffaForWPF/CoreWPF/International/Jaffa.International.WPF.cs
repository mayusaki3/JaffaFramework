using Jaffa.Diagnostics;
using System;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows;

namespace Jaffa
{
    /// <summary>
    /// Jaffaフレームワーク・WPF版国際化対応サポート
    /// </summary>
    public partial class International : Object
    {
        #region メソッド

        #region 現在のカルチャーに対応するKey値で指定された文字列リソースを取得 (GetCurrentCultureResourceString) [Private]

        /// <summary>
        /// 現在のカルチャーに対応するKey値で指定された文字列リソースを取得します。
        /// </summary>
        /// <param name="key">Key値</param>
        static private string GetCurrentCultureResourceString(string key)
        {
            string rt = "";
            key = key.Replace("{DynamicResource ", "").Replace("}", "");
            ResourceDictionary dic = new ResourceDictionary();
            try
            {
                dic.Source = new Uri("Resources/Dictionary_" + currentCulture + ".xaml", UriKind.Relative);
                rt = dic[key] as string;
            }
            catch(Exception es)
            {
                Logging.Write(Logging.LogTypes.Error, Logging.ExceptionToList(es));
            }
            return rt;
        }

        #endregion

        #region 現在のカルチャーをすべてのウィンドウに反映 (ChangeCulture) [Private]

        /// <summary>
        /// 現在のカルチャーをすべてのウィンドウに反映します。
        /// </summary>
        static private void ChangeCulture()
        {
            // Coreリソース切り替えのため解放
            resManager = null;

            // 各ウィンドウのリソースを更新
            foreach (Window win in Jaffa.Application.Current.Windows)
            {
                win.Resources.Source = new Uri("Resources/Dictionary_" + currentCulture + ".xaml", UriKind.Relative);
            }

            // カルチャー変更通知イベント
            OnChangeCulture();
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
            if (resManager == null)
            {
                // リソースマネージャ初期化
                try
                {
                    resManager = new ResourceManager("JaffaForWPF.Resources.Resources_" + currentCulture, Assembly.GetExecutingAssembly());
                }
                catch(Exception es)
                {
                    return "ResourceManager Initialize failed. " + es.Message;
                }
            }
            string[] tl = text.Split(new char[] { '{' });
            StringBuilder rt = new StringBuilder();
            foreach (string t in tl)
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
                        rt.Append(resManager.GetString(t.Substring(0, s)));
                    }
                    catch { }
                    rt.Append(t.Substring(s + 1));
                }
            }
            return rt.ToString();
        }

        static private ResourceManager resManager = null;

        #endregion

        #endregion
    }
}
