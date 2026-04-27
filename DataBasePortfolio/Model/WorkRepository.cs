using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBasePortfolio.Model
{
    //https://learn.microsoft.com/ja-jp/dotnet/api/microsoft.entityframeworkcore.dbcontext?view=efcore-9.0
    public class WorkRepository
    {
        public WorkRepository()
        {
            using (var context = new WorkContext())
            {
                context.Database.Migrate();//DBのマイグレーションを実行
            }
        }
        //Create(Add)

        public void AddWork(Work work)
        {
            using (var context = new WorkContext())
            {
                context.Works.Add(work);
                context.SaveChanges();
            }
        }
        //Read
        public List<Work> GetAllWorks()
        {
            using (var context = new WorkContext())
            {
                var query = from w in context.Works//wはWorkの範囲変数で頭文字
                            select w;
                return query.ToList(); //ToListでデータをList型に変換して返す
            }
        }

        //Update
        public void UpdateWork(Work work)
        {
            using (var context = new WorkContext())
            {
                context.Works.Update(work);
                context.SaveChanges();
            }
        }
        //Delete

        public void RemoveWork(Work work)
        {
            using (var context = new WorkContext())
            {
                context.Works.Remove(work);
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
