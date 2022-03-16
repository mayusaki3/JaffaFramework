using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JaffaCoreTest
{
    [TestClass]
    public class UnitTest_Diagnostics_Logging
    {
        private bool setEvent = false;

        private void Logging_LogWriting(object? sender, Jaffa.Diagnostics.LogWritingEventArgs e)
        {


        }

        // 既定値テスト

        [TestMethod]
        public void TestMethod01()
        {
            // 設定初期値
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.LoggingMode, Jaffa.Diagnostics.LoggingMode.None);
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.Folder, @"Logs\");
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.FileName, "syslog[@].txt");
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.MaxFileSizeKB, 2048);
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.FrameworkMessage, false);
        }

        [TestMethod]
        public void TestMethod02()
        {
            // イベントデータ初期値
            System.DateTime dt = new System.DateTime(2022, 01, 02, 03, 04, 05, 06);
            string[] msgs = new string[] { "Logging Message.", "ログに出力するメッセージ。", "%1, %2, {abc} など変換はしない。" };
            Jaffa.Diagnostics.LogWritingEventArgs args = new Jaffa.Diagnostics.LogWritingEventArgs(dt,msgs);
            Assert.AreEqual(args.DateTime, dt);
            Assert.AreEqual(args.Messages, msgs);
        }

        // プロパティ設定テスト

        [TestMethod]
        public void TestMethod11()
        {
            // LoggingMode
            Jaffa.Diagnostics.LoggingSettings.LoggingMode = Jaffa.Diagnostics.LoggingMode.Week;
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.LoggingMode, Jaffa.Diagnostics.LoggingMode.Week);
            Jaffa.Diagnostics.LoggingSettings.LoggingMode = Jaffa.Diagnostics.LoggingMode.Day;
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.LoggingMode, Jaffa.Diagnostics.LoggingMode.Day);
            Jaffa.Diagnostics.LoggingSettings.LoggingMode = Jaffa.Diagnostics.LoggingMode.Month;
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.LoggingMode, Jaffa.Diagnostics.LoggingMode.Month);
            Jaffa.Diagnostics.LoggingSettings.LoggingMode = Jaffa.Diagnostics.LoggingMode.Size;
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.LoggingMode, Jaffa.Diagnostics.LoggingMode.Size);
            Jaffa.Diagnostics.LoggingSettings.LoggingMode = Jaffa.Diagnostics.LoggingMode.None;
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.LoggingMode, Jaffa.Diagnostics.LoggingMode.None);

            // Folder
            Jaffa.Diagnostics.LoggingSettings.Folder = @"aaa";
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.Folder, @"aaa\");
            Jaffa.Diagnostics.LoggingSettings.Folder = @"bbb\\";
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.Folder, @"aaa\");
            Jaffa.Diagnostics.LoggingSettings.Folder = @"\";
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.Folder, @"aaa\");
            Jaffa.Diagnostics.LoggingSettings.Folder = @"\\";
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.Folder, @"aaa\");
            Jaffa.Diagnostics.LoggingSettings.Folder = @"\\\";
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.Folder, @"aaa\");
            Jaffa.Diagnostics.LoggingSettings.Folder = @"b\\\";
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.Folder, @"aaa\");
            Jaffa.Diagnostics.LoggingSettings.Folder = @"b\\";
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.Folder, @"aaa\");
            Jaffa.Diagnostics.LoggingSettings.Folder = @"b";
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.Folder, @"b\");
            Jaffa.Diagnostics.LoggingSettings.Folder = @"c\";
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.Folder, @"c\");
            Jaffa.Diagnostics.LoggingSettings.Folder = "";
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.Folder, "");

            // FileName
            Jaffa.Diagnostics.LoggingSettings.FileName = "";
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.FileName, "[@].txt");
            Jaffa.Diagnostics.LoggingSettings.FileName = "a.log";
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.FileName, "a[@].log");
            Jaffa.Diagnostics.LoggingSettings.FileName = "a[[@]].log";
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.FileName, "a[[@]].log");

            // MaxFileSizeKB
            Jaffa.Diagnostics.LoggingSettings.MaxFileSizeKB = 1;
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.MaxFileSizeKB, 2);
            Jaffa.Diagnostics.LoggingSettings.MaxFileSizeKB = 2;
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.MaxFileSizeKB, 2);
            Jaffa.Diagnostics.LoggingSettings.MaxFileSizeKB = 32767;
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.MaxFileSizeKB, 32767);
            Jaffa.Diagnostics.LoggingSettings.MaxFileSizeKB = 32768;
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.MaxFileSizeKB, 32767);

            // FrameworkMessage
            Jaffa.Diagnostics.LoggingSettings.FrameworkMessage = true;
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.FrameworkMessage, true);
            Jaffa.Diagnostics.LoggingSettings.FrameworkMessage = false;
            Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.FrameworkMessage, false);
        }

        // イベントテスト

        [TestMethod]
        public void TestMethod12()
        {

            if (setEvent == false)
            {
                setEvent = true;
                Jaffa.Diagnostics.Logging.LogWriting += Logging_LogWriting;
            }
            //chgCount = 0;


            //    Jaffa.DateTime.CalcDifferenceNow(System.DateTime.Now.AddHours(-2));
            //    Assert.AreEqual(Jaffa.DateTime.DifferenceNow.Add(new System.TimeSpan(0, 0, 0, 0, 500)).ToString(@"dddd\.hh\:mm\:ss"),
            //                                                     new System.TimeSpan(0, -2, 0, 0, 500).ToString(@"dddd\.hh\:mm\:ss"));
            //    Assert.AreEqual(Jaffa.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), System.DateTime.Now.AddHours(-2).ToString("yyyy-MM-dd HH:mm:ss"));
        }


        //[TestMethod]
        //public void TestMethod13()
        //{
        //    Jaffa.DateTime.CalcDifferenceNow(System.DateTime.Now.AddMinutes(37));
        //    Assert.AreEqual(Jaffa.DateTime.DifferenceNow.Add(new System.TimeSpan(0, 0, 0, 0, 500)).ToString(@"dddd\.hh\:mm\:ss"),
        //                                                     new System.TimeSpan(0, 0, 37, 0, 500).ToString(@"dddd\.hh\:mm\:ss"));
        //    Assert.AreEqual(Jaffa.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), System.DateTime.Now.AddMinutes(37).ToString("yyyy-MM-dd HH:mm:ss"));
        //}

        //// オフセット値設定テスト２（プロパティ）

        //[TestMethod]
        //public void TestMethod21()
        //{
        //    Jaffa.DateTime.DifferenceNow = new System.TimeSpan(5, 3, 2, 6);
        //    Assert.AreEqual(Jaffa.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), System.DateTime.Now.Add(new System.TimeSpan(5, 3, 2, 6)).ToString("yyyy-MM-dd HH:mm:ss"));
        //}
    }
}