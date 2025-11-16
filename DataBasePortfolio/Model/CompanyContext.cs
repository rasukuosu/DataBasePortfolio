using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataBasePortfolio.Migrations;

namespace DataBasePortfolio.Model
{
    class CompanyContext : DbContext
    {
        public DbSet<Company> Companys { get; set; } //DBの項目をマッピング
        string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "company.db");
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder //実際に使うDBの構築


        .UseSqlite($"Data Source={dbPath}")
        //DBの初期データ投入列がnullの時のみ、seedingを実行
        .UseSeeding((context, _) =>
            {
            var Companys = context.Set<Company>().FirstOrDefault(c => c.CompanyName == "サンプルアニメ制作会社");
            if (Companys == null) {
                context.Set<Company>().Add(new Company { CompanyName = "サンプルアニメ制作会社", President = "サンプル描美" });
                context.SaveChanges();
            }
        })
        .UseAsyncSeeding(async(context, _, cancellationToken) =>
            {
            var Companys = await context.Set<Company>().FirstOrDefaultAsync(c => c.CompanyName == "サンプルアニメ制作会社", cancellationToken);
                if (Companys == null)
                {
                    context.Set<Company>().AddAsync(new Company { CompanyName = "サンプルアニメ制作会社", President = "サンプル描美" });
                    await context.SaveChangesAsync(cancellationToken);

                }

            });
        }
} 

