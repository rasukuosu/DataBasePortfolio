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
        public ObservableCollection<Company> CompaniesList { get; set; }//Viewに表示するためのObservableCollection型のプロパティ


        public CompanyVM(CompanyRepository repository)
        {
            _companyRepository = repository;//Modelのリポジトリをインスタンス化
            var companyData = repository.GetAllCompanys();//一旦リポジトリからList型でデータを取得
            CompaniesList = new ObservableCollection<Company>(companyData);//ObservableCollectionにGetAllCompanyのリストを変換して格納
            _Company = new Company();//Viewからの入力を受け取るためのプロパティを初期化
        }
        public CompanyVM() : this(new CompanyRepository())
        {
            //Viewがインスタンスを作るためのコンストラクタ＝コンストラクタ・チェイニング 
            //引数なしコンストラクタでCompanyRepositoryのインスタンスを生成して
            //引数付きコンストラクタに渡し
        }


        //Viewからの情報を保持するためのプロパティ
        [ObservableProperty]
        private Company _Company;

        [RelayCommand]
        public void Create()///メソッド名 + "Command" = xaml側でbindしたプロパティ名
        {

            _companyRepository.AddCompany(_Company);//Modelのリポジトリを使ってDBに追加
                CompaniesList.Add(_Company);//Viewに表示するためのObservableCollectionにも追加
                 Company = new Company();//追加後、入力用のプロパティを初期化

        }
       
        [RelayCommand]
        public void Delete()
        {
            _companyRepository.RemoveCompany(_Company);//Modelのリポジトリを使ってDBから削除
            CompaniesList.Remove(_Company);//Viewに表示するためのObservableCollectionからも削除
            Company = new Company();//削除後、入力用のプロパティを初期化
        }
        [RelayCommand]
        public void Read()
        {

            _companyRepository = new CompanyRepository();
            var companyData = _companyRepository.GetAllCompanys();
            
        }
    }
}
