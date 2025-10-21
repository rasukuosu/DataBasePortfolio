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
    internal partial class CompanyVM: ObservableObject
    {
       
        private CompanyRepository _companyRepository;//Modelのリポジトリを保持するフィールド
        public ObservableCollection<Company> _companiesList;//Viewに表示するためのObservableCollection型のプロパティ
        CompanyVM(CompanyRepository repository)
        {
             _companyRepository =  repository;//Modelのリポジトリをインスタンス化
            var companyData = repository.GetAllCompanys();//一旦リポジトリからList型でデータを取得
            _companiesList = new ObservableCollection<Company>(companyData);//ObservableCollectionにGetAllCompanyのリストを変換して格納
        }
       
        //Viewに表示するためのプロパティ
        [ObservableProperty]
        private Company _company;

        


        //ここからWPF用のListViewの実装
        //Viewに変更通知もできるようにrepositoryのqueryのToList（）したデータを
        //ObservableCollectionにぶち込む
    }
}
