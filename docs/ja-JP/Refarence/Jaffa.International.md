# Jaffa.International クラス

International クラスは、国際化対応をサポートします。

## 構文

```
public static class International
```

## プロパティ

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>CurrentCulture</td><td>
現在のカルチャー名を取得します。<br>
<b>構文</b><br><table>
<tr><td>static string CurrentCulture { get; }</td></tr>
</table></td></tr>

<tr><td>CurrentCultureSetting</td><td>
現在の設定カルチャー名を取得します。<br>CurrentCultureプロパティとの違いは "Auto" の有無です。<br>
<b>構文</b><br><table>
<tr><td>static string CurrentCultureSetting { get; }</td></tr>
</table></td></tr>

</table>

## メソッド

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>ChangeCultureFromDisplayLanguageName</td><td>
現在のカルチャーを言語名で変更します。<br>
カルチャーが変更されると OnCultureChanged イベントが発生します。<br>
<b>構文</b><br><table>
<tr><td>
static void ChangeCultureFromDisplayLanguageName(string name);<br>
</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>name</td><td>表示名またはカルチャー名を指定します。</td></tr>
</table></td></tr>

<tr><td>ConvertCurrentCultureResourceString</td><td>
文字列内のリソース指定を現在のカルチャーで変換します。<br>
<b>構文</b><br><table>
<tr><td>
static string ConvertCurrentCultureResourceString(string region, string text);<br>
</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>region</td><td>リソース領域名を指定します。</td></tr>
<tr><td>text</td><td>テキストを指定します。<br>
テキスト内の {resource-name} を現在のカルチャーに対応するリソースから変換します。
</td></tr>
</table><b>戻り値</b><br><table>
<tr><td>変換されたテキスト。</td><td>
</td></tr>
</table></td></tr>

<tr><td>GetAvailableLanguageCodeList</td><td>
利用可能な言語コードリストを取得します。<br>
JaffaCore/Resources/CultureList.resx の SUPPORT_LIST に、次のようにサポートする{言語コード},{言語名} の行を設定します。
<pre>
例. Auto,{CULTURE_AUTO}
    en-US,English
    ja-JP,日本語
</pre>
この例の「{CULTURE_AUTO}」部分は、言語コードのリソースで置き換わります。<br>
<b>構文</b><br><table>
<tr><td>
static string[] GetAvailableLanguageCodeList();<br>
</td></tr>
</table><b>戻り値</b><br><table>
<tr><td>利用可能な言語コードリスト。</td><td>
</td></tr>
</table></td></tr>

<tr><td>GetAvailableLanguageNameList</td><td>
利用可能な言語名リストを取得します。<br>
JaffaCore/Resources/CultureList.resx の SUPPORT_LIST に、次のようにサポートする{言語コード},{言語名} の行を設定します。
<pre>
例. Auto,{CULTURE_AUTO}
    en-US,English
    ja-JP,日本語
</pre>
この例の「{CULTURE_AUTO}」部分は、言語コードのリソースで置き換わります。<br>
<b>構文</b><br><table>
<tr><td>
static string[] GetAvailableLanguageNameList();
</td></tr>
</table><b>戻り値</b><br><table>
<tr><td>利用可能な言語名リストリスト。</td><td>
</td></tr>
</table></td></tr>

<tr><td>GetDisplayLanguageName</td><td>
カルチャー名に対応する表示名を取得します。<br>
<b>構文</b><br><table>
<tr><td>static string GetDisplayLanguageName(string culture);</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>
culture</td><td>カルチャー名を指定します。<br>
</td></tr>
</table><b>戻り値</b><br><table>
<tr><td>表示名。</td><td>
</td></tr>
</table></td></tr>

<tr><td>GetResourceCultureName</td><td>
Jaffaフレームワークのリソースからカルチャー名を検索し、最もマッチするカルチャー名を取得します。<br>
<b>構文</b><br><table>
<tr><td>static string GetResourceCultureName(string name);</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>name</td><td>マッチングするカルチャー名を指定します。</td></tr>
</table><b>戻り値</b><br><table>
<tr><td>最もマッチするカルチャー名。</td><td>
</td></tr>
</table></td></tr>

<tr><td>Initialize</td><td>
カルチャー情報を初期化します。<br>
Core から自動で呼ばれるため、呼び出しは不要です。<br>
<b>構文</b><br><table>
<tr><td>
static void Initialize();<br>
</td></tr>
</table></td></tr>

</table>

## イベント

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>CultureChanged</td><td>
CurrentCultureが変更されたことを通知します。<br>
<b>構文</b><br><table>
<tr><td>static event EventHandler&lt;EventArgs&gt; CultureChanged;</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>sender</td><td>currentCulture オブジェクトです。</td></tr>
<tr><td>e</td><td>既定のイベントデータです。</td></tr>
</table></td></tr>

</table>

