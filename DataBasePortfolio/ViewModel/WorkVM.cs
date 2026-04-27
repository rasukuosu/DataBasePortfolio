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
    public partial class WorkVM: ObservableValidator
    {
        private WorkRepository _workRepository;//Modelのリポジトリを保持するフィールド
        public ObservableCollection<Work> WorksList { get; set; }//Viewに表示するためのObservableCollection型のプロパティ、追加と削除のコレクション全体が更新されたときのみしか通知を出さないため、WorkクラスのプロパティをObservablProperty化して項目ごとの通知を出させる必要がある


        public WorkVM(WorkRepository repository)
        {
            _workRepository = repository;//Modelのリポジトリをインスタンス化
            var workData = repository.GetAllWorks();//一旦リポジトリからList型でデータを取得、ここにデータベースの現在のデータを格納
            WorksList = new ObservableCollection<Work>(workData);//ObservableCollectionにGetAllWorkのリストを変換して格納、以降これがViewに表示されるリスト
            _work = new Work();//Viewからの入力を受け取るためにプロパティを初期化
        }
        public WorkVM() : this(new WorkRepository())
        {
            //Viewがインスタンスを作るためのコンストラクタ＝コンストラクタ・チェイニング 
            //引数なしコンストラクタでWorkRepositoryのインスタンスを生成して
            //引数付きコンストラクタに渡し
        }


        //ViewとModelを同期させるためのプロパティ
        [ObservableProperty]
        private Work _work;
        [RelayCommand]
        public void CreateWork()//  xaml側でbindしたプロパティ名 はメソッド名 + "Command"
        {
            if (_work.Author == null || _work.WorkName == null || _work.Status == null)
            {
                MessageBox.Show("Errorが発生しました空欄がないかを確認してください");
                return;
            }
            else if (_work.Affiliation.Contains("株式会社"))
            {
                MessageBox.Show("Errorが発生しました株式会社を含んでいないかを確認してください");
                return;
            }
            else
            {
                _workRepository.AddWork(_work);//Modelのリポジトリを使ってDBに追加
                WorksList.Add(_work);//Viewに表示するためのObservableCollectionにも追加
                _work = new Work();//追加後、入力用のプロパティを初期化
            }
        }

        [RelayCommand]
        public void DeleteWork()
        {
            _workRepository.RemoveWork(_work);//Modelのリポジトリを使ってDBから削除
            WorksList.Remove(_work);//Viewに表示するためのObservableCollectionからも削除
            _work = new Work();//削除後、入力用のプロパティを初期化
        }
        [RelayCommand]
        public void ReadWorksList()
        {

            _workRepository = new WorkRepository();
            var workData = _workRepository.GetAllWorks();
        }
        [RelayCommand]
        public void UpdateWork()
        {

            if (_work.Author == null || _work.WorkName == null || _work.Status == null)
            {
                MessageBox.Show("Errorが発生しました空欄がないかを確認してください");
                //_workRepository.ReloadEntity(_work);usingでcontextを都度破棄するため不要
                return;
            }
            else if ((_work.Affiliation.Contains("株式会社") || _work.Affiliation == null))
            {
                MessageBox.Show("Errorが発生しました株式会社を含んでいないか、空欄ではないかを確認してください");
                //_workRepository.ReloadEntity(_work);usingでcontextを都度破棄するため不要->必要ない可能性がある為コメントアウト
                return;
            }
            else
            {
                _workRepository.UpdateWork(_work);//Modelのリポジトリを使ってDBを更新
                //_work = new Work();//更新後、入力用のプロパティを初期化->必要ない可能性がある為コメントアウト
                var workData = _workRepository.GetAllWorks();
            }


        }
        [RelayCommand]
        public void ShowDeleteWindow()//delete確認ウィンドウを開くコマンド
        {
            DeleteValidationWindow deleteValidationWindow = new DeleteValidationWindow();
            deleteValidationWindow.ShowDialog();
            if (deleteValidationWindow.DialogResult == true)
            {


                _workRepository.RemoveWork(_work);//Modelのリポジトリを使ってDBから削除
                WorksList.Remove(_work);//Viewに表示するためのObservableCollectionからも削除

                _work = new Work();//削除後、入力用のプロパティを初期化

            }
            else
            {
                return;
            }
        }


    }
}
