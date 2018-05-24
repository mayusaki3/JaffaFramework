using System;
using System.IO;

namespace Jaffa
{
    /// <summary>
    /// Jaffaフレームワーク・アプリケーションサポート
    /// </summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public static partial class Application : Object
    {
        #region プロパティ

        #region カンパニーフォルダー名を参照または設定 ([R/W] CampanyFolderName)

        private static string campanyFolderName = "";

        /// <summary>
        /// カンパニーフォルダー名を参照または設定します。
        /// </summary>
        public static string CampanyFolderName
        {
            get
            {
                return campanyFolderName;
            }
            set
            {
                campanyFolderName = value;
            }
        }

        #endregion

        #region アプリケーションフォルダー名を参照または設定 ([R/W] ApplicationFolderName)

        private static string applicationFolderName = "";

        /// <summary>
        /// アプリケーションフォルダー名を参照または設定します。
        /// </summary>
        public static string ApplicationFolderName
        {
            get
            {
                return applicationFolderName;
            }
            set
            {
                applicationFolderName = value;
            }
        }

        #endregion

        #endregion
    }
}
