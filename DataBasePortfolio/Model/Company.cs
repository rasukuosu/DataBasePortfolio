using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataBasePortfolio.Model
{
    [Table("Companys")]
    [Index(nameof(CompanyName), IsUnique =true)]//会社名にユニーク制約をつける
    public class Company : ObservableObject//ObservableObjectにしないと編集してDBから値をReloadしたとき、その変化をDataGridが検知できない
    {
        [Key]
        public int CompanyId { get; set; }//DB用企業ID,Keyをつけた時点で自動生成
        private string _companyName; // 値を保存する場所
        [Required]
        public string CompanyName
        {
            get => _companyName;
            set => SetProperty(ref _companyName, value); // 値をセットしつつ、無理やりObserbableProperty化してObservableCollectionに項目ごとの通知を出させてDataGridを更新させる
        }

        // --- President の書き換え ---
        private string _president; // 値を保存する場所
        [Required]
        public string President
        {
            get => _president;
            set => SetProperty(ref _president, value); // 値をセットしつつ、無理やりObserbableProperty化してObservableCollectionに項目ごとの通知を出させてDataGridを更新させる
        }
        //[Required]
        //public string URL { get; set; }//会社概要のURL
    }
}
