# Jaffa.DateTime クラス

DateTime クラスは、DateTimeの拡張機能をサポートします。

## 構文

```
public class DateTime
```

## プロパティ

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>DifferenceNow</td><td>
現在時刻のオフセット値を参照または設定または設定します。<br>
<b>構文</b><br><table>
<tr><td>static System.TimeSpan DifferenceNow { get; set; }</td></tr>
</table></td></tr>

<tr><td>Now</td><td>
オフセットされた現在時刻を参照します。<br>
<b>構文</b><br><table>
<tr><td>static System.DateTime Now { get; }</td></tr>
</table></td></tr>

</table>

## メソッド

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>CalcDifferenceNow</td><td>
現在時刻とのオフセット値を設定します。<br>
<b>構文</b><br><table>
<tr><td>
static void CalcDifferenceNow(System.DateTime reference);<br>
</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>
reference</td><td>基準時刻を指定します。<br>
</td></tr>
</table></td></tr>

</table>
