using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using DataBasePortfolio.Model;

namespace DataBasePortfolio.ViewModel
{
    partial class CompanyVM: ObservableObject
    {
        private Company _company;

        [ObservableProperty]
        private int _companyId;
        [ObservableProperty]
        private string _companyName;
        [ObservableProperty]
        private string _president;
        [ObservableProperty]
        private string _url;
        public CompanyVM()
        {
            _company = new Company();
            CompanyId = _company.CompanyId;
            CompanyName = _company.CompanyName;
            President = _company.President;
            //URL = _company.URL;

        }
    }
}
