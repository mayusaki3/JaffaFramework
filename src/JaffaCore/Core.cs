using Jaffa.Diagnostics;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;

namespace Jaffa
{
    /// <summary>
    /// Jaffaフレームワーク・コア
    /// </summary>
    public static class Core
    {
        #region 定数

        /// <summary>
        /// Jaffaリソース領域名
        /// </summary>
        public const string Jaffa = "Jaffa";

        /// <summary>
        /// Jaffaカルチャーリソース領域名
        /// </summary>
        public const string JaffaCulture = "JaffaCulture";

        #endregion

        #region イベント

        #region カルチャー変更イベント (International_CultureChanged)

        /// <summary>
        /// カルチャー変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void International_CultureChanged(object sender, System.EventArgs e)
        {
            // リソースマネージャーの切り替え
            Assembly thisAsm = Assembly.GetExecutingAssembly();
            SetResource(Jaffa, "Jaffa.Resources." + International.CurrentCulture + ".Resource", thisAsm);
        }

        #endregion

        #endregion

        #region メソッド

        #region 初期化 (Initialize)

        /// <summary>
        /// コアを初期化します。
        /// </summary>
        public static void Initialize()
        {
            // 起動ログ
            if (isInitialize == false)
            {
                // 起動パス記憶
                startupPath = Process.GetCurrentProcess().MainModule.FileName;

                // Jaffaリソースマネージャ初期化１
                Assembly thisAsm = Assembly.GetExecutingAssembly();
                SetResource(JaffaCulture,"Jaffa.Resources.CultureList", thisAsm);

                // 国際化対応の初期化
                International.Initialize();

                // Jaffaリソースマネージャ初期化２
                SetResource(Jaffa, "Jaffa.Resources." + International.CurrentCulture + ".Resource", thisAsm);

                if (LoggingSettings.FrameworkMessage)
                {
                    Logging.Write(MakeMessage(Jaffa, "JFW00001 {JAFFA_TITLE} {JAFFA_START} [ {JAFFA_VERSION} " + Version + " ]"));
                }

                // カルチャー変更イベント設定
                International.CultureChanged += International_CultureChanged;

                isInitialize = true;
            }
        }
        private static bool isInitialize = false;

        #endregion

        #region 終了 (Terminate)

        /// <summary>
        /// コアを終了します。
        /// </summary>
        public static void Terminate()
        {
            if (isInitialize == true)
            {
                // カルチャー変更イベント解除
                International.CultureChanged -= International_CultureChanged;

                if (LoggingSettings.FrameworkMessage)
                {
                    Logging.Write(MakeMessage("Jaffa", "JFW00002 {JAFFA_TITLE} {JAFFA_END}"));
                    Logging.Write("");
                }

                // ログ出力待ち（3秒変化なしで打ち切り）
                int remain = Logging.WriteQueueCount;
                int unchange = 0;
                while (Logging.WriteQueueCount > 0)
                {
                    Thread.Sleep(100);
                    if (remain == Logging.WriteQueueCount)
                    {
                        unchange++;
                        if (unchange > 30) break;
                    }
                    else
                    {
                        remain = Logging.WriteQueueCount;
                        unchange = 0;
                    }
                }
                isInitialize = false;
            }
        }

        #endregion

        #region リソースマネージャを追加 (AddResource)

        /// <summary>
        /// リソースマネージャを追加します。
        /// </summary>
        /// <param name="name">リソース名</param>
        /// <param name="resourcePath">リソースパス名</param>
        /// <param name="assembly">リソースが格納されたアセンブリ</param>
        public static void SetResource(string name, string resourcePath, Assembly assembly)
        {
            Assembly thisAsm = Assembly.GetExecutingAssembly();
            if (resManLst.Contains(name) == true)
            {
                resManLst[name] = new ResourceManager(resourcePath.Replace('-', '_'), assembly);
            }
            else
            {
                resManLst.Add(name, new ResourceManager(resourcePath.Replace('-', '_'), assembly));
            }
        }

        #endregion

        #region リソースマネージャを参照 (Resource)

        /// <summary>
        /// リソースマネージャを参照します。
        /// </summary>
        /// <param name="name">リソース名</param>
        /// <returns>リソースマネージャ</returns>
        public static ResourceManager Resource(string name)
        {
            return resManLst[name] as ResourceManager;
        }
        private static readonly Hashtable resManLst = new();

        #endregion

        #region メッセージ構築 (MakeMessage)

        /// <summary>
        /// メッセージを構築します。
        /// </summary>
        /// <param name="name">リソース名</param>
        /// <param name="message">メッセージ</param>
        /// <param name="paramList">メッセージに埋め込むパラメータのリスト</param>
        /// <returns>構築したメッセージ</returns>
        /// <remarks>
        /// メッセージは、テキスト中に {resource-name} と %paramList-index を指定できます。
        /// パラメータは、テキスト中に {resource-name} を指定できます。
        /// メッセージとパラメータは、それぞれリソースを参照してから、１つに編集します。
        /// </remarks>
        public static string MakeMessage(string name, string message, string[] paramList = null)
        {
            StringBuilder rt = new(International.ConvertCurrentCultureResourceString(name, message));
            if (paramList != null)
            {
                for (int i = 0; i < paramList.Length; i++)
                {
                    rt.Replace("%" + i.ToString(), International.ConvertCurrentCultureResourceString(name, paramList[i]));
                }
            }
            return rt.ToString();
        }

        #endregion

        #endregion

        #region プロパティ

        #region 起動パスを参照 ([R] StartupPath)

        /// <summary>
        /// 起動パスを参照します。
        /// </summary>
        public static string StartupPath
        {
            get
            {
                return startupPath;
            }
        }
        private static string startupPath = null;

        #endregion

        #region Jaffaバージョンを参照 ([R] Version)

        /// <summary>
        /// Jaffaバージョンを参照します。
        /// </summary>
        public static string Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        #endregion

        #endregion
    }
}
