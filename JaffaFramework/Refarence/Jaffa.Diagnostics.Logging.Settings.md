# Jaffa.Diagnostics.Logging.Settings �N���X

Settings �N���X�́A���M���O�@�\�̐ݒ��ێ����܂��B

## �\��

```
public static class Settings : Object
```

## �v���p�e�B

<table><tr><td>���O</td><td>����</td></tr>

<tr><td>FileName</td><td>
���O�t�@�C�������Q�Ƃ܂��͐ݒ肵�܂��B<br>
�t�@�C������'[@]'�̕�����LoggingMode�ɍ��킹�ĕω����A<br>
Size�̏ꍇ��1�`2,<br>
Day�̏ꍇ��1�`31,<br>
Week�̏ꍇ��1�`7,<br>
Month�̏ꍇ��1�`12�̒l�����܂��B<br>
����l��"applog[@].txt"�ł��B<br>
<b>�\��</b><br><table>
<tr><td>static string FileName</td></tr>
</table></td></tr>

<tr><td>Folder</td><td>
���O�o�͐�t�H���_���Q�Ƃ܂��͐ݒ肵�܂��B<br>
����l��""�ł��B<br>
<b>�\��</b><br><table>
<tr><td>static string Folder</td></tr>
</table></td></tr>

<tr><td>LoggingMode</td><td>
���M���O���[�h���Q�Ƃ܂��͐ݒ肵�܂��B<br>
����l��LoggingModes.None�ł��B<br>
<b>�\��</b><br><table>
<tr><td>static LoggingModes LoggingMode</td></tr>
</table></td></tr>

<tr><td>MaxFileSizeKB</td><td>
���O�t�@�C���T�C�Y������Q�Ƃ܂��͐ݒ肵�܂��B<br>
2�`32767�͈̔�(�P��KByte)�Ŏw�肵�A�͈͊O�̏ꍇ�͎����������܂��B<br>
LoggingMode��Size�̏ꍇ�ɗL���ŁA�T�C�Y�𒴂����1����̂݃o�b�N�A�b�v���쐬���܂��B<br>
����l��2048�ł��B<br>
<b>�\��</b><br><table>
<tr><td>static int MaxFileSizeKB</td></tr>
</table></td></tr>

</table>

## �֘A

- [LoggingModes �񋓌^](Jaffa.Diagnostics.Logging.LoggingModes.md)

