using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataBasePortfolio.Model
{
    class CompanyContext : DbContext
    {
        public DbSet<Company> Companys { get; set; } //DBの項目をマッピング

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //実際に使うDBの構築
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "company.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
           
        }
    }
}
