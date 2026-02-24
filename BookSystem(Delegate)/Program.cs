using BookSystem_Delegate_.Models;
using Utils.Enums;

namespace BookSystem_Delegate_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library1 = new Library(5);

			Console.WriteLine("Enter Username: ");
            string username = Console.ReadLine();
			Console.WriteLine("Enter Email: ");
            string email = Console.ReadLine();
			Role role;

			while (true)
            {
                Console.WriteLine("Enter your role: (Admin, Member)");
                string givenRole = Console.ReadLine();
				if (Enum.TryParse(givenRole, out role))
                {
                    break;
                }
				Console.WriteLine("Please enter your role correctly.");
            }

            User user1 = new User(username,email,role);
            Book book1 = new Book("Dune","Frank Herbert",412);
			Book book2 = new Book("Dune Probhet", "Frank Herbert", 200);
			Book book3 = new Book("Wutherin Heights", "Someone famous", 70);
			Book book4 = new Book("Game of Thrones", "R.R. Martin", 619);
			//Book book5 = new Book("newbook", "someone unknown", 120);

			try
            {
                library1.AddBook(book1);
                library1.AddBook(book2);
                library1.AddBook(book3);
                library1.AddBook(book4);
                //library1.AddBook(book5);

				string? operation = string.Empty;
				while (operation != null)
				{
					Console.WriteLine("What do u wanna do?");
					operation = Console.ReadLine();
					switch (operation)
					{
						case "0":
							operation = null;
							break;
						case "1":
							if (user1.Role == Role.Admin)
							{
								Console.WriteLine("Add book method!\nEnter book name: ");
								string bookName = Console.ReadLine();
								Console.WriteLine("Enter book author: ");
								string author = Console.ReadLine();
								Console.WriteLine("Enter page count:");
								int pageCount = int.Parse(Console.ReadLine());
								Book newBook = new Book(bookName, author, pageCount);
								library1.AddBook(newBook);
								Console.WriteLine("Added succesfully!");
							}
							Console.WriteLine("Members can not use this operation!");
							break;
						case "2":
							Console.WriteLine("Enter the id u want to check: ");
							int searchId = int.Parse(Console.ReadLine());
							Book searchedBook = library1.GetBookById(searchId);
							searchedBook.ShowInfo();
							break;
						case "3":
							Console.WriteLine("All books: ");
							List<Book>bookList=library1.GetAllBooks();
							foreach (var item in bookList)
								item.ShowInfo();
							break;
						case "4":
							if (user1.Role == Role.Admin)
							{
								Console.WriteLine("Enter the id u want to delete: ");
								int deleteId = int.Parse(Console.ReadLine());
								library1.DeleteBookById(deleteId);
								Console.WriteLine($"Deleted the book with id - {deleteId}");
							}
							Console.WriteLine("Members are not allowed to use this operation!");
							break;
						case "5":
							if (user1.Role == Role.Admin)
							{
								Console.WriteLine("Enter book id that you want to edit: ");
								int editId = int.Parse(Console.ReadLine());
								library1.EditBookName(editId);
							}
							Console.WriteLine("Members are not allowed to use this operation!");
							break;
						case "6":
							Console.WriteLine("Enter minimum page count to filter: ");
							int minPage = int.Parse(Console.ReadLine());
							Console.WriteLine("Enter maximum page count to filter: ");
							int maxPage = int.Parse(Console.ReadLine());
							List<Book> newList = library1.FilterByPageCount(minPage, maxPage);
							foreach (var item in newList)
								item.ShowInfo();
							break;
						default:
							Console.WriteLine("Wrong operation!");
							break;
					}
				}
			}
			catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
