# Jaffa.Diagnostics.Logging クラス

Logging クラスは、アプリケーションのロギング対応をサポートします。<br>
ログの時刻は Jaffa.Internal.DateTime クラスの現在時刻です。WPFではログファイルの時刻もJaffa.Internal.DateTime クラスの現在時刻に設定されますが、UWPでは実際の時刻のままです。

## 構文

```
public static class Logging : Object
```

## プロパティ

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>LastFilename</td><td>
最後にログ出力したファイル名を参照します。<br>
<b>構文</b><br><table>
<tr><td>static string LastFilename { get; }</td></tr>
</table></td></tr>

<tr><td>LogWriteWaiting</td><td>
ログ出力中断を参照または設定します。trueの場合、メモリ上にバッファリングされます。<br>既定値は true です。<br>
<b>構文</b><br><table>
<tr><td>static bool LogWriteWaiting { get; set; }</td></tr>
</table></td></tr>

<tr><td>MuteLoggingEvent</td><td>
ログ出力時のLoggingイベント無効化を参照または設定します。<br>既定値は false です。<br>
<b>構文</b><br><table>
<tr><td>static bool MuteLoggingEvent { get; set; }</td></tr>
</table></td></tr>

</table>

## メソッド

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>BytesToHexDump</td><td>
バイト配列を16進ダンプに変換します。<br>
<b>構文</b><br><table>
<tr><td>
static List&lt;string&gt; BytesToHexDump(byte[] bytes);<br>
static List&lt;string&gt; BytesToHexDump(byte[] bytes, uint start, uint size);<br>
</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>bytes</td><td>ダンプ対象のバイト配列を指定します。</td></tr>
<tr><td>start</td><td>0から始まるダンプの開始位置を指定します。</td></tr>
<tr><td>size</td><td>出力するバイト数を指定します。</td></tr>
</table></td></tr>

<tr><td>ExceptionToList</td><td>
例外をログ用リストに変換します。<br>
<b>構文</b><br><table>
<tr><td>
static List&lt;string&gt; ExceptionToList(Exception exp);<br>static string MakeCoreMessage(string message, string[] paramList);<br>
</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>exp</td><td>例外を指定します。</td></tr>
</table></td></tr>

<tr><td>FlushAsync</td><td>
キャッシュされたログの書き込みを完了します。<br>
<b>構文</b><br><table>
<tr><td>static async Task FlushAsync();<br></td></tr>
</table></td></tr>

<tr><td>Write</td><td>
ログに情報メッセージを書き込みます。<br>
<b>構文</b><br><table>
<tr><td>
static void Write(String message, LogTypes type = LogTypes.Information);<br>
static void Write(String[] messages, LogTypes type = LogTypes.Information);<br>
static void Write(Exception exp, LogTypes type = LogTypes.Error);<br>
static void Write(List<string> messages, LogTypes type = LogTypes.Information);<br>
</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>exp</td><td>例外を指定します。</td></tr>
<tr><td>message</td><td>メッセージを指定します。</td></tr>
<tr><td>messages</td><td>メッセージリストを指定します。</td></tr>
<tr><td>type</td><td>ログタイプを指定します。</td></tr>
</table></td></tr>

<tr><td>WriteDump</td><td>
ログにバイト配列を16進ダンプとして書き込みます。<br>
<b>構文</b><br><table>
<tr><td>
static void WriteDump(byte[] bytes, LogTypes type = LogTypes.Information);<br>
static void WriteDump(byte[] bytes, uint start, uint size, LogTypes type = LogTypes.Information);<br>
</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>bytes</td><td>ダンプ対象のバイト配列を指定します。</td></tr>
<tr><td>size</td><td>出力するバイト数を指定します。</td></tr>
<tr><td>start</td><td>0から始まるダンプの開始位置を指定します。</td></tr>
<tr><td>type</td><td>ログタイプを指定します。</td></tr>
</table></td></tr>

</table>

## イベント

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>LogWriting</td><td>
ログ出力の内容を通知します。<br>
<b>構文</b><br><table>
<tr><td>static event EventHandler<LogWritingEventArgs> LogWriting;</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>e</td><td>ログ出力の内容を通知するイベントデータです。</td></tr>
<tr><td>sender</td><td>ログ出力の内容を保持している ConcurrentQueue&lt;LoggingData&gt; ロギングバッファです。</td></tr>
</table></td></tr>

</table>

## 関連

- [DateTime クラス](Jaffa.Internal.DateTime.md)
- [LogWritingEventArgs クラス](Jaffa.Diagnostics.Logging.LogWritingEventArgs.md)
- [Settings クラス](Jaffa.Diagnostics.Logging.Settings.md)
- [LoggingModes 列挙型](Jaffa.Diagnostics.Logging.LoggingModes.md)
- [LogTypes 列挙型](Jaffa.Diagnostics.Logging.LogTypes.md)


