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
    /// Interaction logic for ucChildDataGrid.xaml
    /// </summary>
    public partial class ucChildDataGrid : UserControl
    {
        private AdultViewModel adultVM = new AdultViewModel();
        private ChildViewModel childVM = new ChildViewModel();
        private ReaderViewModel readerVM = new ReaderViewModel();

        public ucChildDataGrid()
        {
            InitializeComponent();
        }

        public void SetItemsSourceByAdultIdReader(string adultIdReader)
        {
            List<ChildInformation> lstChildInfo = new List<ChildInformation>();

            Adult adult = adultVM.adultRepo.GetByIdReader(adultIdReader);

            foreach (Child child in adult.Children)
            {
                if (!child.Status)
                    continue;
                if (child != null)
                {
                    lstChildInfo.Add(new ChildInformation(
                        child.IdReader,
                        child.Reader.LName + " " + child.Reader.FName,
                        child.Reader.boF,
                        child.Reader.ReaderType == true ? "Người lớn" : "Trẻ em",
                        child.CreatedAt,
                        child.ModifiedAt
                    ));
                }
            }
            //Child child1 = childVM.GetByAdultID(adultIdReader);
            //Child child2 = childVM.GetByAdultIDSecond(adultIdReader);

            //if(child1 != null)
            //{
            //    Reader ChildReader1 = readerVM.readerRepo.GetById(child1.IdReader);


            //}

            //if(child2 != null)
            //{
            //    Reader ChildReader2 = readerVM.readerRepo.GetById(child2.IdReader);

            //    lstChildInfo.Add(new ChildInformation(
            //        ChildReader2.Id,
            //        ChildReader2.FullName,
            //        ChildReader2.BoF,
            //        ChildReader2.ReaderType,
            //        ChildReader2.CreatedAt,
            //        ChildReader2.ModifiedAt
            //    ));
            //}
            dgChildInfo.ItemsSource = lstChildInfo;
        }
    }
}
