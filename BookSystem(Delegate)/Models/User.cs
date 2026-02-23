using BookSystem_Delegate_.Interfaces;
using Utils.Enums;

namespace BookSystem_Delegate_.Models
{
	internal class User : IEntity
	{
		public string Username { get; set; }
		public string Email { get; set; }
		public Role Role{ get; set; }

		private static int ID;
		public int Id { get; }

		public User(string username, string email, Role role)
		{
			Username = username;
			Email = email;
			Role = role;
			ID++;
			Id = ID;
		}

		public void ShowInfo()
		{
			Console.WriteLine($"Username - {Username}, Email - {Email}, Role - {this.Role}.");
		}
	}
}
