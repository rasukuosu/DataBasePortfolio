using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataBasePortfolio.Model;

namespace DataBasePortfolio.ViewModel
{
    public partial class CompanyVM : ObservableObject
    {

        private CompanyRepository _companyRepository;//Modelのリポジトリを保持するフィールド
        public ObservableCollection<Company> CompaniesList { get; }//Viewに表示するためのObservableCollection型のプロパティ


        public CompanyVM(CompanyRepository repository)
        {
            _companyRepository = repository;//Modelのリポジトリをインスタンス化
            var companyData = repository.GetAllCompanys();//一旦リポジトリからList型でデータを取得
            CompaniesList = new ObservableCollection<Company>(companyData);//ObservableCollectionにGetAllCompanyのリストを変換して格納
        }
        public CompanyVM() : this(new CompanyRepository())
        {
            //Viewがインスタンスを作るためのコンストラクタ＝コンストラクタ・チェイニング 
            //引数なしコンストラクタでCompanyRepositoryのインスタンスを生成して
            //引数付きコンストラクタに渡し
        }


        //Viewに表示するためのプロパティ
        [ObservableProperty]
        private Company _Company;

     


        //ここからWPF用のListViewの実装
        //Viewに変更通知もできるようにrepositoryのqueryのToList（）したデータを
        //ObservableCollectionにぶち込む
    }
}
