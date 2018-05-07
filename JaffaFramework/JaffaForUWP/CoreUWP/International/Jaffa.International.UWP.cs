﻿using Jaffa.Diagnostics;
using System;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
            key = key.Replace("{DynamicResource ", "").Replace("{StaticResource ", "").Replace("}", "");
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
            // 言語設定を更新
            Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = currentCulture;

            // Coreリソース切り替えのため解放
            resLoader = null;

            // アプリケーションのリソースを更新
            Application.Current.Resources.Source = new Uri("ms-appx:///Resources/Dictionary_" + currentCulture + ".xaml");

            // 各ページのリソースを更新
            foreach (Page page in Jaffa.Application.Pages)
            {
                page.Resources.Source = new Uri("ms-appx:///Resources/Dictionary_" + currentCulture + ".xaml");
            }

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
            Page curpage = null;
            foreach (var page in Jaffa.Application.Pages)
            {
                Logging.Write("page: " + page.Name);

                if (page.Frame != null)
                {
                    // Navigation使用時
                    int csize = page.Frame.CacheSize;
                    page.Frame.CacheSize = 0;
                    page.Frame.CacheSize = csize;
                    curpage = page;
                }
                else
                {
                }
            }

            // ナビゲーション情報を使ってページ再表示
            if (curpage != null)
            {
                // Navigation使用時
                string snav = curpage.Frame.GetNavigationState();
                curpage.Frame.SetNavigationState(snav);

                if (raiseEvent)
                {
                    // カルチャー変更通知イベント
                    OnChangeCulture();
                }
            }
            else
            {
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
