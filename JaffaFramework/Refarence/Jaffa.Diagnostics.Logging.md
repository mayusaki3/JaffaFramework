# Jaffa.Diagnostics.Logging �N���X

Logging �N���X�́A�A�v���P�[�V�����̃��M���O�Ή����T�|�[�g���܂��B<br>
���O�̎����� Jaffa.Internal.DateTime �N���X�̌��ݎ����ł��BWPF�ł̓��O�t�@�C���̎�����Jaffa.Internal.DateTime �N���X�̌��ݎ����ɐݒ肳��܂����AUWP�ł͎��ۂ̎����̂܂܂ł��B

## �\��

```
public static class Logging : Object
```

## �v���p�e�B

<table><tr><td>���O</td><td>����</td></tr>

<tr><td>LastFilename</td><td>
�Ō�Ƀ��O�o�͂����t�@�C�������Q�Ƃ��܂��B<br>
<b>�\��</b><br><table>
<tr><td>static string LastFilename { get; }</td></tr>
</table></td></tr>

<tr><td>LogWriteWaiting</td><td>
���O�o�͒��f���Q�Ƃ܂��͐ݒ肵�܂��Btrue�̏ꍇ�A��������Ƀo�b�t�@�����O����܂��B<br>����l�� true �ł��B<br>
<b>�\��</b><br><table>
<tr><td>static bool LogWriteWaiting { get; set; }</td></tr>
</table></td></tr>

<tr><td>MuteLoggingEvent</td><td>
���O�o�͎���Logging�C�x���g���������Q�Ƃ܂��͐ݒ肵�܂��B<br>����l�� false �ł��B<br>
<b>�\��</b><br><table>
<tr><td>static bool MuteLoggingEvent { get; set; }</td></tr>
</table></td></tr>

</table>

## ���\�b�h

<table><tr><td>���O</td><td>����</td></tr>

<tr><td>BytesToHexDump</td><td>
�o�C�g�z���16�i�_���v�ɕϊ����܂��B<br>
<b>�\��</b><br><table>
<tr><td>
static List&lt;string&gt; BytesToHexDump(byte[] bytes);<br>
static List&lt;string&gt; BytesToHexDump(byte[] bytes, uint start, uint size);<br>
</td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>bytes</td><td>�_���v�Ώۂ̃o�C�g�z����w�肵�܂��B</td></tr>
<tr><td>start</td><td>0����n�܂�_���v�̊J�n�ʒu���w�肵�܂��B</td></tr>
<tr><td>size</td><td>�o�͂���o�C�g�����w�肵�܂��B</td></tr>
</table></td></tr>

<tr><td>ExceptionToList</td><td>
��O�����O�p���X�g�ɕϊ����܂��B<br>
<b>�\��</b><br><table>
<tr><td>
static List&lt;string&gt; ExceptionToList(Exception exp);<br>static string MakeCoreMessage(string message, string[] paramList);<br>
</td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>exp</td><td>��O���w�肵�܂��B</td></tr>
</table></td></tr>

<tr><td>FlushAsync</td><td>
�L���b�V�����ꂽ���O�̏������݂��������܂��B<br>
<b>�\��</b><br><table>
<tr><td>static async Task FlushAsync();<br></td></tr>
</table></td></tr>

<tr><td>Write</td><td>
���O�ɏ�񃁃b�Z�[�W���������݂܂��B<br>
<b>�\��</b><br><table>
<tr><td>
static void Write(String message, LogTypes type = LogTypes.Information);<br>
static void Write(String[] messages, LogTypes type = LogTypes.Information);<br>
static void Write(Exception exp, LogTypes type = LogTypes.Error);<br>
static void Write(List<string> messages, LogTypes type = LogTypes.Information);<br>
</td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>exp</td><td>��O���w�肵�܂��B</td></tr>
<tr><td>message</td><td>���b�Z�[�W���w�肵�܂��B</td></tr>
<tr><td>messages</td><td>���b�Z�[�W���X�g���w�肵�܂��B</td></tr>
<tr><td>type</td><td>���O�^�C�v���w�肵�܂��B</td></tr>
</table></td></tr>

<tr><td>WriteDump</td><td>
���O�Ƀo�C�g�z���16�i�_���v�Ƃ��ď������݂܂��B<br>
<b>�\��</b><br><table>
<tr><td>
static void WriteDump(byte[] bytes, LogTypes type = LogTypes.Information);<br>
static void WriteDump(byte[] bytes, uint start, uint size, LogTypes type = LogTypes.Information);<br>
</td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>bytes</td><td>�_���v�Ώۂ̃o�C�g�z����w�肵�܂��B</td></tr>
<tr><td>size</td><td>�o�͂���o�C�g�����w�肵�܂��B</td></tr>
<tr><td>start</td><td>0����n�܂�_���v�̊J�n�ʒu���w�肵�܂��B</td></tr>
<tr><td>type</td><td>���O�^�C�v���w�肵�܂��B</td></tr>
</table></td></tr>

</table>

## �C�x���g

<table><tr><td>���O</td><td>����</td></tr>

<tr><td>LogWriting</td><td>
���O�o�͂̓��e��ʒm���܂��B<br>
<b>�\��</b><br><table>
<tr><td>static event EventHandler<LogWritingEventArgs> LogWriting;</td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>e</td><td>���O�o�͂̓��e��ʒm����C�x���g�f�[�^�ł��B</td></tr>
<tr><td>sender</td><td>���O�o�͂̓��e��ێ����Ă��� ConcurrentQueue&lt;LoggingData&gt; ���M���O�o�b�t�@�ł��B</td></tr>
</table></td></tr>

</table>

## �֘A

- [DateTime �N���X](Jaffa.Internal.DateTime.md)
- [LogWritingEventArgs �N���X](Jaffa.Diagnostics.Logging.LogWritingEventArgs.md)
- [Settings �N���X](Jaffa.Diagnostics.Logging.Settings.md)
- [LoggingModes �񋓌^](Jaffa.Diagnostics.Logging.LoggingModes.md)
- [LogTypes �񋓌^](Jaffa.Diagnostics.Logging.LogTypes.md)


