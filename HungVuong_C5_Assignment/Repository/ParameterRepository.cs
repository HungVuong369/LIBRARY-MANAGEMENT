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

        public static string GetNewID()
        {
            string id = "QD";

            var number = DatabaseFirst.Instance.db.Parameters.Select(reader => reader.Id.Substring(2)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            id += number;

            return id;
        }

        public void Add(Parameter newParameter)
        {
            Items.Add(newParameter);

            DatabaseFirst.Instance.db.Parameters.Add(newParameter);
        }

        public void Lock(Parameter parameter)
        {
            Items.Remove(parameter);

            var item = DatabaseFirst.Instance.db.Parameters.FirstOrDefault(i => i.Id == parameter.Id);

            item.Status = false;
        }

        public void Delete(Parameter parameter)
        {
            Items.Remove(parameter);

            var item = DatabaseFirst.Instance.db.Parameters.FirstOrDefault(i => i.Id == parameter.Id);

            DatabaseFirst.Instance.db.Parameters.Remove(item);
        }

        public void Restore(Parameter parameter)
        {
            Items.Remove(parameter);

            var item = DatabaseFirst.Instance.db.Parameters.FirstOrDefault(i => i.Id == parameter.Id);

            item.Status = true;
        }

        public void Update(Parameter parameter, Parameter newParameter)
        {
            parameter.ModifiedAt = newParameter.ModifiedAt;
            parameter.Name = newParameter.Name;
            parameter.Description = newParameter.Description;
            parameter.Value = newParameter.Value;

            var item = DatabaseFirst.Instance.db.Parameters.FirstOrDefault(i => i.Id == parameter.Id);

            item.Name = newParameter.Name;
            item.ModifiedAt = newParameter.ModifiedAt;
            item.Description = newParameter.Description;
            item.Value = newParameter.Value;
        }

        public Parameter GetByID(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);
    }
}
