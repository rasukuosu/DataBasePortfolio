using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DataBasePortfolio
{
    /// <summary>
    /// DeleteValidationWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class DeleteValidationWindow : Window
    {
        public DeleteValidationWindow()
        {
            InitializeComponent();

        }

        private string targetCode = "DELETEROW";
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            string code = this.targetTextBox.Text;
            if (code == targetCode)
            {
                this.DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("入力されたコードが正しくありません。再度確認してください。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
           
        }
    }
}
