# DataBasePortfolio（アニメ制作会社、企業名・社長名管理ソフト）
# 概要
　アニメーション制作会社の情報をシンプルに管理する、SQLiteベースのデスクトップアプリケーションです。
データ操作（CRUD）に加え、MVVMパターンに基づいた設計を目指し開発しました。
# 利用法
https://github.com/rasukuosu/DataBasePortfolio/releases/tag/v1.0.0
こちらのURLの「DataBasePorffolio_Release_1.0_win-x64.zip」をダウンロードいただき、ZIPファイルを展開のうえ、.exeファイルを実行して頂ければ、利用可能です
# 開発背景
## 製作期間
　2025/8~2026/2（６か月程度）  
　訓練とは別に個人学習の一環として制作しました。限られた時間の中で「継続して形にする」ことを目標としました。
## 製作中の目標とできるようになったこと
### 目標
1.manabyでの訓練を行いながら、体調を安定させつつ最低限動作を確認できるものを完成させること。  
2.Entity Framework Coreを用いたデータベース作成と、C#の復習
### できるようになったこと
1. MVVMパターンの学習と実践。
2. EFCoreによるSeedingやMigrate()などの制御。
3. 公式ドキュメントやWebページ、Geminiなどを使ってエラーの原因を理解し、複雑なところはブログで整理すること。
4. 訓練を日中に行ったうえで体調を維持しながら、少しずつ自宅で開発を続けること。
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
  社名と代表者名を入力しDBへ登録。バリデーション機能により、空欄が含まれる場合の例外を未然に防止。  
  ![Image](https://github.com/user-attachments/assets/02f0e774-6b0c-42af-a30c-49630d2129b5)
  テキストボックスが空欄の場合    
  ![Image](https://github.com/user-attachments/assets/82df6945-9fb6-4f0d-ae56-9172e6622cb4)
### Read  
  Readボタンを押して最新のDB内容を取得してDataGrid内に表示。  
### Update  
  DataGrid内の変更したい行を選択し、CompanyとPresidentのTextBoxの内容を変更。Updateボタンで更新。  
  ![Image](https://github.com/user-attachments/assets/73e77426-375f-4ba0-ae18-405b5246b37d)
### Delete
  DataGrid内の変更したい行を選択し、Deleteボタンを押下、確認ウィンドウで指定文字列をうち、確定ボタンを押下。これによりDataGridの行が削除される。  誤削除を防止するため、確認ウィンドウに特定の文字列を入力させるバリデーションを実装。
  ![Image](https://github.com/user-attachments/assets/a540e73f-4036-4b8c-a556-3465a95a3f46)
## こだわり
### 機能面
#### 1. Delete時の確認処理
単なるボタンクリックではなく、特定の文字列入力を求めることで、重要データ誤削除リスクを抑えました。  
#### 2. DataGridの即時表示更新
ObservableCollection の「要素の増減のみ通知する」という制限を、Model側（Table）に ObservableObject を継承させ SetProperty を実装することで解消。Update時のDataGrid表示への即時反映を実装。  
#### 3. CompanyVMのコンストラクタチェイニング
XAML側（View）の制約により引数付きコンストラクタが直接呼べない問題を、コンストラクタチェイニングを用いることで解決。初期化したコンストラクタとDataBindingを両立させました。  
### 制作面
この６ヶ月間、訓練（VBAエキスパート取得や職場実習の準備、スキーマ療法による自己理解等）をしながら、並行して本アプリの開発を行いました。自身の体調を管理しながら着実に開発を続けることを目指しました。
# ブログ
https://neattanaka.hatenablog.com/

