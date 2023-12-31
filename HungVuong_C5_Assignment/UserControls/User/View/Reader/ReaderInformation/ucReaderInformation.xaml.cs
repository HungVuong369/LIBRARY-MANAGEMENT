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
    /// Interaction logic for ucReaderInformation.xaml
    /// </summary>
    public partial class ucReaderInformation : UserControl
    {
        private ReaderViewModel readerVM = new ReaderViewModel();
        private AdultViewModel adultVM = new AdultViewModel();
        private ChildViewModel childVM = new ChildViewModel();

        public ucReaderInformation()
        {
            InitializeComponent();

            dgReader.ItemsSource = readerVM.readerRepo.Items;
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string readerID = button.Tag.ToString();

            Reader reader = readerVM.readerRepo.GetById(readerID);

            if (reader.ReaderType == true)
            {
                Adult adult = adultVM.adultRepo.GetByIdReader(readerID);
                Child child1 = childVM.GetByAdultID(readerID);
                Child child2 = childVM.GetByAdultIDSecond(readerID);
                ucAdultInformation info = new ucAdultInformation(reader, adult, child1, child2);
                WindowDefault window = new WindowDefault();
                window.grdContainer.Children.Add(info);
                window.ShowDialog();
            }
            else
            {
                Child child = childVM.childRepo.GetByIdReader(readerID);
                Adult adult = adultVM.adultRepo.GetByIdReader(child.IdAdult);
                Reader adultReader = readerVM.readerRepo.GetById(adult.IdReader);

                ucChildInformation info = new ucChildInformation(adultReader, adult, reader, child);
                WindowDefault window = new WindowDefault();
                window.grdContainer.Children.Add(info);
                window.ShowDialog();
            }
        }
    }
}
