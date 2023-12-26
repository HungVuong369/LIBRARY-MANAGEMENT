﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HungVuong_C5_Assignment
{
    public class PenaltyReasonViewModel
    {
        #region Pagination Code
        public string Search { get; set; } = string.Empty;

        private ObservableCollection<PenaltyReason> _StorageLstPenaltyReason;
        private ObservableCollection<PenaltyReason> _LstPenaltyReason;

        public ucPenaltyReasonDataGrid PenaltyReasonDataGrid { get; set; }

        public RelayCommand<object> SearchTextChangedCommand { get; private set; }
        #endregion

        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public PenaltyReasonRepository PenaltyReasonRepo;

        public PenaltyReason SelectedPenaltyReason { get; set; }

        public RelayCommand<object> AddCommand { get; private set; }
        public RelayCommand<object> DeleteCommand { get; private set; }
        public RelayCommand<object> UpdateCommand { get; private set; }

        public PenaltyReasonViewModel()
        {
            this.PenaltyReasonRepo = unitOfWork.PenaltyReasons;
        }

        public PenaltyReasonViewModel(ucPenaltyReasonDataGrid ucPenaltyReasonDataGrid)
        {
            this.PenaltyReasonDataGrid = ucPenaltyReasonDataGrid;

            PenaltyReasonRepo = unitOfWork.PenaltyReasons;

            ReloadStorage();
            PenaltyReasonDataGrid.pagination.LoadPage();

            PenaltyReasonDataGrid.pagination.ChangedPageEvent += Pagination_ChangedPageEvent;
            PenaltyReasonDataGrid.pagination.SelectionChangedComboBoxEvent += Pagination_SelectionChangedComboBoxEvent;
            PenaltyReasonDataGrid.pagination.cbPage.SelectedIndex = 1;
            PenaltyReasonDataGrid.dgPenaltyReasons.DataContext = this;

            SearchTextChangedCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    ReloadDataGridBySearch(Search);
                }
            );

            AddCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    WindowDefault window = new WindowDefault();
                    window.Content = new ucAddPenaltyReason(window);
                    window.ShowDialog();

                    if (window.DialogResult == true)
                    {
                        PenaltyReason newPenaltyReason = window.Tag as PenaltyReason;

                        PenaltyReasonRepo.Add(newPenaltyReason);

                        DatabaseFirst.Instance.SaveChanged();

                        ReloadStorage();

                        if (Search != string.Empty)
                            SearchByText(Search);

                        ReloadDataGrid();

                        PenaltyReasonDataGrid.pagination.LoadPage();

                        MessageBox.Show($"PenaltyReason '{newPenaltyReason.Name}' added successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            );

            DeleteCommand = new RelayCommand<object>(
               p => true,
               p =>
               {
                   if (MessageBox.Show($"Are you sure you want to delete PenaltyReason '{SelectedPenaltyReason.Name}'", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                   {
                       string name = SelectedPenaltyReason.Name;
                       PenaltyReasonRepo.Remove(SelectedPenaltyReason);
                       DatabaseFirst.Instance.SaveChanged();

                       ReloadStorage();

                       if (PenaltyReasonDataGrid.pagination.CurrentPage > PenaltyReasonDataGrid.pagination.MaxPage)
                       {
                           PenaltyReasonDataGrid.pagination.CurrentPage -= 1;
                           ReloadDataGrid();
                           PenaltyReasonDataGrid.pagination.LoadPage();
                       }
                       else
                       {
                           ReloadDataGrid();
                           PenaltyReasonDataGrid.pagination.LoadPage();
                       }

                       if (Search != string.Empty)
                           ReloadDataGridBySearch(Search);

                       MessageBox.Show($"PenaltyReason '{name}' successfully deleted!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                   }
               }
           );

            UpdateCommand = new RelayCommand<object>(
               p => true,
               p =>
               {
                   WindowDefault window = new WindowDefault();
                   ucUpdatePenaltyReason updatePenaltyReason = new ucUpdatePenaltyReason(window, SelectedPenaltyReason);
                   window.Content = updatePenaltyReason;
                   window.ShowDialog();

                   if (window.DialogResult == true)
                   {
                       PenaltyReason newPenaltyReason = window.Tag as PenaltyReason;

                       PenaltyReasonRepo.Update(SelectedPenaltyReason, newPenaltyReason);

                       DatabaseFirst.Instance.SaveChanged();

                       ReloadStorage();

                       if (Search != string.Empty)
                           SearchByText(Search);

                       ReloadDataGrid();

                       PenaltyReasonDataGrid.pagination.LoadPage();

                       MessageBox.Show($"PenaltyReason update successful!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                   }
               }
           );
        }

        private void ReloadDataGridBySearch(string search)
        {
            SearchByText(search);
            ReloadDataGrid();
        }

        private void Pagination_SelectionChangedComboBoxEvent(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            PenaltyReasonDataGrid.pagination.ItemPerPage = int.Parse((PenaltyReasonDataGrid.pagination.cbPage.SelectedItem as ComboBoxItem).Content.ToString());
            Reload();
        }

        private void Pagination_ChangedPageEvent(Pagination pagination)
        {
            ReloadDataGrid();
        }

        private void Reload()
        {
            ReloadStorage();
            Search = string.Empty;

            PenaltyReasonDataGrid.pagination.CurrentPage = 1;
            PenaltyReasonDataGrid.pagination.LoadPage();

            ReloadDataGrid();
        }

        private void ReloadDataGrid()
        {
            PenaltyReasonDataGrid.dgPenaltyReasons.ItemsSource = null;
            PenaltyReasonDataGrid.dgPenaltyReasons.ItemsSource = _LstPenaltyReason.Skip((PenaltyReasonDataGrid.pagination.CurrentPage - 1) * PenaltyReasonDataGrid.pagination.ItemPerPage).Take(PenaltyReasonDataGrid.pagination.ItemPerPage);
            PenaltyReasonDataGrid.pagination.ReloadShowing<PenaltyReason>(_LstPenaltyReason.ToList());
        }

        private void ReloadStorage()
        {
            this._StorageLstPenaltyReason = new ObservableCollection<PenaltyReason>(DatabaseFirst.Instance.db.PenaltyReasons);

            this._LstPenaltyReason = new ObservableCollection<PenaltyReason>(this._StorageLstPenaltyReason);

            PenaltyReasonDataGrid.pagination.SetMaxPage<PenaltyReason>(_LstPenaltyReason.ToList());

            PenaltyReasonDataGrid.dgPenaltyReasons.ItemsSource = _LstPenaltyReason.Skip((PenaltyReasonDataGrid.pagination.CurrentPage - 1) * PenaltyReasonDataGrid.pagination.ItemPerPage).Take(PenaltyReasonDataGrid.pagination.ItemPerPage);
        }

        private void SearchByText(string search)
        {
            this._LstPenaltyReason.Clear();

            foreach (var item in this._StorageLstPenaltyReason)
            {
                if (item.Id.ToLower().Contains(search.ToLower()))
                {
                    this._LstPenaltyReason.Add(item);
                }
                else if (item.Name.ToLower().Contains(search.ToLower()))
                {
                    this._LstPenaltyReason.Add(item);
                }
                else if(item.Price.ToString().Contains(search))
                {
                    this._LstPenaltyReason.Add(item);
                }
                else if(item.CreatedAt.ToString().Contains(search))
                {
                    this._LstPenaltyReason.Add(item);
                }
                else if (item.ModifiedAt.ToString().Contains(search))
                {
                    this._LstPenaltyReason.Add(item);
                }
            }

            PenaltyReasonDataGrid.pagination.SetMaxPage<PenaltyReason>(_LstPenaltyReason.ToList());
            PenaltyReasonDataGrid.pagination.CurrentPage = 1;
            PenaltyReasonDataGrid.pagination.LoadPage();
        }
    }
}