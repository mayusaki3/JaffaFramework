# Jaffa.UI.Page クラス

Page クラスは、UWP アプリケーションの Page と JaffaFramework とを結びつける、基本的な機能を提供します。

## 構文

```
public static class Page : Object
```
						
## メソッド

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>Start</td><td>
Jaffaフレームワークにページ開始を通知します。<br>
<b>構文</b><br><table>
<tr><td>UWP</td><td>static void Start(Windows.UI.Xaml.Controls.Page page);</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>page</td><td>Jaffaフレームワークを利用するページのインスタンスを指定します。</td></tr>
</table></td></tr>

</table>

## イベント

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>CreatePageEvent</td><td>
ページインスタンスが生成されたことを通知します。<br>
<b>構文</b><br><table>
<tr><td>UWP</td><td>delegate void CreatePageEventHandler(object sender, EventArgs e)</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>sender</td><td>生成された Windows.UI.Xaml.Controls.Page オブジェクトです。</td></tr>
<tr><td>e</td><td>既定のイベントデータです。</td></tr>
</table></td></tr>

</table>

