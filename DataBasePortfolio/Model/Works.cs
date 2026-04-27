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
    [Table("Works")]
    [Index(nameof(WorkName), IsUnique =true)]
    public class Work : ObservableObject
    {
        [Key]
        public int WorkId { get; set; }

        //画像をbyte[]型で保存する画面の変更通知用フィールドとエンティティプロパティ
        private byte[] _imageBytes;
        [Required]
        public byte[] ImageBytes 
        {
            get => _imageBytes;
            set => SetProperty(ref _imageBytes, value);
        }
        //画像のパスを保存する変更通知用フィールドとエンティティプロパティ
        private string _imagePath;
        [Required]
        public string ImagePath
        {
            get => _imagePath;
            set => SetProperty(ref _imagePath, value);
        }


        private string _workName;//作品名を保存する変更通知用フィールドとエンティティプロパティ
        [Required]
        public string WorkName
        {
            get => _workName;
            set => SetProperty(ref _workName, value);
        }
        private string _author;//作者名を保存する変更通知用フィールドとエンティティプロパティ
        [Required]
        public string Author
        {
            get => _author;
            set => SetProperty(ref _author, value);
        }
        private string _affiliation;//所属を保存する変更通知用フィールドとエンティティプロパティ
        [Required]
        public string Affiliation
        {
            get => _affiliation;
            set => SetProperty(ref _affiliation, value);
        }
        private string _status;//確認中など状態を保存する変更通知用フィールドとエンティティプロパティ
        [Required]
        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

    }
}
