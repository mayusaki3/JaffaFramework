# Jaffa.Diagnostics.Logging クラス

Logging クラスは、ロギング機能をサポートします。

## 構文

```
static class Logging
```

## プロパティ

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>LastFilename</td><td>
最後にログ出力したファイル名を参照します。<br>
<b>構文</b><br><table>
<tr><td>static string LastFilename { get; }</td></tr>
</table></td></tr>

<tr><td>LogWriteWaiting</td><td>
ログ出力中断を参照または設定します。<br>
既定値は true ですので、必要な初期化が終わったら false に設定して解除してください。<br>
trueの場合、メモリ上にバッファリングされます。<br>
<b>構文</b><br><table>
<tr><td>static bool LogWriteWaiting { get; set; }</td></tr>
</table></td></tr>

<tr><td>MuteLoggingEvent</td><td>
ログ出力時のLoggingイベント無効化を参照または設定します。既定値は false です。<br>
<b>構文</b><br><table>
<tr><td>static bool MuteLoggingEvent { get; set; }</td></tr>
</table></td></tr>

<tr><td>SysLogWriteWaiting</td><td>
ログ出力中断を参照または設定します。既定値は false です。<br>
Jaffaフレームワーク内で使用します。<br>
<b>構文</b><br><table>
<tr><td>static bool SysLogWriteWaiting { get; set; }</td></tr>
</table></td></tr>

<tr><td>WriteQueueCount</td><td>
ログ書き込みキューイング数を参照します。<br>
<b>構文</b><br><table>
<tr><td>static int WriteQueueCount { get; }</td></tr>
</table></td></tr>

</table>

## メソッド

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>BytesToHexDump</td><td>
バイト配列を16進ダンプに変換します。<br>
<b>構文</b><br><table>
<tr><td>
static List<string> BytesToHexDump(byte[] bytes);<br>
static List<string> BytesToHexDump(byte[] bytes, uint start, uint size);<br>
</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>bytes</td><td>ダンプ対象のバイト配列を指定します。</td></tr>
<tr><td>start</td><td>0から始まるダンプの開始位置を指定します。</td></tr>
<tr><td>size</td><td>出力するバイト数を指定します。</td></tr>
</table><b>戻り値</b><br><table>
<tr><td>16進ダンプのリスト。</td><td>
</td></tr>
</table></td></tr>

<tr><td>ExceptionToList</td><td>
例外をログ用リストに変換します。<br>
<b>構文</b><br><table>
<tr><td>
static List<string> ExceptionToList(Exception exp);<br>
</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>exp</td><td>例外クラスのインスタンスを指定します。</td></tr>
</table><b>戻り値</b><br><table>
<tr><td>例外メッセージのリスト。</td><td>
</td></tr>
</table></td></tr>

<tr><td>FlushAsync</td><td>
キャッシュされたログの書き込みを完了します。<br>

<b>構文</b><br><table>
<tr><td>
static async Task FlushAsync();<br>
</td></tr>
</table><b>戻り値</b><br><table>
<tr><td>スレッドキューで実行するためにキューに配置された作業を表すタスク。</td><td>
</td></tr>
</table></td></tr>

<tr><td>Write</td><td>
ログにメッセージを書き込みます。<br>
<b>構文</b><br><table>
<tr><td>
static void Write(String message = "", LogType type = LogType.Information);<br>
static void Write(List<string> messages, LogType type = LogType.Information);<br>
static void Write(String[] messages, LogType type = LogType.Information);<br>
static void Write(Exception exp, LogType type = LogType.Error);<br>
</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>exp</td><td>出力する例外クラスのインスタンスを指定します。</td></tr>
<tr><td>message</td><td>出力するメッセージを指定します。</td></tr>
<tr><td>messages</td><td>出力するメッセージのリストまたは配列を指定します。</td></tr>
<tr><td>type</td><td>ログタイプを指定します。</td></tr>
</table></td></tr>

<tr><td>WriteDump</td><td>
ログにバイト配列を16進ダンプとして書き込みます。<br>
<b>構文</b><br><table>
<tr><td>
static void WriteDump(byte[] bytes, LogType type = LogType.Information);<br>
static void WriteDump(byte[] bytes, uint start, uint size, LogType type = LogType.Information);<br>
</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>bytes</td><td>ダンプ対象のバイト配列を指定します。</td></tr>
<tr><td>start</td><td>0から始まるダンプの開始位置を指定します。</td></tr>
<tr><td>size</td><td>出力するバイト数を指定します。</td></tr>
<tr><td>type</td><td>ログタイプを指定します。</td></tr>
</table></td></tr>

</table>

## イベント

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>LogWriting</td><td>
CurrentCultureが変更されたことを通知します。<br>
<b>構文</b><br><table>
<tr><td>static event EventHandler<LogWritingEventArgs> LogWriting;</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>sender</td><td>ロギングバッファオブジェクトです。</td></tr>
<tr><td>e</td><td>LogWritingEventArgs イベントデータです。</td></tr>
</table></td></tr>

</table>

