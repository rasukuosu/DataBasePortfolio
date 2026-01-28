using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataBasePortfolio.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataBasePortfolio.ViewModel
{
    public partial class CompanyVM : ObservableValidator
    {

        private CompanyRepository _companyRepository;//Modelのリポジトリを保持するフィールド
        public ObservableCollection<Company> CompaniesList { get; set; }//Viewに表示するためのObservableCollection型のプロパティ


        public CompanyVM(CompanyRepository repository)
        {
            _companyRepository = repository;//Modelのリポジトリをインスタンス化
            var companyData = repository.GetAllCompanys();//一旦リポジトリからList型でデータを取得、ここにデータベースの現在のデータを格納
            CompaniesList = new ObservableCollection<Company>(companyData);//ObservableCollectionにGetAllCompanyのリストを変換して格納、以降これがViewに表示されるリスト
            _Company = new Company();//Viewからの入力を受け取るためにプロパティを初期化
        }
        public CompanyVM() : this(new CompanyRepository())
        {
            //Viewがインスタンスを作るためのコンストラクタ＝コンストラクタ・チェイニング 
            //引数なしコンストラクタでCompanyRepositoryのインスタンスを生成して
            //引数付きコンストラクタに渡し
        }

        private int result;//メッセージの種類を判別するためのフィールド
        //ViewとModelを同期させるためのプロパティ
        [ObservableProperty]
        private Company _Company;
        [RelayCommand]
        public void Create()//  xaml側でbindしたプロパティ名 はメソッド名 + "Command"
        {
            if (_Company.CompanyName == null || _Company.President == null  )
            {
                MessageBox.Show("Errorが発生しました空欄がないかを確認してください");
                return;
            }
            else if (_Company.CompanyName.Contains("株式会社") )
            {
                MessageBox.Show("Errorが発生しました株式会社を含んでいないかを確認してください");
                return;
            }
            else
            {
                _companyRepository.AddCompany(_Company);//Modelのリポジトリを使ってDBに追加
                CompaniesList.Add(_Company);//Viewに表示するためのObservableCollectionにも追加
                Company = new Company();//追加後、入力用のプロパティを初期化
            }
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
        [RelayCommand]
        public void Update()
        {
           
            if (_Company.CompanyName == null || _Company.President == null)
            {
                MessageBox.Show("Errorが発生しました空欄がないかを確認してください");
                _companyRepository.ReloadEntity(_Company);
                return;
            }
            else if (_Company.CompanyName.Contains("株式会社"))
            {
                MessageBox.Show("Errorが発生しました株式会社を含んでいないかを確認してください");
                _companyRepository.ReloadEntity(_Company);
                return;
            }
            else { 
            _companyRepository.Update(_Company);//Modelのリポジトリを使ってDBを更新
                //Company = new Company();//更新後、入力用のプロパティを初期化
            }
    }
    }
}
