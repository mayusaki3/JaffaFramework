# Jaffa.Application �N���X

Application �N���X�́AUWP �܂��� WPF �A�v���P�[�V������ JaffaFramework �Ƃ����т���A��{�I�ȋ@�\��񋟂��܂��B

## �\��

```
public static class Application : Object
```
## �v���p�e�B

<table><tr><td>���O</td><td>����</td></tr>

<tr><td>Current</td><td>
�A�v���P�[�V�����C���X�^���X���Q�Ƃ��܂��B<br>
<b>�\��</b><br><table>
<tr><td>UWP</td><td>static Windows.UI.Xaml.Application Current</td></tr>
<tr><td>WPF</td><td>static System.Windows.Application Current</td></tr>
</table></td></tr>

<tr><td>Pages</td><td>
�A�v���P�[�V�����ŃC���X�^���X�����ꂽ�y�[�W���Q�Ƃ��܂��B<br>
<b>�\��</b><br><table>
<tr><td>UWP</td><td>static Windows.UI.Xaml.Controls.Page[] Pages</td></tr>
</table></td></tr>

<tr><td>Resource</td><td>
���\�[�X���[�_�[/�}�l�[�W���[���Q�Ƃ��܂��B<br>
<b>�\��</b><br><table>
<tr><td>UWP</td><td>static Windows.ApplicationModel.Resources.ResourceLoader Resource</td></tr>
<tr><td>WPF</td><td>static System.Resources.ResourceManager Resource</td></tr>
</table></td></tr>

<tr><td>StartupPath</td><td>
�A�v���P�[�V�����̋N���p�X���Q�Ƃ��܂��B<br>
<b>�\��</b><br><table>
<tr><td>WPF</td><td>static string StatupPath</td></tr>
</table></td></tr>

<tr><td>WaitingChangeCulture</td><td>
�A�v���P�[�V�����J���`���[���x���X�V��Ԃ���ݒ�܂��͎Q�Ƃ��܂��B<br>
<b>�\��</b><br><table>
<tr><td>UWP</td><td>static bool WaitingChangeCulture</td></tr>
</table></td></tr>

</table>

## ���\�b�h

<table><tr><td>���O</td><td>����</td></tr>

<tr><td>Start</td><td>
Jaffa�t���[�����[�N�ɃA�v���P�[�V�����J�n��ʒm���܂��B<br>
InitializeComponent�̑O�Ɏ��s����K�v������܂��B<br>
<b>�\��</b><br><table>
<tr><td>UWP</td><td>static void Start(Windows.UI.Xaml.Application app);</td></tr>
<tr><td>WPF</td><td>static void Start(System.Windows.Application app);<br>static void Start(System.Windows.Application app, string resourceName);</td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>app</td><td>Jaffa�t���[�����[�N�𗘗p����A�v���P�[�V�����̃C���X�^���X���w�肵�܂��B</td></tr>
<tr><td>resourceName</td><td>���ۉ��Ή��Ɏg�p���郊�\�[�X�����w�肵�܂��B</td></tr>
</table></td></tr>

</table>

## �C�x���g

<table><tr><td>���O</td><td>����</td></tr>

<tr><td>PageUnloaded</td><td>
�y�[�W�C���X�^���X���A�����[�h���ꂽ���Ƃ�ʒm���܂��B<br>
<b>�\��</b><br><table>
<tr><td>delegate void PageUnloadedHandler(object sender, EventArgs e);</td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>sender</td><td>�A�����[�h���ꂽ Windows.UI.Xaml.Controls.Page �I�u�W�F�N�g�ł��B</td></tr>
<tr><td>e</td><td>����̃C�x���g�f�[�^�ł��B</td></tr>
</table></td></tr>

</table>
