using Jaffa.Diagnostics;
using System;

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
            Logging.Write(MakeMessage("{JAFFA_TITLE} {JAFFA_VERSION} " + " {JAFFA_START}"));
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
        }

        #endregion

        #region コアライブラリ内メッセージを構築 (MakeMessage)

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
            return Jaffa.International.MakeMessage(message, paramList);
        }

        #endregion

        #endregion

        #region プロパティ
        #endregion
    }
}
