using BookSystem_Delegate_.Interfaces;
using System.Data;
using Utils.Exceptions;

namespace BookSystem_Delegate_.Models
{
	internal class Library : IEntity
	{
		private static int ID;
		public int Id { get; }
		public int BookLimit { get; set; }
		public Library(int limit)
		{
			BookLimit = limit;
			ID++;
			Id = ID;
		}
		private List<Book> _books = new List<Book>();

		public void AddBook(Book book)
		{
			foreach (var item in _books)
			{
				if (item.IsDeleted == false)
				{
					if (item.Name == book.Name)
					{
						throw new AlreadyExistsException("Book already exists!");
					}
				}
			}
			if(_books.Count+1>BookLimit)
				throw new CapacityLimitException("Library is already full!");
			_books.Add(book);
		}

		public Book? GetBookById(int? id)
		{
			if(id == null)
				throw new NullReferenceException();
			foreach (var item in _books)
			{
				if(item.Id == id && item.IsDeleted == false)
				{
					return item;
				}
			}
			return null;
		}




		public List<Book> GetAllBooks()
		{
			List<Book> newBooks = _books;
			return newBooks;
		}


	}
}
