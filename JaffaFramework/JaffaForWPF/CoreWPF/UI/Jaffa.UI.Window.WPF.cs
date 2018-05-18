using System;

namespace Jaffa.UI
{
    /// <summary>
    /// Jaffaフレームワーク・WWP版ウィンドウサポート
    /// </summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public static class Window : Object
    {
        #region メソッド

        #region ウィンドウ開始 (Start)

        /// <summary>
        /// Jaffaフレームワークにウィンドウ開始を通知します。
        /// </summary>
        /// <param name="win">Jaffaフレームワークを利用するウィンドウのインスタンスを指定します。</param>
        public static void Start(System.Windows.Window window)
        {
            // カルチャに合わせてリソースを切り替え
            window.Resources = Internal.Core.ChangeResources(window.Resources, Jaffa.International.GetAvailableLanguageCodeList(), Jaffa.International.CurrentCulture);
        }

        #endregion

        #endregion
    }
}
