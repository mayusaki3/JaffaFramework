# Jaffa.Diagnostics.LogWritingEventArgs クラス

LogWritingEventArgs クラスは、ログ出力イベントのイベントデータです。

## 構文

```
public class LogWritingEventArgs : EventArgs
```

## コンストラクタ―

<table><tr><td>説明</td></tr>

<tr><td>
ログ出力イベント引数を初期化します。<br>
<b>構文</b><br><table>
<tr><td>LogWritingEventArgs(DateTime dateTime, string[] messages);</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>dateTime</td><td>メッセージの発生日時を指定します。</td></tr>
<tr><td>messages</td><td>メッセージリストを指定します。</td></tr>
</table></td></tr>

</table>


## プロパティ

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>DateTime</td><td>
メッセージの発生日時を参照します。<br>
<b>構文</b><br><table>
<tr><td>System.DateTime DateTime { get; }</td></tr>
</table></td></tr>

<tr><td>Messages</td><td>
メッセージリストを参照します。<br>
<b>構文</b><br><table>
<tr><td>string[] Messages { get; }</td></tr>
</table></td></tr>

</table>
