using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HungVuong_C5_Assignment
{
    public class ParameterRepository : RepositoryBase<Parameter>, IRepositoryBase<Parameter>
    {
        public ParameterRepository()
        {
            Items = new List<Parameter>();
        }

        public List<Parameter> Load()
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.Parameters.Where(i => i.Status));

            return Items;
        }

        public void UpdateValueByID(string id, string value)
        {
            int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, TSQL.UpdateParameterById(id, value));

            if (nRow != -1)
            {
                var item = Items.FirstOrDefault(i => i.Id == id);

                item.Value = value;
            }
            else
                MessageBox.Show("Records Inserted Failed!");
        }

        public Parameter GetByID(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);

        public void Delete(string id)
        {
            var entity = Items.Where(e => e.Id.CompareTo(id) == 0).FirstOrDefault();
            Items.Remove(entity);
        }
    }
}
