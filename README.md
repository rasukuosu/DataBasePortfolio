# DataBasePortfolio（アニメ制作会社、企業名・社長名管理ソフト）
# 概要
　各アニメーション制作会社の情報を管理する、シンプルなDataBaseソフト。
# 開発背景
## 製作期間
　2025/8~2026/2（６か月程度）  
　manabyでの訓練とは別に個人学習の一環として制作しました。
## 製作中の目標とできるようになったこと
### 目標
　manabyでの訓練を行いながら、最低限動作を確認できるものを完成させること。
### できるようになったこと
1. MVVMパターンの学習と実践。
2. EFCoreによるSeedingやMigrate()などの制御。
3. 公式ドキュメントやWebページ、Geminiなどを使ってエラーの原因を理解し、複雑なところはブログで整理すること。
4. manabyでの訓練を日中に行ったうえで体調を維持しながら、少しずつ自宅で開発を続けること。
# 使用環境
![WPF](https://img.shields.io/badge/WPF-5C2D91?style=for-the-badge&logo=dotnet&logoColor=white)
![XAML](https://img.shields.io/badge/XAML-0C619E?style=for-the-badge&logo=visual-studio&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)   
.net8(C#12)  
![SQLite](https://img.shields.io/badge/Sqlite-003B57?style=for-the-badge&logo=sqlite&logoColor=white)  
Microsoft.Data.Sqlite 9.09  
![EF Core](https://img.shields.io/badge/Entity%20Framework%20Core-0F72B0?style=for-the-badge&logo=dotnet&logoColor=white)  
Microsoft.EntityFrameworkCore.Sqlite 9.0.10  
![CommunityToolkit.Mvvm](https://img.shields.io/badge/CommunityToolkit.Mvvm-0078D4?style=for-the-badge&logo=microsoft&logoColor=white)  
CommunityToolkit.Mvvm 8.4.0  
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91?style=for-the-badge&logo=visual-studio&logoColor=white)   
VisualStudio2026 Community 18.2.2

# ソフト紹介
## 基本機能
### Create
  CompanyとPresidentのTextBoxに社名と社長名を入れ、Createボタンを押すことで登録。
  ![Image](https://github.com/user-attachments/assets/82df6945-9fb6-4f0d-ae56-9172e6622cb4)
  テキストボックスが空欄の場合
  ![Image](https://github.com/user-attachments/assets/82df6945-9fb6-4f0d-ae56-9172e6622cb4)
### Read  
  Readボタンを押して最新のDB内容を取得し、DataGrid内に表示。
### Update  
  DataGrid内の変更したい行を選択し、CompanyとPresidentのTextBoxの内容を変更し、Updateボタンで更新。
  ![Image](https://github.com/user-attachments/assets/73e77426-375f-4ba0-ae18-405b5246b37d)
### Delete
  DataGrid内の変更したい行を選択し、Deleteボタンを押下、確認ウィンドウで指定文字列をうち、確定ボタンを押下。これによりDataGridの行が削除される。  
  
  ![Image](https://github.com/user-attachments/assets/a540e73f-4036-4b8c-a556-3465a95a3f46)
## こだわり
### 機能面
#### 1. Delete時の確認処理
Deleteをする際、確認のためのValidation機能をつけたこと。誤って行を消してしまう事故をふせぐ。
#### 2. DataGridの即時表示更新
ObservableCollectionはコレクション全体が削除や追加によって変化しないと変更通知を出さないが、Model側のTableをObservableObjectにしてプロパティに変更通知機能をもたせることで、UpdateでもDataGridの表示内容の更新を実現した。
#### 3. CompanyVMのコンストラクタチェイニング
Window.DataContextは引数のないコンストラクタしか呼ぶことができないが、コンストラクタチェイニングを行うことで引数をもつ初期化のされたCompanyVMのインスタンスを作成することができる。
### 制作面
昨年8月から2026年の2月まで、6ヶ月
# ブログ
https://blog.hatena.ne.jp/neatTanaka/neattanaka.hatenablog.com/
