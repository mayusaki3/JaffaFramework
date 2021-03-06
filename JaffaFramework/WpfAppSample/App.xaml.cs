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
            // Jaffa: フレームワークのログも出力させます
            Jaffa.Diagnostics.Logging.Settings.FrameworkMessage = true;
            Jaffa.Diagnostics.Logging.Settings.LoggingMode = Jaffa.Diagnostics.Logging.LoggingModes.Size;
            Jaffa.Diagnostics.Logging.Settings.MaxFileSizeKB = 1;

            // Jaffa: ログはいつでも出力できます(キャッシュに入ります)
            Jaffa.Diagnostics.Logging.Write("Jaffa Framework for WPF Sample Application Start.");

            // Jaffa: フレームワーク開始 (Required)
            Jaffa.Application.Start(this, "WpfAppSample.Properties.Resources");
            Jaffa.Application.CampanyFolderName = "JaffaFramework";
            Jaffa.Application.ApplicationFolderName = "WpfAppSample";
            Jaffa.Internal.DateTime.CalcDifferenceNow(new DateTime(2020, 10, 17, 15, 30, 12));

            // Jaffa: ログはいつでも出力できます(キャッシュに入ります)
            Jaffa.Diagnostics.Logging.Write("App Initialized.");

            // Jaffa: 初期表示前にカルチャを切り替える
            Jaffa.International.ChangeCultureFromDisplayLanguageName("English");
        }
    }
}
