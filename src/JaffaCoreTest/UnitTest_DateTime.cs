using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JaffaCoreTest
{
    [TestClass]
    public class UnitTest_DateTime
    {
        // 秒単位に丸め用
        private const int ms500 = 500;
        private System.TimeSpan ms500t = new System.TimeSpan(0,0,0,0, ms500);

        // 比較用フォーマット
        private const string fmtSpan = @"dddd\.hh\:mm\:ss";
        private const string fmtTime = "yyyy-MM-dd HH:mm:ss";


        // 既定値テスト（プロパティ）

        [TestMethod]
        public void TestMethod01()
        {
            // 既定値
            Assert.AreEqual(Jaffa.DateTime.DifferenceNow, new System.TimeSpan(0, 0, 0, 0));
            Assert.AreEqual(Jaffa.DateTime.Now.Add(ms500t).ToString(fmtTime), System.DateTime.Now.Add(ms500t).ToString(fmtTime));
        }

        // オフセット値設定テスト１（メソッド）
        // 計算時間でDifferenceNowにms単位で差が出るため、sに丸める

        [TestMethod]
        public void TestMethod11()
        {
            // CalcDifferenceNow：日を指定
            Jaffa.DateTime.CalcDifferenceNow(System.DateTime.Now.AddDays(213));
            Assert.AreEqual(Jaffa.DateTime.DifferenceNow.Add(ms500t).ToString(fmtSpan),
                                                             new System.TimeSpan(213,0,0,0,ms500).ToString(fmtSpan));
            Assert.AreEqual(Jaffa.DateTime.Now.ToString(fmtTime), System.DateTime.Now.AddDays(213).ToString(fmtTime));
        }

        [TestMethod]
        public void TestMethod12()
        {
            // CalcDifferenceNow：時を指定
            Jaffa.DateTime.CalcDifferenceNow(System.DateTime.Now.AddHours(-2));
            Assert.AreEqual(Jaffa.DateTime.DifferenceNow.Add(ms500t).ToString(fmtSpan),
                            new System.TimeSpan(0, -2, 0, 0,ms500).ToString(fmtSpan));
            Assert.AreEqual(Jaffa.DateTime.Now.ToString(fmtTime), 
                            System.DateTime.Now.AddHours(-2).ToString(fmtTime));
        }

        [TestMethod]
        public void TestMethod13()
        {
            // CalcDifferenceNow：分を指定
            Jaffa.DateTime.CalcDifferenceNow(System.DateTime.Now.AddMinutes(37));
            Assert.AreEqual(Jaffa.DateTime.DifferenceNow.Add(ms500t).ToString(fmtSpan),
                            new System.TimeSpan(0, 0, 37, 0,ms500).ToString(fmtSpan));
            Assert.AreEqual(Jaffa.DateTime.Now.ToString(fmtTime),
                            System.DateTime.Now.AddMinutes(37).ToString(fmtTime));
        }

        // オフセット値設定テスト２（プロパティ）

        [TestMethod]
        public void TestMethod21()
        {
            // DifferenceNow : 日,時,分,秒を指定
            Jaffa.DateTime.DifferenceNow = new System.TimeSpan(5, 3, 2, 6);
            Assert.AreEqual(Jaffa.DateTime.Now.ToString(fmtTime),
                            System.DateTime.Now.Add(new System.TimeSpan(5, 3, 2, 6)).ToString(fmtTime));
        }
    }
}