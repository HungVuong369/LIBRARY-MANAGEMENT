﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HungVuong_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucBookISBNInformation.xaml
    /// </summary>
    public partial class ucBookISBNInformation : UserControl
    {
        private BookViewModel _BookVM = new BookViewModel();
        private ObservableCollection<BookISBNInformation> _StorageLstBookISBNInfo;
        private ObservableCollection<BookISBNInformation> _LstBookISBNInfo;

        public ucBookISBNInformation()
        {
            InitializeComponent();
            this._StorageLstBookISBNInfo = new ObservableCollection<BookISBNInformation>(DataAccess.GetListBookISBNInformation());

            this._LstBookISBNInfo = new ObservableCollection<BookISBNInformation>(this._StorageLstBookISBNInfo);

            pagination.SetMaxPage<BookISBNInformation>(_LstBookISBNInfo.ToList());

            dgBookISBN.ItemsSource = null;
            dgBookISBN.ItemsSource = _LstBookISBNInfo.Take(pagination.ItemPerPage);

            pagination.LoadPage();

            dgBookISBN.ItemsSource = _LstBookISBNInfo;
        }

        public void ReloadDataGrid()
        {
            dgBookISBN.ItemsSource = null;
            dgBookISBN.ItemsSource = _LstBookISBNInfo.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
            pagination.ReloadShowing<BookISBNInformation>(_LstBookISBNInfo.ToList());
        }

        public void ReloadStorage()
        {
            this._StorageLstBookISBNInfo = new ObservableCollection<BookISBNInformation>(DataAccess.GetListBookISBNInformation());

            this._LstBookISBNInfo = new ObservableCollection<BookISBNInformation>(this._StorageLstBookISBNInfo);

            pagination.SetMaxPage<BookISBNInformation>(_LstBookISBNInfo.ToList());

            dgBookISBN.ItemsSource = _LstBookISBNInfo.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
        }

        public void Search(string search)
        {
            this._LstBookISBNInfo.Clear();

            foreach (var item in this._StorageLstBookISBNInfo)
            {
                if (item.ISBN.ToLower().Contains(search.ToLower()))
                    this._LstBookISBNInfo.Add(item);
                else if(item.Language.ToLower().Contains(search.ToLower()))
                    this._LstBookISBNInfo.Add(item);
                else if(item.AuthorName.ToLower().Contains(search.ToLower()))
                    this._LstBookISBNInfo.Add(item);
                else if(item.AuthorBoF.ToString("dd/MM/yyyy").Contains(search))
                    this._LstBookISBNInfo.Add(item);
            }
            pagination.SetMaxPage<BookISBNInformation>(_LstBookISBNInfo.ToList());
            pagination.CurrentPage = 1;
            pagination.LoadPage();
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            WindowDefault window = new WindowDefault();
            window.SizeToContent = SizeToContent.Manual;
            window.Width = 750;
            window.Height = 550;
            window.Content = new ucDetailBookISBN(button.Tag.ToString());
            window.ShowDialog();
        }
    }
}
