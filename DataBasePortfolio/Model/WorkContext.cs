using DataBasePortfolio;
using DataBasePortfolio.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBasePortfolio.Model
{
    internal class WorkContext : DbContext
    {
        public DbSet<Work> Works { get; set; } //DBの項目をマッピング

        // ユーザー個別のアプリデータ保存先（AppData/Local）にフォルダとファイルパスを設定,dbファイルを作成
        private readonly string dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "DataBasePortfolio",
            "works.db");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 実際に接続する前に、保存先フォルダが存在するか確認し、なければ作成する
            string directoryPath = Path.GetDirectoryName(dbPath);
            if (!string.IsNullOrEmpty(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            optionsBuilder.UseSqlite($"Data Source={dbPath}") // 実際に使うDBの構築
                                                              // DBの初期データ投入列がnullの時のみ、seedingを実行
                .UseSeeding((context, _) =>
                {
                    var Works = context.Set<Work>().FirstOrDefault(w => w.WorkName == "オープニングタイトル"); //データベースがdefaultの状態か確かめるための行
                    if (Works == null)
                    {
                        context.Set<Work>().Add(new Work{ WorkName = "オープニングタイトル", Author = "サンプル描男" });
                        context.SaveChanges();
                    }
                })
                .UseAsyncSeeding(async (context, _, cancellationToken) =>
                {
                    var Works = await context.Set<Work>().FirstOrDefaultAsync(w => w.WorkName == "オープニングタイトル", cancellationToken);
                    if (Works == null)
                    {
                        // 非同期Addを実行
                        await context.Set<Work>().AddAsync(new Work { WorkName = "オープニングタイトル", Author = "サンプル描男" }, cancellationToken);
                        await context.SaveChangesAsync(cancellationToken);
                    }
                });
        }

        // インデックスを使わないでテーブルに制約を書ける場合
        // protected override void OnModelCreating(ModelBuilder modelBuilder) 
        // {
        //     modelBuilder.Entity<Company>().ToTable("Companys");
        // }
    }
}
