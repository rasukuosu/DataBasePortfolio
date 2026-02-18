using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataBasePortfolio;

namespace DataBasePortfolio.Model
{
    class CompanyContext : DbContext
    {
        public DbSet<Company> Companys { get; set; } //DBの項目をマッピング

        // ユーザー個別のアプリデータ保存先（AppData/Local）にフォルダとファイルパスを設定
        private readonly string dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "DataBasePortfolio", 
            "company.db");

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
                    var Companys = context.Set<Company>().FirstOrDefault(c => c.CompanyName == "サンプルアニメスタジオ");
                    if (Companys == null)
                    {
                        context.Set<Company>().Add(new Company { CompanyName = "サンプルアニメスタジオ", President = "サンプル描美" });
                        context.SaveChanges();
                    }
                })
                .UseAsyncSeeding(async (context, _, cancellationToken) =>
                {
                    var Companys = await context.Set<Company>().FirstOrDefaultAsync(c => c.CompanyName == "サンプルアニメスタジオ", cancellationToken);
                    if (Companys == null)
                    {
                        // 非同期Addを実行
                        await context.Set<Company>().AddAsync(new Company { CompanyName = "サンプルアニメスタジオ", President = "サンプル描美" }, cancellationToken);
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
