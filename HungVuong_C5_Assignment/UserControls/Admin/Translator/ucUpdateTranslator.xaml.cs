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
    /// Interaction logic for ucUpdateTranslator.xaml
    /// </summary>
    public partial class ucUpdateTranslator : UserControl
    {
        public ucUpdateTranslator(WindowDefault window, Translator translator)
        {
            InitializeComponent();
            CRUDTranslatorViewModel crud = new CRUDTranslatorViewModel(window, txtName, txtDescription, txtSummary);
            crud.Update(translator);
            DataContext = crud;
        }
    }
}
