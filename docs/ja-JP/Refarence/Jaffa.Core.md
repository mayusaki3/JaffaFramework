# Jaffa.Core クラス

Core クラスは、Jaffaフレームワークの基本機能をサポートします。

## 構文

```
public class Core
```

## コンストラクタ―

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>Core</td><td>
Jaffaフレームワークを初期化します<br>
<b>構文</b><br><table>
<tr><td>static Core();</td></tr>
</table></td></tr>

</table>

## 定数

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>Jaffa</td><td>
Jaffaフレームワークが使用するリソース領域名です。<br>
<b>構文</b><br><table>
<tr><td>const string Jaffa = "Jaffa";</td></tr>
</table></td></tr>

<tr><td>JaffaCulture</td><td>
Jaffaフレームワークが使用するカルチャーリソース領域名です。<br>
<b>構文</b><br><table>
<tr><td>const string JaffaCulture = "JaffaCulture";</td></tr>
</table></td></tr>

</table>

## プロパティ

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>StartupPath</td><td>
起動パスを参照します。<br>
<b>構文</b><br><table>
<tr><td>static string StartupPath { get; }</td></tr>
</table></td></tr>

<tr><td>Version</td><td>
Jaffaバージョンを参照します。<br>
<b>構文</b><br><table>
<tr><td>static string Version { get; }</td></tr>
</table></td></tr>

</table>

## メソッド

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>MakeMessage</td><td>
リソースを参照してメッセージを構築します。<br>
<b>構文</b><br><table>
<tr><td>static string MakeMessage(string name, string message, string[] paramList = null);</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>name</td><td>対象のリソース名を指定します。</td></tr>
<tr><td>message</td><td>メッセージテキストを指定します。<br>
message内の "{resource-name}" がリソースの resource-name で定義された内容に置き換わります。
</td></tr>
<tr><td>paramList</td><td>メッセージに埋め込むパラメータのリストを指定します。<br>
message内の "%0", "%1" 等がリストの内容に置き換わります。<br>
内容に "{resource-name}" が含まれていた場合は、さらにリソースの resource-name で定義された内容に置き換わります。
</td></tr>
</table><b>戻り値</b><br><table>
<tr><td>構築されたメッセージ。</td><td>
</td></tr>
</table></td></tr>

<tr><td>Resource</td><td>
リソースマネージャを参照します。<br>
<b>構文</b><br><table>
<tr><td>
static ResourceManager Resource(string name);<br>
</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>name</td><td>対象のリソース名を指定します。</td></tr>
</table><b>戻り値</b><br><table>
<tr><td>該当するリソースマネージャ。</td><td>
</td></tr>
</table></td></tr>

<tr><td>SetResource</td><td>
アプリケーションで利用するリソースマネージャを設定します。<br>
<b>構文</b><br><table>
<tr><td>
static void SetResource(string name, string resourcePath, Assembly assembly);
</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>name</td><td>後で参照するためにリソース名を指定します。</td></tr>
<tr><td>resourcePath</td><td>リソースパス名を指定します。<br>
リソースパス名内の{Culture}は現在のカルチャー名に置き換わります。</td></tr>
<tr><td>assembly</td><td>リソースが格納されたアセンブリを指定します。</td></tr>
</table></td></tr>

</table>
