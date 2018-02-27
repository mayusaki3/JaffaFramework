﻿using System;
using System.Reflection;

namespace Jaffa.Internal
{
    /// <summary>
    /// Jaffaフレームワーク・UWP版共通コアライブラリ
    /// </summary>
    public static partial class Core : Object
    {
        #region プロパティ

        #region Jaffaフレームワークのバージョンを取得 ([R} Version)

        /// <summary>
        /// Jaffaフレームワークのバージョンを取得します。
        /// </summary>
        public static System.Version Version
        {
            get
            {
                return System.Reflection.Assembly.Load(new AssemblyName("JaffaForUWP")).GetName().Version;
            }
        }

        #endregion

        #endregion
    }
}
