using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HungVuong_C5_Assignment
{
    public class ReaderManagementRepository
    {
        private AdultViewModel _AdultVM = new AdultViewModel();
        private ReaderViewModel _ReaderVM = new ReaderViewModel();
        private ChildViewModel _ChildVM = new ChildViewModel();
        private ParameterViewModel _ParameterVM = new ParameterViewModel();

        public bool AddAdult(AdultReader adultReader)
        {
            if (_AdultVM.IsExistIdentify(adultReader.Identify))
            {
                MessageBox.Show("Identify is duplicated!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            _ReaderVM.readerRepo.Add(adultReader.Lname, adultReader.FName, adultReader.BoF, true, true, DateTime.Now, DateTime.Now);

            _AdultVM.adultRepo.Add(adultReader.Identify, adultReader.Address, adultReader.Province, adultReader.Phone, adultReader.ExpireDate, true, DateTime.Now, DateTime.Now);

            DatabaseFirst.Instance.SaveChanged();

            return true;
        }

        public bool AddChild(string adultID, string lName, string fName, DateTime boF)
        {
            _ReaderVM.readerRepo.Add(lName, fName, boF, false, true, DateTime.Now, DateTime.Now);

            _ChildVM.childRepo.Add(adultID);

            DatabaseFirst.Instance.SaveChanged();

            return true;
        }

        private void DeleteAdult(int quantityChild, string id)
        {
            if (quantityChild == 0)
            {
                _AdultVM.adultRepo.RemoveByIdReader(id);
                _ReaderVM.readerRepo.RemoveByID(id);
                DatabaseFirst.Instance.SaveChanged();
                MessageBox.Show("Deleted successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                WindowDefault window = new WindowDefault();
                ucConfirmDelete ucConfirmDelete = new ucConfirmDelete(window, _ChildVM.GetByAdultID(id), _ChildVM.GetByAdultIDSecond(id));
                window.grdContainer.Children.Add(ucConfirmDelete);
                window.ShowDialog();

                if (window.DialogResult == true)
                {
                    Child child = _ChildVM.GetByAdultID(id);

                    while (child != null)
                    {
                        _ChildVM.childRepo.RemoveByIdReader(child.IdReader);
                        _ReaderVM.readerRepo.RemoveByID(child.IdReader);
                        child = _ChildVM.GetByAdultID(id);
                    }
                    _AdultVM.adultRepo.RemoveByIdReader(id);
                    _ReaderVM.readerRepo.RemoveByID(id);

                    DatabaseFirst.Instance.SaveChanged();
                    MessageBox.Show("Deleted successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void DeleteChild(string id)
        {
            _ChildVM.childRepo.RemoveByIdReader(id);
            _ReaderVM.readerRepo.RemoveByID(id);
        }

        public void DeleteReader(string id)
        {
            if (_ReaderVM.isAdult(id))
            {
                int quantityChild = _ChildVM.GetQuantityChildByAdultID(id);
                DeleteAdult(quantityChild, id);
            }
            else
            {
                DeleteChild(id);
                DatabaseFirst.Instance.SaveChanged();
                MessageBox.Show("Deleted successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        private void RestoreChild(Reader reader, Child child)
        {
            reader.Status = true;

            this._ReaderVM.readerRepo.Restore(reader);

            this._ChildVM.childRepo.Restore(child);
        }

        private void RestoreAdult(Reader reader, Adult adult)
        {
            reader.Status = true;

            this._ReaderVM.readerRepo.Restore(reader);

            this._AdultVM.adultRepo.Restore(adult);
        }

        public void RestoreReader(string id)
        {
            Reader reader = _ReaderVM.readerRepo.Items.FirstOrDefault(i => i.Id == id);

            if (reader.ReaderType == false)
            {
                Child child = _ChildVM.childRepo.GetByIdReader(reader.Id);

                if (DatabaseFirst.Instance.db.Adults.FirstOrDefault(i => i.IdReader == child.IdAdult && i.Status == false) != null)
                {
                    WindowDefault window = new WindowDefault();

                    Reader adultReader = _ReaderVM.readerRepo.GetById(child.IdAdult);

                    Adult adult = _AdultVM.adultRepo.GetByIdReader(child.IdAdult);

                    window.grdContainer.Children.Add(new ucConfirmRestoreChild(window, adultReader, adult));

                    window.ShowDialog();

                    if (window.DialogResult == true)
                    {
                        this.RestoreAdult(adultReader, adult);

                        this.RestoreChild(reader, child);

                        DatabaseFirst.Instance.SaveChanged();

                        MessageBox.Show("Resore Successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    int quantity = DatabaseFirst.Instance.db.Adults.FirstOrDefault(i => i.IdReader == child.IdAdult).Children.Where(c => c.Status == true).Count();

                    if (quantity == int.Parse(_ParameterVM.parameterRepo.GetByID("QD1").Value))
                    {
                        MessageBox.Show("Children cannot be restored!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    this.RestoreChild(reader, child);

                    DatabaseFirst.Instance.SaveChanged();

                    MessageBox.Show("Resore Successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                int quantityChild = DatabaseFirst.Instance.db.Adults.FirstOrDefault(i => i.IdReader == reader.Id).Children.Where(c => c.Status == true).Count();
                //int quantityChild = _ChildVM.GetQuantityChildByAdultID(reader.Id);

                if (quantityChild == 0)
                {
                    Adult adult = _AdultVM.adultRepo.GetByIdReader(reader.Id);

                    this.RestoreAdult(reader, adult);

                    DatabaseFirst.Instance.SaveChanged();

                    MessageBox.Show("Resore Successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    WindowDefault window = new WindowDefault();

                    Child child1 = _ChildVM.GetByAdultID(reader.Id);
                    Child child2 = _ChildVM.GetByAdultIDSecond(reader.Id);

                    Reader childReader1 = _ReaderVM.readerRepo.GetById(child1.IdReader);

                    Reader childReader2 = null;

                    if (child2 != null)
                        childReader2 = _ReaderVM.readerRepo.GetById(child2.IdReader);

                    ucConfirmRestoreAdult ucConfirm = new ucConfirmRestoreAdult(window, childReader1, child1, childReader2, child2);

                    window.grdContainer.Children.Add(ucConfirm);

                    window.ShowDialog();

                    if (window.DialogResult == true)
                    {
                        Adult adult = _AdultVM.adultRepo.GetByIdReader(reader.Id);

                        if ((string)window.Tag == "Restore Adult")
                        {
                            this.RestoreAdult(reader, adult);

                            DatabaseFirst.Instance.SaveChanged();

                            MessageBox.Show("Restore successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);

                            return;
                        }

                        Child child = _ChildVM.GetByAdultID(reader.Id);

                        while (child != null)
                        {
                            Reader readerChild = _ReaderVM.readerRepo.GetById(child.IdReader);

                            this.RestoreChild(readerChild, child);

                            child = _ChildVM.GetByAdultID(reader.Id);
                        }

                        this.RestoreAdult(reader, adult);

                        DatabaseFirst.Instance.SaveChanged();

                        MessageBox.Show("Restore successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        public void TransitionChild(string childIdReader, string adultIdReader)
        {
            _ChildVM.childRepo.TransitionChild(childIdReader, adultIdReader);
            DatabaseFirst.Instance.SaveChanged();
        }
    }
}
