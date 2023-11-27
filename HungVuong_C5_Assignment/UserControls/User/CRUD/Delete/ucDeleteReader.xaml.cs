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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HungVuong_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucDeleteReader.xaml
    /// </summary>
    public partial class ucDeleteReader : UserControl
    {
        private ReaderViewModel readerVM = new ReaderViewModel();
        private ChildViewModel childVM = new ChildViewModel();
        private AdultViewModel adultVM = new AdultViewModel();

        public ucDeleteReader()
        {
            InitializeComponent();

            dgReader.ItemsSource = readerVM.readerRepo.Items;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            string id = button.Tag.ToString();

            if(MessageBox.Show("Are you sure you want to delete?", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (readerVM.isAdult(id))
                {
                    int quantityChild = childVM.GetQuantityChildByAdultID(id);

                    if(quantityChild == 0)
                    {
                        adultVM.adultRepo.RemoveByIdReader(id);
                        readerVM.readerRepo.RemoveByID(id);

                        MessageBox.Show("Deleted successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        WindowDefault window = new WindowDefault();
                        ucConfirmDelete ucConfirmDelete = new ucConfirmDelete(window, childVM.GetByAdultID(id), childVM.GetByAdultIDSecond(id));
                        window.Content = ucConfirmDelete;
                        window.ShowDialog();

                        if(window.DialogResult == true)
                        {
                            Child child = childVM.GetByAdultID(id);

                            while (child != null)
                            {
                                childVM.childRepo.RemoveByIdReader(child.IdReader);
                                readerVM.readerRepo.RemoveByID(child.IdReader);
                                child = childVM.GetByAdultID(id);
                            }
                            adultVM.adultRepo.RemoveByIdReader(id);
                            readerVM.readerRepo.RemoveByID(id);

                            MessageBox.Show("Deleted successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                else
                {
                    childVM.childRepo.RemoveByIdReader(id);
                    readerVM.readerRepo.RemoveByID(id);
                    MessageBox.Show("Deleted successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                dgReader.ItemsSource = null;
                dgReader.ItemsSource = readerVM.readerRepo.Items;
            }
        }
    }
}
