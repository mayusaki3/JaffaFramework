# Jaffa.Diagnostics.Logging.Settings クラス

Settings クラスは、ロギング機能の設定を保持します。

## 構文

```
public static class Settings : Object
```

## プロパティ

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>FileName</td><td>
ログファイル名を参照または設定します。<br>
ファイル名の'[@]'の部分はLoggingModeに合わせて変化し、<br>
Sizeの場合は1～2,<br>
Dayの場合は1～31,<br>
Weekの場合は1～7,<br>
Monthの場合は1～12の値を取ります。<br>
既定値は"applog[@].txt"です。<br>
<b>構文</b><br><table>
<tr><td>static string FileName</td></tr>
</table></td></tr>

<tr><td>Folder</td><td>
ログ出力先フォルダを参照または設定します。<br>
既定値は""です。<br>
<b>構文</b><br><table>
<tr><td>static string Folder</td></tr>
</table></td></tr>

<tr><td>LoggingMode</td><td>
ロギングモードを参照または設定します。<br>
既定値はLoggingModes.Noneです。<br>
<b>構文</b><br><table>
<tr><td>static LoggingModes LoggingMode</td></tr>
</table></td></tr>

<tr><td>MaxFileSizeKB</td><td>
ログファイルサイズ上限を参照または設定します。<br>
2～32767の範囲(単位KByte)で指定し、範囲外の場合は自動調整します。<br>
LoggingModeがSizeの場合に有効で、サイズを超えると1世代のみバックアップを作成します。<br>
既定値は2048です。<br>
<b>構文</b><br><table>
<tr><td>static int MaxFileSizeKB</td></tr>
</table></td></tr>

</table>

## 関連

- [LoggingModes 列挙型](Jaffa.Diagnostics.Logging.LoggingModes.md)

