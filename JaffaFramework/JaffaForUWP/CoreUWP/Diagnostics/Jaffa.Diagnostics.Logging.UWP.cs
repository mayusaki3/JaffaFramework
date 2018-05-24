using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;

namespace Jaffa.Diagnostics
{
    /// <summary>
    /// Jaffaフレームワーク・ユニバーサル版ロギングサポート
    /// </summary>
    public static partial class Logging
    {
        #region メソッド 

        #region ログ書き込み・ログバッファ消去 (WriteLogBufferToFileAsync) [private]

        /// <summary>
        /// ログ書き込み・ログバッファ消去
        /// </summary>
        /// <param name="log">ログデータ</param>
        /// <param name="logName1">ログファイル名</param>
        /// <param name="logName2">ログファイル名（リネーム用）</param>
        private static async Task WriteLogBufferToFileAsync(LoggingData log, string logName1, string logName2)
        {
            StorageFolder logFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(Settings.Folder, CreationCollisionOption.OpenIfExists);
            if (Settings.LoggingMode == LoggingModes.Size)
            {
                // サイズチェック
                try
                {
                    StorageFile cf = await logFolder.GetFileAsync(logName1);
                    BasicProperties bprop = await cf.GetBasicPropertiesAsync();
                    if (bprop.Size > (ulong)Settings.MaxFileSizeKB * 1024)
                    {
                        // サイズオーバー
                        DebugWrite("]]>!! SIZE OVER !!");
                        try
                        {
                            StorageFile df = await logFolder.GetFileAsync(logName2);
                            await df.DeleteAsync();
                        }
                        catch (FileNotFoundException)
                        {
                            // ファイルなし
                        }
                        await cf.RenameAsync(logName2);
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
                    StorageFile cf = await logFolder.GetFileAsync(logName1);
                    BasicProperties bprop = await cf.GetBasicPropertiesAsync();
                    TimeSpan dtdiff = bprop.DateModified.Subtract(log.DateTime);
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
                        StorageFile df = await logFolder.GetFileAsync(logName1);
                        await df.DeleteAsync();
                    }
                }
                catch (FileNotFoundException)
                {
                    // ファイルなし
                }
            }

            var sf = await logFolder.CreateFileAsync(logName1, Windows.Storage.CreationCollisionOption.OpenIfExists);

            DebugWrite("]]>", sf.Path, lastFilename);
            DebugWrite("]]", log);

            lastFilename = sf.Path;
            await FileIO.AppendLinesAsync(sf, new List<string>(log.ToStrings()));

            WriteQueueCount--;
        }

        #endregion

        #endregion
    }
}
