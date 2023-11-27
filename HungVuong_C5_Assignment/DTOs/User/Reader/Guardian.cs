using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class Guardian : INotifyPropertyChanged
    {
        public string AdultID { get; set; }
        public string Identify { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

        private int _QuantityChild;
        public int QuantityChild
        {
            get
            {
                return this._QuantityChild;
            }
            set
            {
                this._QuantityChild = value;
                OnPropertyChanged();
            }
        }

        public DateTime BoF { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Guardian(string adultID, string identify, string fullName, string city, string phone, int quantityChild, DateTime boF)
        {
            this.AdultID = adultID;
            this.Identify = identify;
            this.FullName = fullName;
            this.City = city;
            this.Phone = phone;
            this.QuantityChild = quantityChild;
            this.BoF = boF;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
