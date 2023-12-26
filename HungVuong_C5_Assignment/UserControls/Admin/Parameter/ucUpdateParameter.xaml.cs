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
    /// Interaction logic for ucUpdateParameter.xaml
    /// </summary>
    public partial class ucUpdateParameter : UserControl
    {
        public ucUpdateParameter(WindowDefault window, Parameter parameter)
        {
            InitializeComponent();
            CRUDParameterViewModel crud = new CRUDParameterViewModel(window, txtName, txtDescription, txtValue);
            crud.Update(parameter, txtValue);
            DataContext = crud;
        }
    }
}
