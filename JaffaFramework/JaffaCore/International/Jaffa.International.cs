using System;
using System.Collections.Generic;
using System.Text;

namespace Jaffa
{
    /// <summary>
    /// Jaffaフレームワーク・国際化対応サポート
    /// </summary>
    //[System.Diagnostics.DebuggerNonUserCode]
    public static partial class International
    {
        #region イベント

        #region カルチャー変更通知イベント (ChangeCultureEvent)


        #endregion

        #region カルチャー変更通知イベント呼び出し ([private] OnChangeCulture)


        #endregion

        #endregion

        #region メソッド

        #region 利用可能な言語リストを取得 (GetAvailableLanguageList)

        /// <summary>
        /// 利用可能な言語リストを取得します。
        /// </summary>
        public static string[] GetAvailableLanguageList()
        {
            string res = null;
            try
            {
                res = Jaffa.Application.Resource.GetString("Dictionarys");
            }
            catch { }
            if (res == null)
            {
                return new string[0];
            }
            string[] langs = res.Split(new char[] { '\n' });
            List<string> rt = new List<string>();
            foreach (string lang in langs)
            {
                string[] s = lang.Split(new char[] { ',', '\r', '\n' });
                if (s[1].IndexOf("{DynamicResource") >= 0)
                {
                    string key = s[1].Replace("{DynamicResource ", "").Replace("}", "");
                    s[1] = GetCurrentCultureResourceString(key);
                }
                rt.Add(s[1]);
            }
            return rt.ToArray();
        }

        #endregion

        #region カルチャー名に対応する表示名を取得 (GetDisplayLanguageName)

        /// <summary>
        /// カルチャー名に対応する表示名を取得します。
        /// </summary>
        /// <param name="culture">カルチャー名</param>
        /// <returns>表示名</returns>
        public static string GetDisplayLanguageName(string culture)
        {
            string res = null;
            try
            {
                res = Jaffa.Application.Resource.GetString("Dictionarys");
            }
            catch { }
            if (res == null)
            {
                return culture;
            }
            string[] langs = res.Split(new char[] { '\n' });
            string rt = culture;
            foreach (string lang in langs)
            {
                string[] s = lang.Split(new char[] { ',', '\r', '\n' });
                if(s[0].Equals(culture))
                {
                    if (s[1].IndexOf("{DynamicResource") >= 0)
                    {
                        string key = s[1].Replace("{DynamicResource ", "").Replace("}", "");
                        s[1] = GetCurrentCultureResourceString(key);
                    }
                    rt = s[1];
                }
            }
            return rt;
        }

        #endregion

        #region リソースとマッチするカルチャー名を取得 (GetResourceCultureName)

        /// <summary>
        /// リソース上のDictionaryに設定された内容からカルチャー名を検索し、最もマッチするカルチャー名を取得します。
        /// </summary>
        /// <param name="name">マッチングするカルチャー名</param>
        /// <returns>リソース上のカルチャー名</returns>
        public static string GetResourceCultureName(string name)
        {
            string res = null;
            try
            {
                res = Jaffa.Application.Resource.GetString("Dictionarys");
            }
            catch { }
            if (res == null)
            {
                return "";
            }
            string[] langs = res.Split(new char[] { '\n' });
            string rt = "";
            foreach (string lang in langs)
            {
                string[] s = lang.Split(new char[] { ',', '\r', '\n' });
                if (!s[0].Equals("Auto"))
                {
                    if(rt.Equals(""))
                    {
                        rt = s[0];
                    }
                    if(s[0].Equals(name))
                    {
                        // 完全一致
                        rt = name;
                        break;
                    }
                    if (s[0].IndexOf(name + "-") == 0)
                    {
                        // 前方一致
                        rt = s[0];
                    }
                }
            }

            // 初回は起動時のカルチャー名として記憶
            if(startupCulture.Equals(""))
            {
                startupCulture = rt;
                currentCultureSetting = rt;
                currentCulture = rt;
            }

            return rt;
        }

        #endregion

        #region 現在のカルチャーを変更 (ChangeCultureFromDisplayLanguageName)


        #endregion

        #region フレームワーク内メッセージを構築 (MakeMessage)

        /// <summary>
        /// フレームワーク内メッセージを構築します。
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="paramList">メッセージに埋め込むパラメータのリスト</param>
        /// <returns>構築したメッセージ</returns>
        /// <remarks>
        /// メッセージは、テキスト中に {resource-name} と %paramList-index を指定できます。
        /// パラメータは、テキスト中に {resource-name} を指定できます。
        /// メッセージとパラメータは、それぞれリソースを参照してから、１つに編集します。
        /// </remarks>
        public static string MakeMessage(string message)
        {
            return MakeMessage(message, new string[0]);
        }

        /// <summary>
        /// フレームワーク内メッセージを構築します。
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="paramList">メッセージに埋め込むパラメータのリスト</param>
        /// <returns>構築したメッセージ</returns>
        /// <remarks>
        /// メッセージは、テキスト中に {resource-name} と %paramList-index を指定できます。
        /// パラメータは、テキスト中に {resource-name} を指定できます。
        /// メッセージとパラメータは、それぞれリソースを参照してから、１つに編集します。
        /// </remarks>
        public static string MakeMessage(string message, string[] paramList)
        {
            StringBuilder rt = new StringBuilder(ConvertCurrentCultureResourceString(message));
            for(int i = 0; i < paramList.Length; i++)
            {
                rt.Replace("%" + i.ToString(), ConvertCurrentCultureResourceString(paramList[i]));
            }
            return rt.ToString();
        }

        #endregion

        #endregion

        #region プロパティ

        #region 起動時のカルチャー名を参照 ([R] startupCulture) [Private]

        private static string startupCulture = "";

        #endregion

        #region 現在の設定カルチャー名を参照 ([R] CurrentCultureSetting)

        private static string currentCultureSetting = "";

        /// <summary>
        /// 現在の設定カルチャー名を参照します。CurrentCultureプロパティとの違いは "Auto" の有無です。
        /// </summary>
        public static string CurrentCultureSetting
        {
            get
            {
                return currentCultureSetting;
            }
        }

        #endregion

        #region 現在のカルチャー名を参照 ([R] CurrentCulture)

        private static string currentCulture = "";

        /// <summary>
        /// 現在のカルチャー名を参照します。
        /// </summary>
        public static string CurrentCulture
        {
            get
            {
                return currentCulture;
            }
        }

        #endregion

        #endregion
    }
}
