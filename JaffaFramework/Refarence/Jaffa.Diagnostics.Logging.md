# Jaffa.Diagnostics.Logging クラス

Logging クラスは、アプリケーションのロギング対応をサポートします。

## 構文

```
public static class Logging : Object
```

## プロパティ

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>LogWriteWaiting</td><td>
ログ出力中断を参照または設定します。trueの場合、メモリ上にバッファリングされます。<br>既定値は true です。<br>
<b>構文</b><br><table>
<tr><td>static bool LogWriteWaiting</td></tr>
</table></td></tr>

<tr><td>MuteLoggingEvent</td><td>
ログ出力時のLoggingイベント無効化を参照または設定します。<br>既定値は false です。<br>
<b>構文</b><br><table>
<tr><td>static bool MuteLoggingEvent</td></tr>
</table></td></tr>

<tr><td>LastFilename</td><td>
最後にログ出力したファイル名を参照します。<br>
<b>構文</b><br><table>
<tr><td>static string LastFilename</td></tr>
</table></td></tr>

</table>

## メソッド

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>Write</td><td>
ログに情報メッセージを書き込みます。<br>
<b>構文</b><br><table>
<tr><td>static void Write(String message);<br>
static void Write(LogTypes type, String message);<br>
static void Write(String[] messages);<br>
static void Write(LogTypes type, String[] messages);<br>
static void Write(List&lt;string&gt; messages);<br>
static void Write(LogTypes type, List&lt;string&gt; messages);<br>
static void Write(Exception exp);<br>
static void Write(LogTypes type, Exception exp);<br></td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>type</td><td>ログタイプを指定します。省略時は LogTypes.Information です。</td></tr>
<tr><td>message</td><td>メッセージを指定します。</td></tr>
<tr><td>messages</td><td>メッセージリストを指定します。</td></tr>
<tr><td>exp</td><td>例外を指定します。</td></tr>
</table></td></tr>

<tr><td>WriteDump</td><td>
ログにバイト配列を16進ダンプとして書き込みます。<br>
<b>構文</b><br><table>
<tr><td>static void WriteDump(byte[] bytes);<br>
static void WriteDump(LogTypes type, byte[] bytes);<br>
static void WriteDump(LogTypes type, byte[] bytes, uint start, uint size);<br></td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>type</td><td>ログタイプを指定します。省略時は LogTypes.Information です。</td></tr>
<tr><td>bytes</td><td>ダンプ対象のバイト配列を指定します。</td></tr>
<tr><td>start</td><td>0から始まるダンプの開始位置を指定します。</td></tr>
<tr><td>size</td><td>出力するバイト数を指定します。</td></tr>
</table></td></tr>

<tr><td>BytesToHexDump</td><td>
バイト配列を16進ダンプに変換します。<br>
<b>構文</b><br><table>
<tr><td>static List&lt;string&gt; BytesToHexDump(byte[] bytes);<br>
static List&lt;string&gt; BytesToHexDump(byte[] bytes, uint start, uint size);<br></td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>bytes</td><td>ダンプ対象のバイト配列を指定します。</td></tr>
<tr><td>start</td><td>0から始まるダンプの開始位置を指定します。</td></tr>
<tr><td>size</td><td>出力するバイト数を指定します。</td></tr>
</table></td></tr>

<tr><td>ExceptionToList</td><td>
例外をログ用リストに変換します。<br>
<b>構文</b><br><table>
<tr><td>static List&lt;string&gt; ExceptionToList(Exception exp);<br>static string MakeCoreMessage(string message, string[] paramList);</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>exp</td><td>例外を指定します。</td></tr>
</table></td></tr>

</table>

## イベント

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>LogWriting</td><td>
ログ出力の内容を通知します。<br>
<b>構文</b><br><table>
<tr><td>delegate void LogWritingHandler(LogWritingEventArgs e);</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>e</td><td>ログ出力の内容を通知するイベントデータです。</td></tr>
</table></td></tr>

</table>

## 関連

- [Settings クラス](Jaffa.Diagnostics.Logging.Settings.md)
- [LogWritingEventArgs クラス](Jaffa.Diagnostics.Logging.LogWritingEventArgs.md)
- [LogTypes 列挙型](Jaffa.Diagnostics.Logging.LogTypes.md)
- [LoggingModes 列挙型](Jaffa.Diagnostics.Logging.LoggingModes.md)

