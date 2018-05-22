using Jaffa.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jaffa
{
    /// <summary>
    /// Jaffaフレームワーク・国際化対応サポート
    /// </summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public static partial class International
    {
        #region イベント

        #region カルチャー変更イベント (CultureChanged)

        public delegate void CultureChangedHandler(object sender, EventArgs e);
        /// <summary>
        /// CurrentCultureが変更されたことを通知します。
        /// </summary>
        public static event CultureChangedHandler CultureChanged;

        #endregion

        #region カルチャー変更イベント呼び出し ([private] OnCultureChanged)

        /// <summary>
        /// カルチャー変更通知イベントを呼び出します。
        /// </summary>
        private static void OnCultureChanged()
        {
            // カルチャー変更を通知
            CultureChanged?.Invoke(currentCulture, new EventArgs());
        }

        #endregion

        #endregion

        #region メソッド

        #region アプリケーションで利用可能な言語名リストを取得 (GetAvailableLanguageNameList)

        /// <summary>
        /// アプリケーションで利用可能な言語名リストを取得します。
        /// </summary>
        /// <remarks>
        /// アプリケーションの Resources.resw(UWP) / Resources.resx(WPF) に 文字列 Dictionarys を追加し、
        /// 次のようにサポートする{言語コード},{言語名} の行を設定します。
        /// 例. Auto,{CultureAuto}
        ///     en-US,English
        ///     ja-JP,日本語
        /// この例の「{CultureAuto}」部分は、言語コードのリソースで置き換わります。
        /// </remarks>
        public static string[] GetAvailableLanguageNameList()
        {
            string res = null;
            try
            {
                res = Jaffa.Application.Resource.GetString("Dictionarys");
            }
            catch(Exception es)
            {
                Logging.Write(Logging.LogTypes.Error, Logging.ExceptionToList(es));
            }
            if (res == null)
            {
                return new string[0];
            }
            string[] langs = res.Split(new char[] { '\n' });
            List<string> rt = new List<string>();
            foreach (string lang in langs)
            {
                string[] s = lang.Split(new char[] { ',', '\r', '\n' });
                if (s[1].IndexOf("{") >= 0)
                {
                    string key = s[1].Replace("{", "").Replace("}", "");
                    string val = GetCurrentCultureResourceString(key);
                    if (val.Length > 0) s[1] = val;
                }
                rt.Add(s[1]);
            }
            return rt.ToArray();
        }

        #endregion

        #region アプリケーションで利用可能な言語コードリストを取得 (GetAvailableLanguageCodeList)

        /// <summary>
        /// アプリケーションで利用可能な言語コードリストを取得します。
        /// </summary>
        /// <remarks>
        /// アプリケーションの Resources.resw(UWP) / Resources.resx(WPF) に 文字列 Dictionarys を追加し、
        /// 次のようにサポートする{言語コード},{言語名} の行を設定します。
        /// 例. Auto,{CultureAuto}
        ///     en-US,English
        ///     ja-JP,日本語
        /// </remarks>
        public static string[] GetAvailableLanguageCodeList()
        {
            string res = null;
            try
            {
                res = Jaffa.Application.Resource.GetString("Dictionarys");
            }
            catch (Exception es)
            {
                Logging.Write(Logging.LogTypes.Error, Logging.ExceptionToList(es));
            }
            if (res == null)
            {
                return new string[0];
            }
            string[] langs = res.Split(new char[] { '\n' });
            List<string> rt = new List<string>();
            foreach (string lang in langs)
            {
                string[] s = lang.Split(new char[] { ',', '\r', '\n' });
                if (s[0].Equals("Auto") == false)
                {
                    rt.Add(s[0]);
                }
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
                    if (s[1].IndexOf("{") >= 0)
                    {
                        string key = s[1].Replace("{", "").Replace("}", "");
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
            string rt = "";
            string res = null;
            try
            {
                res = Jaffa.Application.Resource.GetString("Dictionarys");
            }
            catch { }
            if (res == null)
            {
                rt = name;
            }
            else
            {
                string[] langs = res.Split(new char[] { '\n' });
                foreach (string lang in langs)
                {
                    string[] s = lang.Split(new char[] { ',', '\r', '\n' });
                    s[0] = s[0].Trim();
                    if (!s[0].Equals("Auto"))
                    {
                        if (rt.Equals(""))
                        {
                            rt = s[0];
                        }
                        if (s[0].Equals(name))
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

            }

            // 初回は起動時のカルチャー名として記憶
            if (startupCulture.Equals(""))
            {
                startupCulture = rt;
                currentCultureSetting = rt;
                currentCulture = rt;
            }

            return rt;
        }

        #endregion

        #region 現在のカルチャーを変更 (ChangeCultureFromDisplayLanguageName)

        /// <summary>
        /// 現在のカルチャーを言語名で変更します。UWPの場合はCultureChangedイベントでページをリロードしてください。
        /// </summary>
        /// <param name="name">表示名</param>
        public static void ChangeCultureFromDisplayLanguageName(string name)
        {
            // 表示名からカルチャー名を取得
            string res = Jaffa.Application.Resource.GetString("Dictionarys");
            if (res == null)
            {
                return;
            }
            string[] langs = res.Split(new char[] { '\n' });
            List<string> rt = new List<string>();
            foreach (string lang in langs)
            {
                string[] s = lang.Split(new char[] { ',', '\r', '\n' });
                if (s[1].IndexOf("{") >= 0)
                {
                    s[1] = GetCurrentCultureResourceString(s[1]);
                }
                if (s[1].Equals(name))
                {
                    string saveCulture = currentCulture;
                    currentCultureSetting = s[0];
                    if (s[0].Equals("Auto"))
                    {
                        currentCulture = startupCulture;
                    }
                    else
                    {
                        currentCulture = s[0];
                    }
                    if(saveCulture != currentCulture || isChangeCulture)
                    {
                        isChangeCulture = false;
                        ChangeCulture();
                        break;
                    }
                }
            }
        }
        private static bool isChangeCulture = true;

        #endregion

        #region フレームワーク内メッセージを構築 (MakeCoreMessage)

        /// <summary>
        /// フレームワーク内メッセージを構築します。
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <returns>構築したメッセージ</returns>
        /// <remarks>
        /// メッセージは、テキスト中に {resource-name} を指定できます。
        /// </remarks>
        public static string MakeCoreMessage(string message)
        {
            return MakeCoreMessage(message, new string[0]);
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
        public static string MakeCoreMessage(string message, string[] paramList)
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

        #region 起動時のカルチャー名を取得 ([R] startupCulture) [Private]

        private static string startupCulture = "";

        #endregion

        #region 現在の設定カルチャー名を取得 ([R] CurrentCultureSetting)

        private static string currentCultureSetting = "";

        /// <summary>
        /// 現在の設定カルチャー名を取得します。CurrentCultureプロパティとの違いは "Auto" の有無です。
        /// </summary>
        public static string CurrentCultureSetting
        {
            get
            {
                return currentCultureSetting;
            }
        }

        #endregion

        #region 現在のカルチャー名を取得 ([R] CurrentCulture)

        private static string currentCulture = "";

        /// <summary>
        /// 現在のカルチャー名を取得します。
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
