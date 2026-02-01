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
using System.Windows.Navigation;


namespace DataBasePortfolio.ViewModel
{
    /// <summary>
    /// DeleteValidationWindow.xaml のValidationチェックVM。
    /// しかし、Xaml側でVMのプロパティを扱う方法がわからないため一旦保留。
    /// </summary>
    public partial class DeleteValidationWindowVM : ObservableValidator
    {
        public DeleteValidationWindowVM() { 
  
        }
        [ObservableProperty]
        private string targetCode;//答え合わせ用
        [ObservableProperty]
        private string inputCode;//ユーザが入力するコード
        //internal bool inputResult;
        //[RelayCommand]
        //public void CheckInput() { 
        //  if (TargetCode == InputCode)
        //    {
        //        inputResult = true;
        //    }
        //  else
        //    {
        //        inputResult = false;
        //    }
        //}
        //[RelayCommand]
        //public void Cancel()
        //{ return; }
    }
}
