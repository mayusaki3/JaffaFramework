using System;
using System.Reflection;
using Windows.UI.Xaml;

namespace Jaffa.Internal
{
    /// <summary>
    /// Jaffaフレームワーク・UWP版共通コアライブラリ
    /// </summary>
    public static partial class Core : Object
    {
        #region メソッド

        #region 変更されたリソース作成 (MakeChangedResources)

        /// <summary>
        /// 変更されたリソースを作成します。
        /// </summary>
        /// <param name="currentResource">現在のリソース</param>
        /// <param name="prefixList">リソースファイル名のプレフィックスリスト</param>
        /// <param name="newPrefix">新しいリソースファイル名のプレフィックス</param>
        /// <returns>変更されたリソース</returns>
        /// <remarks>
        /// 現在のリソース内のMergedDictionariesすべてのソースについて、プレフィックスリストに含まれる部分を新しいプレフィックスに書き換え、変更されたリソースを作成します。
        /// </remarks>
        static public ResourceDictionary MakeChangedResources(ResourceDictionary currentResource, string[] prefixList, string newPrefix)
        {
            var rt = new ResourceDictionary();
            rt.MergedDictionaries.Clear();
            foreach (var res in currentResource.MergedDictionaries)
            {
                string newsrc = res.Source.ToString();
                foreach (var prefix in prefixList)
                {
                    newsrc = newsrc.Replace(prefix, newPrefix);
                }

                // りソース設定
                rt.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri(newsrc) });
            }
            return rt;
        }

        #endregion

        #endregion

        #region プロパティ

        #region Jaffaフレームワークのバージョンを取得 ([R} Version)

        /// <summary>
        /// Jaffaフレームワークのバージョンを取得します。
        /// </summary>
        public static System.Version Version
        {
            get
            {
                return System.Reflection.Assembly.Load(new AssemblyName("JaffaForUWP")).GetName().Version;
            }
        }

        #endregion

        #endregion
    }
}
