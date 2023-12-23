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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HungVuong_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucLoanBook.xaml
    /// </summary>
    public partial class ucLoanBook : UserControl
    {
        public BookInformation BookInfo;
        public Grid GridContainer;
        public Storyboard fadeInOutStoryboard;

        public ucLoanBook(BookInformation bookInfo)
        {
            InitializeComponent();
            BookInfo = bookInfo;
            this.DataContext = ShowBooksViewModel.Instance;
        }

        private void btnContainer_Click(object sender, RoutedEventArgs e)
        {
            btnContainer.Tag = this;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            GridContainer = sender as Grid;
            GridContainer.DataContext = BookInfo;
        }

        private void GroupBox_Loaded(object sender, RoutedEventArgs e)
        {
            GroupBox gb = sender as GroupBox;
            gb.Header = BookInfo.ISBN;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            fadeInOutStoryboard = new Storyboard();

            DoubleAnimation opacityAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.6,
                Duration = TimeSpan.FromMilliseconds(500),
                AutoReverse = true
            };

            Storyboard.SetTarget(opacityAnimation, this);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));

            fadeInOutStoryboard.Children.Add(opacityAnimation);
            fadeInOutStoryboard.RepeatBehavior = RepeatBehavior.Forever;

            // Thêm Storyboard vào Grid
            foreach(var item in this.Resources.Keys)
            {
                if (item.ToString() == "FadeInOut")
                    return;
            }
            this.Resources.Add("FadeInOut", fadeInOutStoryboard);
        }
    }
}
