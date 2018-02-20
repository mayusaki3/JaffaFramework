using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows;

namespace Jaffa
{
    /// <summary>
    /// Jaffaフレームワーク・WPF版アプリケーションサポート
    /// </summary>
    public static partial class Application : Object
    {
        #region イベント
        #endregion

        #region メソッド

        #region アプリケーション開始 (Start)

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int GetUserDefaultLCID();

        /// <summary>
        /// Jaffaフレームワークにアプリケーション開始を通知します。
        /// </summary>
        /// <param name="app">Jaffaフレームワークを利用するアプリケーションのインスタンス</param>
        /// <param name="resourceName">国際化対応に使用するリソース名または空文字</param>
        public static void Start(System.Windows.Application app, string resourceName)
        {
            // アプリケーションへの参照設定
            appInst = app;

            // 起動パス記憶
            startupPath = System.IO.Path.GetFullPath(Environment.GetCommandLineArgs()[0]);
        }

        #endregion

        #endregion

        #region プロパティ

        #region アプリケーションを参照 ([R] Current)

        static private System.Windows.Application appInst = null;

        /// <summary>
        /// アプリケーションを参照します。
        /// </summary>
        public static System.Windows.Application Current
        {
            get
            {
                return appInst;
            }
        }

        #endregion

        #region アプリケーション起動パスを参照 ([R] StartupPath)

        static private string startupPath = null;

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
