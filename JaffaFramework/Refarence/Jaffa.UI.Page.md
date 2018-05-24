# Jaffa.UI.Page クラス

Page クラスは、UWP アプリケーションの Page と JaffaFramework とを結びつける、基本的な機能を提供します。

## 構文

```
public static class Page : Object
```
						
## メソッド

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>Reload</td><td>
ページをリロードします。<br>
<b>構文</b><br><table>
<tr><td>UWP</td><td>static void Reload(Windows.UI.Xaml.Controls.Frame frame, Windows.UI.Xaml.Controls.Page page);<br>
static void Reload(Windows.UI.Xaml.Controls.Frame frame, Windows.UI.Xaml.Controls.Page page, Preprocess preprocess, Postprocess postprocess);</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>frame</td><td>リロードするフレームのインスタンスを指定します。</td></tr>
<tr><td>page</td><td>リロードするページのインスタンスを指定します。</td></tr>
<tr><td>preprocess</td><td>リロードの前処理を指定します。</td></tr>
<tr><td>postprocess</td><td>リロードの後処理を指定します。</td></tr>
</table>

<b>解説</b><br><table>
<tr><td>
指定したページのInitializeComponent相当の処理を行います。<br>
※リロード中はログ出力をキャッシュします。画面にログを表示している場合は、preprocess / postprocess で退避および復元してください。<br>
※親子関係のページについても再作成されますが、一度表示しないとアンロードされません。リロード前に一度表示を行ってください。
</td></tr>
</table>

</td></tr>

<tr><td>Start</td><td>
Jaffaフレームワークにページ開始を通知します。<br>
InitializeComponentの前に実行する必要があります。<br>
<b>構文</b><br><table>
<tr><td>UWP</td><td>static void Start(Windows.UI.Xaml.Controls.Page page);</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>page</td><td>Jaffaフレームワークを利用するページのインスタンスを指定します。</td></tr>
</table></td></tr>

</table>

## イベント

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>Creating</td><td>
ページインスタンスが生成されたことを通知します。<br>
<b>構文</b><br><table>
<tr><td>UWP</td><td>delegate void CreatingHandler(object sender, EventArgs e)</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>sender</td><td>生成された Windows.UI.Xaml.Controls.Page オブジェクトです。</td></tr>
<tr><td>e</td><td>既定のイベントデータです。</td></tr>
</table></td></tr>

</table>

## ファンクション

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>Preprocess</td><td>
リロードの前処理を行えます。<br>
<b>テンプレート</b><br><table>
<tr><td>UWP</td><td>delegate void Preprocess(Windows.UI.Xaml.Controls.Frame frame, Windows.UI.Xaml.Controls.Page page);</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>frame</td><td>リロードするフレームのインスタンスです。</td></tr>
<tr><td>page</td><td>リロードするページのインスタンスです。</td></tr>
</table></td></tr>

<tr><td>Postprocess</td><td>
リロードの後処理を行えます。<br>
<b>テンプレート</b><br><table>
<tr><td>UWP</td><td>delegate void Postprocess(Windows.UI.Xaml.Controls.Frame frame, Windows.UI.Xaml.Controls.Page page);</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>frame</td><td>リロードしたフレームのインスタンスです。</td></tr>
<tr><td>page</td><td>リロードしたページのインスタンスです。</td></tr>
</table></td></tr>

</table>
