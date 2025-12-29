using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataTier
{
    public class BookRepository
    {
        public List<Book> LoadBooksFromFile(string filePath)
        {
            var books = new List<Book>();
            if (!File.Exists(filePath)) return books;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(',');
                if (parts.Length == 3)
                {
                    books.Add(new Book
                    {
                        Title = parts[0].Trim(),
                        Genre = parts[1].Trim(),
                        Price = double.TryParse(parts[2].Trim(), out var p) ? p : 0
                    });
                }
            }
            return books;
        }
    }
}