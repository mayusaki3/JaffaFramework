using System;
using System.Collections.Generic;
using System.Text;

namespace Jaffa.UI.Controls
{
    /// <summary>
    /// Jaffaフレームワーク・Consoleコントロール
    /// </summary>
    ///[System.Diagnostics.DebuggerNonUserCode]
    public partial class ConsoleBox
    {
        #region インナークラス

        #region インナーテキストクラス (InnerText)

        /// <summary>
        /// インナーテキストクラス
        /// </summary>
        public partial class InnerText : Object
        {
            #region コンストラクタ―/デストラクター

            /// <summary>
            /// コンストラクタ―
            /// </summary>
            public InnerText()
            { }

            /// <summary>
            /// コンストラクタ―
            /// </summary>
            /// <param name="text">保持するテキスト</param>
            public InnerText(string text)
            {
                this.text = text;
            }

            ///// <summary>
            ///// コンストラクタ―
            ///// </summary>
            ///// <param name="text">保持するテキスト</param>
            ///// <param name="lineForeColor">行の前景色</param>
            //public InnerText(string text, Color lineForeColor)
            //{
            //    this.text = text;
            //    this.lineForeColor = lineForeColor;
            //}

            ///// <summary>
            ///// XControls.XConsoleBox.InnerText クラスの新しいインスタンスを初期化します。
            ///// </summary>
            ///// <param name="text">保持するテキスト</param>
            ///// <param name="lineForeColor">行の前景色</param>
            ///// <param name="lineBackColor">行の背景色</param>
            //public InnerText(string text, Color lineForeColor, Color lineBackColor)
            //{
            //    this.text = text;
            //    this.lineForeColor = lineForeColor;
            //    this.lineBackColor = lineBackColor;
            //}

            #endregion

            //#region メソッド

            //#region ToStringメソッド

            ///// <summary>
            ///// 内容をテキストに変換します。
            ///// </summary>
            ///// <returns></returns>
            //public new string ToString()
            //{
            //    StringBuilder sb = new StringBuilder();
            //    sb.Append(text);
            //    return sb.ToString();
            //}

            //#endregion

            //#endregion

            #region プロパティ

            #region テキストを取得または設定 ([R/W] Text)

            private string text = "";

            /// <summary>
            /// テキストを取得または設定します。
            /// </summary>
            public string Text
            {
                get
                {
                    return text;
                }
                set
                {
                    text = value;
                }
            }

            #endregion

            #endregion
        }

        #endregion

        #endregion

    }
}
