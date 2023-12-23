using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class SearchBookViewModel : BaseViewModel
    {
        public string BookName { get; set; } = "";

        public List<Category> LstCategory { get; private set; } = new List<Category>();
        public List<Author> LstAuthor { get; private set; } = new List<Author>();
        public Author SelectedAuthor { get; set; }
        public Category SelectedCategory { get; set; }

        public RelayCommand<object> BookNameTextChangedCommand { get; private set; }
        public RelayCommand<object> CategorySelectionChangedCommand { get; private set; }
        public RelayCommand<object> AuthorSelectionChangedCommand { get; private set; }

        public SearchBookViewModel()
        {
            LstCategory.Add(new Category() { Name="None", Id="None" });
            LstAuthor.Add(new Author() { Name="None", Id="None" });

            LstCategory.AddRange(DatabaseFirst.Instance.db.Categories.Where(i => i.Status == true));
            LstAuthor.AddRange(DatabaseFirst.Instance.db.Authors.Where(i => i.Status == true));
            SelectedCategory = LstCategory.FirstOrDefault();
            SelectedAuthor = LstAuthor.FirstOrDefault();

            BookNameTextChangedCommand = new RelayCommand<object>(
                p => true,
                p => {
                    ShowBooksViewModel.Instance.UpdateViewBooks(SelectedCategory.Id, SelectedAuthor.Id, BookName);
                }
            );

            CategorySelectionChangedCommand = new RelayCommand<object>(
                p => true,
                p => {
                    ShowBooksViewModel.Instance.UpdateViewBooks(SelectedCategory.Id, SelectedAuthor.Id, BookName);
                }
            );

            AuthorSelectionChangedCommand = new RelayCommand<object>(
                p => true,
                p => {
                    ShowBooksViewModel.Instance.UpdateViewBooks(SelectedCategory.Id, SelectedAuthor.Id, BookName);
                }
            );
        }
    }
}
