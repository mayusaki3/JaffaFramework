# Jaffa.Application クラス

Application クラスは、UWP または WPF アプリケーションと JaffaFramework とを結びつける、基本的な機能を提供します。

## 構文

```
public static class Application : Object
```
## プロパティ

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>ApplicationFolderName</td><td>
アプリケーションフォルダー名を参照または設定します。<br>
<b>構文</b><br><table>
<tr><td>static string ApplicationFolderName { get; set; }</td></tr>
</table></td></tr>

<tr><td>CampanyFolderName</td><td>
カンパニーフォルダー名を参照または設定します。<br>
<b>構文</b><br><table>
<tr><td>static string CampanyFolderName { get; set; }</td></tr>
</table></td></tr>

<tr><td>Current</td><td>
アプリケーションインスタンスを参照します。<br>
<b>構文</b><br><table>
<tr><td>UWP</td><td>static Windows.UI.Xaml.Application Current { get; }</td></tr>
<tr><td>WPF</td><td>static System.Windows.Application Current { get; }</td></tr>
</table></td></tr>

<tr><td>Pages</td><td>
アプリケーションでインスタンス化されたページを参照します。<br>
<b>構文</b><br><table>
<tr><td>UWP</td><td>static Windows.UI.Xaml.Controls.Page[] Pages { get; }</td></tr>
</table></td></tr>

<tr><td>Resource</td><td>
リソースローダー/マネージャーを参照します。<br>
<b>構文</b><br><table>
<tr><td>UWP</td><td>static Windows.ApplicationModel.Resources.ResourceLoader Resource { get; }</td></tr>
<tr><td>WPF</td><td>static System.Resources.ResourceManager Resource { get; }</td></tr>
</table></td></tr>

<tr><td>StartupPath</td><td>
アプリケーションの起動パスを参照します。<br>
<b>構文</b><br><table>
<tr><td>WPF</td><td>static string StatupPath { get; }</td></tr>
</table></td></tr>

<tr><td>WaitingChangeCulture</td><td>
アプリケーションカルチャーが遅延更新状態かを設定または参照します。<br>
<b>構文</b><br><table>
<tr><td>UWP</td><td>static bool WaitingChangeCulture { get; set; }</td></tr>
</table></td></tr>

</table>

## メソッド

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>Start</td><td>
Jaffaフレームワークにアプリケーション開始を通知します。<br>
InitializeComponentの前に実行する必要があります。<br>
<b>構文</b><br><table>
<tr><td>UWP</td><td>
static void Start(Windows.UI.Xaml.Application app);<br>
</td></tr>
<tr><td>WPF</td><td>
static void Start(System.Windows.Application app, string resourceName = "");<br>
</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>app</td><td>Jaffaフレームワークを利用するアプリケーションのインスタンスを指定します。</td></tr>
<tr><td>resourceName</td><td>国際化対応に使用するリソース名を指定します。</td></tr>
</table></td></tr>

</table>

## イベント

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>PageUnloaded</td><td>
ページインスタンスがアンロードされたことを通知します。<br>
<b>構文</b><br><table>
<tr><td>static event EventHandler&lt;EventArgs&gt; PageUnloaded;</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>e</td><td>既定のイベントデータです。</td></tr>
<tr><td>sender</td><td>アンロードされた Windows.UI.Xaml.Controls.Page オブジェクトです。</td></tr>
</table></td></tr>

</table>
