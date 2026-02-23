using BookSystem_Delegate_.Models;
using Utils.Enums;

namespace BookSystem_Delegate_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library1 = new Library(2);
            User user1 = new User("sabirsas","sabirsas@code.edu.az",Role.Member);
            Book book1 = new Book("Dune","Frank Herbert",412);
			Book book2 = new Book("Dune Probhet", "Frank Herbert", 200);

            try
            {
                library1.AddBook(book1);
                library1.AddBook(book2);

                //List<Book> newb = library1.GetAllBooks();
                //foreach (var item in newb)
                //{
                //	item.ShowInfo();
                //}

                Book newBook = library1.GetBookById(2);
                newBook.ShowInfo();
			}
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //user1.ShowInfo();
            //book1.ShowInfo();
        }
    }
}
