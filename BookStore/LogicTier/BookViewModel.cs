using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;

namespace LogicTier
{
    public class BookViewModel
    {
        public string Title => _book.Title;
        public string Genre => _book.Genre;
        public double Price => _book.Price;

        private readonly Book _book;
        public BookViewModel(Book book) => _book = book;
    }
}