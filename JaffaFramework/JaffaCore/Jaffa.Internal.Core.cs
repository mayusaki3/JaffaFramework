using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Jaffa.Internal
{
    /// <summary>
    /// Jaffaフレームワーク・共通コアライブラリ
    /// </summary>
    ///[EditorBrowsable(EditorBrowsableState.Never)]
    public static class Core : Object
    {
        #region インナークラス

        #region コアライブラリ用ヘルパークラス (CoreHelper) [private]

        /// <summary>
        /// コアライブラリ用ヘルパークラス
        /// </summary>
        private class CoreHelper : object, IDisposable
        {
            #region コンストラクタ―/デストラクター

            /// <summary>
            /// 
            /// </summary>
            public CoreHelper()
                :base()
            {
            }

            /// <summary>
            /// 
            /// </summary>
            ~CoreHelper()
            {
                Dispose();
            }

            /// <summary>
            /// 
            /// </summary>
            public void Dispose()
            {
                // コア後処理
                Jaffa.Internal.Core.Terminate();
            }

            #endregion
        }

        #endregion

        #endregion

        #region メソッド

        #region コアライブラリ初期化 (Initialize)

        /// <summary>
        /// コアライブラリを初期化を行います。
        /// </summary>
        public static void Initialize()
        {
            if (coreHelper == null)
            {
                coreHelper = new CoreHelper();
            }
        }

        private static CoreHelper coreHelper = null;

        #endregion

        #region コアライブラリ後処理 (Terminate) [private]

        /// <summary>
        /// コアライブラリの後処理を行います。
        /// </summary>
        private static void Terminate()
        {
        }

        #endregion

        #endregion

        #region プロパティ
        #endregion
    }
}
