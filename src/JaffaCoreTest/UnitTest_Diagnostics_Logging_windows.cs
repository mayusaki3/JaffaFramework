using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JaffaCoreTest
{
    [TestClass]
    public class UnitTest_Diagnostics_Logging_windows
    {
        // 既定値テスト

        [TestMethod]
        public void TestMethod01()
        {
            // 設定初期値
            //Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.LoggingMode, Jaffa.Diagnostics.LoggingMode.None);
            //Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.Folder, @"Logs\");
            //Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.FileName, "syslog[@].txt");
            //Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.MaxFileSizeKB, 2048);
            //Assert.AreEqual(Jaffa.Diagnostics.LoggingSettings.FrameworkMessage, false);
        }

        [TestMethod]
        public void TestMethod02()
        {
            // イベントデータ初期値
            //System.DateTime dt = new System.DateTime(2022, 01, 02, 03, 04, 05, 06);
            //string[] msgs = new string[] { "Logging Message.", "ログに出力するメッセージ。", "%1, %2, {abc} など変換はしない。" };
            //Jaffa.Diagnostics.LogWritingEventArgs args = new Jaffa.Diagnostics.LogWritingEventArgs(dt,msgs);
            //Assert.AreEqual(args.DateTime, dt);
            //Assert.AreEqual(args.Messages, msgs);
        }


        //// オフセット値設定テスト１（メソッド）

        //[TestMethod]
        //public void TestMethod11()
        //{
        //    Jaffa.DateTime.CalcDifferenceNow(System.DateTime.Now.AddDays(213));
        //    Assert.AreEqual(Jaffa.DateTime.DifferenceNow.Add(new System.TimeSpan(0, 0, 0, 0, 500)).ToString(@"dddd\.hh\:mm\:ss"),
        //                                                     new System.TimeSpan(213, 0, 0, 0, 500).ToString(@"dddd\.hh\:mm\:ss"));
        //    Assert.AreEqual(Jaffa.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), System.DateTime.Now.AddDays(213).ToString("yyyy-MM-dd HH:mm:ss"));
        //}

        //[TestMethod]
        //public void TestMethod12()
        //{
        //    Jaffa.DateTime.CalcDifferenceNow(System.DateTime.Now.AddHours(-2));
        //    Assert.AreEqual(Jaffa.DateTime.DifferenceNow.Add(new System.TimeSpan(0, 0, 0, 0, 500)).ToString(@"dddd\.hh\:mm\:ss"),
        //                                                     new System.TimeSpan(0, -2, 0, 0, 500).ToString(@"dddd\.hh\:mm\:ss"));
        //    Assert.AreEqual(Jaffa.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), System.DateTime.Now.AddHours(-2).ToString("yyyy-MM-dd HH:mm:ss"));
        //}

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