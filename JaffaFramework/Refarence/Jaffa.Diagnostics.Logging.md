# Jaffa.Diagnostics.Logging �N���X

Logging �N���X�́A�A�v���P�[�V�����̃��M���O�Ή����T�|�[�g���܂��B

## �\��

```
public static class Logging : Object
```

## �v���p�e�B

<table><tr><td>���O</td><td>����</td></tr>

<tr><td>LogWriteWaiting</td><td>
���O�o�͒��f���Q�Ƃ܂��͐ݒ肵�܂��Btrue�̏ꍇ�A��������Ƀo�b�t�@�����O����܂��B<br>����l�� true �ł��B<br>
<b>�\��</b><br><table>
<tr><td>static bool LogWriteWaiting</td></tr>
</table></td></tr>

<tr><td>MuteLoggingEvent</td><td>
���O�o�͎���Logging�C�x���g���������Q�Ƃ܂��͐ݒ肵�܂��B<br>����l�� false �ł��B<br>
<b>�\��</b><br><table>
<tr><td>static bool MuteLoggingEvent</td></tr>
</table></td></tr>

<tr><td>LastFilename</td><td>
�Ō�Ƀ��O�o�͂����t�@�C�������Q�Ƃ��܂��B<br>
<b>�\��</b><br><table>
<tr><td>static string LastFilename</td></tr>
</table></td></tr>

</table>

## ���\�b�h

<table><tr><td>���O</td><td>����</td></tr>

<tr><td>Write</td><td>
���O�ɏ�񃁃b�Z�[�W���������݂܂��B<br>
<b>�\��</b><br><table>
<tr><td>static void Write(String message);<br>
static void Write(LogTypes type, String message);<br>
static void Write(String[] messages);<br>
static void Write(LogTypes type, String[] messages);<br>
static void Write(List&lt;string&gt; messages);<br>
static void Write(LogTypes type, List&lt;string&gt; messages);<br>
static void Write(Exception exp);<br>
static void Write(LogTypes type, Exception exp);<br></td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>type</td><td>���O�^�C�v���w�肵�܂��B�ȗ����� LogTypes.Information �ł��B</td></tr>
<tr><td>message</td><td>���b�Z�[�W���w�肵�܂��B</td></tr>
<tr><td>messages</td><td>���b�Z�[�W���X�g���w�肵�܂��B</td></tr>
<tr><td>exp</td><td>��O���w�肵�܂��B</td></tr>
</table></td></tr>

<tr><td>WriteDump</td><td>
���O�Ƀo�C�g�z���16�i�_���v�Ƃ��ď������݂܂��B<br>
<b>�\��</b><br><table>
<tr><td>static void WriteDump(byte[] bytes);<br>
static void WriteDump(LogTypes type, byte[] bytes);<br>
static void WriteDump(LogTypes type, byte[] bytes, uint start, uint size);<br></td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>type</td><td>���O�^�C�v���w�肵�܂��B�ȗ����� LogTypes.Information �ł��B</td></tr>
<tr><td>bytes</td><td>�_���v�Ώۂ̃o�C�g�z����w�肵�܂��B</td></tr>
<tr><td>start</td><td>0����n�܂�_���v�̊J�n�ʒu���w�肵�܂��B</td></tr>
<tr><td>size</td><td>�o�͂���o�C�g�����w�肵�܂��B</td></tr>
</table></td></tr>

<tr><td>BytesToHexDump</td><td>
�o�C�g�z���16�i�_���v�ɕϊ����܂��B<br>
<b>�\��</b><br><table>
<tr><td>static List&lt;string&gt; BytesToHexDump(byte[] bytes);<br>
static List&lt;string&gt; BytesToHexDump(byte[] bytes, uint start, uint size);<br></td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>bytes</td><td>�_���v�Ώۂ̃o�C�g�z����w�肵�܂��B</td></tr>
<tr><td>start</td><td>0����n�܂�_���v�̊J�n�ʒu���w�肵�܂��B</td></tr>
<tr><td>size</td><td>�o�͂���o�C�g�����w�肵�܂��B</td></tr>
</table></td></tr>

<tr><td>ExceptionToList</td><td>
��O�����O�p���X�g�ɕϊ����܂��B<br>
<b>�\��</b><br><table>
<tr><td>static List&lt;string&gt; ExceptionToList(Exception exp);<br>static string MakeCoreMessage(string message, string[] paramList);</td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>exp</td><td>��O���w�肵�܂��B</td></tr>
</table></td></tr>

</table>

## �C�x���g

<table><tr><td>���O</td><td>����</td></tr>

<tr><td>LogWriting</td><td>
���O�o�͂̓��e��ʒm���܂��B<br>
<b>�\��</b><br><table>
<tr><td>delegate void LogWritingHandler(LogWritingEventArgs e);</td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>e</td><td>���O�o�͂̓��e��ʒm����C�x���g�f�[�^�ł��B</td></tr>
</table></td></tr>

</table>

## �֘A

- [Settings �N���X](Jaffa.Diagnostics.Logging.Settings.md)
- [LogWritingEventArgs �N���X](Jaffa.Diagnostics.Logging.LogWritingEventArgs.md)
- [LogTypes �񋓌^](Jaffa.Diagnostics.Logging.LogTypes.md)
- [LoggingModes �񋓌^](Jaffa.Diagnostics.Logging.LoggingModes.md)

