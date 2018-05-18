using Jaffa.Diagnostics;
using System;
using System.ComponentModel;

namespace Jaffa.Mvvm
{
    /// <summary>
    /// Jaffaフレームワーク・Mvvmデータバインディングプロパティ用ヘルパークラス
    /// </summary>
 //   [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class BindingPropertyBase : Object, INotifyPropertyChanged
    {
        #region イベント

        #region プロパティ変更通知イベント (PropertyChanged)

        /// <summary>
        /// プロパティの値が変更されたことを通知します。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #endregion

        #region メソッド

        #endregion
    }
}
