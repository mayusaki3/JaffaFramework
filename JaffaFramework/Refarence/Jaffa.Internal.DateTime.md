# Jaffa.Internal.DateTime クラス

DateTime クラスは、Jaffaフレームワークの時刻に関する拡張機能を提供します。

## 構文

```
public static class Core : Object
```
						
## プロパティ

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>DifferenceNow</td><td>
現在時刻のオフセット値を参照または設定または設定します。<br>
<b>構文</b><br><table>
<tr><td>static System.TimeSpan DifferenceNow</td></tr>
</table></td></tr>

<tr><td>Now</td><td>
オフセットされた現在時刻を参照します。<br>
<b>構文</b><br><table>
<tr><td>static System.DateTime Now</td></tr>
</table></td></tr>

</table>

## メソッド

<table><tr><td>名前</td><td>説明</td></tr>

<tr><td>CalcDifferenceNow</td><td>
現在時刻とのオフセット値を設定します。<br>
<b>構文</b><br><table>
<tr><td>static void CalcDifferenceNow(System.DateTime reference);</td></tr>
</table><b>パラメーター</b><br><table>
<tr><td>reference</td><td>基準時刻を指定します。</td></tr>
</table>

<b>解説</b><br><table>
<tr><td>
CalcDifferenceNow を呼び出したタイミングで、Now で返される時刻が基準時刻に設定されます。<br>
System.DateTime.Now の代わりに使用すると、特定の時刻に動作する機能の確認に役立ちます。<br>
</td></tr>
</table>

</td></tr>

</table></td></tr>
</table>
