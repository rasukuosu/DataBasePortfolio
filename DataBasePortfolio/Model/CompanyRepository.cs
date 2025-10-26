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
        private readonly CompanyContext _context;//contextの状態を保持
        //コンストラクタでインスタンス作成
        public CompanyRepository()
        {
            _context = new CompanyContext();

        }
        //Create(Add)

        public void AddCompany(Company company)
        {
            _context.Companys.Add(company);
            _context.SaveChanges();
        }
        //Read
        public List<Company> GetAllCompanys()
        {
            var query = from c in _context.Companys //cはCompanyの範囲変数
                        select c;   
            return query.ToList(); //ToListでデータをList型に変換して返す
        }

        //Update

        //Delete

        public void RemoveCompany(Company company)
        {
            _context.Companys.Remove(company);
            _context.SaveChanges();


        }
    }
}

