using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;

namespace LogicTier
{
    public class BookStoreViewModel
    {
        private readonly List<Book> _books;

        public string StoreName => "Книжный магазин";
        public List<BookViewModel> Books { get; private set; }

        public Dictionary<string, double> TotalByGenre =>
            _books.GroupBy(b => b.Genre)
                  .ToDictionary(g => g.Key, g => g.Sum(b => b.Price));

        public double AvgFantasyPrice
        {
            get
            {
                var fantasyBooks = _books.Where(b => b.Genre == "Фантастика").ToList();
                return fantasyBooks.Any() ? fantasyBooks.Average(b => b.Price) : 0;
            }
        }

        public BookStoreViewModel(string dataFilePath)
        {
            var repo = new BookRepository();
            _books = repo.LoadBooksFromFile(dataFilePath);
            Books = _books.Select(b => new BookViewModel(b)).ToList();
        }
    }
}