using System;
using System.Collections.Generic;

namespace Jaffa
{
    /// <summary>
    /// Jaffaフレームワーク・ユニバーサル版アプリケーションサポート
    /// </summary>
    public static partial class Application : Object
    {
        #region イベント
        #endregion

        #region メソッド

        #region アプリケーション開始 (Start)

        /// <summary>
        /// Jaffaフレームワークにアプリケーション開始を通知します。
        /// </summary>
        public static void Start()
        {
        }

        #endregion

        #endregion

        #region プロパティ

        #region アプリケーションを参照 ([R] Current)

        /// <summary>
        /// アプリケーションを参照します。
        /// </summary>
        public static Windows.UI.Xaml.Application Current
        {
            get
            {
                return Windows.UI.Xaml.Application.Current;
            }
        }

        #endregion

        #endregion
    }
}
