using System;
using System.IO;

namespace Jaffa.Diagnostics
{
    /// <summary>
    /// Jaffaフレームワーク・デスクトップ(WPF)版ロギングサポート
    /// </summary>
    public static partial class Logging
    {
        #region メソッド

        #region ログ書き込み・ログバッファ消去 (writeLogBufferToFileAsync) [private]

        /// <summary>
        /// ログ書き込み・ログバッファ消去
        /// </summary>
        /// <param name="log">ログデータ</param>
        /// <param name="logName1">ログファイル名</param>
        /// <param name="logName2">ログファイル名（リネーム用）</param>
        private static async void writeLogBufferToFileAsync(LoggingData log, string logName1, string logName2)
        {
            Uri appUri = new Uri(Application.StartupPath);
            Uri outUri = new Uri(appUri, System.Environment.ExpandEnvironmentVariables(Settings.Folder));
            string logFolder = outUri.LocalPath;
            if (Settings.LoggingMode == LoggingModes.Size)
            {
                // サイズチェック
                try
                {
            //        StorageFile cf = await logFolder.GetFileAsync(logName1);
            //        BasicProperties bprop = await cf.GetBasicPropertiesAsync();
            //        if (bprop.Size > (ulong)Settings.MaxFileSizeKB * 1024)
            //        {
            //            // サイズオーバー
            //            debugWrite("]]>!! SIZE OVER !!");
            //            try
            //            {
            //                StorageFile df = await logFolder.GetFileAsync(logName2);
            //                await df.DeleteAsync();
            //            }
            //            catch (FileNotFoundException)
            //            {
            //                // ファイルなし
            //            }
            //            await cf.RenameAsync(logName2);
            //        }
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
            //        StorageFile cf = await logFolder.GetFileAsync(logName1);
            //        BasicProperties bprop = await cf.GetBasicPropertiesAsync();
            //        TimeSpan dtdiff = bprop.DateModified.Subtract(log.DateTime);
                    bool fileChear = false;
                    switch (Settings.LoggingMode)
                    {
                        case LoggingModes.Day:
                        case LoggingModes.Week:
                            // ログデータ日時とログファイル更新日時差が１日越で１周したとみなす
            //                if (dtdiff.Days > 1) fileChear = true;
                            break;
                        case LoggingModes.Month:
                            // ログデータ日時とログファイル更新日時差が３１日越で１周したとみなす
            //                if (dtdiff.Days > 31) fileChear = true;
                            break;
                    }
                    if (fileChear)
                    {
            //           debugWrite("]]>!! FILE CLEAR !!");
            //            StorageFile df = await logFolder.GetFileAsync(logName1);
            //            await df.DeleteAsync();
                    }
                }
                catch (FileNotFoundException)
                {
                    // ファイルなし
                }
            }

            //StorageFile sf = await logFolder.CreateFileAsync(logName1, Windows.Storage.CreationCollisionOption.OpenIfExists);

            //debugWrite("]]>", sf.Path, lastFilename);
            debugWrite("]]", log);

            //lastFilename = sf.Path;
            //await FileIO.AppendLinesAsync(sf, new List<string>(log.ToStrings()));
        }

        #endregion

        #endregion
    }
}
