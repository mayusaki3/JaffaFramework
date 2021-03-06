# Jaffa.Internal.Core クラス

Core クラスは、Jaffaフレームワークの基本機能を提供します。

## 構文

```
public static class Core : Object
```
						
## プロパティ

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>Version</td><td>
Jaffaフレームワークのバージョンを取得します。<br>
<b>構文</b><br><table>
<tr><td>static System.Version Version { get; }</td></tr>
</table></td></tr>

</table>

## メソッド

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>Initialize</td><td>
コアライブラリを初期化を行います。<br>
Jaffa.Application.Start();から呼ばれます。<br>
<b>構文</b><br><table>
<tr><td>
static void Initialize();<br>
</td></tr>
</table></td></tr>

<tr><td>MakeChangedResources</td><td>
変更されたリソースを作成します。<br>
<b>構文</b><br><table>
<tr><td>
static ResourceDictionary MakeChangedResources(ResourceDictionary currentResource, string[] prefixList, string newPrefix);<br>
</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>currentResource</td><td>現在のリソースを指定します。</td></tr>
<tr><td>prefixList</td><td>リソースファイル名のプレフィックスリストを指定します。</td></tr>
<tr><td>newPrefix</td><td>新しいリソースファイル名のプレフィックスを指定します。</td></tr>
</table>

<b>戻り値</b><br><table>
<tr><td>変更されたリソース。</td></tr>
</table>

<b>解説</b><br><table>
<tr><td>
現在のリソース内のMergedDictionariesすべてのソースについて、プレフィックスリストに含まれる部分を新しいプレフィックスに書き換え、変更されたリソースを作成します。
</td></tr>
</table>

</td></tr>

<tr><td>MakeMessage</td><td>
コアライブラリ内メッセージを構築します。<br>
このメソッドが参照するリソースは、Jaffaフレームワーク内のものです。<br>
<b>構文</b><br><table>
<tr><td>
static string MakeMessage(string message, string[] paramList = null);<br>
</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>message</td><td>メッセージを指定します。</td></tr>
<tr><td>paramList</td><td>メッセージに埋め込むパラメータのリストを指定します。</td></tr>
</table>

<b>戻り値</b><br><table>
<tr><td>構築したメッセージ。</td></tr>
</table>

<b>解説</b><br><table>
<tr><td>
メッセージは、テキスト中に {resource-name} と %paramList-index を指定できます。<br>
パラメータは、テキスト中に {resource-name} を指定できます。<br>
メッセージとパラメータは、それぞれリソースを参照してから、１つに編集します。<br>
</td></tr>
</table>

</td></tr>

</table></td></tr>
</table>
