using BookSystem_Delegate_.Interfaces;
using System.ComponentModel.DataAnnotations;
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

		public void DeleteBookById(int? id)
		{
			if (id == null)
				throw new NullReferenceException();
			foreach (var item in _books)
			{
				if (item.Id == id && item.IsDeleted == false)
				{
					item.IsDeleted = true;
					return;
				}
			}
			throw new NotFoundException("There is no book with the given index!");
		}
		
		public void EditBookName(int? id)
		{
			if (id == null)
				throw new NullReferenceException();
			foreach (var item in _books)
			{
				if (item.Id == id)
				{
					Console.WriteLine("Enter new book name: ");
					string newName = Console.ReadLine();
					item.Name = newName;
					return;
				}
			}
			throw new NotFoundException("There is no book with the given index!");
		}

		public List<Book> FilterByPageCount(int minPageCount, int maxPageCount)
		{
			List<Book> newBooks = new List<Book>();
			foreach (var item in _books)
			{
				if(item.PageCount >= minPageCount && item.PageCount <= maxPageCount && item.IsDeleted == false)
					newBooks.Add(item);
			}
			return newBooks;
		}

		public List<Book> GetAllBooks()
		{
			List<Book> newBooks = _books;
			return newBooks;
		}


	}
}
