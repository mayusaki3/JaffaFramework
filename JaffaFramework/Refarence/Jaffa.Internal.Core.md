# Jaffa.Internal.Core �N���X

Core �N���X�́AJaffa�t���[�����[�N�̊�{�@�\��񋟂��܂��B

## �\��

```
public static class Core : Object
```
						
## �v���p�e�B

<table><tr><td>���O</td><td>����</td></tr>

<tr><td>Version</td><td>
Jaffa�t���[�����[�N�̃o�[�W�������擾���܂��B<br>
<b>�\��</b><br><table>
<tr><td>static System.Version Version</td></tr>
</table></td></tr>

</table>

## ���\�b�h

<table><tr><td>���O</td><td>����</td></tr>

<tr><td>Initialize</td><td>
�R�A���C�u���������������s���܂��B<br>
Jaffa.Application.Start();����Ă΂�܂��B<br>
<b>�\��</b><br><table>
<tr><td>static void Initialize();</td></tr>
</table></td></tr>

<tr><td>MakeMessage</td><td>
�R�A���C�u���������b�Z�[�W���\�z���܂��B<br>
���̃��\�b�h���Q�Ƃ��郊�\�[�X�́AJaffa�t���[�����[�N���̂��̂ł��B<br>
<b>�\��</b><br><table>
<tr><td>static string MakeMessage(string message);<br>static string MakeMessage(string message, string[] paramList)</td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>message</td><td>���b�Z�[�W���w�肵�܂��B</td></tr>
<tr><td>paramList</td><td>���b�Z�[�W�ɖ��ߍ��ރp�����[�^�̃��X�g���w�肵�܂��B</td></tr>
</table>

<b>�߂�l</b><br><table>
<tr><td>�\�z�������b�Z�[�W�B</td></tr>
</table>

<b>���</b><br><table>
<tr><td>
���b�Z�[�W�́A�e�L�X�g���� {resource-name} �� %paramList-index ���w��ł��܂��B<br>
�p�����[�^�́A�e�L�X�g���� {resource-name} ���w��ł��܂��B<br>
���b�Z�[�W�ƃp�����[�^�́A���ꂼ�ꃊ�\�[�X���Q�Ƃ��Ă���A�P�ɕҏW���܂��B<br>
</td></tr>
</table>

</td></tr>

</table></td></tr>
</table>
