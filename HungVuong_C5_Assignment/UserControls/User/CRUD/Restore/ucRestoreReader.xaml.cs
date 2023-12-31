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
    /// Interaction logic for ucRestoreReader.xaml
    /// </summary>
    public partial class ucRestoreReader : UserControl
    {
        private ObservableCollection<Reader> _LstReader = new ObservableCollection<Reader>(DataAccess.GetListReader(false));
        private List<Adult> _LstAdult = DataAccess.GetListAdult(false);
        private List<Child> _LstChild = DataAccess.GetListChild(false);

        private ReaderViewModel _ReaderVM = new ReaderViewModel();
        private ChildViewModel _ChildVM = new ChildViewModel();
        private AdultViewModel _AdultVM = new AdultViewModel();
        private ParameterViewModel _ParameterVM = new ParameterViewModel();

        public ucRestoreReader()
        {
            InitializeComponent();

            dgReader.ItemsSource = _LstReader;
        }

        private Reader GetReaderByID(string id)
        {
            foreach (var item in _LstReader)
            {
                if (item.Id == id)
                    return item;
            }
            return null;
        }

        private Child GetChildByIdReader(string IdReader)
        {
            foreach(var item in this._LstChild)
            {
                if (item.IdReader == IdReader)
                    return item;
            }
            return null;
        }

        private Adult GetAdultByIdReader(string IdReader)
        {
            foreach (var item in this._LstAdult)
            {
                if (item.IdReader == IdReader)
                    return item;
            }
            return null;
        }

        public int GetQuantityChildByAdultID(string adultID)
        {
            int count = 0;
            foreach (var item in this._LstChild)
            {
                if (item.IdAdult == adultID)
                    count++;
            }
            return count;
        }

        public Child GetByAdultID(string adultID)
        {
            foreach (var item in this._LstChild)
            {
                if (item.IdAdult == adultID)
                    return item;
            }
            return null;
        }

        public Child GetByAdultIDSecond(string adultID)
        {
            bool flag = false;

            foreach (var item in this._LstChild)
            {
                if (item.IdAdult == adultID)
                {
                    if (!flag)
                    {
                        flag = true;
                        continue;
                    }

                    return item;
                }
            }
            return null;
        }

        private void RestoreChild(Reader reader, Child child)
        {
            reader.Status = true;

            this._ReaderVM.readerRepo.Restore(reader);

            this._ChildVM.childRepo.Restore(child);

            _LstChild.Remove(child);

            _LstReader.Remove(reader);
        }

        private void RestoreAdult(Reader reader, Adult adult)
        {
            reader.Status = true;

            this._ReaderVM.readerRepo.Restore(reader);

            this._AdultVM.adultRepo.Restore(adult);

            _LstAdult.Remove(adult);

            _LstReader.Remove(reader);
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            Reader reader = (sender as Button).Tag as Reader;

            if (reader.ReaderType == false)
            {
                Child child = GetChildByIdReader(reader.Id);

                if (this._AdultVM.adultRepo.GetByIdReader(child.IdAdult) == null)
                {
                    WindowDefault window = new WindowDefault();

                    Reader adultReader = GetReaderByID(child.IdAdult);

                    Adult adult = GetAdultByIdReader(child.IdAdult);

                    window.grdContainer.Children.Add(new ucConfirmRestoreChild(window, adultReader, adult));

                    window.ShowDialog();

                    if(window.DialogResult == true)
                    {
                        this.RestoreAdult(adultReader, adult);

                        this.RestoreChild(reader, child);

                        MessageBox.Show("Resore Successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    int quantity = this._ChildVM.GetQuantityChildByAdultID(child.IdAdult);
                    if(quantity == int.Parse(_ParameterVM.parameterRepo.GetByID("QD1").Value))
                    {
                        MessageBox.Show("Children cannot be restored!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    this.RestoreChild(reader, child);

                    MessageBox.Show("Resore Successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                int quantityChild = GetQuantityChildByAdultID(reader.Id);

                if (quantityChild == 0)
                {
                    Adult adult = GetAdultByIdReader(reader.Id);

                    this.RestoreAdult(reader, adult);

                    MessageBox.Show("Resore Successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    WindowDefault window = new WindowDefault();

                    Child child1 = GetByAdultID(reader.Id);
                    Child child2 = GetByAdultIDSecond(reader.Id);

                    Reader childReader1 = GetReaderByID(child1.IdReader);

                    Reader childReader2 = null;

                    if (child2 != null)
                        childReader2 = GetReaderByID(child2.IdReader);

                    ucConfirmRestoreAdult ucConfirm = new ucConfirmRestoreAdult(window, childReader1, child1, childReader2, child2);

                    window.grdContainer.Children.Add(ucConfirm);

                    window.ShowDialog();

                    if (window.DialogResult == true)
                    {
                        Adult adult = GetAdultByIdReader(reader.Id);

                        if ((string)window.Tag == "Restore Adult")
                        {
                            this.RestoreAdult(reader, adult);

                            MessageBox.Show("Restore successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);

                            return;
                        }

                        Child child = GetByAdultID(reader.Id);
                        
                        while (child != null)
                        {
                            Reader readerChild = GetReaderByID(child.IdReader);

                            this.RestoreChild(readerChild, child);

                            child = GetByAdultID(reader.Id);
                        }

                        this.RestoreAdult(reader, adult);

                        MessageBox.Show("Restore successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }
    }
}
