﻿using System;
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
    /// Interaction logic for ucAddPenaltyReason.xaml
    /// </summary>
    public partial class ucAddPenaltyReason : UserControl
    {
        public ucAddPenaltyReason(WindowDefault window)
        {
            InitializeComponent();
            DataContext = new CRUDPenaltyReasonViewModel(window, txtName, txtDescription, txtPrice);
        }

        private void txtPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != string.Empty && !char.IsDigit(e.Text[0]))
                e.Handled = true;
        }
    }
}
