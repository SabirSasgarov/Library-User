using BookSystem_Delegate_.Interfaces;

namespace BookSystem_Delegate_.Models
{
	internal class Book : IEntity
	{
		private static int ID;
		public int Id { get; }
		public string Name { get; set; }
		public string Author { get; set; }
		public int PageCount {  get; set; }
		public bool IsDeleted { get; set; } = false;

		public void ShowInfo()
		{
			Console.WriteLine($"Name - {Name}, Author - {Author}, Page count - {PageCount}.");
		}

		public Book(string name, string author, int pageCount)
		{
			Name = name;
			Author = author;
			PageCount = pageCount;
			ID++;
			Id = ID;
		}

	}
}
