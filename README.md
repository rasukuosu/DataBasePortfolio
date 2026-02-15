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
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![SQLite](https://img.shields.io/badge/Sqlite-003B57?style=for-the-badge&logo=sqlite&logoColor=white)
![EF Core](https://img.shields.io/badge/Entity%20Framework%20Core-0F72B0?style=for-the-badge&logo=dotnet&logoColor=white)
![WPF](https://img.shields.io/badge/WPF-5C2D91?style=for-the-badge&logo=dotnet&logoColor=white)
![CommunityToolkit.Mvvm](https://img.shields.io/badge/CommunityToolkit.Mvvm-0078D4?style=for-the-badge&logo=microsoft&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91?style=for-the-badge&logo=visual-studio&logoColor=white)
![XAML](https://img.shields.io/badge/XAML-0C619E?style=for-the-badge&logo=visual-studio&logoColor=white)
# ソフト紹介
## 基本機能
###Create
　CompanyとPresidentのTextBoxに社名と社長名を入れ、Createボタンを押すことで登録。
###Read  
  Readボタンを押して最新のDB内容を取得し、DataGrid内に表示。
###Update  
  DataGrid内の変更したい行を選択し、CompanyとPresidentのTextBoxの内容を変更し、Updateボタンで更新。
###Delete
  DataGrid内の変更したい行を選択し
## こだわり
## Acknowledgments
- Badges: [markdown-badges](https://github.com/Ileriayo/markdown-badges) by Ileriayo
