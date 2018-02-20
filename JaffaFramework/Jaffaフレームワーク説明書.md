# Jaffaフレームワーク説明書  ver 0.0.2 


## はじめに

Jaffaフレームワークは、Windowsユニバーサルアプリケーション（UWP)とデスクトップアプリケーション(WPF)で
共通に使えるライブラリとして開発しました。

## フレームワークの組み込み方

見た目何も変わりませんが、Jaffaフレームワークを組み込む方法を記載します。

### 提供ファイル

|ファイル|説明|
|---|---|
|JaffaForUWP.dll|Jaffaフレームワーク・UWP版ライブラリ。<br>ユニバーサルアプリケーションへの組み込みおよび固有機能を提供します。|
|JaffaForWPF.dll|Jaffaフレームワーク・WPF版コアライブラリ。<br>デスクトップアプリケーション(WPF)への組み込みおよび固有機能を提供します。|

### UWPアプリケーションの場合

1. 参照設定で JaffaForUWP.dll を追加します。
2. App.xaml.csのコンストラクターの最後に、以下のコードを追加します。
   ```
	// Jaffaフレームワーク開始
	Jaffa.Application.Start();
   ```
3. 各ページのコンストラクタ―内、this.InitializeComponent();の次の行に、以下のコードを追加します。
   ```
	Jaffa.UI.Page.Start(this);
   ```

### WPFアプリケーションの場合

1. 参照設定で JaffaForWPF.dll を追加します。
2. App.xaml.csにコンストラクターを追加して、次のコードを追加します。
   ```
	// Jaffaフレームワーク開始
	Jaffa.Application.Start(this);
   ```
## 提供機能

まだ何もありません。


## リファレンス

[Jaffa 名前空間](Refarence/Jaffa.md)
