# Jaffa.International クラス

International クラスは、アプリケーションの国際化対応をサポートします。

## 構文

```
public static class International
```

## プロパティ

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>CurrentCultureSetting</td><td>
現在の設定カルチャー名を取得します。<br>CurrentCultureプロパティとの違いは "Auto" の有無です。<br>
<b>構文</b><br><table>
<tr><td>static string CurrentCultureSetting</td></tr>
</table></td></tr>

<tr><td>CurrentCulture</td><td>
現在のカルチャー名を参照します。<br>
<b>構文</b><br><table>
<tr><td>static string CurrentCulture</td></tr>
</table></td></tr>

</table>

## メソッド

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>GetAvailableLanguageList</td><td>
アプリケーションで利用可能な言語リストを取得します。<br>
アプリケーションの Resources.resw(UWP) / Resources.resx(WPF) に 文字列 Dictionarys を追加し、次のようにサポートする{言語コード},{言語名} の行を設定します。<br>
<pre>
例. Auto,{DynamicResource CultureAuto}
    en-US,English
    ja-JP,日本語
</pre>この例の「{DynamicResource CultureAuto}」部分は、言語コードのリソースで置き換わります。<br>
<b>構文</b><br><table>
<tr><td>static string[] GetAvailableLanguageList();</td></tr>
</table></td></tr>

<tr><td>GetDisplayLanguageName</td><td>
カルチャー名に対応する表示名を取得します。<br>
<b>構文</b><br><table>
<tr><td>static string GetDisplayLanguageName(string culture);</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>culture</td><td>カルチャー名を指定します。</td></tr>
</table></td></tr>

<tr><td>GetResourceCultureName</td><td>
リソース上のDictionaryに設定された内容からカルチャー名を検索し、最もマッチするカルチャー名を取得します。<br>
<b>構文</b><br><table>
<tr><td>static string GetResourceCultureName(string name);</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>name</td><td>マッチングするカルチャー名を指定します。</td></tr>
</table></td></tr>

<tr><td>ChangeCultureFromDisplayLanguageName</td><td>
現在のカルチャーを言語名で変更します。UWPアプリのページキャッシュはクリアされます。<br>
<b>構文</b><br><table>
<tr><td>static void ChangeCultureFromDisplayLanguageName(string name);</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>name</td><td>表示名を指定します。</td></tr>
</table></td></tr>

<tr><td>MakeCoreMessage</td><td>
フレームワーク内メッセージを構築します。<br>
メッセージは、テキスト中に {resource-name} と %paramList-index を指定できます。<br>
パラメータは、テキスト中に {resource-name} を指定できます。<br>
メッセージとパラメータは、それぞれリソースを参照してから、１つに編集します。<br>
<b>構文</b><br><table>
<tr><td>static string MakeCoreMessage(string message);<br>static string MakeCoreMessage(string message, string[] paramList);</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>message</td><td>メッセージを指定します。</td></tr>
<tr><td>paramList</td><td>メッセージに埋め込むパラメータのリストを指定します。</td></tr>
</table></td></tr>

</table>

## イベント

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>ChangeCultureEvent</td><td>
CurrentCultureが変更されたことを通知します。<br>
<b>構文</b><br><table>
<tr><td>delegate void ChangeCultureEventHandler(object sender, EventArgs e);</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>sender</td><td>currentCulture オブジェクトです。</td></tr>
<tr><td>e</td><td>既定のイベントデータです。</td></tr>
</table></td></tr>

</table>

