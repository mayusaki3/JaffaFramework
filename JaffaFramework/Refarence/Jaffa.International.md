# Jaffa.International �N���X

International �N���X�́A�A�v���P�[�V�����̍��ۉ��Ή����T�|�[�g���܂��B

## �\��

```
public static class International
```

## �v���p�e�B

<table><tr><td>���O</td><td>����</td></tr>

<tr><td>CurrentCultureSetting</td><td>
���݂̐ݒ�J���`���[�����擾���܂��B<br>CurrentCulture�v���p�e�B�Ƃ̈Ⴂ�� "Auto" �̗L���ł��B<br>
<b>�\��</b><br><table>
<tr><td>static string CurrentCultureSetting</td></tr>
</table></td></tr>

<tr><td>CurrentCulture</td><td>
���݂̃J���`���[�����Q�Ƃ��܂��B<br>
<b>�\��</b><br><table>
<tr><td>static string CurrentCulture</td></tr>
</table></td></tr>

</table>

## ���\�b�h

<table><tr><td>���O</td><td>����</td></tr>

<tr><td>GetAvailableLanguageList</td><td>
�A�v���P�[�V�����ŗ��p�\�Ȍ��ꃊ�X�g���擾���܂��B<br>
�A�v���P�[�V������ Resources.resw(UWP) / Resources.resx(WPF) �� ������ Dictionarys ��ǉ����A���̂悤�ɃT�|�[�g����{����R�[�h},{���ꖼ} �̍s��ݒ肵�܂��B<br>
<pre>
��. Auto,{DynamicResource CultureAuto}
    en-US,English
    ja-JP,���{��
</pre>���̗�́u{DynamicResource CultureAuto}�v�����́A����R�[�h�̃��\�[�X�Œu�������܂��B<br>
<b>�\��</b><br><table>
<tr><td>static string[] GetAvailableLanguageList();</td></tr>
</table></td></tr>

<tr><td>GetDisplayLanguageName</td><td>
�J���`���[���ɑΉ�����\�������擾���܂��B<br>
<b>�\��</b><br><table>
<tr><td>static string GetDisplayLanguageName(string culture);</td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>culture</td><td>�J���`���[�����w�肵�܂��B</td></tr>
</table></td></tr>

<tr><td>GetResourceCultureName</td><td>
���\�[�X���Dictionary�ɐݒ肳�ꂽ���e����J���`���[�����������A�ł��}�b�`����J���`���[�����擾���܂��B<br>
<b>�\��</b><br><table>
<tr><td>static string GetResourceCultureName(string name);</td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>name</td><td>�}�b�`���O����J���`���[�����w�肵�܂��B</td></tr>
</table></td></tr>

<tr><td>ChangeCultureFromDisplayLanguageName</td><td>
���݂̃J���`���[�����ꖼ�ŕύX���܂��BUWP�A�v���̃y�[�W�L���b�V���̓N���A����܂��B<br>
<b>�\��</b><br><table>
<tr><td>static void ChangeCultureFromDisplayLanguageName(string name);</td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>name</td><td>�\�������w�肵�܂��B</td></tr>
</table></td></tr>

<tr><td>MakeCoreMessage</td><td>
�t���[�����[�N�����b�Z�[�W���\�z���܂��B<br>
���b�Z�[�W�́A�e�L�X�g���� {resource-name} �� %paramList-index ���w��ł��܂��B<br>
�p�����[�^�́A�e�L�X�g���� {resource-name} ���w��ł��܂��B<br>
���b�Z�[�W�ƃp�����[�^�́A���ꂼ�ꃊ�\�[�X���Q�Ƃ��Ă���A�P�ɕҏW���܂��B<br>
<b>�\��</b><br><table>
<tr><td>static string MakeCoreMessage(string message);<br>static string MakeCoreMessage(string message, string[] paramList);</td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>message</td><td>���b�Z�[�W���w�肵�܂��B</td></tr>
<tr><td>paramList</td><td>���b�Z�[�W�ɖ��ߍ��ރp�����[�^�̃��X�g���w�肵�܂��B</td></tr>
</table></td></tr>

</table>

## �C�x���g

<table><tr><td>���O</td><td>����</td></tr>

<tr><td>ChangeCultureEvent</td><td>
CurrentCulture���ύX���ꂽ���Ƃ�ʒm���܂��B<br>
<b>�\��</b><br><table>
<tr><td>delegate void ChangeCultureEventHandler(object sender, EventArgs e);</td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>sender</td><td>currentCulture �I�u�W�F�N�g�ł��B</td></tr>
<tr><td>e</td><td>����̃C�x���g�f�[�^�ł��B</td></tr>
</table></td></tr>

</table>

