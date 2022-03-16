using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace JaffaCoreTest
{
    [TestClass]
    public class UnitTest_International
    {
        // 注意
        // カルチャ自動設定のテストは、日本語版Windowsが前提です。

        private bool setEvent = false;
        private int chgCount = 0;

        private void International_CultureChanged(object? sender, System.EventArgs e)
        {
            chgCount++;
        }

        // 既定値テスト

        [TestMethod]
        public void TestMethod01()
        {
            // 既定値
            Jaffa.International.Initialize();
            Assert.AreEqual(Jaffa.International.CurrentCulture, "ja-JP");
            Assert.AreEqual(Jaffa.International.CurrentCultureSetting, "Auto");
        }

        // メソッドテスト

        [TestMethod]
        public void TestMethod11()
        {
            Jaffa.International.ChangeCultureFromDisplayLanguageName("English");

            // GetAvailableLanguageNameList
            string[] lst = Jaffa.International.GetAvailableLanguageNameList();
            Assert.AreEqual(lst.Length, 3);
            Assert.AreEqual(lst[0], "Automatic setting");
            Assert.AreEqual(lst[1], "English");
            Assert.AreEqual(lst[2], "日本語");

            // GetAvailableLanguageCodeList
            lst = Jaffa.International.GetAvailableLanguageCodeList();
            Assert.AreEqual(lst[0], "Auto");
            Assert.AreEqual(lst[1], "en-US");
            Assert.AreEqual(lst[2], "ja-JP");

            // GetDisplayLanguageName
            Assert.AreEqual(Jaffa.International.GetDisplayLanguageName("Auto"), "Automatic setting");
            Assert.AreEqual(Jaffa.International.GetDisplayLanguageName("en-US"), "English");
            Assert.AreEqual(Jaffa.International.GetDisplayLanguageName("ja-JP"), "日本語");

            // ConvertCurrentCultureResourceString
            Assert.AreEqual(Jaffa.International.ConvertCurrentCultureResourceString(Jaffa.Core.Jaffa,
                            "{JAFFA_TITLE}"),
                            "Jaffa Framework");

            Jaffa.International.ChangeCultureFromDisplayLanguageName("日本語");

            // GetAvailableLanguageNameList
            lst = Jaffa.International.GetAvailableLanguageNameList();
            Assert.AreEqual(lst[0], "自動設定");
            Assert.AreEqual(lst[1], "English");
            Assert.AreEqual(lst[2], "日本語");

            // GetAvailableLanguageCodeList
            lst = Jaffa.International.GetAvailableLanguageCodeList();
            Assert.AreEqual(lst[0], "Auto");
            Assert.AreEqual(lst[1], "en-US");
            Assert.AreEqual(lst[2], "ja-JP");

            // GetDisplayLanguageName
            Assert.AreEqual(Jaffa.International.GetDisplayLanguageName("Auto"), "自動設定");
            Assert.AreEqual(Jaffa.International.GetDisplayLanguageName("en-US"), "English");
            Assert.AreEqual(Jaffa.International.GetDisplayLanguageName("ja-JP"), "日本語");

            // GetResourceCultureName
            Assert.AreEqual(Jaffa.International.GetResourceCultureName("en-US"), "en-US");
            Assert.AreEqual(Jaffa.International.GetResourceCultureName("en"), "en-US");
            Assert.AreEqual(Jaffa.International.GetResourceCultureName("ja-JP"), "ja-JP");
            Assert.AreEqual(Jaffa.International.GetResourceCultureName("ja"), "ja-JP");

            // ConvertCurrentCultureResourceString
            Assert.AreEqual(Jaffa.International.ConvertCurrentCultureResourceString(Jaffa.Core.Jaffa,
                            "{JAFFA_TITLE}"),
                            "Jaffaフレームワーク");
            Assert.AreEqual(Jaffa.International.ConvertCurrentCultureResourceString(Jaffa.Core.Jaffa,
                            "A}{JAFFA_TITLE"),
                            "A}{JAFFA_TITLE");
            Assert.AreEqual(Jaffa.International.ConvertCurrentCultureResourceString(Jaffa.Core.Jaffa,
                            "A{}JAFFA_TITLE}"),
                            "AJAFFA_TITLE}");
            Assert.AreEqual(Jaffa.International.ConvertCurrentCultureResourceString(Jaffa.Core.Jaffa,
                            "A{JAFFA_TITLE}"),
                            "AJaffaフレームワーク");
            Assert.AreEqual(Jaffa.International.ConvertCurrentCultureResourceString(Jaffa.Core.Jaffa,
                            "A{JAFFA_TITL}"),
                            "A");
            Assert.AreEqual(Jaffa.International.ConvertCurrentCultureResourceString(Jaffa.Core.Jaffa,
                            "A{JAFFA_TITLE}B{JAFFA_TITLE}"),
                            "AJaffaフレームワークBJaffaフレームワーク");
        }

        // メソッドと関連イベントテスト

        [TestMethod]
        public void TestMethod12()
        {
            // ChangeCultureFromDisplayLanguageName と CultureChangedイベント
            Jaffa.International.ChangeCultureFromDisplayLanguageName("日本語");
            if (setEvent == false)
            {
                setEvent = true;
                Jaffa.International.CultureChanged += International_CultureChanged;
            }
            chgCount = 0;

            Jaffa.International.ChangeCultureFromDisplayLanguageName("日本語");
            Assert.AreEqual(chgCount, 0);
            Jaffa.International.ChangeCultureFromDisplayLanguageName("なぞ語");
            Assert.AreEqual(chgCount, 0);
            Jaffa.International.ChangeCultureFromDisplayLanguageName("English");
            Assert.AreEqual(chgCount, 1);
            Jaffa.International.ChangeCultureFromDisplayLanguageName("English");
            Assert.AreEqual(chgCount, 1);
            Jaffa.International.ChangeCultureFromDisplayLanguageName("日本語");
            Assert.AreEqual(chgCount, 2);
            Jaffa.International.ChangeCultureFromDisplayLanguageName("Undefine");
            Assert.AreEqual(chgCount, 2);
        }

        // リソース設定テスト（エラー）

        [TestMethod]
        public void TestMethod21()
        {
            // ChangeCultureFromDisplayLanguageName と CultureChangedイベント
            Jaffa.International.ChangeCultureFromDisplayLanguageName("日本語");
            if (setEvent == false)
            {
                setEvent = true;
                Jaffa.International.CultureChanged += International_CultureChanged;
            }
            chgCount = 0;

            // 差し替え
            Assembly thisAsm = Assembly.GetExecutingAssembly();
            Jaffa.Core.SetResource(Jaffa.Core.JaffaCulture, "JaffaCoreTest.Res.CultureList", thisAsm);

            // ChangeCultureFromDisplayLanguageName
            Jaffa.International.ChangeCultureFromDisplayLanguageName("日本語");
            Assert.AreEqual(chgCount, 0);
            Jaffa.International.ChangeCultureFromDisplayLanguageName("English");
            Assert.AreEqual(chgCount, 0);

            // GetAvailableLanguageNameList
            string[] lst = Jaffa.International.GetAvailableLanguageNameList();
            Assert.AreEqual(lst.Length, 0);

            // GetAvailableLanguageCodeList
            lst = Jaffa.International.GetAvailableLanguageCodeList();
            Assert.AreEqual(lst.Length, 0);

            // GetDisplayLanguageName
            Assert.AreEqual(Jaffa.International.GetDisplayLanguageName("Auto"), "Auto");
            Assert.AreEqual(Jaffa.International.GetDisplayLanguageName("en-US"), "en-US");
            Assert.AreEqual(Jaffa.International.GetDisplayLanguageName("ja-JP"), "ja-JP");

            // GetResourceCultureName
            Assert.AreEqual(Jaffa.International.GetResourceCultureName("en-US"), "en-US");
            Assert.AreEqual(Jaffa.International.GetResourceCultureName("en"), "en");
            Assert.AreEqual(Jaffa.International.GetResourceCultureName("ja-JP"), "ja-JP");
            Assert.AreEqual(Jaffa.International.GetResourceCultureName("ja"), "ja");

            // 差し戻し
            Jaffa.Core.SetResource(Jaffa.Core.JaffaCulture, "Jaffa.Resources.CultureList", thisAsm);
        }
    }
}