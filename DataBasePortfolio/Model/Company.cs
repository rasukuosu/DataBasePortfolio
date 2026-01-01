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
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }//DB用企業ID,Keyをつけた時点で自動生成
        [Required]//Null不可
        
        public string CompanyName { get; set; }//会社名    
        [Required]
        public string President  { get; set; }//代表取締役
        //[Required]
        //public string URL { get; set; }//会社概要のURL
    }
}
