using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Jaffa.UI.Controls
{
    /// <summary>
    /// Jaffaフレームワーク・WPF版Consoleコントロール
    /// </summary>
    ///[System.Diagnostics.DebuggerNonUserCode]
    public partial class ConsoleBox : System.Windows.Controls.Control
    {
        #region インナークラス

        #region インナーテキストクラス (InnerText)

        /// <summary>
        /// インナーテキストクラス
        /// </summary>
        public partial class InnerText : Object
        {
            #region コンストラクタ―/デストラクター

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

            #region LineBackColorプロパティ

            private SolidColorBrush lineBackColor = SystemColors.ControlBrush;
            /// <summary>
            /// 行のデフォルト背景色を取得または設定します。
            /// </summary>
            public SolidColorBrush LineBackColor
            {
                get
                {
                    return lineBackColor;
                }
                set
                {
                    lineBackColor = value;
                }
            }

            #endregion

            #region LineForeColorプロパティ

            private SolidColorBrush lineForeColor = SystemColors.ControlTextBrush;
            /// <summary>
            /// 行のデフォルト前景色を取得または設定します。
            /// </summary>
            public SolidColorBrush LineForeColor
            {
                get
                {
                    return lineForeColor;
                }
                set
                {
                    lineForeColor = value;
                }
            }

            #endregion


            #endregion
        }

        #endregion

        #endregion
    }
}