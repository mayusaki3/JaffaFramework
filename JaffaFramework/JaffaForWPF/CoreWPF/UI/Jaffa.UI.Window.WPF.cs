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
        /// InitializeComponentの前に実行する必要があります。
        /// </summary>
        /// <param name="win">Jaffaフレームワークを利用するウィンドウのインスタンスを指定します。</param>
        public static void Start(System.Windows.Window window)
        {
            // カルチャに合わせてリソースを切り替え
            window.Resources = Internal.Core.MakeChangedResources(window.Resources, Jaffa.International.GetAvailableLanguageCodeList(), Jaffa.International.CurrentCulture);
        }

        #endregion

        #endregion
    }
}
