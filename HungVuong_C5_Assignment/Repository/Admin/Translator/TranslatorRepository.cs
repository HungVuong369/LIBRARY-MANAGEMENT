using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class TranslatorRepository : RepositoryBase<Translator>
    {
        public TranslatorRepository()
        {
            Items = new List<Translator>();
        }

        public List<Translator> Load()
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.Translators);

            return Items;
        }

        public static string GetNewID()
        {
            string id = "T";

            var number = DatabaseFirst.Instance.db.Translators.Select(i => i.Id.Substring(1)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public void Add(Translator newTranslator)
        {
            Items.Add(newTranslator);

            DatabaseFirst.Instance.db.Translators.Add(newTranslator);
        }

        public void Remove(Translator translator)
        {
            Items.Remove(translator);

            var item = DatabaseFirst.Instance.db.Translators.FirstOrDefault(i => i.Id == translator.Id);

            item.Status = false;
        }

        public void Restore(Translator translator)
        {
            Items.Remove(translator);

            var item = DatabaseFirst.Instance.db.Translators.FirstOrDefault(i => i.Id == translator.Id);

            item.Status = true;
        }

        public void Update(Translator translator, Translator newTranslator)
        {
            translator.ModifiedAt = newTranslator.ModifiedAt;
            translator.Name = newTranslator.Name;
            translator.Description = newTranslator.Description;
            translator.Summary = newTranslator.Summary;
            translator.boF = newTranslator.boF;

            var item = DatabaseFirst.Instance.db.Translators.FirstOrDefault(i => i.Id == translator.Id);

            item.ModifiedAt = newTranslator.ModifiedAt;
            item.Name = newTranslator.Name;
            item.Description = newTranslator.Description;
            item.Summary = newTranslator.Summary;
            item.boF = newTranslator.boF;
        }

        public Translator GetById(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);
    }
}
