using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class ProvinceRepository : RepositoryBase<Province>
    {
        public ProvinceRepository()
        {
            Items = new List<Province>();
        }

        public List<Province> Load()
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.Provinces.Where(i => i.Status));

            return Items;
        }

        public static string GetNewID()
        {
            string id = "";

            var number = DatabaseFirst.Instance.db.Provinces.Select(i => i.Id.ToString().Substring(0)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            id += number;

            return id;
        }

        public void Add(Province newProvince)
        {
            Items.Add(newProvince);

            DatabaseFirst.Instance.db.Provinces.Add(newProvince);
        }

        public void Remove(Province newProvince)
        {
            Items.Remove(newProvince);

            var item = DatabaseFirst.Instance.db.Provinces.FirstOrDefault(i => i.Id == newProvince.Id);

            item.Status = false;
        }

        public void Restore(Province province)
        {
            Items.Remove(province);

            var item = DatabaseFirst.Instance.db.Provinces.FirstOrDefault(i => i.Id == province.Id);

            item.Status = true;
        }

        public void Update(Province province, Province newProvince)
        {
            province.Name = newProvince.Name;

            var item = DatabaseFirst.Instance.db.Provinces.FirstOrDefault(i => i.Id == province.Id);

            item.Name = newProvince.Name;
        }

        public Province GetById(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);
    }
}
