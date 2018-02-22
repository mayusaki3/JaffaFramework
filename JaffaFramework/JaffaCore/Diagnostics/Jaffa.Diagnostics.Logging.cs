using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Jaffa.Diagnostics
{
    /// <summary>
    /// Jaffaフレームワーク・ロギングサポート
    /// </summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public static partial class Logging : Object
    {
        #region インナークラス

        #region コアライブラリ用ヘルパークラス (CoreLogginfHelper)

        /// <summary>
        /// コアライブラリ用ロギングヘルパークラス
        /// </summary>
        private class CoreLogginfHelper : object , IDisposable
        {
            #region コンストラクター

            public CoreLogginfHelper()
            {
            }

            ~CoreLogginfHelper()
            {
                Dispose();
            }

            public void Dispose()
            {
            }

            #endregion

            #region イベント

            #endregion
        }

        #endregion

        #endregion

        #region イベント
        #endregion

        #region メソッド

        #region 初期化 (Initialize)

        /// <summary>
        /// ロギングサポートを初期化します。
        /// </summary>
        public static void Initialize()
        {
            if (coreHelper == null)
            {
                coreHelper = new CoreLogginfHelper();
            }
        }

        private static CoreLogginfHelper coreHelper = null;

        #endregion

        #endregion

        #region プロパティ
        #endregion
    }
}
