using System;
using System.IO;
using System.Threading.Tasks;

namespace Jaffa.Diagnostics
{
    /// <summary>
    /// Jaffaフレームワーク・デスクトップ(WPF)版ロギングサポート
    /// </summary>
    public static partial class Logging
    {
        #region メソッド

        #region 既定のログ出力先フォルダを取得 (GetDefaultFolder) [private]

        /// <summary>
        /// 既定のログ出力先フォルダを取得します。
        /// </summary>
        /// <returns>既定のフォルダ</returns>
        private static string GetDefaultFolder()
        {
            string rt = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\";
            rt = (rt + Jaffa.Application.CampanyFolderName + @"\").Replace(@"\\", @"\");
            rt = (rt + Jaffa.Application.ApplicationFolderName + @"\").Replace(@"\\", @"\");
            return rt;
        }

        #endregion

        #region ログ書き込み・ログバッファ消去 (WriteLogBufferToFileAsync) [private]

        /// <summary>
        /// ログ書き込み・ログバッファ消去
        /// </summary>
        /// <param name="log">ログデータ</param>
        /// <param name="logName1">ログファイル名</param>
        /// <param name="logName2">ログファイル名（リネーム用）</param>
#pragma warning disable 1998
        private static async Task WriteLogBufferToFileAsync(LoggingData log, string logName1, string logName2)
#pragma warning restore 1998
        {
            Uri appUri = new Uri(GetDefaultFolder());
            Uri outUri = new Uri(appUri, System.Environment.ExpandEnvironmentVariables(Settings.Folder));
            string logFolder = outUri.LocalPath;

            // フォルダー作成
            if (Directory.Exists(logFolder) == false)
            {
                Directory.CreateDirectory(logFolder);
            }

            if (Settings.LoggingMode == LoggingModes.Size)
            {
                // サイズチェック
                try
                {
                    FileInfo fi = new FileInfo(logFolder + @"\" + logName1);
                    if (fi.Length > (long)Settings.MaxFileSizeKB * 1024)
                    {
                        // サイズオーバー
                        DebugWrite("]]>!! SIZE OVER !!");
                        try
                        {
                            File.Delete(logFolder + @"\" + logName2);
                        }
                        catch (FileNotFoundException)
                        {
                            // ファイルなし
                        }
                        File.Move(logFolder + @"\" + logName1, logFolder + @"\" + logName2);
                    }
                }
                catch (FileNotFoundException)
                {
                    // ファイルなし
                }
            }
            else
            {
                // ファイル日付チェック
                try
                {
                    DateTime fd = System.IO.File.GetLastWriteTime(logFolder + @"\" + logName1);
                    TimeSpan dtdiff = fd.Subtract(log.DateTime);
                    bool fileChear = false;
                    switch (Settings.LoggingMode)
                    {
                        case LoggingModes.Day:
                        case LoggingModes.Week:
                            // ログデータ日時とログファイル更新日時差が１日越で１周したとみなす
                            if (dtdiff.Days > 1) fileChear = true;
                            break;
                        case LoggingModes.Month:
                            // ログデータ日時とログファイル更新日時差が３１日越で１周したとみなす
                            if (dtdiff.Days > 31) fileChear = true;
                            break;
                    }
                    if (fileChear)
                    {
                        DebugWrite("]]>!! FILE CLEAR !!");
                        File.Delete(logFolder + @"\" + logName1);
                    }
                }
                catch (FileNotFoundException)
                {
                    // ファイルなし
                }
            }

            using (var fs = new FileStream(logFolder + logName1, FileMode.Append))
            {
                DebugWrite("]]>", fs.Name, lastFilename);
                using (var sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                {
                    DebugWrite("]]", log);
                    foreach (var txt in log.ToStrings())
                    {
                        sw.WriteLine(txt);
                    }
                }
                lastFilename = fs.Name;
            }

            WriteQueueCount--;
        }

        #endregion

        #endregion
    }
}
