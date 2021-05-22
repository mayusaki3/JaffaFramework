# Jaffa.Diagnostics.LoggingMode 列挙型

LoggingMode 列挙型は、ログの動作モードを表します。

## 構文

```
public enum LoggingMode : byte
```

## フィールド

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>Day</td><td>日単位でファイルを切り替えます。ファイル名には日(01-31)が入ります。</td></tr>
<tr><td>Month</td><td>月単位でファイルを切り替えます。ファイル名には月(01-12)が入ります。</td></tr>
<tr><td>None</td><td>ファイルに出力しません。</td></tr>
<tr><td>Size</td><td>指定したサイズを超えたらファイルを切り替えます。ファイル名には(01-02)が入ります。<br/>常に01が新しいファイルです。</td></tr>
<tr><td>Week</td><td>週単位でファイルを切り替えます。ファイル名には週(01-07)が入ります。</td></tr>

</table>

