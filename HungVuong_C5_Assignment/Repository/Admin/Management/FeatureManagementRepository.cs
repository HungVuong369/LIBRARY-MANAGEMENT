using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HungVuong_C5_Assignment
{
    public class FeatureManagementRepository
    {
        private FunctionViewModel _FunctionVM = new FunctionViewModel();

        public bool Update(Function parentFunction, string functionID, string newName, string newDescription, string newUrlImage)
        {
            if(parentFunction != null)
            {
                if (_FunctionVM.IsExist(newName, parentFunction.Id) || newName.ToLower() == parentFunction.Name.ToLower())
                {
                    MessageBox.Show("Existed feature!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }

            string IdParent = null;
            string urlImage = "None";

            if (parentFunction != null)
            {
                IdParent = parentFunction.Id;
            }

            if (newUrlImage != "Click me!")
            {
                urlImage = newUrlImage;
            }

            _FunctionVM.functionRepo.UpdateByID(functionID, newName, newDescription, IdParent, urlImage);
            DatabaseFirst.Instance.SaveChanged();
            return true;
        }

        public void Delete(Function function)
        {
            this._FunctionVM.functionRepo.Remove(function);
            DatabaseFirst.Instance.SaveChanged();
        }

        public void Restore(Function function)
        {
            _FunctionVM.functionRepo.Restore(function);
            DatabaseFirst.Instance.SaveChanged();
        }
    }
}
