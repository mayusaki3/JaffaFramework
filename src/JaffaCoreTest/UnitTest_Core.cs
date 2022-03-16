using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace JaffaCoreTest
{
    [TestClass]
    public class UnitTest_Core
    {
        // 定数・既定値テスト

        [TestMethod]
        public void TestMethod01()
        {
            // 定数値
            Assert.AreEqual(Jaffa.Core.Jaffa, "Jaffa");
            Assert.AreEqual(Jaffa.Core.JaffaCulture, "JaffaCulture");

            // アセンブルバージョン
            Assert.AreEqual(Jaffa.Core.Version, "0.0.4.1");

            // 起動パス（一部のみ確認）
            Assert.IsTrue(Jaffa.Core.StartupPath.IndexOf(@"\JaffaFramework\src\JaffaCoreTest\bin\") > 0);

            // 既定のリソース
            Assert.AreEqual(Jaffa.Core.Resource("Jaffa").BaseName, "Jaffa.Resources.ja_JP.Resource");
        }

        // リソース設定テスト（メソッド）

        [TestMethod]
        public void TestMethod11()
        {
            // SetResource
            Assembly thisAsm = Assembly.GetExecutingAssembly();
            Jaffa.Core.SetResource("Test", "JaffaCoreTest.Res.{Culture}.ResTest", thisAsm);
            Assert.AreEqual(Jaffa.Core.Resource("Test").BaseName, "JaffaCoreTest.Res.ja_JP.ResTest");
        }

        [TestMethod]
        public void TestMethod12()
        {
            // MakeMessage
            Assembly thisAsm = Assembly.GetExecutingAssembly();
            Jaffa.Core.SetResource("Test", "JaffaCoreTest.Res.{Culture}.ResTest", thisAsm);
            Assert.AreEqual(Jaffa.Core.MakeMessage("Test", ""), "");
            Assert.AreEqual(Jaffa.Core.MakeMessage("Test", "{TEST_NAME}"), "テスト １番");
            Assert.AreEqual(Jaffa.Core.MakeMessage("Test", "%0=%1+%2", new string[] { "3", "2", "1" }), "3=2+1");
            Assert.AreEqual(Jaffa.Core.MakeMessage("Test", "X{AA}{TEST_PARAM} %4Y{BB}", new string[] { "a", "b", "c", "d", "e" }), "XABC a : d : c : b DEF eY");
        }

        // リソース設定テスト（イベント）

        [TestMethod]
        public void TestMethod21()
        {
            // カルチャー変更イベントでリソースが変更されるか（Testはイベントなしで変更されない）
            Assembly thisAsm = Assembly.GetExecutingAssembly();
            Jaffa.Core.SetResource("Test", "JaffaCoreTest.Res.{Culture}.ResTest", thisAsm);
            Assert.AreEqual(Jaffa.Core.MakeMessage(Jaffa.Core.Jaffa, "{JAFFA_TITLE}"), "Jaffaフレームワーク");
            Assert.AreEqual(Jaffa.Core.MakeMessage("Test", "{TEST_NAME}"), "テスト １番");
            Jaffa.International.ChangeCultureFromDisplayLanguageName("en-US");
            Assert.AreEqual(Jaffa.Core.MakeMessage(Jaffa.Core.Jaffa, "{JAFFA_TITLE}"), "Jaffa Framework");
            Assert.AreEqual(Jaffa.Core.MakeMessage("Test", "{TEST_NAME}"), "テスト １番");   // イベントで再設定しない
        }
    }
}