# Jaffa�t���[�����[�N������  ver 0.0.2 


## �͂��߂�

Jaffa�t���[�����[�N�́AWindows���j�o�[�T���A�v���P�[�V�����iUWP)�ƃf�X�N�g�b�v�A�v���P�[�V����(WPF)��
���ʂɎg���郉�C�u�����Ƃ��ĊJ�����܂����B

## �t���[�����[�N�̑g�ݍ��ݕ�

�����ډ����ς��܂��񂪁AJaffa�t���[�����[�N��g�ݍ��ޕ��@���L�ڂ��܂��B

### �񋟃t�@�C��

|�t�@�C��|����|
|---|---|
|JaffaForUWP.dll|Jaffa�t���[�����[�N�EUWP�Ń��C�u�����B<br>���j�o�[�T���A�v���P�[�V�����ւ̑g�ݍ��݂���ьŗL�@�\��񋟂��܂��B|
|JaffaForWPF.dll|Jaffa�t���[�����[�N�EWPF�ŃR�A���C�u�����B<br>�f�X�N�g�b�v�A�v���P�[�V����(WPF)�ւ̑g�ݍ��݂���ьŗL�@�\��񋟂��܂��B|

### UWP�A�v���P�[�V�����̏ꍇ

1. �Q�Ɛݒ�� JaffaForUWP.dll ��ǉ����܂��B
2. App.xaml.cs�̃R���X�g���N�^�[�̍Ō�ɁA�ȉ��̃R�[�h��ǉ����܂��B
   ```
	// Jaffa�t���[�����[�N�J�n
	Jaffa.Application.Start();
   ```
3. �e�y�[�W�̃R���X�g���N�^�\���Athis.InitializeComponent();�̎��̍s�ɁA�ȉ��̃R�[�h��ǉ����܂��B
   ```
	Jaffa.UI.Page.Start(this);
   ```

### WPF�A�v���P�[�V�����̏ꍇ

1. �Q�Ɛݒ�� JaffaForWPF.dll ��ǉ����܂��B
2. App.xaml.cs�ɃR���X�g���N�^�[��ǉ����āA���̃R�[�h��ǉ����܂��B
   ```
	// Jaffa�t���[�����[�N�J�n
	Jaffa.Application.Start(this);
   ```
## �񋟋@�\

�܂���������܂���B


## ���t�@�����X

[Jaffa ���O���](Refarence/Jaffa.md)
