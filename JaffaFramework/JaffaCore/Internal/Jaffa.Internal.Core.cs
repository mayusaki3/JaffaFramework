using Jaffa.Diagnostics;
using System;
using System.ComponentModel;

namespace Jaffa.Internal
{
    /// <summary>
    /// Jaffaフレームワーク・共通コアライブラリ
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static partial class Core : Object
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
            /// コンストラクタ―
            /// </summary>
            public CoreHelper()
                :base()
            { }

            /// <summary>
            /// デストラクター
            /// </summary>
            ~CoreHelper()
            {
                Dispose();
            }

            /// <summary>
            /// リソースの開放
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
                Logging.Write(MakeMessage("{JAFFA_TITLE} {JAFFA_VERSION} " + Version + " {JAFFA_START}"));
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
            Logging.Write(new string[] { MakeMessage("{JAFFA_TITLE} {JAFFA_END}"), "", ""});
            coreHelper = null;
        }

        #endregion

        #region コアライブラリ内メッセージを構築 (MakeCoreMessage)

        /// <summary>
        /// コアライブラリ内メッセージを構築します。
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
            return Jaffa.International.MakeCoreMessage(message, paramList);        }

        #endregion

        #endregion
    }
}
