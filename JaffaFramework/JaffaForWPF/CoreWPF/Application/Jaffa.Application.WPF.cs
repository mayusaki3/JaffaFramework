using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Jaffa
{
    /// <summary>
    /// Jaffaフレームワーク・WPF版アプリケーションサポート
    /// </summary>
    public static partial class Application : Object
    {
        #region メソッド

        #region アプリケーション開始 (Start)

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int GetUserDefaultLCID();

        /// <summary>
        /// Jaffaフレームワークにアプリケーション開始を通知します。
        /// </summary>
        /// <param name="app">Jaffaフレームワークを利用するアプリケーションのインスタンスを指定します。</param>
        public static void Start(System.Windows.Application app)
        {
            Start(app, "");
        }

        /// <summary>
        /// Jaffaフレームワークにアプリケーション開始を通知します。
        /// </summary>
        /// <param name="app">Jaffaフレームワークを利用するアプリケーションのインスタンスを指定します。</param>
        /// <param name="resourceName">国際化対応に使用するリソース名を指定します。</param>
        public static void Start(System.Windows.Application app, string resourceName)
        {
            // アプリケーションへの参照設定
            appInst = app;

            // 起動パス記憶
            startupPath = System.IO.Path.GetFullPath(Environment.GetCommandLineArgs()[0]);

            // リソースマネージャ初期化
            thisAsm = app.GetType().Assembly;
            resMan = new System.Resources.ResourceManager(resourceName, thisAsm);

            // 起動時のカルチャー名を記憶
            int cid = GetUserDefaultLCID();
            CultureInfo ci = new CultureInfo(cid);
            Jaffa.International.GetResourceCultureName(ci.Name);

            // コアライブラリ初期化
            Jaffa.Internal.Core.Initialize();
        }

        #endregion

        #endregion

        #region プロパティ

        #region アプリケーションインスタンスを参照 ([R] Current)

        private static System.Windows.Application appInst = null;

        /// <summary>
        /// アプリケーションインスタンスを参照します。
        /// </summary>
        public static System.Windows.Application Current
        {
            get
            {
                return appInst;
            }
        }

        #endregion

        #region リソースマネージャを参照 ([R] Resource)

        private static System.Reflection.Assembly thisAsm = null;
        private static System.Resources.ResourceManager resMan = null;

        /// <summary>
        /// リソースマネージャを参照します。
        /// </summary>
        public static System.Resources.ResourceManager Resource
        {
            get
            {
                return resMan;
            }
        }

        #endregion

        #region アプリケーション起動パスを参照 ([R] StartupPath)

        private static string startupPath = null;

        /// <summary>
        /// アプリケーションの起動パスを参照します。
        /// </summary>
        public static string StartupPath
        {
            get
            {
                return startupPath;
            }
        }

        #endregion

        #endregion
    }
}
