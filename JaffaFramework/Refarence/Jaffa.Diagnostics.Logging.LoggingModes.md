# Jaffa.Diagnostics.Logging.LoggingModes 列挙型

LoggingModes 列挙型は、ログの動作モードを表します。

## 構文

```
public enum LoggingModes : byte
```

## フィールド

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>None</td><td>ファイルに出力しません。</td></tr>
<tr><td>Size</td><td>指定したサイズを超えたらファイルを切り替えます。ファイル名には(1-2)が入ります。常に1が新しいファイルです。</td></tr>
<tr><td>Day</td><td>日単位でファイルを切り替えます。ファイル名には日(1-31)が入ります。</td></tr>
<tr><td>Week</td><td>週単位でファイルを切り替えます。ファイル名には週(1-7)が入ります。</td></tr>
<tr><td>Month</td><td>月単位でファイルを切り替えます。ファイル名には月(1-12)が入ります。</td></tr>

</table>

