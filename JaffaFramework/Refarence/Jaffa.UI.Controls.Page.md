# Jaffa.UI.Controls.Page �N���X

Page �N���X�́AUWP �A�v���P�[�V������ Page �� JaffaFramework �Ƃ����т���A��{�I�ȋ@�\��񋟂��܂��B

## �\��

```
public static class Page : Object
```
						
## ���\�b�h

<table><tr><td>���O</td><td>����</td></tr>

<tr><td>Reload</td><td>
�y�[�W�������[�h���܂��B<br>
<b>�\��</b><br><table>
<tr><td>UWP</td><td>
static void Reload(Windows.UI.Xaml.Controls.Frame frame, Windows.UI.Xaml.Controls.Page page, Preprocess preprocess = null, Postprocess postprocess = null);<br>
</td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>frame</td><td>�����[�h����t���[���̃C���X�^���X���w�肵�܂��B</td></tr>
<tr><td>page</td><td>�����[�h����y�[�W�̃C���X�^���X���w�肵�܂��B</td></tr>
<tr><td>preprocess</td><td>�����[�h�̑O�������w�肵�܂��B</td></tr>
<tr><td>postprocess</td><td>�����[�h�̌㏈�����w�肵�܂��B</td></tr>
</table>

<b>���</b><br><table>
<tr><td>
�w�肵���y�[�W��InitializeComponent�����̏������s���܂��B<br>
�������[�h���̓��O�o�͂��L���b�V�����܂��B��ʂɃ��O��\�����Ă���ꍇ�́Apreprocess / postprocess �őޔ�����ѕ������Ă��������B<br>
���e�q�֌W�̃y�[�W�ɂ��Ă��č쐬����܂����A��x�\�����Ȃ��ƃA�����[�h����܂���B�����[�h�O�Ɉ�x�\�����s���Ă��������B
</td></tr>
</table>

</td></tr>

<tr><td>Start</td><td>
Jaffa�t���[�����[�N�Ƀy�[�W�J�n��ʒm���܂��B<br>
InitializeComponent�̑O�Ɏ��s����K�v������܂��B<br>
<b>�\��</b><br><table>
<tr><td>UWP</td><td>
static void Start(Windows.UI.Xaml.Controls.Page page);<br>
</td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>page</td><td>Jaffa�t���[�����[�N�𗘗p����y�[�W�̃C���X�^���X���w�肵�܂��B</td></tr>
</table></td></tr>

</table>

## �C�x���g

<table><tr><td>���O</td><td>����</td></tr>

<tr><td>Creating</td><td>
�y�[�W�C���X�^���X���������ꂽ���Ƃ�ʒm���܂��B<br>
<b>�\��</b><br><table>
<tr><td>UWP</td><td>static event EventHandler&lt;EventArgs&gt; Creating;</td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>e</td><td>����̃C�x���g�f�[�^�ł��B</td></tr>
<tr><td>sender</td><td>�������ꂽ Windows.UI.Xaml.Controls.Page �I�u�W�F�N�g�ł��B</td></tr>
</table></td></tr>

</table>

## �t�@���N�V����

<table><tr><td>���O</td><td>����</td></tr>

<tr><td>Preprocess</td><td>
�����[�h�̑O�������s���܂��B�ꎞ�I�ȏ��̑ޔ��ȂǂɎg�p���܂��B<br>
<b>�e���v���[�g</b><br><table>
<tr><td>UWP</td><td>delegate void Preprocess(Windows.UI.Xaml.Controls.Frame frame, Windows.UI.Xaml.Controls.Page page);</td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>frame</td><td>�����[�h����t���[���̃C���X�^���X�ł��B</td></tr>
<tr><td>page</td><td>�����[�h����y�[�W�̃C���X�^���X�ł��B</td></tr>
</table></td></tr>

<tr><td>Postprocess</td><td>
�����[�h�̌㏈�����s���܂��B�ꎞ�I�ȏ��̕����ȂǂɎg�p���܂��B<br>
<b>�e���v���[�g</b><br><table>
<tr><td>UWP</td><td>delegate void Postprocess(Windows.UI.Xaml.Controls.Frame frame, Windows.UI.Xaml.Controls.Page page);</td></tr>
</table><b>�p�����[�^�[</b><br><table>
<tr><td>frame</td><td>�����[�h�����t���[���̃C���X�^���X�ł��B</td></tr>
<tr><td>page</td><td>�����[�h�����y�[�W�̃C���X�^���X�ł��B</td></tr>
</table></td></tr>

</table>
