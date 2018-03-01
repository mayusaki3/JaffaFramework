﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppSample
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // Jaffa: ログはいつでも出力できます(キャッシュに入ります)
            Jaffa.Diagnostics.Logging.Write("Jaffa Framework for WPF Sample Application Start.");

            // Jaffa: フレームワーク開始
            Jaffa.Application.Start(this, "WpfAppSample.Properties.Resources");

            // Jaffa: ログはいつでも出力できます(キャッシュに入ります)
            Jaffa.Diagnostics.Logging.Write("App Initialized.");
        }
    }
}
