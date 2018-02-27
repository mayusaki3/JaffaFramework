using System;

namespace Jaffa.UI
{
    /// <summary>
    /// Jaffaフレームワーク・UWP版ページサポート
    /// </summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public static class Page : Object
    {
        #region イベント

        #region ページインスタンス生成イベント (CreatePageEvent)

        /// <summary>
        /// ページインスタンスが生成されたことを通知します。
        /// </summary>
        /// <param name="sender">生成された Windows.UI.Xaml.Controls.Page オブジェクトです。</param>
        /// <param name="e">既定のイベントデータです。</param>
        public delegate void CreatePageEventHandler(object sender, EventArgs e);
        
        /// <summary>
        /// ページインスタンスが生成されたことを通知します。
        /// </summary>
        public static event CreatePageEventHandler CreatePageEvent;

        #endregion

        #endregion

        #region メソッド

        #region ページ開始 (Start)

        /// <summary>
        /// Jaffaフレームワークにページ開始を通知します。
        /// </summary>
        /// <param name="win">Jaffaフレームワークを利用するページのインスタンスを指定します。</param>
        public static void Start(Windows.UI.Xaml.Controls.Page page)
        {
            // ページ生成通知イベント
            if (CreatePageEvent != null)
            {
                CreatePageEvent(page, new EventArgs());
            }
        }

        #endregion

        #endregion
    }
}
