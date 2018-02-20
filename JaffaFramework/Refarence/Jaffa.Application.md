# Jaffa.Application クラス

Application クラスは、UWP または WPF アプリケーションと JaffaFramework とを結びつける、基本的な機能を提供します。

## 構文

```
public static class Application : Object`
```
						
## コンストラクター

なし

## プロパティ

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>Current</td><td>
アプリケーションインスタンスを参照します。<br>
<b>構文</b><br><table>
<tr><td>UWP</td><td>Windows.UI.Xaml.Application Current</td></tr>
<tr><td>WPF</td><td>System.Windows.Application Current</td></tr>
</table></td></tr>

<tr><td>StartupPath</td><td>
アプリケーションの起動パスを参照します。<br>
<b>構文</b><br><table>
<tr><td>WPF</td><td>string StatupPath</td></tr>
</table></td></tr>

</table>

## メソッド

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>Start</td><td>
Jaffaフレームワークにアプリケーション開始を通知します。<br>
<b>構文</b><br><table>
<tr><td>UWP</td><td>void Start();</td></tr>
<tr><td>WPF</td><td>void Start(System.Windows.Application app, string resourceName);</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>app</td><td>Jaffaフレームワークを利用するアプリケーションのインスタンス</td></tr>
<tr><td>resourceName</td><td>国際化対応に使用するリソース名または空文字</td></tr>
</table></td></tr>

</table>

## イベント

なし
