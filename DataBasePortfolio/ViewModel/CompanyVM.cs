using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataBasePortfolio.Model;

namespace DataBasePortfolio.ViewModel
{
    internal class CompanyVM: ObservableObject
    {
        private CompanyRepository _companyRepository;
        CompanyVM(CompanyRepository repository)
        {
             _companyRepository = repository;//Modelのリポジトリをインスタンス化
        }
       
        //Viewに表示するためのプロパティ
        [ObservableProperty]
        private Company _company;


        //ここからWPF用のListViewの実装
        //Viewに変更通知もできるようにrepositoryのqueryのToList（）したデータを
        //ObservableCollectionにぶち込む
    }
}
