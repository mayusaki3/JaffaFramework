using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jaffa.Diagnostics
{
    /// <summary>
    /// Jaffaフレームワーク・ロギングサポート
    /// </summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public static partial class Logging : Object
    {
        #region インナークラス

        #region ログタイプ (LogTypes)

        /// <summary>
        /// ログタイプ
        /// </summary>
        public enum LogTypes : byte
        {
            /// <summary>
            /// 情報メッセージ
            /// </summary>
            Information,
            /// <summary>
            /// 警告メッセージ
            /// </summary>
            Warning,
            /// <summary>
            /// エラーメッセージ
            /// </summary>
            Error
        }

        #endregion

        #region ロギングモード (LoggingModes)

        /// <summary>
        /// ロギングモード
        /// </summary>
        public enum LoggingModes : byte
        {
            /// <summary>
            /// ファイルに出力しません。
            /// </summary>
            None,
            /// <summary>
            /// 指定したサイズを超えたらファイルを切り替えます。ファイル名には(1-2)が入ります。常に1が新しいファイルです。
            /// </summary>
            Size,
            /// <summary>
            /// 日単位でファイルを切り替えます。ファイル名には日(1-31)が入ります。
            /// </summary>
            Day,
            /// <summary>
            /// 週単位でファイルを切り替えます。ファイル名には週(1-7)が入ります。
            /// </summary>
            Week,
            /// <summary>
            /// 月単位でファイルを切り替えます。ファイル名には月(1-12)が入ります。
            /// </summary>
            Month
        }

        #endregion

        #region ロギングデータクラス (LoggingData) [private]

        /// <summary>
        /// ロギングデータクラス
        /// </summary>
        private class LoggingData : Object
        {
            #region コンストラクター

            /// <summary>
            /// ロギングデータを初期化します。
            /// </summary>
            /// <param name="dateTime">発生日時</param>
            /// <param name="logType">ログタイプ</param>
            /// <param name="messages">メッセージリスト</param>
            public LoggingData(DateTime dateTime, LogTypes logType, List<string> messages)
            {
                this.dateTime = dateTime;
                this.logType = logType;
                this.messages = messages;
            }

            #endregion

            #region プロパティ

            #region 発生時刻を参照 ([R] DateTime)

            private DateTime dateTime = Internal.DateTime.Now;

            /// <summary>
            /// 発生時刻を参照します。
            /// </summary>
            public DateTime DateTime
            {
                get
                {
                    return dateTime;
                }
            }

            #endregion

            #region ログタイプを参照 ([R] LogType)

            private LogTypes logType = LogTypes.Information;

            /// <summary>
            /// ログタイプを参照します。
            /// </summary>
            public LogTypes LogType
            {
                get
                {
                    return logType;
                }
            }

            #endregion

            #region ロギングメッセージリストを参照 ([R] Messages)

            private List<string> messages = new List<string>();

            /// <summary>
            /// ロギングメッセージリストを参照します。
            /// </summary>
            public string[] Messages
            {
                get
                {
                    return messages.ToArray();
                }
            }

            #endregion

            #endregion

            #region メソッド

            #region 発生日時付きメッセージ配列を参照 (ToStrings)

            /// <summary>
            /// 発生日時付きでメッセージ配列を参照します。
            /// </summary>
            /// <returns>メッセージ配列</returns>
            public string[] ToStrings()
            {
                List<string> rt = new List<string>();
                foreach (string msg in this.messages)
                {
                    rt.Add(ToString(msg));
                }
                return rt.ToArray();
            }

            #endregion

            #region メッセージ配列を参照 (ToShortStrings)

            /// <summary>
            /// メッセージ配列を参照します。
            /// </summary>
            /// <returns>メッセージ配列</returns>
            public string[] ToShortStrings()
            {
                List<string> rt = new List<string>();
                foreach (string msg in this.messages)
                {
                    rt.Add(ToShortString(msg));
                }
                return rt.ToArray();
            }

            #endregion

            #region 発生日時付きメッセージリストを参照 (ToString) [private]

            /// <summary>
            /// 発生日時付きでメッセージを参照します。
            /// </summary>
            /// <returns>メッセージ</returns>
            private string ToString(string message)
            {
                StringBuilder sb = new StringBuilder(ToShortString(message));
                sb.Insert(0, this.DateTime.ToString("yyyyMMddHHmmssfff|"));
                return sb.ToString();
            }

            #endregion

            #region タイプ付きメッセージを編集 (ToShortString) [private]

            /// <summary>
            /// メッセージを編集します。
            /// </summary>
            /// <param name="message">メッセージ</param>
            /// <returns>編集したメッセージ</returns>
            private string ToShortString(string message)
            {
                StringBuilder sb = new StringBuilder();
                switch (this.logType)
                {
                    case LogTypes.Information:
                        sb.Append("I");
                        break;
                    case LogTypes.Warning:
                        sb.Append("W");
                        break;
                    case LogTypes.Error:
                        sb.Append("E");
                        break;
                }
                sb.Append("|");
                sb.Append(message);
                return sb.ToString();
            }

            #endregion

            #endregion
        }

        #endregion

        #region ロギング設定クラス (Settings)

        /// <summary>
        /// ロギング設定クラス
        /// </summary>
        public static class Settings : Object
        {
            #region プロパティ

            #region ロギングモードを参照または設定 ([R/W] LoggingMode)

            private static LoggingModes loggingMode = LoggingModes.None;

            /// <summary>
            /// ロギングモードを参照または設定します。
            /// </summary>
            public static LoggingModes LoggingMode
            {
                get
                {
                    return loggingMode;
                }
                set
                {
                    loggingMode = value;
                }
            }

            #endregion

            #region ログ出力先フォルダを参照または設定 ([R/W] Folder)

            private static string folder = @"Logs\";

            /// <summary>
            /// ログ出力先フォルダを参照または設定します。
            /// </summary>
            public static string Folder
            {
                get
                {
                    return folder;
                }
                set
                {
                    folder = value;
                    if (folder.Length > 0)
                    {
                        if (!folder.Substring(folder.Length - 1, 1).Equals(@"\"))
                        {
                            folder = folder + @"\";
                        }
                    }
                }
            }

            #endregion

            #region ログファイル名を参照または設定 ([R/W] FileName)

            private static string fileName = "applog[@].txt";

            /// <summary>
            /// ログファイル名を参照または設定します。
            /// ファイル名の'[@]'の部分はLoggingModeに合わせて変化し、
            /// Sizeの場合は1～2, 
            /// Dayの場合は1～31, 
            /// Weekの場合は1～7,
            /// Monthの場合は1～12の値を取ります。
            /// </summary>
            public static string FileName
            {
                get
                {
                    return fileName;
                }
                set
                {
                    fileName = value;
                    fileName.Replace(@"\", "");
                    if (fileName.LastIndexOf(".") < 1)
                    {
                        fileName = fileName + ".txt";
                    }
                    if (fileName.LastIndexOf("[@]") < 1)
                    {
                        int pos = fileName.LastIndexOf(".");
                        fileName = fileName.Substring(0, pos) +
                            "[@]" +
                            fileName.Substring(pos);
                    }
                }
            }

            #endregion

            #region ログファイルサイズ上限をKByte単位で参照または設定 ([R/W] MaxFileSizeKB)

            private static int maxFileSizeKB = 2048;

            /// <summary>
            /// ログファイルサイズ上限を参照または設定します。
            /// 2～32767の範囲(単位KByte)で指定し、範囲外の場合は自動調整します。
            /// LoggingModeがSizeの場合に有効で、サイズを超えると1世代のみバックアップを作成します。
            /// </summary>
            public static int MaxFileSizeKB
            {
                get
                {
                    return maxFileSizeKB;
                }
                set
                {
                    if (value < 2)
                    {
                        maxFileSizeKB = 2;
                    }
                    else if (value > 32767)
                    {
                        maxFileSizeKB = 32767;
                    }
                    else
                    {
                        maxFileSizeKB = value;
                    }
                }
            }

            #endregion

            #region フレームワークメッセージのログ出力が有効かどうかを参照または設定 ([R/W] FrameworkMessage)

            private static bool frameworkMessage = false;

            /// <summary>
            /// フレームワークログ出力が有効かどうかを参照または設定します。
            /// </summary>
            public static bool FrameworkMessage
            {
                get
                {
                    return frameworkMessage;
                }
                set
                {
                    frameworkMessage = value;
                }
            }

            #endregion

            #endregion
        }

        #endregion

        #region ログ出力イベント引数クラス (LogWritingEventArgs)

        /// <summary>
        /// ログ出力イベント引数クラス
        /// </summary>
        public class LogWritingEventArgs : EventArgs
        {
            #region コンストラクター

            /// <summary>
            /// ログ出力イベント引数を初期化します。
            /// </summary>
            /// <param name="dateTime">発生日時</param>
            /// <param name="messages">メッセージリスト</param>
            public LogWritingEventArgs(DateTime dateTime, string[] messages)
            {
                this.dateTime = dateTime;
                this.messages = messages;
            }

            #endregion

            #region プロパティ

            #region メッセージの発生日時を参照 ([R] DateTime)

            private DateTime dateTime;

            /// <summary>
            /// メッセージの発生日時を参照します。
            /// </summary>
            public DateTime DateTime
            {
                get
                {
                    return dateTime;
                }
            }

            #endregion

            #region メッセージリストを参照 ([R] Messages)

            private string[] messages = null;

            /// <summary>
            /// メッセージリストを参照します。
            /// </summary>
            public string[] Messages
            {
                get
                {
                    return messages;
                }
            }

            #endregion

            #endregion
        }

        #endregion

        #endregion

        #region イベント

        #region ログ出力イベント (LogWriting)

        /// <summary>
        /// ログ出力の内容を通知します。
        /// </summary>
        public static event EventHandler<LogWritingEventArgs> LogWriting;
        
        #endregion

        #endregion

        #region メソッド

        #region ログメッセージ書き込み (Write)

        /// <summary>
        /// ログにメッセージを書き込みます。
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="type">ログタイプ</param>
        public static void Write(String message, LogTypes type = LogTypes.Information)
        {
            Write(new string[] { message }, type);
        }

        /// <summary>
        /// ログにメッセージを書き込みます。
        /// </summary>
        /// <param name="type">ログタイプ</param>
        /// <param name="messages">メッセージリスト</param>
        public static void Write(String[] messages, LogTypes type = LogTypes.Information)
        {
            List<string> msgs = new List<string>(messages);
            Write(msgs, type);
        }

        /// <summary>
        /// ログにメッセージを書き込みます。
        /// </summary>
        /// <param name="exp">例外</param>
        /// <param name="type">ログタイプ</param>
        public static void Write(Exception exp, LogTypes type = LogTypes.Error)
        {
            Write(ExceptionToList(exp), type);
        }

        /// <summary>
        /// ログにメッセージを書き込みます。
        /// </summary>
        /// <param name="messages">メッセージリスト</param>
        /// <param name="type">ログタイプ</param>
        public static void Write(List<string> messages, LogTypes type = LogTypes.Information)
        {
            LoggingData data = new LoggingData(Internal.DateTime.Now, type, messages);
            DebugWrite(data);
            loggingBuffer.Enqueue(data);
            WriteLogFileAsync();
        }
        private static ConcurrentQueue<LoggingData> loggingBuffer = new ConcurrentQueue<LoggingData>();

        #region DebugWrite

        [Conditional("DEBUG")]
        private static void DebugWrite(LoggingData data)
        {
            foreach (string msg in data.ToStrings())
            {
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }

        /// <summary>
        /// デバッグ用にメッセージを出力します。
        /// </summary>
        /// <param name="message">メッセージ</param>
        [Conditional("DEBUG")]
        private static void DebugWrite(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        /// <summary>
        /// デバッグ用にメッセージとデータを出力します。
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="data">データリスト</param>
        [Conditional("DEBUG")]
        private static void DebugWrite(string message, LoggingData data)
        {
            foreach (string msg in data.ToStrings())
            {
                System.Diagnostics.Debug.WriteLine(message + " " + msg);
            }
        }

        /// <summary>
        /// デバッグ用にメッセージとデータを出力します。
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="data">データリスト</param>
        [Conditional("DEBUG")]
        private static void DebugWrite(string message, ConcurrentQueue<LoggingData> data)
        {
            foreach (LoggingData log in data)
            {
                foreach (string msg in log.ToStrings())
                {
                    System.Diagnostics.Debug.WriteLine(message + " " + msg);
                }
            }
        }

        /// <summary>
        /// デバッグ用にメッセージとデータを出力します。
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="data">データリスト</param>
        [Conditional("DEBUG")]
        private static void DebugWrite(string message, List<string> data)
        {
            foreach (string msg in data)
            {
                System.Diagnostics.Debug.WriteLine(message + " " + msg);
            }
        }

        /// <summary>
        /// デバッグ用にメッセージを出力します。
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="newname">新しいファイル名</param>
        /// <param name="oldname">古いファイル名</param>
        [Conditional("DEBUG")]
        private static void DebugWrite(string message, string newname, string oldname)
        {
            if (newname.Equals(oldname)) return;
            System.Diagnostics.Debug.WriteLine(message + newname);
        }

        #endregion

        #endregion

        #region ログ16進ダンプ書き込み (WriteDump)

        /// <summary>
        /// ログにバイト配列を16進ダンプとして書き込みます。
        /// </summary>
        /// <param name="bytes">ダンプ対象のバイト配列</param>
        /// <param name="type">ログタイプ</param>
        public static void WriteDump(byte[] bytes, LogTypes type = LogTypes.Information)
        {
            uint size = (uint)bytes.Length;
            WriteDump(bytes, 0, size, type);
        }

        /// <summary>
        /// ログにバイト配列を16進ダンプとして書き込みます。
        /// </summary>
        /// <param name="bytes">ダンプ対象のバイト配列</param>
        /// <param name="start">0から始まるダンプの開始位置</param>
        /// <param name="size">出力するバイト数</param>
        /// <param name="type">ログタイプ</param>
        public static void WriteDump(byte[] bytes, uint start, uint size, LogTypes type = LogTypes.Information)
        {
            Write(BytesToHexDump(bytes, start, size), type);
        }

        #endregion

        #region バイト配列16進ダンプ変換 (BytesToHexDump)

        /// <summary>
        /// バイト配列を16進ダンプに変換します。
        /// </summary>
        /// <param name="bytes">ダンプ対象のバイト配列</param>
        /// <returns>16進ダンプ</returns>
        public static List<string> BytesToHexDump(byte[] bytes)
        {
            uint size = (uint)bytes.Length;
            return BytesToHexDump(bytes, 0, size);
        }

        /// <summary>
        /// バイト配列の指定した範囲を16進ダンプに変換します。
        /// </summary>
        /// <param name="bytes">ダンプ対象のバイト配列</param>
        /// <param name="start">0から始まるダンプの開始位置</param>
        /// <param name="size">出力するバイト数</param>
        /// <returns></returns>
        public static List<string> BytesToHexDump(byte[] bytes, uint start, uint size)
        {
            List<string> rt = new List<string>();
            StringBuilder hexArea;          // 16進表示部編集ワーク
            StringBuilder charArea;         // 文字表示部編集ワーク
            try
            {
                rt.Add(DUMP_HEADER);
                rt.Add(DUMP_LINE);
                for (uint i = start; i < start + size; i += 16)
                {
                    // 1行分編集
                    hexArea = new StringBuilder(48);
                    charArea = new StringBuilder(16);
                    for (int j = 0; j < 16; j++)
                    {
                        if (i + j < start + size)
                        {
                            // 出力範囲内
                            hexArea.Append(bytes[i + j].ToString("X2") + " ");
                            if (bytes[i + j] < 0x20 || bytes[i + j] > 0x7f)
                            {
                                charArea.Append(".");
                            }
                            else
                            {
                                charArea.Append(Convert.ToChar(bytes[i + j]));
                            }
                        }
                        else
                        {
                            // 出力範囲外
                            hexArea.Append("   ");
                            charArea.Append(" ");
                        }
                    }
                    rt.Add(i.ToString("X8") + " " + hexArea.ToString() + charArea.ToString());
                }
            }
            catch (Exception es)
            {
                try
                {
                    rt.Add(Jaffa.International.MakeCoreMessage("**{LOGGING_EXCEPTION}: ") + es.Message.Remove('\r').Split(new char[] { '\n' })[0]);
                }
                catch
                {
                }
            }

            rt.Add(DUMP_LINE);
            return rt;
        }

        private const string DUMP_HEADER = "ADDR     +0 +1 +2 +3 +4 +5 +6 +7 +8 +9 +A +B +C +D +E +F 0123456789ABCDEF";
        private const string DUMP_LINE = "-------- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- ----------------";

        #endregion

        #region 例外をログ用リストに変換 (ExceptionToList)

        /// <summary>
        /// 例外をログ用リストに変換します。
        /// </summary>
        /// <param name="exp">例外</param>
        /// <returns>ログ用リスト</returns>
        public static List<string> ExceptionToList(Exception exp)
        {
            List<string> rt = new List<string>();
            rt.Add(exp.Message);
            if (exp.StackTrace != null)
            {
                foreach (string tr in exp.StackTrace.Remove('\r').Split(new char[] { '\n' }))
                {
                    rt.Add("\t" + tr);
                }
            }
            return rt;
        }

        #endregion

        #region 非同期ログ出力 (WriteLogFileAsync) [private]

        private static async void WriteLogFileAsync()
        {
            while (logWriteWaiting == false && syslogWriteWaiting == false && !loggingBuffer.IsEmpty)
            {
                await writeisLock.WaitAsync();
                try
                {

                    LoggingData log;
                    if (loggingBuffer.TryDequeue(out log))
                    {
                        #region ログ通知

                        if (muteLoggingEvent == false)
                        {
                            try
                            {
                                // イベント通知
                                LogWriting?.Invoke(loggingBuffer, new LogWritingEventArgs(log.DateTime, log.ToShortStrings()));
                            }
                            catch
                            {
                            }
                        }

                        #endregion

                        #region ログ書き込み

                        if (Settings.LoggingMode != LoggingModes.None)
                        {
                            // ファイル名生成
                            string logName1 = "";
                            string logName2 = "";
                            switch (Settings.LoggingMode)
                            {
                                case LoggingModes.Size:
                                    logName1 = Settings.FileName.Replace("[@]", "01");
                                    logName2 = Settings.FileName.Replace("[@]", "02");
                                    break;
                                case LoggingModes.Day:
                                    logName1 = Settings.FileName.Replace("[@]", log.DateTime.ToString("dd"));
                                    break;
                                case LoggingModes.Week:
                                    logName1 = Settings.FileName.Replace("[@]", (log.DateTime.DayOfWeek + 1).ToString("00"));
                                    break;
                                case LoggingModes.Month:
                                    logName1 = Settings.FileName.Replace("[@]", log.DateTime.ToString("MM"));
                                    break;
                            }

                            // 書き込み
                            WriteQueueCount++;
                            await WriteLogBufferToFileAsync(log, logName1, logName2);
                        }

                        #endregion
                    }
                }
                catch
                {
                    // エラー・無視する
                }
                finally
                {
                    writeisLock.Release();
                }
            }
        }
        private static SemaphoreSlim writeisLock = new SemaphoreSlim(1, 1);

        #endregion

        #region キャッシュされたログの書き込みを完了 (FlushAsync)

        /// <summary>
        /// キャッシュされたログの書き込みを完了します。
        /// </summary>
        public static async Task FlushAsync()
        {
            WriteLogFileAsync();
            while (WriteQueueCount > 0)
            {
                await Task.Delay(10);
            }
        }

        #endregion

        #endregion

        #region プロパティ

        #region ログ出力中断を参照または設定 ([R/W] LogWriteWaiting)

        private static bool logWriteWaiting = true;

        /// <summary>
        /// ログ出力中断を参照または設定します。trueの場合、メモリ上にバッファリングされます。
        /// </summary>
        public static bool LogWriteWaiting
        {
            get
            {
                return logWriteWaiting;
            }
            set
            {
                logWriteWaiting = value;
                if (!logWriteWaiting)
                {
                    WriteLogFileAsync();
                }
            }
        }

        #endregion

        #region Jaffaフレームワーク内ログ出力中断を参照または設定 ([R/W] SysLogWriteWaiting)

        private static bool syslogWriteWaiting = false;

        /// <summary>
        /// ログ出力中断を参照または設定します。Jaffaフレームワーク内で使用します。
        /// </summary>
        public static bool SysLogWriteWaiting
        {
            get
            {
                return syslogWriteWaiting;
            }
            set
            {
                syslogWriteWaiting = value;
                if (!syslogWriteWaiting)
                {
                    WriteLogFileAsync();
                }
            }
        }

        #endregion

        #region ログ出力時のLoggingイベント無効化を参照または設定 ([R/W] MuteLoggingEvent)

        private static bool muteLoggingEvent = false;

        /// <summary>
        /// ログ出力時のLoggingイベント無効化を参照または設定します。
        /// </summary>
        public static bool MuteLoggingEvent
        {
            get
            {
                return muteLoggingEvent;
            }
            set
            {
                muteLoggingEvent = value;
            }
        }

        #endregion

        #region 最後にログ出力したファイル名を参照 ([R] LastFilename)

        private static string lastFilename = "";

        /// <summary>
        /// 最後にログ出力したファイル名を参照します。
        /// </summary>
        public static string LastFilename
        {
            get
            {
                return lastFilename;
            }
        }

        #endregion

        #region ログ書き込みタスクキューイング数を参照または設定 ([R/W] WriteQueueCount) [private]

        private static int writeQueueCount = 0;

        /// <summary>
        /// ログ書き込みタスクキューイング数を参照または設定します。
        /// </summary>
        private static int WriteQueueCount
        {
            get
            {
                return writeQueueCount;
            }
            set
            {
                writeQueueCount = value;
            }
        }

        #endregion

        #endregion
    }
}
