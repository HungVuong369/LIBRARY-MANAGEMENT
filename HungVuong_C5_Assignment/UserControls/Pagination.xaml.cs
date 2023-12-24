using System;
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
    /// Interaction logic for Pagination.xaml
    /// </summary>
    public partial class Pagination : UserControl
    {
        public delegate void ChangedPage(Pagination pagination);
        public event ChangedPage ChangedPageEvent;

        public delegate void SelectionChangedComBoBoxHandle(object sender, SelectionChangedEventArgs e);
        public event SelectionChangedComBoBoxHandle SelectionChangedComboBoxEvent;

        public int CurrentPage = 1;
        public int MaxPage = 0;
        public int ItemPerPage = 20;

        public Pagination()
        {
            InitializeComponent();
        }

        public void ReloadShowing<T>(List<T> list)
        {
            if (MaxPage == 0)
                lblShowing.Content = $"Showing 0 to 0 entities";
            else if (MaxPage == CurrentPage && list.Count % ItemPerPage != 0)
                lblShowing.Content = $"Showing {(CurrentPage - 1) * ItemPerPage + 1} to {(CurrentPage - 1) * ItemPerPage + list.Count % ItemPerPage} entities";
            else
                lblShowing.Content = $"Showing {(CurrentPage - 1) * ItemPerPage + 1} to {(CurrentPage) * ItemPerPage} entities";
        }

        public void SetMaxPage<T>(List<T> list)
        {
            MaxPage = (list.Count / ItemPerPage);

            if (list.Count % ItemPerPage != 0)
            {
                MaxPage += 1;
            }
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage -= 1;
            LoadPage();

            btnLastPage.IsEnabled = true;
            if (CurrentPage - 1 == 0)
            {
                btnPreviousPage.IsEnabled = false;
                btnFirstPage.IsEnabled = false;
            }
            btnNextPage.IsEnabled = true;
            ChangedPageEvent?.Invoke(this);
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage += 1;

            LoadPage();

            btnPreviousPage.IsEnabled = true;
            btnFirstPage.IsEnabled = true;

            if (CurrentPage + 1 > MaxPage)
            {
                btnNextPage.IsEnabled = false;
                btnLastPage.IsEnabled = false;
            }
            ChangedPageEvent?.Invoke(this);
        }

        public void LoadPage()
        {
            if (CurrentPage == 0)
                CurrentPage = 1;
            btnOne.IsEnabled = btnTwo.IsEnabled = btnThree.IsEnabled = btnFour.IsEnabled = btnFive.IsEnabled = true;

            btnOne.Visibility = btnTwo.Visibility = btnThree.Visibility = btnFour.Visibility = btnFive.Visibility = Visibility.Visible;

            if (CurrentPage == 1)
            {
                btnOne.IsEnabled = false;
                btnOne.Content = CurrentPage;
                if (CurrentPage + 1 > MaxPage)
                {
                    btnNextPage.IsEnabled = false;
                    btnLastPage.IsEnabled = false;
                    btnTwo.Visibility = Visibility.Collapsed;
                }
                btnTwo.Content = CurrentPage + 1;

                if (CurrentPage + 2 > MaxPage)
                    btnThree.Visibility = Visibility.Collapsed;
                btnThree.Content = CurrentPage + 2;

                if (CurrentPage + 3 > MaxPage)
                    btnFour.Visibility = Visibility.Collapsed;

                btnFour.Content = CurrentPage + 3;
                if (CurrentPage + 4 > MaxPage)
                    btnFive.Visibility = Visibility.Collapsed;

                if(MaxPage >= 2)
                    btnNextPage.IsEnabled = btnLastPage.IsEnabled = true;
                btnPreviousPage.IsEnabled = btnFirstPage.IsEnabled = false;
                btnFive.Content = CurrentPage + 4;
                return;
            }
            else if (CurrentPage == 2)
            {
                btnTwo.IsEnabled = false;
                btnTwo.Content = CurrentPage;

                btnOne.Content = CurrentPage - 1;

                if (CurrentPage + 1 > MaxPage)
                {
                    btnThree.Visibility = Visibility.Collapsed;
                }
                btnThree.Content = CurrentPage + 1;

                if (CurrentPage + 2 > MaxPage)
                    btnFour.Visibility = Visibility.Collapsed;

                if (CurrentPage + 3 > MaxPage)
                    btnFive.Visibility = Visibility.Collapsed;

                btnFour.Content = CurrentPage + 2;
                btnFive.Content = CurrentPage + 3;
                return;
            }
            else if (CurrentPage == MaxPage)
            {
                btnFive.Content = CurrentPage;
                btnFive.IsEnabled = false;

                if (CurrentPage - 1 <= 0)
                    btnFour.Visibility = Visibility.Collapsed;
                btnFour.Content = CurrentPage - 1;

                if (CurrentPage - 2 <= 0)
                    btnThree.Visibility = Visibility.Collapsed;
                btnThree.Content = CurrentPage - 2;

                if (CurrentPage - 3 <= 0)
                    btnTwo.Visibility = Visibility.Collapsed;

                if (CurrentPage - 4 <= 0)
                    btnOne.Visibility = Visibility.Collapsed;

                btnTwo.Content = CurrentPage - 3;
                btnOne.Content = CurrentPage - 4;
                btnNextPage.IsEnabled = false;
                return;
            }
            else if (CurrentPage == MaxPage - 1)
            {
                btnFour.IsEnabled = false;
                btnFour.Content = CurrentPage;

                btnFive.Content = CurrentPage + 1;
                btnThree.Content = CurrentPage - 1;

                if (CurrentPage - 2 <= 0)
                    btnTwo.Visibility = Visibility.Collapsed;

                btnTwo.Content = CurrentPage - 2;

                if (CurrentPage - 3 <= 0)
                    btnOne.Visibility = Visibility.Collapsed;

                btnOne.Content = CurrentPage - 3;
                return;
            }

            if (CurrentPage - 2 > 0)
                btnOne.Content = CurrentPage - 2;
            if (CurrentPage - 1 != 0)
                btnTwo.Content = CurrentPage - 1;

            btnThree.IsEnabled = false;
            btnThree.Content = CurrentPage;

            if (CurrentPage + 1 != MaxPage)
                btnFour.Content = CurrentPage + 1;

            if (CurrentPage + 2 <= MaxPage)
                btnFive.Content = CurrentPage + 2;

        }

        private void btnOne_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage = int.Parse((sender as Button).Content.ToString());
            if(CurrentPage == 1)
            {
                btnPreviousPage.IsEnabled = false;
                btnNextPage.IsEnabled = true;
                btnLastPage.IsEnabled = true;
                btnFirstPage.IsEnabled = false;
            }
            else if(CurrentPage == MaxPage)
            {
                btnNextPage.IsEnabled = false;
                btnPreviousPage.IsEnabled = true;
                btnLastPage.IsEnabled = false;
                btnFirstPage.IsEnabled = true;
            }
            else
            {
                btnNextPage.IsEnabled = true;
                btnPreviousPage.IsEnabled = true;
                btnLastPage.IsEnabled = true;
                btnFirstPage.IsEnabled = true;
            }
            LoadPage();
            ChangedPageEvent?.Invoke(this);
        }

        private void btnLastPage_Click(object sender, RoutedEventArgs e)
        {
            btnFirstPage.IsEnabled = true;
            btnPreviousPage.IsEnabled = true;
            btnNextPage.IsEnabled = false;
            btnLastPage.IsEnabled = false;
            CurrentPage = MaxPage;
            LoadPage();
            ChangedPageEvent?.Invoke(this);
        }

        private void btnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            btnFirstPage.IsEnabled = false;
            btnNextPage.IsEnabled = true;
            btnPreviousPage.IsEnabled = false;
            btnLastPage.IsEnabled = true;
            CurrentPage = 1;
            LoadPage();
            ChangedPageEvent?.Invoke(this);
        }

        private void cbPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectionChangedComboBoxEvent?.Invoke(sender, e);
        }

        public void HideButton()
        {
            grdContainer.Visibility = Visibility.Collapsed;
        }
    }
}
