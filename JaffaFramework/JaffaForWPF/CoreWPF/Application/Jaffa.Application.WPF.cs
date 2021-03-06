﻿using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;

namespace Jaffa
{
    /// <summary>
    /// Jaffaフレームワーク・WPF版アプリケーションサポート
    /// </summary>
    public static partial class Application
    {
        #region インナークラス

        #region 安全で副作用がない P/Invoke メソッドクラス (SafeNativeMethods)

        [SuppressUnmanagedCodeSecurityAttribute]
        internal static class SafeNativeMethods
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern int GetUserDefaultLCID();
        }
        #endregion

        #endregion

        #region メソッド

        #region アプリケーション開始 (Start)

        /// <summary>
        /// Jaffaフレームワークにアプリケーション開始を通知します。
        /// </summary>
        /// <param name="app">Jaffaフレームワークを利用するアプリケーションのインスタンスを指定します。</param>
        /// <param name="resourceName">国際化対応に使用するリソース名を指定します。</param>
        public static void Start(System.Windows.Application app, string resourceName = "")
        {
            // アプリケーションへの参照設定
            appInst = app;

            // 起動パス記憶
            startupPath = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

            // リソースマネージャ初期化
            thisAsm = app.GetType().Assembly;
            resMan = new System.Resources.ResourceManager(resourceName, thisAsm);

            // 起動時のカルチャー名を記憶
            int cid = SafeNativeMethods.GetUserDefaultLCID();
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
