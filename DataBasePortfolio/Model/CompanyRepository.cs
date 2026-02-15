using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace DataBasePortfolio.Model
{
    //https://learn.microsoft.com/ja-jp/dotnet/api/microsoft.entityframeworkcore.dbcontext?view=efcore-9.0
    public class CompanyRepository
    {
        //コンストラクタでインスタンス作成
        public CompanyRepository()
        {
            using (var context = new CompanyContext())
            {
                context.Database.Migrate();//DBのマイグレーションを実行
            }
        }
        //Create(Add)

        public void AddCompany(Company company)
        {
            using (var context = new CompanyContext())
            {
                context.Companys.Add(company);
                context.SaveChanges();
            }
        }
        //Read
        public List<Company> GetAllCompanys()
        {using (var context = new CompanyContext())
            {
                var query = from c in context.Companys//cはCompanyの範囲変数
                            select c;
                return query.ToList(); //ToListでデータをList型に変換して返す
            }
        }

        //Update
        public void Update(Company company)
        {
            using (var context = new CompanyContext())
            {
                context.Companys.Update(company);
                context.SaveChanges();
            }
        }
        //Delete

        public void RemoveCompany(Company company)
        {
            using (var context = new CompanyContext())
            {
                context.Companys.Remove(company);
                context.SaveChanges();
            }

        }

        ////エラーが起こったときEF Coreが持っているメモリ上のキャッシュを捨てて、DBから最新の値を再取得する→usingでcontextを都度破棄するため不要
        //public void ReloadEntity(Company company)
        //{
        //    EntityEntry<Company> entry = context.Entry(company);
        //    entry.Reload();
        //}

    }
}

